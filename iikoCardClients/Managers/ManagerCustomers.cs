using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Managers
{
    class ManagerCustomers
    {
        static int CountAll = 0;
        static int CountUpload = 0;
        static int CountFail = 0;
        static int CountBalance = 0;
        static int CountCategory = 0;
        static int CountCorporateNutritions = 0;
        static public int GetCountAll { get { return CountAll; } }
        static public int GetCountUpload { get { return CountUpload; } }
        static public int GetCountFail { get { return CountFail; } }
        static public int GetCountBalance { get { return CountBalance; } }
        static public int GetCountCategory { get { return CountCategory; } }
        static public int GetCountCorporateNutritions { get { return CountCorporateNutritions; } }

        

        Organization _organization;
        Category _categories;
        CorporateNutritions _corporateNutritions;
        ManagerAPI deliveryAPI;

        public ManagerCustomers(Organization organization, Category categories, CorporateNutritions corporateNutritions, ManagerAPI managerAPI)
        {
            _organization = organization;
            _categories = categories;
            _corporateNutritions = corporateNutritions;
            deliveryAPI = managerAPI;
            RefreshCounter();
        }

        public void RefreshCounter()
        {
            CountAll = 0;
            CountUpload = 0;
            CountFail = 0;
            CountBalance = 0;
            CountCategory = 0;
            CountCorporateNutritions = 0;
        }

        public void UploadCustomers(IEnumerable<ShortCustomerInfo> shortCustomers, string balance, object[] status, bool owerwriteName = false)
        {
            try
            {
                if (status != null)
                    ((System.Windows.Forms.Label)status?.Last()).Invoke(
                        new Action(() => ((System.Windows.Forms.Label)status?.Last()).Text = shortCustomers.Count().ToString()));
                ManagerSQL.GetInstance.Tables.RefrashData();
                foreach (var customer in shortCustomers)
                {
                    CountAll++;
                    UploadCustomer(customer, balance, owerwriteName);
                    if (status != null)
                        ((System.Windows.Forms.Label)status?.First()).Invoke(
                            new Action(() => ((System.Windows.Forms.Label)status?.First()).Text = CountAll.ToString()));
                }
            }
            catch (Exception)
            {
                CountFail++;
                if (CountAll != shortCustomers.Count())
                    UploadCustomers(shortCustomers.Skip(CountAll), balance, status, owerwriteName);
            }
        }

        void UploadCustomer(ShortCustomerInfo _customer, string Balance, bool owerwriteName = false)
        {
            decimal balance = 0;
            bool guest = false;
            var customer = new Data.Biz.Customer();
            
            try
            {
                //проверяем гостя в бд по таб номеру 
                if (_customer.TabNumber != null && _customer.TabNumber != "")
                {
                    var customerSQL = ManagerSQL.GetTables.Customer.Customers
                        .FirstOrDefault(data => data.TabNumber == _customer.TabNumber);
                    var cardSQL = ManagerSQL.GetTables.Card.Cards
                        .FirstOrDefault(data => data.Track == _customer.Card);

                    //Проверяем карту которую получили на существование
                    //если она существует ничего не далаем
                    //если она новая, добавляем к гостю новую карту
                    //если такого гостя нет, то упадем в ошибку при попытке достучаться в Xml
                    if (cardSQL == null || !customerSQL.Xml.Card.Contains(cardSQL.Id))
                    {
                        var b = Task.Run(() => deliveryAPI.CreateNewCardCustomer(_customer.Card, customerSQL.Id, customerSQL.IdOrganization)).Result;
                    }
                    

                }
                else
                {
                    //если у гостя нет таб номера в базе ищем по фио
                    var customerSQL = ManagerSQL.GetTables.Customer.Customers
                        .FirstOrDefault(data => data.Name == _customer.Name);
                    var cardSQL = ManagerSQL.GetTables.Card.Cards
                        .FirstOrDefault(data => data.Track == _customer.Card);
                    if (cardSQL == null || !customerSQL.Xml.Card.Contains(cardSQL.Id))
                    {
                        var b = Task.Run(() => deliveryAPI.CreateNewCardCustomer(_customer.Card, customerSQL.Id, customerSQL.IdOrganization)).Result;
                    }
                }
                //если гость существует, то получаем его баланс по его карте
                //если же гостя нет, мы упадем в обработчик ошибки, где создаем правильную карточку гостя
                customer = Task.Run(() => deliveryAPI.GetCustomerBizByCard(_customer.Card, _organization.Id)).Result;
               
                
                balance = customer.walletBalances.Where(data => data.wallet.id == _corporateNutritions.IdWallet)
                    .FirstOrDefault()
                    .balance;
                guest = true;
                //если баланс отработал, тоесть гость есть в системе
                //получаем его id, путем попытки создания гостя с существующей картой
                //если нужно меняем его имя, меняем
                if (owerwriteName)
                {
                    customer = new Data.Biz.Customer()
                    {
                        id = Task.Run(() => deliveryAPI.CreateCustomer(
                            _customer.Name,
                            _customer.Card,
                            _organization.Id)).Result
                    };
                    ManagerSQL.GetTables.Customer.UpdateName(customer.id, _customer.Name);
                }
                
                //падаем в ошибку для обработки категорий и корпоративного питания
                throw new Exception();
            }
            catch (Exception)
            {
                //баланс мы не получили, создаем гостя
                if (guest == false)
                {
                    customer = new Data.Biz.Customer()
                    {
                        id = Task.Run(() => deliveryAPI.CreateCustomer(_customer.Name, _customer.Card, _organization.Id)).Result
                    };
                    customer = Task.Run(() => deliveryAPI.GetCustomerBizByCard(_customer.Card, _organization.Id)).Result;
                }
                //присваиваем гостю категорию
                if (Task.Run(() => deliveryAPI.SetCategoryByCustomer(customer.id, _categories.Id, _organization.Id)).Result)
                    CountCategory++;
                //назначаем гостю кошелек в программе
                if (Task.Run(() => deliveryAPI.SetCorporateNutritionByCustomer(customer.id, _corporateNutritions.Id, _organization.Id)).Result)
                    CountCorporateNutritions++;
                CountUpload++;


                //заносим информацию в бд
                customer.userData = _customer.TabNumber;
                SaveCustomerDataBase(customer);
                
                //выходим если не нужно изменять баланс
                if (Balance is null || Balance == "") return;
                //выравниваем баланс в зависимости пополнить или списать нам нужно от текущего значения
                if (((int)balance).ToString() != Balance)
                {
                    var boolBalance = false;
                    if (balance == 0 || balance < Convert.ToDecimal(Balance))
                        boolBalance = Task.Run(() => deliveryAPI.AddBalanceByCustomer(
                            customer.id,
                            _corporateNutritions.IdWallet, 
                            (Convert.ToDecimal(Balance) - balance).ToString().Replace(',','.'), 
                            _organization.Id)).Result;
                    else
                        boolBalance = Task.Run(() => deliveryAPI.DelBalanceByCustomer(
                            customer.id, 
                            _corporateNutritions.IdWallet,
                            (balance - Convert.ToDecimal(Balance)).ToString().Replace(',', '.'),
                            _organization.Id)).Result;
                    if (boolBalance) CountBalance++;
                }

                
                
                
                
            }
        }

        private void SaveCustomerDataBase(Data.Biz.Customer customer)
        {
            try
            {
                //заносим гостя в бд
                ///используемые таблицы
                ///customer
                ///card
                ///Wallet
                ///1.пытаемся добавить гостя с данным id в базу
                var dateCreate = DateTime.Now;
                var insert = ManagerSQL.GetInstance.Tables.Customer.Insert(new Customer()
                {
                    Id = customer.id,
                    IdiikoBiz = customer.id,
                    IdOrganization = _organization.Id,
                    Name = customer.name,
                    TabNumber = customer.userData,
                    IsActive = !customer.isDeleted,
                    Phone = customer.phone,
                    Create = dateCreate,
                    Comment = customer.comment
                });
                ///2.берем xml схему и проверяем на актуальные данные, если инсерт отбил с ошибкой,
                ///значит гость есть и нам нужен xml пакет
                ///иначе создаем пакет и записываем его
                if (!insert)
                {
                    //получаем из базы уже существующего гостя
                    var customerData = (Customer)ManagerSQL.GetInstance.Tables.Customer
                        .Select($"Id = '{customer.id}'")
                        .First();
                    //перепрописываем табельный номер
                    ManagerSQL.GetInstance.Tables.Customer.UpdateTabNumber(new Customer()
                    {
                        Id = customer.id,
                        TabNumber = customer.userData
                    });
                   
                    //категории перетираем на новые
                    customerData.Xml.Category.Clear();
                    customerData.Xml.Category.AddRange(customer.categories.Select(data => data.id));
                    //карты, если есть новые, добавляем
                    foreach (var i_card in customer.cards)
                    {
                        if (!customerData.Xml.Card.Contains(i_card.Id))
                        {
                            if (ManagerSQL.GetInstance.Tables.Card.Insert(new Card()
                            {
                                Id = i_card.Id,
                                Track = i_card.Track,
                                IsActive = i_card.IsActivated,
                                Create = dateCreate
                            }))
                                customerData.Xml.Card.Add(i_card.Id);
                        }
                    }
                    //обрабатываем кошельки
                    var walletsData = ManagerSQL.GetTables.Wallet.Wallets
                        .Where(data => customerData.Xml.Wallet.Contains(data.Id))
                        .Select(data => data.Name)
                        .ToList();
                    foreach (var i_wallet in customer.walletBalances)
                    {
                        var strGuid = string.Empty;
                        
                        if (!walletsData.Contains(i_wallet.wallet.name))
                        {
                            if (ManagerSQL.GetInstance.Tables.Wallet.Insert(new Wallet()
                            {
                                IdName = i_wallet.wallet.id,
                                Id = strGuid = Guid.NewGuid().ToString(),
                                Balance = i_wallet.balance
                            }))
                                customerData.Xml.Wallet.Add(strGuid);
                        }
                    }
                    //обновление данных для данного гостя
                    ManagerSQL.GetInstance.Tables.Customer.UpdateXML(new Customer()
                    {
                        Id = customer.id,
                        Xml = customerData.Xml
                    });

                }
                else
                {
                    //создаем xml пакет
                    var xml = new CustomerXml();
                    var strGuid = string.Empty;
                    //обрабатываем массив карт
                    foreach (var i_card in customer.cards)
                    {
                        if (ManagerSQL.GetInstance.Tables.Card.Insert(new Card()
                        {
                            Id = i_card.Id,
                            Track = i_card.Track,
                            IsActive = i_card.IsActivated,
                            Create = dateCreate
                        }))
                            xml.Card.Add(i_card.Id);
                    }
                    //обрабатываем массив балансов
                    foreach (var i_wallet in customer.walletBalances)
                    {
                        if (ManagerSQL.GetInstance.Tables.Wallet.Insert(new Wallet()
                        {
                            IdName = i_wallet.wallet.id,
                            Id = strGuid = Guid.NewGuid().ToString(),
                            Balance = i_wallet.balance
                        }))
                            xml.Wallet.Add(strGuid);
                    }
                    //обрабатываем массив категорий
                    xml.Category.AddRange(customer.categories.Select(data => data.id));

                    //обновление данных для данного гостя
                    ManagerSQL.GetInstance.Tables.Customer.UpdateXML(new Customer()
                    {
                        Id = customer.id,
                        Xml = xml
                    });
                }
            }
            catch (Exception)
            { }
        }
    }
}
