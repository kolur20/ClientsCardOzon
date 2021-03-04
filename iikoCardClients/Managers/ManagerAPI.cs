using iikoCardClients.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace iikoCardClients.Managers
{
    class ManagerAPI
    {
        const string URL = @"https://iiko.biz:9900/api/0/";


        static string token = string.Empty;
        static HttpClientHandler httpClientHandler;
        static TimeSpan cancellationTime = new TimeSpan(0, 0, 20);
        static HttpClient client;

        readonly int TimeDelayThread = 600;
        readonly string MessageTimeCollapse = "Too many requests, wait";

        string API_Login { get; set; }
        string API_Password { get; set; }
        public string Token { get { return token; } }

        public static void Initialization()
        {
            httpClientHandler = new HttpClientHandler();
            httpClientHandler.MaxConnectionsPerServer = 3;
            client = new HttpClient(httpClientHandler);
            client.Timeout = cancellationTime;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("UTF-8"));
            client.BaseAddress = new Uri(URL);
        }

        public ManagerAPI(string login, string pass)
        {
            API_Login = login;
            API_Password = pass;


            token = Task.Run(() => GetToken()).Result;

        }
        private async Task<string> GetToken()
        {
            //if (token == string.Empty || !Task.Run(() => isValidToken()).Result)
            //{
            var uri = $"auth/access_token?user_id={API_Login}&user_secret={API_Password}";
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return (await response.Content.ReadAsStringAsync()).Trim('"');
            throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

            //}
            //return token;
        }


        private async Task<bool> isValidToken()
        {
            try
            {
                var uri = $"auth/echo?msg=successfully&access_token={token}";
                var response = await client.GetAsync(uri).ConfigureAwait(false);
                return (await response.Content.ReadAsStringAsync()).Contains("successfully") ? true : false;
            }
            catch (Exception) { return false; }
        }
        private string GetErrorMessage(string message)
        {
            return (string)JObject.Parse(message)["message"];
        }

        public async Task<IEnumerable<Organization>> GetOrganizations()
        {
            try
            {
                var response = await client.GetAsync($"organization/list?access_token={token}&request_timeout={new TimeSpan(0, 0, 3)}")
                    .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"organization/list?access_token={token}&request_timeout={new TimeSpan(0, 0, 3)}")
                    .ConfigureAwait(false);
                }

                return JArray.Parse(await response.Content.ReadAsStringAsync())
                    .SelectTokens(@"$.[?(@.isActive === true)]")
                    .Select(data => new Organization()
                    {
                        IsActive = (bool)data.SelectToken("isActive"),
                        Name = (string)data["fullName"],
                        Id = (string)data["id"]
                    })
                    .ToList();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetOrganizations()).Result;
                }
                return null;
            }

        }

        public async Task<bool> CreateNewCardCustomer(string card, string customerId, string organizationId = null)
        {
            try
            {

                var json = new JObject()
                {
                    { "cardTrack", card },
                    { "cardNumber", card }
                };
                var response = await client.PostAsync(
                    $"customers/{customerId}/add_card?access_token={token}&organization={ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.PostAsync(
                    $"customers/{customerId}/add_card?access_token={token}&organization={ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                }
                

                return response.StatusCode == HttpStatusCode.OK ?true : throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => CreateNewCardCustomer(card, customerId, organizationId)).Result;
                }
                return false;
            }
        }


        public async Task<Data.Biz.Customer> GetCustomerBizById(string idiikoBiz, string organizationId)
        {
            try
            {
                var response = await client.GetAsync($"customers/get_customer_by_id?access_token={token}&organization={organizationId}&id={idiikoBiz}")
                  .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"customers/get_customer_by_id?access_token={token}&organization={organizationId}&id={idiikoBiz}")
                   .ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

                return JsonConvert.DeserializeObject<Data.Biz.Customer>(await response.Content.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetCustomerBizById(idiikoBiz, organizationId)).Result;
                }
                throw new Exception(ex.Message);

            }
        }

        //получение полного объекта гостя с биза
        public async Task<Data.Biz.Customer> GetCustomerBizByCard(string card, string organizationId)
        {
            try
            {
                var response = await client.GetAsync($"customers/get_customer_by_card?access_token={token}&organization={organizationId}&card={card}")
                  .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"customers/get_customer_by_card?access_token={token}&organization={organizationId}&card={card}")
                   .ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

                return JsonConvert.DeserializeObject<Data.Biz.Customer>(await response.Content.ReadAsStringAsync());

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetCustomerBizByCard(card, organizationId)).Result;
                }
                throw new Exception(ex.Message);

            }
        }



        public async Task<ShortCustomerInfo> GetCustomerInfoByCard(string card, string organizationId, string walletId)
        {
            try
            {
                
                var response = await client.GetAsync($"customers/get_customer_by_card?access_token={token}&organization={organizationId}&card={card}")
                   .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"customers/get_customer_by_card?access_token={token}&organization={organizationId}&card={card}")
                   .ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));
               
                var jObj = JObject.Parse(await response.Content.ReadAsStringAsync());

                return new ShortCustomerInfo()
                {
                    Id = (string)jObj.SelectToken("id"),
                    Name = (string)jObj.SelectToken("name"),
                    Card = card,
                    Wallet = jObj["walletBalances"]
                        .Select(data => new Wallet()
                        {
                            Balance = (decimal)data.SelectToken("balance"),
                            IdName = (string)data["wallet"].SelectToken("id"),
                            Name = (string)data["wallet"].SelectToken("name")
                        })
                        .Where(data => data.IdName == walletId)
                        .FirstOrDefault(),
                    Category = jObj["categories"]
                        .Select(data => (string)data.SelectToken("name"))

                };

                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetCustomerInfoByCard(card, organizationId, walletId)).Result;
                }
                throw new Exception(ex.Message);

            }
        }

        public async Task<decimal> GetCastomerBalance(string card, string corporateNutritionsIdWallet, string organizationId = null)
        {
            try
            {
               
                organizationId = organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId;

                var response = await client.GetAsync($"customers/get_customer_by_card?access_token={token}&organization={organizationId}&card={card}")
                    .ConfigureAwait(false);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"customers/get_customer_by_card?access_token={token}&organization={organizationId}&card={card}")
                    .ConfigureAwait(false);
                }
                if (response.StatusCode == HttpStatusCode.BadRequest)
                    throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));
                
                
                return JObject.Parse(await response.Content.ReadAsStringAsync())["walletBalances"]
                    .Select(data => new
                    {
                        Balance = (decimal)data.SelectToken("balance"),
                        WalletId = (string)data["wallet"].SelectToken("id")
                    })
                    .Where(data => data.WalletId == corporateNutritionsIdWallet)
                    .FirstOrDefault()
                    .Balance;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetCastomerBalance(card, corporateNutritionsIdWallet, organizationId)).Result;
                }
                throw new Exception(ex.Message);
                
            }


        }

        public async Task<IEnumerable<ShortCustomerInfo>> GetShortGuestInfo(DateTime dateFrom, DateTime dateTo, string organizationId = null)
        {
            
            try
            {
                var response = await client.GetAsync(string.Format("customers/get_customers_by_organization_and_by_period?access_token={0}&organization={1}&dateFrom={2}&dateTo={3}",
                    token,
                    organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId,
                    dateFrom.ToString("yyyy-MM-dd"),
                    dateTo.ToString("yyyy-MM-dd")))
                    .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync(string.Format("customers/get_customers_by_organization_and_by_period?access_token={0}&organization={1}&dateFrom={2}&dateTo={3}",
                    token,
                    organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId,
                    dateFrom.ToString("yyyy-MM-dd"),
                    dateTo.ToString("yyyy-MM-dd")))
                    .ConfigureAwait(false);
                }

                return JArray.Parse(await response.Content.ReadAsStringAsync())
                    //.SelectTokens(@"$.[?(@.isActive === true)]")
                    .Select(data => new ShortCustomerInfo()
                    {
                        
                        Name = (string)data["name"],
                        Id = (string)data["id"]
                    })
                    .ToList();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetShortGuestInfo(dateFrom, dateTo, organizationId)).Result;
                }
                return null;
            }
        }
        /// <summary>
        /// получение отчета по корпиту
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="corpNutritionsId"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public async Task<List<Data.Biz.ReportBiz>> GetReportCorporateNutrition(string organizationId, string corpNutritionsId, string dateFrom, string dateTo)
        {
            try
            {
                var response = await client.GetAsync(string.Format("organization/{0}/corporate_nutrition_report?corporate_nutrition_id={1}&date_from={2}&date_to={3}&access_token={4}",
                    organizationId,
                    corpNutritionsId,
                    dateFrom,
                    dateTo,
                    token))
                    .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync(string.Format("organization/{0}/corporate_nutrition_report?corporate_nutrition_id={1}&date_from={2}&date_to={3}&access_token={4}",
                       organizationId,
                       corpNutritionsId,
                       dateFrom,
                       dateTo,
                       token))
                       .ConfigureAwait(false);
                }

                return JArray.Parse(await response.Content.ReadAsStringAsync())
                    .Select(data => new Data.Biz.ReportBiz()
                    {
                        balanceOnPeriodEnd = (decimal)data["balanceOnPeriodEnd"],
                        balanceOnPeriodStart = (decimal)data["balanceOnPeriodStart"],
                        balanceRefillSum = (decimal)data["balanceRefillSum"],
                        balanceResetSum = (decimal)data["balanceResetSum"],
                        payFromWalletSum = (decimal)data["payFromWalletSum"],

                        paidOrdersCount = (int)data["paidOrdersCount"],

                        employeeNumber = (string)data["employeeNumber"],
                        guestCardTrack = (string)data["guestCardTrack"],
                        guestCategoryNames = (string)data["guestCategoryNames"],
                        guestId = (string)data["guestId"],
                        guestName = (string)data["guestName"],
                        guestPhone = (string)data["guestPhone"]
                    })
                    .ToList();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetReportCorporateNutrition(organizationId, corpNutritionsId, dateFrom, dateTo)).Result;
                }
                return null;
            }
        }

        //public async Task<IEnumerable<ShortCustomerInfo>> SetCategoryGuest(IEnumerable<ShortCustomerInfo> guestInfos, Organization organization = null)
        //{
        //    if (guestInfos.Count() > 200)
        //        throw new Exception("Count guests exceeds the allowed value");
        //    try
        //    {
        //        token = Task.Run(() => GetToken()).Result;

        //        var json = new JObject()
        //        {
        //            {
        //                "guestIds", new JArray
        //                {
        //                    guestInfos.Select(guest => guest.Id)
        //                }
        //            }
        //        };


        //        var response = await client.PostAsync(
        //            $"customers/get_categories_by_guests?access_token={token}&organization={(organization is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organization.Id)}",
        //            new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
        //        if (response.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            token = Task.Run(() => GetToken()).Result;
        //            response = await client.PostAsync(
        //            $"customers/get_categories_by_guests?access_token={token}&organization={(organization is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organization.Id)}",
        //            new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
        //        }

        //        var guests = JArray.Parse(await response.Content.ReadAsStringAsync())
        //            .Select(data => new
        //            {
        //                id = (string)data["guestId"],
        //                Category = data["categories"].Select(categories => (string)categories["name"]).ToArray()
        //            })
        //            .ToArray();
        //        foreach (var guest in guestInfos)
        //        {
        //            guest.Category = guests.Where(data => data.id == guest.Id).FirstOrDefault().Category;
        //        }
        //        return guestInfos;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains(MessageTimeCollapse))
        //        {
        //            Thread.Sleep(TimeDelayThread);
        //            return Task.Run(() => SetCategoryGuest(guestInfos, organization)).Result;
        //        }
        //        return null;
        //    }
        //}


        public async Task<IEnumerable<Category>> GetCategories(string organizationId = null)
        {
            
            try
            {
                var response = await client.GetAsync($"organization/{ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}/guest_categories?access_token={token}")
                    .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"organization/{ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}/guest_categories?access_token={token}")
                    .ConfigureAwait(false);
                }

                return JArray.Parse(await response.Content.ReadAsStringAsync())
                    .SelectTokens(@"$.[?(@.isActive === true)]")
                    .Select(data => new Category()
                    {
                        Name = (string)data["name"],
                        Id = (string)data["id"],
                        IsActive = true
                    })
                    .ToList();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetCategories(organizationId)).Result;
                }
                return null;
            }
        }

        public async Task<IEnumerable<CorporateNutritions>> GetCorporateNutritions(string organizationId = null)
        {
            
            try
            {
                var response = await client.GetAsync($"organization/{ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}/corporate_nutritions?access_token={token}")
                    .ConfigureAwait(false);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.GetAsync($"organization/{ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}/corporate_nutritions?access_token={token}")
                    .ConfigureAwait(false);
                }

                return JArray.Parse(await response.Content.ReadAsStringAsync())
                    .Select(data => new CorporateNutritions()
                    {
                        Name = (string)data["name"],
                        Id = (string)data["id"],
                        IdWallet = data["wallets"].Select(wallet => (string)wallet["id"]).FirstOrDefault()
                        //data["categories"].Select(categories => (string)categories["name"]).ToArray()
                    })
                    .ToList();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => GetCorporateNutritions(organizationId)).Result;
                }
                return null;
            }
        }

        public async Task<bool> CreateCustomersCategory(string nameCategory, string organizationId = null)
        {
            try
            {
                

                var json = new JObject()
                {
                    { "isActive", "true" },
                    { "isDefaultForNewGuests", "false"},
                    { "name", nameCategory }
                    
                };
                

                var response = await client.PostAsync(
                    $"organization/{ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}/create_or_update_guest_category?access_token={token}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.PostAsync(
                    $"organization/{ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}/create_or_update_guest_category?access_token={token}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                }
                return response.StatusCode == HttpStatusCode.OK ? true : throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync())); 
               
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => CreateCustomersCategory(nameCategory, organizationId)).Result;
                }
                return false;
            }
        }

        public async Task<string> CreateCustomer(string name, string card, string organizationId = null)
        {
            try
            {
                
                var json = name != null ? new JObject()
                    {
                        { "name", name },
                        { "magnetCardTrack", card },
                        { "magnetCardNumber", card },
                    } :
                    new JObject()
                    {
                        { "magnetCardTrack", card },
                        { "magnetCardNumber", card },
                    };
                
                var response = await client.PostAsync(
                    $"customers/create_or_update?access_token={token}&organization={ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}",
                    new StringContent("{ \"customer\" : " + json.ToString() + "}", Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.PostAsync(
                    $"customers/create_or_update?access_token={token}&organization={ (organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId)}",
                    new StringContent("{ \"customer\" : " + json.ToString() + "}", Encoding.UTF8, "application/json"));
                }
                var answer = await response.Content.ReadAsStringAsync();
                
                return response.StatusCode == HttpStatusCode.OK ? answer.Trim('"') : throw new Exception(GetErrorMessage(answer));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => CreateCustomer(name, card, organizationId)).Result;
                }
                return null;
            }
        }

        public async Task<bool> SetCategoryByCustomer(string customerId, string categoriesId, string organizationId = null)
        {
            try
            {
                token = Task.Run(() => GetToken()).Result;

                var response = await client.PostAsync(
                    String.Format("customers/{0}/add_category?access_token={1}&organization={2}&categoryId={3}",
                        customerId,
                        token,
                        organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId,
                        categoriesId),
                    new StringContent(new JObject().ToString(), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;

                    response = await client.PostAsync(
                        String.Format("customers/{0}/add_category?access_token={1}&organization={2}&categoryId={3}",
                            customerId,
                            token,
                            organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId,
                            categoriesId),
                        new StringContent(new JObject().ToString(), Encoding.UTF8, "application/json"));
                }
                return response.StatusCode == HttpStatusCode.OK ? true : throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("already binded to customer"))
                {
                    return true;
                }
                
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => SetCategoryByCustomer(customerId, categoriesId, organizationId)).Result;
                }
                
                return false;
            }
        }

        public async Task<bool> SetCorporateNutritionByCustomer(string customerId, string corporateNutritionsId, string organizationId = null)
        {
            try
            {
                token = Task.Run(() => GetToken()).Result;

                var response = await client.PostAsync(
                    String.Format("customers/{0}/add_to_nutrition_organization?access_token={1}&organization={2}&corporate_nutrition_id={3}",
                        customerId,
                        token,
                        organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId,
                        corporateNutritionsId),
                    new StringContent(new JObject().ToString(), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;

                    response = await client.PostAsync(
                        String.Format("customers/{0}/add_to_nutrition_organization?access_token={1}&organization={2}&corporate_nutrition_id={3}",
                            customerId,
                            token,
                            organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId,
                            corporateNutritionsId),
                        new StringContent(new JObject().ToString(), Encoding.UTF8, "application/json"));
                }
                return response.StatusCode == HttpStatusCode.OK ? true : throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => SetCorporateNutritionByCustomer(customerId, corporateNutritionsId, organizationId)).Result;
                }
                return false;
            }
        }

        public async Task<bool> AddBalanceByCustomer(string customerId, string corporateNutritionsIdWallet, string Sum, string organizationId = null)
        {
            try
            {
                


                var json = new JObject()
                {
                    { "customerId", customerId},
                    { "organizationId", organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId },
                    { "walletId", corporateNutritionsIdWallet },
                    { "sum", Sum }
                };


                var response = await client.PostAsync(
                    $"customers/refill_balance?access_token={token}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.PostAsync(
                    $"customers/refill_balance?access_token={token}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                }
                return response.StatusCode == HttpStatusCode.OK ? true : throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => AddBalanceByCustomer(customerId, corporateNutritionsIdWallet, Sum, organizationId)).Result;
                }
                return false;
            }
        }
        public async Task<bool> DelBalanceByCustomer(string customerId, string corporateNutritionsIdWallet, string Sum, string organizationId = null)
        {
            try
            {
               var json = new JObject()
                {
                    { "customerId", customerId},
                    {"organizationId", organizationId is null ? Task.Run(() => GetOrganizations()).Result.First().Id : organizationId },
                    { "walletId", corporateNutritionsIdWallet },
                    { "sum", Sum }
                };


                var response = await client.PostAsync(
                    $"customers/withdraw_balance?access_token={token}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    token = Task.Run(() => GetToken()).Result;
                    response = await client.PostAsync(
                    $"customers/withdraw_balance?access_token={token}",
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));
                }
                return response.StatusCode == HttpStatusCode.OK ? true : throw new Exception(GetErrorMessage(await response.Content.ReadAsStringAsync()));

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(MessageTimeCollapse))
                {
                    Thread.Sleep(TimeDelayThread);
                    return Task.Run(() => DelBalanceByCustomer(customerId, corporateNutritionsIdWallet, Sum, organizationId)).Result;
                }
                return false;
            }
        }
    }
}
