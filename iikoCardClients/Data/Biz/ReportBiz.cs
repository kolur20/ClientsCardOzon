using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data.Biz
{
   
    public class ReportBiz
    {
        [Name("Идентификатор гостя")]
        public string guestId { get; set; }
        
        [Name("Имя гостя")]
        public string guestName { get; set; }
        
        [Name("Телефон гостя")]
        public string guestPhone { get; set; }
        
        [Name("Номер карты гостя")]
        public string guestCardTrack { get; set; }
        
        [Name("Список категорий гостя")]
        public string guestCategoryNames { get; set; }
        
        [Name("Табельный номер гостя")]
        public string employeeNumber { get; set; }
        
        [Name("Баланс на начало периода")]
        public decimal balanceOnPeriodStart { get; set; }

        [Name("Баланс на конец периода")]
        public decimal balanceOnPeriodEnd { get; set; }
        
        [Name("Сумма пополнений")]
        public decimal balanceRefillSum { get; set; }
        
        [Name("Сумма оплат с кошелька")]
        public decimal payFromWalletSum { get; set; }
        
        [Name("Сумма списаний с кошелька")]
        public decimal balanceResetSum { get; set; }
        
        [Name("Количество оплаченных пользователем заказов")]
        public decimal paidOrdersCount { get; set; }
       
    }

}
