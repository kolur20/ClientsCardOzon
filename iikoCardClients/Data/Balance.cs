using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    class Balance
    {
        public Balance() { }


        [Name("track")]
        public string Track { get; set; }

        [Name("balance")]
        public string Sum { get; set; }

    }
}
