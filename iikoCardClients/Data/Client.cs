using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace iikoCardClients.Data
{
    class Client
    {
        public Client(Client info)
        {

            Track = info.Track;
            Number = info.Number;
            Phone = info.Phone;
        }
        public Client()
        {
            
        }

        

        [Name("name")]
        public string Name { get; set; }



        [Name("track")]
        public string Track { get; set; }

        [Name("number")]
        public string Number { get; set; }

        [Name("deleted")]
        public string isDeleted { get; set; }

        [Name("phone")]
        public string Phone { get; set; }




        public void Save(string FilePath)
        {
            
                using (Stream stream = new FileStream(FilePath, FileMode.Create))
                    new XmlSerializer(typeof(Client)).Serialize(stream, this);
           
        }


        public static Client Load(string FilePath)
        {
            using (var stream = new FileStream(FilePath, FileMode.Open))
                using (var reader = new StreamReader(stream))
                    return (Client)new XmlSerializer(typeof(Client)).Deserialize(reader);
           
        }
    }
}
