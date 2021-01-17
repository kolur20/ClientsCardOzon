using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    [Serializable]
    public class CustomerXml
    {
        public List<string> Category { get; set; }
        public List<string> Card { get; set; }
        public List<string> Wallet { get; set; }

        public CustomerXml()
        {
            Category = new List<string>();
            Card = new List<string>();
            Wallet = new List<string>();
        }



        public override string ToString()
        {
            return this.Serialize();
        }


        public string Serialize()
        {
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(CustomerXml));

            using (var writer = new System.IO.StringWriter())
            {
                xml.Serialize(writer, this);
                return writer.ToString();
            }
        }

        public static CustomerXml Deserialize(string str_xml)
        {
            var xml = new System.Xml.Serialization.XmlSerializer(typeof(CustomerXml));

            using (var writer = new System.IO.StringReader(str_xml))
            {
                return (CustomerXml)xml.Deserialize(writer);
            }
        }
    }
}

