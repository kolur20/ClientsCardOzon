using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iikoCardClients.SQL
{
    public struct SqlTables
    {
        public TableWalletName WalletName;
        public TableWallet Wallet;
        public TableOrganization Organization;
        public TableCategory Category;
        public TableCard Card;
        public TableCustomer Customer;


        public SqlTables(SQLiteConnection connection)
        {
            try
            { 
                Wallet = new TableWallet(connection);
                WalletName = new TableWalletName(connection);
                Organization = new TableOrganization(connection);
                Category = new TableCategory(connection);
                Card = new TableCard(connection);
                Customer = new TableCustomer(connection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
