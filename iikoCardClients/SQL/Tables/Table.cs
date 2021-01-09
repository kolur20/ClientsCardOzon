using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public class Table
    {
        public SQLiteConnection connection;
        public void SetConnection(SQLiteConnection connection)
        {
            this.connection = connection;
        }
        public bool SqlRequest(string request)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                new SQLiteCommand(request, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }
        public bool Insert(IEnumerable<IDataSql> data)
        {
            try
            {
                foreach (var i in data)
                    Insert(i);

                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }
        virtual public bool Insert(IDataSql data)
        {
            throw new Exception("Не переопределен метод группового добавления");
        }
    }
}
