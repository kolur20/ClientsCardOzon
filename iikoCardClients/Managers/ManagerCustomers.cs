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
        }

        public void UploadCustomers(IEnumerable<ShortCustomerInfo> shortCustomers, string balance)
        {
            try
            {
                
                foreach (var customer in shortCustomers)
                {
                    CountAll++;
                    UploadCustomer(customer.Name, customer.Card, balance);
                }
            }
            catch (Exception)
            {
                CountFail++;
                if (CountAll != shortCustomers.Count())
                    UploadCustomers(shortCustomers.Skip(CountAll), balance);
            }
        }

        void UploadCustomer(string Name, string Card, string Balance)
        {
            decimal balance = 0;
            bool guest = false;
            var customer = new ShortCustomerInfo();
            
            try
            {
                balance = Task.Run(() => deliveryAPI.GetCastomerBalance(Card, _corporateNutritions, _organization)).Result;
                guest = true;
                customer = new ShortCustomerInfo()
                {
                    Id = Task.Run(() => deliveryAPI.CreateCustomer(null, Card, _organization)).Result
                };
                throw new Exception();
            }
            catch (Exception)
            {
                if (guest == false)
                    customer = new ShortCustomerInfo()
                    {
                        Id = Task.Run(() => deliveryAPI.CreateCustomer(Name, Card, _organization)).Result
                    };

                if (Task.Run(() => deliveryAPI.SetCategoryByCustomer(customer, _categories, _organization)).Result)
                    CountCategory++;
                
                if (Task.Run(() => deliveryAPI.SetCorporateNutritionByCustomer(customer, _corporateNutritions, _organization)).Result)
                    CountCorporateNutritions++;
                CountUpload++;
                
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
