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
        public ManagerExcel(string file)
        {
            originalFileName = file;
        }
        public IEnumerable<ShortCustomerInfo> GetClients()
        {
            var clientList = new List<ShortCustomerInfo>();

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
                if (dataSet.Columns.Count != 3)
                    return null;
                var count = dataSet.Rows.Count;
                foreach (DataRow row in dataSet.Rows)
                {
                    string card = string.Empty;
                    if (row[2].ToString().Contains("/"))
                    {
                        string[] num = row[2].ToString().Split(' ');
                        num[0] = "000".Remove(0, num[0].Count()) + num[0];
                        num[2] = "00000".Remove(0, num[2].Count()) + num[2];
                        card = num[0] + num[2];
                    }
                    else
                    {
                        try
                        {
                            if (row[2].ToString().Trim() == "")
                                throw new Exception();
                            card = "00000000".Remove(0, row[2].ToString().Count()) + row[2].ToString();
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
                    clientList.Add(new ShortCustomerInfo()
                    {
                        Name = row[0].ToString(),
                        Card = card
                    });
                }
                reader.Close();
                //clientList.RemoveAt(0);

            }

            return clientList.ToArray();
        }

        
    }
}
