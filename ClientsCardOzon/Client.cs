using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClientsCardOzon
{
    public class Client
    {
        public static string fileName = "config\\Client.xml";

        public Client(Client info)
        {
            AcessorGroupName = info.AcessorGroupName;
            LegalPosition = info.LegalPosition;
            OrganizationExternalCode = info.OrganizationExternalCode;
            ActivityStatus = info.ActivityStatus;
        }
        public Client() {

            AcessorGroupName = "Депозитные карты";
            LegalPosition = "0";
            OrganizationExternalCode = "1";
            ActivityStatus = "0";
        }


        [Name("AcessorGroupName")]
        [XmlElement]
        public string AcessorGroupName { get; set; }


        [Name("LegalPosition")]
        [XmlElement]
        public string LegalPosition { get; set; }


        [Name("OrganizationExternalCode")]
        [XmlElement]
        public string OrganizationExternalCode { get; set; }


        [Name("Name")]
        public string Name { get; set; }


        [Name("ClientName")]
        [XmlElement]
        public string ClientName { get; set; }


        [Name("ExternalId")]
        public string ExternalId { get; set; }


        [Name("Number")]
        public string Number { get; set; }


        [Name("ActivityStatus")]
        [XmlElement]
        public string ActivityStatus { get; set; }
        



        public void Save(string FilePath)
        {
            try
            {
                using (Stream stream = new FileStream(FilePath, FileMode.Create))
                    new XmlSerializer(typeof(Client)).Serialize(stream, this);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }


        public static Client Load(string FilePath)
        {
            try
            {
                using (var stream = new FileStream(FilePath, FileMode.Open))
                using (var reader = new StreamReader(stream))
                    return (Client)new XmlSerializer(typeof(Client)).Deserialize(reader);
            }
            catch (Exception ex)
            {
                new Client().Save(fileName);
                Log.Error(ex.Message);
            }
            return null;
        }
    }
}
