using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public class TableCard : Table, ITableSql
    {
        public List<Card> Cards;

        public TableCard(SQLiteConnection connection)
        {
            SetConnection(connection);
            try
            {
                Select();
            }
            catch (Exception) { }
        }

        public bool Create()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                string q = @"CREATE TABLE IF NOT EXISTS Card1 (	Id	TEXT NOT NULL UNIQUE,	Track	TEXT NOT NULL UNIQUE,	IsActive	INTEGER NOT NULL DEFAULT 1,	DateCreate	TEXT NOT NULL,	PRIMARY KEY(Id))";

                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }

        public bool Delete(string conditions = null)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                new SQLiteCommand(
                    string.Format("DELETE FROM Card {0}", conditions is null ? "" : "WHERE " + conditions),
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

                var request = string.Format("SELECT * FROM Card {0}",
                    conditions is null ? "" : "WHERE " + conditions);
                Cards = new List<Card>();
                var reader = new SQLiteCommand(request, connection).ExecuteReader();
                while (reader.Read())
                {
                    var data = new Card();
                    data.Id = reader.GetString(reader.GetOrdinal("Id"));
                    data.Track = reader.GetString(reader.GetOrdinal("Track"));
                    data.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                    data.Create = reader.GetDateTime(reader.GetOrdinal("DateCreate"));
                    Cards.Add(data);
                }
                return Cards.ToList();
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }

        public override bool Insert(IDataSql data)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                var q = string.Format("INSERT INTO Card ('Id','Track','Create') VALUES '{0}','{1}','{2}'",
                    data.Id,
                    ((Card)data).Id,
                    ((Card)data).Track,
                    ((Card)data).Create);
                new SQLiteCommand(q, connection).ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { connection.Close(); throw new Exception(ex.Message); }
        }
    }
}
