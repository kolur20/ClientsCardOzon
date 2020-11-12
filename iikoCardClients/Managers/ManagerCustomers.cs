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
        int CountAll = 0;
        int CountUpload = 0;
        int CountFail = 0;
        int CountBalance = 0;
        public int GetCountAll { get { return CountAll; } }
        public int GetCountUpload { get { return CountUpload; } }
        public int GetCountFail { get { return CountFail; } }
        public int GetCountBalance { get { return CountBalance; } }

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
            try
            {
                balance = Task.Run(() => deliveryAPI.GetCastomerBalance(Card, _corporateNutritions, _organization)).Result;
                throw new Exception();
            }
            catch (Exception)
            {
                var customer = new ShortCustomerInfo()
                {
                    Id = Task.Run(() => deliveryAPI.CreateCustomer(Name, Card, _organization)).Result
                };
                
                Task.Run(() => deliveryAPI.SetCategoryByCustomer(customer, _categories,_organization));
                Task.Run(() => deliveryAPI.SetCorporateNutritionByCustomer(customer, _corporateNutritions, _organization));
                CountUpload++;
                if (balance.ToString() != Balance)
                {
                    if (balance < Convert.ToDecimal(Balance))
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
