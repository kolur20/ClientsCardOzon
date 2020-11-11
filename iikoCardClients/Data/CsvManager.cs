using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Data
{
    class CsvManager
    {
        const string path = @"import\";
        string organization;
        string strFilePath;
        bool isDeleted;
        public CsvManager(string file, string name, bool deleted)
        {
            strFilePath = file;



            organization = deleted ? "К удалению " + name : name;
           
            isDeleted = deleted;
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
