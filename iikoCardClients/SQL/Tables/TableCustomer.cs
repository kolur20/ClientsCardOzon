using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public class TableCustomer : Table, ITableSql
    {
        public List<Customer> Customers;

        public TableCustomer(SQLiteConnection connection)
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
                string q = $@"CREATE TABLE {(IfNotExists ? "IF NOT EXISTS" : "")} Customer (	Id	TEXT NOT NULL,	IdBiz	TEXT,	IdOrganization	TEXT,	Name	TEXT,	TabNumber	TEXT,	IsActive	INTEGER NOT NULL DEFAULT 1,	Comment	TEXT,	Xml	TEXT,	Phone	TEXT,	DateCreate TEXT,	PRIMARY KEY(Id))";

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
                    string.Format("DELETE FROM Customer {0}", conditions is null ? "" : "WHERE " + conditions),
                    connection).ExecuteNonQuery();

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
                Customers = new List<Customer>();
                var reader = new SQLiteCommand(request, connection).ExecuteReader();
                while (reader.Read())
                {
                    var data = new Customer();
                    data.Id = reader.GetString(reader.GetOrdinal("Id"));
                    data.Name = reader.GetString(reader.GetOrdinal("Name"));
                    data.IdOrganization = reader.GetString(reader.GetOrdinal("Organization"));
                    data.TabNumber = reader.GetString(reader.GetOrdinal("TabNumber"));
                    data.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    data.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    data.Create = reader.GetDateTime(reader.GetOrdinal("DateCreate"));
                    data.IdiikoBiz = reader.GetString(reader.GetOrdinal("IdiikoBiz"));
                    data.Xml = CustomerXml.Deserialize(reader.GetString(reader.GetOrdinal("Xml")));

                    Customers.Add(data);
                }
                return Customers.ToList();
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }

        override public bool Insert(IDataSql data)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var q = string.Format("INSERT INTO Customer ('Id','IdOrganization','Name','TabNumber','DateCreate','Xml','Phone','Comment','IdiikoBiz')" +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    data.Id,
                    ((Customer)data).IdOrganization,
                    ((Customer)data).Name,
                    ((Customer)data).TabNumber,
                    ((Customer)data).Create,
                    ((Customer)data).Xml,
                    ((Customer)data).Phone,
                    ((Customer)data).Comment,
                    ((Customer)data).IdiikoBiz);
                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }
    }
}
