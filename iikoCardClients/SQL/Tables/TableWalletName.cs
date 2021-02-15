using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public class TableWalletName : Table, ITableSql
    {
        public List<CorporateNutritions> WalletsName;
       
        public TableWalletName(SQLiteConnection connection)
        {
            SetConnection(connection);
            try
            {
                Select();
            }
            catch (Exception) { }
        }

       
        public bool Create(bool IfNotExists = false)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                string q = $@"CREATE TABLE {(IfNotExists ? "IF NOT EXISTS" : "")} WalletName (Id TEXT NOT NULL UNIQUE, Name	TEXT NOT NULL, IdWallet	TEXT NOT NULL,	PRIMARY KEY(Id))";

                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception) { return false; }
        }

        override public bool Insert(IDataSql data)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var q = string.Format("INSERT INTO WalletName ('Id','Name','IdWallet') VALUES ('{0}','{1}','{2}')",
                    data.Id,
                    ((CorporateNutritions)data).Name,
                    ((CorporateNutritions)data).IdWallet);
                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception) { return false; }
        }


        public bool Delete(string conditions = null)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                new SQLiteCommand(
                    string.Format("DELETE FROM WalletName {0}", conditions is null ? "" : "WHERE " + conditions),
                    connection).ExecuteNonQuery();

                return true;
            }
            catch (Exception) { return false; }
        }

       

        public IEnumerable<IDataSql> Select(string conditions = null)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                var request = string.Format("SELECT * FROM WalletName {0}",
                    conditions is null ? "" : "WHERE " + conditions);
                WalletsName = new List<CorporateNutritions>();
                var reader = new SQLiteCommand(request, connection).ExecuteReader();
                while (reader.Read())
                {
                    var data = new CorporateNutritions();
                    data.Id = reader.GetString(reader.GetOrdinal("Id"));
                    data.Name = reader.GetString(reader.GetOrdinal("Name"));
                    data.IdWallet = reader.GetString(reader.GetOrdinal("IdWallet"));
                    WalletsName.Add(data);
                }
                return WalletsName.ToList();
            }
            catch (Exception) { return new List<CorporateNutritions>(); }
        }
    }
}
