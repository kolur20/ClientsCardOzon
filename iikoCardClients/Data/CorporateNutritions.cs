using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    public class CorporateNutritions : iikoCardClients.SQL.IDataSql
    {
        public string Name { get; set; }
        public string IdWallet { get; set; }
        public string Id { get; set; }
    }
}
