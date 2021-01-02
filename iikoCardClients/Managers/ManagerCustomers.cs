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
        Categories _categories;
        CorporateNutritions _corporateNutritions;
        ManagerAPI deliveryAPI;

        public ManagerCustomers(Organization organization, Categories categories, CorporateNutritions corporateNutritions, ManagerAPI managerAPI)
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
            var customer = new ShortCustomerInfo();
            
            try
            {
                //если гость существует, то получаем его баланс по его карте
                //если же гостя нет, мы упадем в обработчик ошибки, где создаем правильную карточку гостя
                balance = Task.Run(() => deliveryAPI.GetCastomerBalance(_customer.Card, _corporateNutritions, _organization)).Result;
                guest = true;
                //если баланс отработал, тоесть гость есть в системе
                //получаем его id, путем попытки создания гостя с существующей картой
                //даже если гость уже есть, если нужно меняем его имя
                customer = new ShortCustomerInfo()
                {
                    Id = Task.Run(() => deliveryAPI.CreateCustomer(
                        owerwriteName ? _customer.Name : null, 
                        _customer.Card, 
                        _organization)).Result
                };
                //падаем в ошибку для обработки категорий и корпоративного питания
                throw new Exception();
            }
            catch (Exception)
            {
                //баланс мы не получили, создаем гостя
                if (guest == false)
                    customer = new ShortCustomerInfo()
                    {
                        Id = Task.Run(() => deliveryAPI.CreateCustomer(_customer.Name, _customer.Card, _organization)).Result
                    };

                //присваиваем гостю категорию
                if (Task.Run(() => deliveryAPI.SetCategoryByCustomer(customer, _categories, _organization)).Result)
                    CountCategory++;
                //назначаем гостю кошелек в программе
                if (Task.Run(() => deliveryAPI.SetCorporateNutritionByCustomer(customer, _corporateNutritions, _organization)).Result)
                    CountCorporateNutritions++;
                CountUpload++;

                //выходим если не нужно изменять баланс
                if (Balance is null) return;
                //выравниваем баланс в зависимости пополнить или списать нам нужно от текущего значения
                if (balance.ToString() != Balance)
                {
                    if (balance == 0 || balance < Convert.ToDecimal(Balance))
                        Task.Run(() => deliveryAPI.AddBalanceByCustomer(
                            customer, 
                            _corporateNutritions, 
                            (Convert.ToDecimal(Balance) - balance).ToString(), 
                            _organization));
                    else
                        Task.Run(() => deliveryAPI.DelBalanceByCustomer(
                            customer, 
                            _corporateNutritions,
                            (balance - Convert.ToDecimal(Balance)).ToString(),
                            _organization));
                    CountBalance++;
                }
                

                
            }
        }
    }
}
