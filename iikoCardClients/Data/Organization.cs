using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    public class Organization : iikoCardClients.SQL.IDataSql
    {
        public string Name { get; set; }

        public string Id { get; set; }
        public bool IsActive { get; set; }
    }
}
