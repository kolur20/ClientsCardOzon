using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    public class Card : iikoCardClients.SQL.IDataSql
    {
        public string Id { get; set; }
        public string Track { get; set; }
        public bool IsActive { get; set; }
        public DateTime Create { get; set; }

    }
}
