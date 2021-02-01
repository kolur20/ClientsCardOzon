using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public class TableCategory : Table, ITableSql
    {
        public List<Category> Categories;

        public TableCategory(SQLiteConnection connection)
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
                string q = $@"CREATE TABLE {(IfNotExists ? "IF NOT EXISTS" : "")} Category (	Id	TEXT NOT NULL UNIQUE,	Name	TEXT NOT NULL,	IsActive	INTEGER NOT NULL DEFAULT 1,	PRIMARY KEY(Id))";

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
                    string.Format("DELETE FROM Category {0}", conditions is null ? "" : "WHERE " + conditions),
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
                var q = string.Format("INSERT INTO Category ('Id','Name','IsActive') VALUES ('{0}','{1}','{2}')",
                    data.Id,
                    ((Category)data).Name,
                    ((Category)data).IsActive ? "1" : "0");
                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool Deactivation(IEnumerable<IDataSql> data)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var content = "";
                foreach (var i in data)
                {
                    content += $"'{i.Id}',";
                }
                
                var q = string.Format("UPDATE Category SET IsActive = 0 WHERE Id NOT IN ({0})",
                    content.Remove(content.Length - 1));
                new SQLiteCommand(q, connection).ExecuteNonQuery();
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

                var request = string.Format("SELECT * FROM Category {0}",
                    conditions is null ? "" : "WHERE " + conditions);
                Categories = new List<Category>();
                var reader = new SQLiteCommand(request, connection).ExecuteReader();
                while (reader.Read())
                {
                    var data = new Category();
                    data.Id = reader.GetString(reader.GetOrdinal("Id"));
                    data.Name = reader.GetString(reader.GetOrdinal("Name"));
                    data.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    Categories.Add(data);
                }
                return Categories.ToList();
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }
    }
}
