using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iikoCardClients.SQL;

namespace iikoCardClients.Managers
{
    class ManagerSQL
    {

        static readonly ManagerSQL instance = new ManagerSQL();
        public static ManagerSQL GetInstance()
        {
            return instance;
        }


        public string FolderDB { get; private set; }
        public string NameDB { get; private set; }

        SQLiteConnection connection;
        //SQLiteCommand command;

        SqlTables Tables;

        static NLog.Logger logger;

        

        ManagerSQL()
        {
            FolderDB = Properties.Settings.Default.DataBase_Folder;
            NameDB = Properties.Settings.Default.DataBase_Name + ".db";

            

            logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Запуск приложения...");
            try
            {
                if (!Directory.Exists(FolderDB))
                {
                    logger.Info($"Создание директории {FolderDB} для базы данных");
                    Directory.CreateDirectory(FolderDB);

                }
                connection = new SQLiteConnection($@"Data Source={FolderDB}\{NameDB}; Version=3;");
                
                logger.Info($"Подключение к базе данный: {connection.ConnectionString}");

                if (!File.Exists(FolderDB + @"\" + NameDB))
                {
                    try
                    {

                        logger.Info($"Создание файла базы данных {NameDB}");
                        SQLiteConnection.CreateFile(FolderDB + @"\" + NameDB);
                        
                        //подключениt к базе данных для создания таблиц
                        if (connection.State != System.Data.ConnectionState.Open)
                            connection.Open();
                        Tables = new SqlTables(connection);
                        logger.Info($"Подключение к базе произведено, создание таблиц");

                        logger.Info(string.Format("Создание таблицы {0} - {1} создана",
                            Tables.Wallet.GetType(),
                            Tables.Wallet.Create() ? "" : "НЕ"));
                        logger.Info(string.Format("Создание таблицы {0} - {1} создана",
                            Tables.WalletName.GetType(),
                            Tables.WalletName.Create() ? "" : "НЕ"));
                        logger.Info(string.Format("Создание таблицы {0} - {1} создана",
                            Tables.Category.GetType(),
                            Tables.Category.Create() ? "" : "НЕ"));
                        logger.Info(string.Format("Создание таблицы {0} - {1} создана",
                            Tables.Card.GetType(),
                            Tables.Card.Create() ? "" : "НЕ"));
                        logger.Info(string.Format("Создание таблицы {0} - {1} создана",
                            Tables.Organization.GetType(),
                            Tables.Organization.Create() ? "" : "НЕ"));
                        logger.Info(string.Format("Создание таблицы {0} - {1} создана",
                            Tables.Customer.GetType(),
                            Tables.Customer.Create() ? "" : "НЕ"));

                        connection.Close();
                        logger.Info("Таблицы базы данных созданы");
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        logger.Error("Во время инициализации подключения к базе данных произошла необратимая ошибка");
                        logger.Fatal(ex.Message);
                        throw ex;
                    }

                }
                else
                {
                    //подключениt к базе данных для создания таблиц
                    if (connection.State != System.Data.ConnectionState.Open)
                        connection.Open();
                    Tables = new SqlTables(connection);
                    connection.Close();
                    logger.Info($"Проверка базы данных произведена");
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex.Message);
                throw new Exception(ex.Message);
            }

        }


    }
}
