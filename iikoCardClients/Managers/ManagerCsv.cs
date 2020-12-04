using CsvHelper;
using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Managers
{
    class ManagerCsv
    {
        const string path = @"import\";
        string organization;
        string strFilePath;
        bool isDeleted;
        public ManagerCsv(string file, string name, bool deleted)
        {
            strFilePath = file;



            organization = deleted ? "К удалению " + name : name;
           
            isDeleted = deleted;
        }
        
        public ManagerCsv(string file)
        {
            strFilePath = file;
        }
        public ManagerCsv() { }

        public IEnumerable<Client> GetClients()
        {
            var clientList = new List<Client>();
            Encoding encoding = Encoding.GetEncoding(866);
            if (!strFilePath.Contains(".csv"))
                return null;
            
            using (StreamReader sr = new StreamReader(strFilePath, encoding))
            {
                //пропускаем первую строку заголовков
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var client = new Client();
                    //client.isDeleted = isDeleted ? "1" : "0";

                    //делим строку
                    string[] rows = sr.ReadLine().Replace("  ", " ").Split(';');
                    client.Name = rows[0];


                    if (rows[2].Contains("/"))
                    {
                        string[] card = rows[2].Split(' ');
                        card[0] = "000".Remove(0, card[0].Count()) + card[0];
                        card[2] = "00000".Remove(0, card[2].Count()) + card[2];
                        client.Number = client.Track = card[0] + card[2];

                    }
                    else
                    {
                        client.Number = client.Track = "00000000".Remove(0,rows[2].Count()) + rows[2];
                    }


                    if (clientList
                        .Select(data => data.Number)
                        .Contains(client.Number))
                        continue;

                    clientList.Add(client);
                }
            }
            return clientList.ToArray();
        }

        

        public void CreateClients(string outname, IEnumerable<ShortCustomerInfo> shortCustomerInfos, bool deleted = false)
        {
            Directory.CreateDirectory(path);
            var csvClients = Path.Combine(path, "Guests " + outname + ".csv");
            using (StreamWriter streamReader = new StreamWriter(csvClients, false, Encoding.UTF8))
            {
                using (CsvWriter csvReader = new CsvWriter(streamReader, new System.Globalization.CultureInfo("en")))
                {
                    // указываем разделитель, который будет использоваться в файле
                    csvReader.Configuration.Delimiter = ";";
                    var clientList = new List<Client>();
                    clientList.AddRange(shortCustomerInfos.Select(
                        data => new Client() {
                            Name = data.Name,
                            Track = data.Card,
                            isDeleted = deleted ? "1" : "0",
                            Number = data.Card

                        })
                        .ToArray()
                        );
                    csvReader.WriteRecords(clientList);
                }
            }
        }



        public void CreateClients()
        {
            Directory.CreateDirectory(path);
            var csvClients = Path.Combine(path,"Guests " + organization + ".csv");

            var clientList = new List<Client>();

            using (StreamWriter streamReader = new StreamWriter(csvClients, false, Encoding.UTF8))
            {
                using (CsvWriter csvReader = new CsvWriter(streamReader, new System.Globalization.CultureInfo("en")))
                {
                    // указываем разделитель, который будет использоваться в файле
                    csvReader.Configuration.Delimiter = ";";

                    using (StreamReader sr = new StreamReader(strFilePath, Encoding.GetEncoding(866)))
                    {
                        //пропускаем первую строку заголовков
                        while (sr.ReadLine().Split(';').Count() != 3)
                        { }

                        while (!sr.EndOfStream)
                        {
                            var client = new Client();
                            client.isDeleted = isDeleted ? "1" : "0";

                            //делим строку
                            string[] rows = sr.ReadLine().Replace("  ", " ").Split(';');
                            client.Name = rows[0];


                            if (rows[2].Contains("/"))
                            {
                                string[] card = rows[2].Split(' ');
                                card[0] = "000".Remove(0, card[0].Count()) + card[0];
                                card[2] = "00000".Remove(0, card[2].Count()) + card[2];
                                client.Number = client.Track = card[0] + card[2];

                            }
                            else
                            {
                                client.Number = client.Track = rows[2];
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



        public void CreateBalanses(string outname, IEnumerable<ShortCustomerInfo> shortCustomerInfos, string balance)
        {
            Directory.CreateDirectory(path);
            var csvClients = Path.Combine(path, "Balance " + outname + ".csv");
            
            using (StreamWriter streamReader = new StreamWriter(csvClients, false, Encoding.UTF8))
            {
                using (CsvWriter csvReader = new CsvWriter(streamReader, new System.Globalization.CultureInfo("en")))
                {
                    csvReader.Configuration.Delimiter = ";";
                    var clientList = new List<Balance>();
                    clientList.AddRange(shortCustomerInfos.Select(
                        data => new Balance()
                        {
                            Track = data.Card,
                            Sum = balance

                        })
                        .ToArray()
                        );
                    csvReader.WriteRecords(clientList);
                }
            }
        }


        public void CreateBalanses(string balance)
        {
            Directory.CreateDirectory(path);
            var csvClients = Path.Combine(path, "Balance " + organization + ".csv");

            var clientList = new List<Balance>();

            using (StreamWriter streamReader = new StreamWriter(csvClients, false, Encoding.UTF8))
            {
                using (CsvWriter csvReader = new CsvWriter(streamReader, new System.Globalization.CultureInfo("en")))
                {
                    // указываем разделитель, который будет использоваться в файле
                    csvReader.Configuration.Delimiter = ";";

                    using (StreamReader sr = new StreamReader(strFilePath, Encoding.GetEncoding(866)))
                    {
                        //пропускаем первую строку заголовков
                        while (sr.ReadLine().Split(';').Count() != 3)
                        { }

                        while (!sr.EndOfStream)
                        {
                            var client = new Balance();
                            client.Sum = balance;
                            //делим строку
                            string[] rows = sr.ReadLine().Replace("  ", " ").Split(';');
                            
                            if (rows[2].Contains("/"))
                            {
                                string[] card = rows[2].Split(' ');
                                card[0] = "000".Remove(0, card[0].Count()) + card[0];
                                card[2] = "00000".Remove(0, card[2].Count()) + card[2];
                                client.Track = card[0] + card[2];

                            }
                            else
                            {
                                client.Track = rows[2];
                            }


                            if (clientList
                                .Select(data => data.Track)
                                .Contains(client.Track))
                                continue;

                            clientList.Add(client);
                        }

                    }





                    csvReader.WriteRecords(clientList);
                }
            }
        }
    }
}
