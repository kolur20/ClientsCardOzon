using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using System.IO;

namespace ClientsCardOzon
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var ClientInfo = Client.Load(Client.fileName);
            Console.WriteLine("Укажите имя файла в текущей папке");
            var strFilePath = Console.ReadLine();
            var csvClients = "Clients.csv";

            var clientList = new List<Client>();

            try
            {
                using (StreamWriter streamReader = new StreamWriter(csvClients, false, Encoding.UTF8))
                {
                    using (CsvWriter csvReader = new CsvWriter(streamReader, new System.Globalization.CultureInfo("en")))
                    {
                        // указываем разделитель, который будет использоваться в файле
                        csvReader.Configuration.Delimiter = ";";

                        using (StreamReader sr = new StreamReader(strFilePath, Encoding.GetEncoding(866)))
                        {
                            //пропускаем первую строку заголовков
                            while(sr.ReadLine().Split(';').Count() != 3)
                            { }

                            while (!sr.EndOfStream)
                            {
                                var client = new Client(ClientInfo);
                                //делим строку
                                string[] rows = sr.ReadLine().Replace("  ", " ").Split(';');
                                client.Name = client.ClientName = rows[0];
                                

                                if (rows[2].Contains("/"))
                                {
                                    string[] card = rows[2].Split(' ');
                                    card[0] = "000".Remove(0, card[0].Count()) + card[0];
                                    card[2] = "00000".Remove(0, card[2].Count()) + card[2];
                                    client.Number = client.ExternalId = card[0] + card[2];
                                    
                                }
                                else
                                {
                                    client.Number = client.ExternalId = rows[2];
                                }

                                
                                if (clientList
                                    .Select(data => data.Number)
                                    .Contains(client.Number))
                                    continue;

                                clientList.Add(client);
                            }

                        }





                        csvReader.WriteRecords(clientList);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();

            }
        }

      
    }
}
