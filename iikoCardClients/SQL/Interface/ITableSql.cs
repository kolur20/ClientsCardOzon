using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public interface ITableSql
    {
        void SetConnection(SQLiteConnection connection);
        bool Create();
        bool Insert(IDataSql data);

        bool Insert(IEnumerable<IDataSql> data);
        bool Delete(string conditions = null);
        bool SqlRequest(string request);
        /// <summary>
        /// SELECT <response> FROM ITableSql <WHERE conditions>
        /// </summary>
        /// <param name="response">перечень данных для запроса</param>
        /// <param name="conditions">параметры запроса</param>
        /// <returns></returns>
        IEnumerable<IDataSql> Select(string conditions = null);
    }
}
