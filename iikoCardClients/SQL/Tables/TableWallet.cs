using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public class TableWallet : Table, ITableSql
    {

        public List<Wallet> Wallets;


        

        public TableWallet(SQLiteConnection connection)
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
                string q = $@"CREATE TABLE {(IfNotExists ? "IF NOT EXISTS" : "")} Wallet (	Id	TEXT NOT NULL UNIQUE,	Balance	REAL NOT NULL,	IdName	TEXT NOT NULL,	PRIMARY KEY(Id))";

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
                    string.Format("DELETE FROM Wallet {0}", conditions is null ? "" : "WHERE "+ conditions),
                    connection).ExecuteNonQuery();

                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }

        override public bool Insert(IDataSql data)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var q = string.Format("INSERT INTO Wallet ('Id','Balance','IdName') VALUES '{0}','{1}','{2}'",
                    data.Id,
                    ((Wallet)data).Balance,
                    ((Wallet)data).IdName);
                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }

        

        public IEnumerable<IDataSql> Select(string conditions = null)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                var request = string.Format("SELECT * FROM Wallet {0}",
                    conditions is null ? "" : "WHERE " + conditions);
                Wallets = new List<Wallet>();
                var reader = new SQLiteCommand(request, connection).ExecuteReader();
                while (reader.Read())
                {
                    var data = new Wallet();
                    data.IdName = reader.GetString(reader.GetOrdinal("IdName"));
                    data.Balance = reader.GetDecimal(reader.GetOrdinal("Balance"));
                    data.Id = reader.GetString(reader.GetOrdinal("Id"));
                    Wallets.Add(data);
                }
                return Wallets.ToList();
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }
        
    }
}
