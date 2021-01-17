using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    public class Customer : SQL.IDataSql
    {
        public string Id { get; set; }
        public string IdOrganization { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string TabNumber { get; set; }
        public bool IsActive { get; set; }
        public string Comment { get; set; }
        public DateTime Create { get; set; }
        public string IdiikoBiz { get; set; }

        public CustomerXml Xml { get; set; }
    }
}
