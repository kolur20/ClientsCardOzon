using ExcelDataReader;
using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.Managers
{
    class ManagerExcel
    {
        string originalFileName = string.Empty;
        NLog.Logger logger = null;
        const int Columns = 3;
        int offset;
        public ManagerExcel(string file)
        {
            originalFileName = file;
            offset = 0;
            logger = NLog.LogManager.GetCurrentClassLogger();
        }
        public IEnumerable<ShortCustomerInfo> GetClients()
        {
            var clientList = new List<ShortCustomerInfo>();
            logger.Info($"Открытие файла {originalFileName} для получения гостей");
            using (var stream = File.Open(originalFileName, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                
                var conf = new ExcelDataSetConfiguration
                {
                    UseColumnDataType = false,
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = false
                        
                    }
                };
                
                var dataSet = reader.AsDataSet(conf).Tables[0];
                switch (dataSet.Columns.Count)
                {
                    case Columns:
                        break;
                    case Columns + 1:
                        offset = 1;
                        break;
                    default:
                        logger.Fatal($"Колличество столбцов ({dataSet.Columns.Count}) не соответствует заданному для парсинга количеству ({Columns})");
                        return null;

                }
                
                //var count = dataSet.Rows.Count;
                foreach (DataRow row in dataSet.Rows)
                {
                    string card = string.Empty;
                    if (row[offset + 2].ToString().Contains("/"))
                    {
                        string[] num = row[offset + 2].ToString().Replace(" ","").Split('/');
                        num[0] = "000".Remove(0, num[0].Count()) + num[0];
                        num[1] = "00000".Remove(0, num[1].Count()) + num[1];
                        card = num[0] + num[1];
                    }
                    else
                    {
                        try
                        {
                            if (row[offset + 2].ToString().Trim() == "")
                                throw new Exception();
                            card = "00000000".Remove(0, row[offset + 2].ToString().Count()) + row[offset + 2].ToString();
                        }
                        catch (Exception)
                        {
                            card = "";
                        }
                        
                    }
                    if (card == "" || clientList
                        .Select(data => data.Card)
                        .Contains(card))
                        continue;
                    if (offset == 1)
                        clientList.Add(new ShortCustomerInfo()
                        {
                            Name = row[offset].ToString().Replace("  "," "),
                            Card = card,
                            TabNumber = row[0].ToString()
                        });
                    else
                        clientList.Add(new ShortCustomerInfo()
                        {
                            Name = row[0].ToString(),
                            Card = card
                        });
                }
                
                logger.Info($"Обработка завершена, строк в документе обработано: {dataSet.Rows.Count}");
                reader.Close();
                //clientList.RemoveAt(0);

            }
            
            logger.Info($"Загрузка гостей завершена, гостей для дальнейшей обработки: {clientList.Count}");
            return clientList.ToArray();
        }

        public void CreateReportWithTabNumber(IEnumerable<ShortCustomerInfo> Customers)
        {
            logger.Info($"Открытие файла {originalFileName} для получения отчета");
            using (var stream = File.Open(originalFileName, FileMode.Open, FileAccess.ReadWrite))
            {
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

                var conf = new ExcelDataSetConfiguration
                {
                    UseColumnDataType = true,
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true

                    }
                };
                
                var dataSet = reader.AsDataSet(conf).Tables[0];
                foreach (DataRow row in dataSet.Rows)
                {
                    var name = row[0].ToString().Replace("  "," ").Split(' ');
                    var sname = "";
                    switch (name.Count())
                    {
                        case 1:
                            sname = "";
                            break;
                        case 2:
                            sname = " " + name[1];
                            break;
                        case 3:
                            sname = " " + name[1].First() + "." + name[2].First() + ".";
                            break;
                        default:
                            break;
                    }
                    
                    try
                    {
                        var s = Customers.Where(
                            data => data.Name.Contains(name[0] + sname)).ToArray();
                        var r = s.Select(data => data.TabNumber).First();
                        row[8] = r;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                logger.Info($"Обработка завершена");
                
                reader.Close();

            }

        }
    }
}
