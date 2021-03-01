using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data.Biz
{
   
    public class ReportBiz
    {
        public decimal balanceOnPeriodEnd { get; set; }
        public decimal balanceOnPeriodStart { get; set; }
        public decimal balanceRefillSum { get; set; }
        public decimal balanceResetSum { get; set; }
        public string employeeNumber { get; set; }
        public string guestCardTrack { get; set; }
        public string guestCategoryNames { get; set; }
        public string guestId { get; set; }
        public string guestName { get; set; }
        public string guestPhone { get; set; }
        public int paidOrdersCount { get; set; }
        public decimal payFromWalletSum { get; set; }

        public string TabNumber { get; set; }
    }

}
