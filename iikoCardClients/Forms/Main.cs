using iikoCardClients.Data;
using iikoCardClients.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iikoCardClients
{
    public partial class FormMain : Form
    {
        static NLog.Logger logger = null;
        static Stopwatch stopWatch = new Stopwatch();
        

        public FormMain()
        {
            InitializeComponent();
            logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Запуск приложения...");

            Managers.ManagerAPI.Initialization();
            tb_LoginAPI.Text = Properties.Settings.Default.LoginAPI;
            tb_PasswordAPI.Text = Properties.Settings.Default.PasswordAPI;
            cb_ManagerCard.Checked = Properties.Settings.Default.ManagerCard;
            

            tb_Organization_Name.Text = Properties.Settings.Default.Organization;
            tb_CorporateNutritions_Name.Text = Properties.Settings.Default.CorporateNutritions;

            tb_DataBase_Folder.Text = Properties.Settings.Default.DataBase_Folder;
            tb_DataBase_Name.Text = Properties.Settings.Default.DataBase_Name;

            //проверка бд
            var managerSql = ManagerSQL.GetInstance;
            //получение данных из бд и заполнение полей
            if (managerSql.Tables.Organization.Organizations != null && managerSql.Tables.Organization.Organizations.Count > 0)
            {
                cb_organizations.Items.Clear();
                cb_organizations.Items.AddRange(managerSql.Tables.Organization.Organizations.Select(data => data.Name).ToArray());
                cb_organizations.SelectedIndex = 0;

                cb_Report_Organization.Items.Clear();
                cb_Report_Organization.Items.AddRange(managerSql.Tables.Organization.Organizations.Select(data => data.Name).ToArray());
                cb_Report_Organization.SelectedIndex = 0;
                
            }
            if (managerSql.Tables.Category.Categories != null && managerSql.Tables.Category.Categories.Count > 0)
            {
                cb_Categories.Items.Clear();
                cb_Categories.Items.AddRange(managerSql.Tables.Category.Categories.Select(data => data.Name).ToArray());
                //необходимо принудительно выбирать вручную
                //cb_Categories.SelectedIndex = 0;
            }
            if (managerSql.Tables.WalletName.WalletsName != null && managerSql.Tables.WalletName.WalletsName.Count > 0)
            {
                cb_CorporateNutritions.Items.Clear();
                cb_CorporateNutritions.Items.AddRange(managerSql.Tables.WalletName.WalletsName.Select(data => data.Name).ToArray());
                cb_CorporateNutritions.SelectedIndex = 0;

                cb_Report_CorpNutritions.Items.Clear();
                cb_Report_CorpNutritions.Items.AddRange(managerSql.Tables.WalletName.WalletsName.Select(data => data.Name).ToArray());
                cb_Report_CorpNutritions.SelectedIndex = 0;
                
            }

            //выставление периода отчета
            var dateTime = DateTime.Now;
            dtp_Report_From.Value = new DateTime(dateTime.Year, dateTime.Month, 1);
            dtp_Report_To.Value = new DateTime(dateTime.Year, dateTime.Month + 1, 1).AddDays(-1);





            logger.Info("Приложение запущено");
        }
        string strFilePath = "";
        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                      ДЕЛЕГАТЫ ДЛЯ ОТОБРАЖЕНИЯ ПРОЦЕССА РАБОТЫ ОПЕРАЦИЙ
        ------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region Делегаты - процессы отображения работы
        //массовая выгрузка в биз
        delegate void DelegateCustomers(string org, string cat, string cor, string api, string login, string file, string balance, object[] StatusCustomers, bool owerwriteName = false);
        DelegateCustomers del_Customers = new DelegateCustomers(UpdateCustomers);
        void CallBackUpdateCustomers(IAsyncResult aRes)
        {
            del_Customers.EndInvoke(aRes);
            CallBackFunc();
        }


        //одиночная выгрузка в биз
        delegate void DelegateCustomer(string org, string cat, string cor, string api, string login, string name, string card, string balance, bool owerwriteName = false);
        DelegateCustomer del_Customer = new DelegateCustomer(UpdateCustomer);
        void CallBackUpdateCustomer(IAsyncResult aRes)
        {
            del_Customer.EndInvoke(aRes);
            CallBackFunc();
        }

        //формирование отчета биза с табельными
        delegate void DelegateReport(string tabNumberReport, string iikoBizReport, string currentReport);
        DelegateReport del_Report = new DelegateReport(CreateTabNumberReport);
        void CallBackCreateReport(IAsyncResult aRes)
        {
            del_Report.EndInvoke(aRes);
            CallBackFucnReport();
        }


        void CallBackFunc(bool cancelFlag = false)
        {
            pb_load.Invoke(new Action(() => pb_load.Enabled = pb_load.Visible = false));
            l_UploadCustomers.Invoke(new Action(() => l_UploadCustomers.Visible = false));
            l_AllCustomers.Invoke(new Action(() => l_AllCustomers.Visible = false));

            stopWatch.Stop();

            if (cancelFlag) return;

            var info = $"Гостей обработано {ManagerCustomers.GetCountAll} \r\n" +
                $"Гостей выгружено {ManagerCustomers.GetCountUpload} \r\n" +
                $"Гостям присвоена категория {ManagerCustomers.GetCountCategory} \r\n" +
                $"Гостей включено в программу питания {ManagerCustomers.GetCountCorporateNutritions} \r\n" +
                $"У гостей обработан баланс {ManagerCustomers.GetCountBalance} \r\n" +
                $"Гостей не обработано {ManagerCustomers.GetCountFail} \r\n" +
                $"Затраченное время {stopWatch.ElapsedMilliseconds / 1000.0f} сек.";
            MessageBox.Show(info, "Выгружено");
            logger.Info(info);
        }

        void CallBackFucnReport(bool cancelFlag = false)
        {
            pb_load.Invoke(new Action(() => pb_load.Enabled = pb_load.Visible = false));
            stopWatch.Stop();

            if (cancelFlag) return;

            var info = $"Файл успешно создан, затрачено {stopWatch.ElapsedMilliseconds / 1000.0f} сек.";
            MessageBox.Show(info, "Успешно");
            logger.Info(info);
        }

        #endregion
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------




        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                     ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ДЛЯ РАБОТЫ ДЕЛЕГАТОВ
       ------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region Вспомогательные методы для делегатов
        static void UpdateCustomer(string org, string cat, string cor, string api, string login, string name, string card, string balance, bool owerwriteName = false)
        {
            try
            {
                if (api == "" || login == "")
                    throw new NullReferenceException(message: "Не заполнены данные пользователя API");
                if (org == "" || cat == "" || cor == "")
                    throw new NullReferenceException(message: "Не заполнены данные для добавления гостей");
                stopWatch.Restart();
               

               var managerCustomers = new ManagerCustomers(
                    ManagerSQL.GetInstance.Tables.Organization.Organizations.Where(data => data.IsActive && data.Name == org).FirstOrDefault(),
                    ManagerSQL.GetInstance.Tables.Category.Categories.Where(data => data.IsActive && data.Name == cat).FirstOrDefault(),
                    ManagerSQL.GetInstance.Tables.WalletName.WalletsName.Where(data => data.Name == cor).FirstOrDefault(),
                    new ManagerAPI(api, login));

                var customer = new ShortCustomerInfo()
                {
                    Name = name.Replace("  "," "),
                    Card = card
                };
                var customers = new List<ShortCustomerInfo>();
                customers.Add(customer);
                logger.Info($"Начата робота с категорией {cat} и программой {cor}");
                logger.Info(balance is null ?
                    $"Добавление одного гостя: {customer.Name} с картой {customer.Card}" :
                    $"Добавление одного гостя: {customer.Name} с картой {customer.Card} и балансом {balance}");
                managerCustomers.UploadCustomers(customers, balance, null, owerwriteName);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                logger.Warn(ex.Message);
            }
        }

        /// <summary>
        /// считывание гостей из файла и загрузка их в биз
        /// </summary>
        /// <param name="org">Текущая организация</param>
        /// <param name="cat">Категория для пользователей</param>
        /// <param name="cor">Программа корпоративного питания</param>
        /// <param name="api">Логин API</param>
        /// <param name="login">Пароль API</param>
        /// <param name="file">Файл гостей для импорта</param>
        /// <param name="balance">Баланс для гостей</param>
        static void UpdateCustomers(string org, string cat, string cor, string api, string login, string file, string balance, object[] StatusCustomers, bool owerwriteName = false)
        {
            try
            {
                if (api == "" || login == "")
                    throw new NullReferenceException(message: "Не заполнены данные пользователя API");
                if (org == "" || cat == "" || cor == "")
                    throw new NullReferenceException(message: "Не заполнены данные для добавления гостей");
                stopWatch.Restart();
                IEnumerable<ShortCustomerInfo> list = new List<ShortCustomerInfo>();
                ManagerCustomers managerCustomers;


                if (file.Contains(".csv"))
                {
                    var csvManager = new ManagerCsv(file);
                    list = csvManager.GetClients()
                        .Select(data => new ShortCustomerInfo()
                        {
                            Name = data.Name,
                            Card = data.Number
                        })
                        .ToArray();
                }
                else if (file.Contains(".xls"))
                {
                    var excelManager = new ManagerExcel(file);
                    list = excelManager.GetClients().ToArray();
                }


                managerCustomers = new ManagerCustomers(
                    ManagerSQL.GetInstance.Tables.Organization.Organizations.Where(data => data.IsActive && data.Name == org).FirstOrDefault(),
                    ManagerSQL.GetInstance.Tables.Category.Categories.Where(data => data.IsActive && data.Name == cat).FirstOrDefault(),
                    ManagerSQL.GetInstance.Tables.WalletName.WalletsName.Where(data => data.Name == cor).FirstOrDefault(),
                    new ManagerAPI(api, login));

                logger.Info($"Начата робота с категорией {cat} и программой {cor}");
                logger.Info(balance is null ?
                    $"Запрошено массовое добавление {list.Count()} гостей без баланса" :
                    $"Запрошено массовое добавление {list.Count()} гостей с балансом {balance}");

                //l_AllCustomers.Invoke(new Action(() => l_AllCustomers.Visible = false));
                managerCustomers.UploadCustomers(list, balance, StatusCustomers, owerwriteName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                logger.Warn(ex.Message);
            }
        }



        static void CreateTabNumberReport(string tabNumberReport, string iikoBizReport, string currentReport)
        {
            try
            {
                stopWatch.Restart();
                var excelManager = new ManagerExcel(tabNumberReport);
                var list = excelManager.GetClients().ToArray();

                new ManagerExcel(iikoBizReport).CreateReportWithTabNumber(list, currentReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                logger.Warn(ex.Message);
            }
        }
        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------





        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                       ФОРМИРОВАНИЕ CSV ДЛЯ БИЗА
         ------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region Формирование CSV для iiko.biz
        private void btn_Open_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (rb_csv.Checked) dialog.Filter = "Файлы csv|*.csv";
            if (rb_excel.Checked) dialog.Filter = "Файлы EXCEL|*.xlsx;*.xls|Файлы .cvs|*.csv";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            tb_file.Text = dialog.SafeFileName;
            strFilePath = dialog.FileName;
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            logger.Info("Инициализация преобразования файлов");
            string status = string.Empty;
            try
            {
                if (strFilePath.Contains(".xlsx") || strFilePath.Contains(".xlx"))
                {
                    logger.Info("Выбран excel документ");
                    var clients = new ManagerExcel(strFilePath).GetClients();
                    var manager = new ManagerCsv();
                    manager.CreateClients(
                        string.Format($"{tb_group.Text} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString().Replace(':', '.')}"),
                        clients,
                        cb_isDeleted.Checked);
                    status += "Файл гостей создан" + '\n';
                    if (!cb_isDeleted.Checked)
                    {
                        manager.CreateBalanses(
                            string.Format($"{tb_group.Text} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString().Replace(':', '.')}"),
                           clients,
                            tb_balance.Text);
                        status += "Файл баланса гостей создан" + '\n';
                    }
                    status += $"Гостей обработано: {clients.Count()}" + '\n';
                }
                else
                {
                    logger.Info("Выбран csv документ");
                    var manager = new ManagerCsv(strFilePath,
                        string.Format($"{tb_group.Text} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString().Replace(':', '.')}"),
                        cb_isDeleted.Checked);
                    manager.CreateClients();
                    status += "Файл гостей создан" + '\n';
                    if (!cb_isDeleted.Checked)
                    {
                        manager.CreateBalanses(tb_balance.Text);
                        status += "Файл баланса гостей создан";
                    }
                }
                MessageBox.Show(status, "Успешно");
                logger.Info(status);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                logger.Warn(ex.Message);

            }
        }

        private void tb_balance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
        #endregion
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------




        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                  ВЫГРУЗКА В IIKO.BIZ
        ------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region Выгрузка в iiko.biz
        private void btn_SaveAPI_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LoginAPI = tb_LoginAPI.Text;
            Properties.Settings.Default.PasswordAPI = tb_PasswordAPI.Text;
            Properties.Settings.Default.ManagerCard = cb_ManagerCard.Checked;

            Properties.Settings.Default.Organization = cb_organizations.Text;
            Properties.Settings.Default.CorporateNutritions = cb_CorporateNutritions.Text;

            Properties.Settings.Default.DataBase_Folder = tb_DataBase_Folder.Text;
            Properties.Settings.Default.DataBase_Name = tb_DataBase_Name.Text;
            Properties.Settings.Default.Save();

            tb_CorporateNutritions_Name.Text = Properties.Settings.Default.CorporateNutritions;
            tb_Organization_Name.Text = Properties.Settings.Default.Organization;
            logger.Info("Сохранение настроек");
        }



        private void tb_CustomersBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void btn_RefreshDataBiz_Click(object sender, EventArgs e)
        {
            try
            {
                var deliveryAPI = new ManagerAPI(tb_LoginAPI.Text, tb_PasswordAPI.Text);
                var organizations = Task.Run(() => deliveryAPI.GetOrganizations()).Result;
                var categoryes = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault().Id)).Result;
                var corporateNutritions = Task.Run(() => deliveryAPI.GetCorporateNutritions(organizations.FirstOrDefault().Id)).Result;

                cb_Categories.Items.Clear();
                cb_organizations.Items.Clear();
                cb_CorporateNutritions.Items.Clear();

                cb_CorporateNutritions.Items.AddRange(corporateNutritions.Select(data => data.Name).ToArray());
                cb_CorporateNutritions.SelectedIndex = 0;
                cb_organizations.Items.AddRange(organizations.Select(data => data.Name).ToArray());
                cb_organizations.SelectedIndex = 0;
                cb_Categories.Items.AddRange(categoryes.Select(data => data.Name).ToArray());
                cb_Categories.SelectedIndex = 0;



                ///ЗАНЕСЕНИЕ ДАННЫХ В БД
                var managerSQLTables = ManagerSQL.GetInstance.Tables;
                managerSQLTables.Organization.Insert(organizations);
                managerSQLTables.Category.Insert(categoryes);
                managerSQLTables.Category.Deactivation(categoryes);
                managerSQLTables.WalletName.Insert(corporateNutritions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.InnerException, "Ошибка");
            }
        }

        private void btn_NewCategory_Click(object sender, EventArgs e)
        {
            var deliveryAPI = new ManagerAPI(tb_LoginAPI.Text, tb_PasswordAPI.Text);
            var organizations = Task.Run(() => deliveryAPI.GetOrganizations()).Result;

            var cat = cb_Categories.Text;
            var org = cb_organizations.Text == "" ? organizations.FirstOrDefault().Name : cb_organizations.Text;

            var result = Task.Run(() =>
                deliveryAPI.CreateCustomersCategory(
                    cat,
                    organizations.Where(data => data.Name == org).FirstOrDefault().Id)
                    ).Result;

            if (result)
            {
                MessageBox.Show("Категория " + cat + " добавлена", "Успешно");
                var categoryes = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault().Id)).Result;
                ManagerSQL.GetInstance.Tables.Category.Insert(categoryes);

                cb_Categories.Items.Clear();
                cb_Categories.Items.AddRange(categoryes.Select(data => data.Name).ToArray());
            }
            else
            {
                MessageBox.Show("Возникла ошибка при добавлении категории", "Ошибка");
            }

        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Файлы EXCEL|*.xlsx;*.xls|Файлы .cvs|*.csv";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            tb_OpenFile.Text = dialog.SafeFileName;
            strFilePath = dialog.FileName;
        }

        
        
        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                pb_load.Enabled = pb_load.Visible = true;
                if (!ManagerSQL.GetInstance.Tables.Category.Categories
                    .Select(Data => Data.Name)
                    .ToArray()
                    .Contains(cb_Categories.Text))
                {
                    MessageBox.Show("Укажите правильную категория гостя", "Ошибка");
                    CallBackFunc(true);
                    return;
                }

                del_Customer.BeginInvoke(
                    cb_organizations.SelectedItem.ToString(),
                    cb_Categories.SelectedItem.ToString(),
                    cb_CorporateNutritions.SelectedItem.ToString(),
                    tb_LoginAPI.Text,
                    tb_PasswordAPI.Text,
                    tb_NameCustomer.Text,
                    tb_CardCustomer.Text,
                    tb_CustomersBalance.Enabled ? tb_CustomersBalance.Text : null,
                    cb_OwerwriteName.Checked,
                    new AsyncCallback(CallBackUpdateCustomer),
                    null
                    );

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Затраченное время {stopWatch.ElapsedMilliseconds / 1000.0f} сек.\r\n Возникла ошибка при добавлении гостей \r\n" + ex.Message, "Ошибка");
            }
        }
        /// <summary>
        /// получение данных из биза, файла гостей и загрузка их в биз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UploadCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                pb_load.Enabled = pb_load.Visible = true;
                l_AllCustomers.Visible = l_UploadCustomers.Visible = true;
                if (!ManagerSQL.GetInstance.Tables.Category.Categories
                    .Select(Data => Data.Name)
                    .Contains(cb_Categories.Text))
                {
                    MessageBox.Show("Укажите правильную категория гостя", "Ошибка");
                    CallBackFunc(true);
                    return;
                }

                del_Customers.BeginInvoke(
                    cb_organizations.SelectedItem.ToString(), 
                    cb_Categories.SelectedItem.ToString(), 
                    cb_CorporateNutritions.SelectedItem.ToString(), 
                    tb_LoginAPI.Text,
                    tb_PasswordAPI.Text, 
                    strFilePath,
                    tb_CustomersBalance.Enabled ? tb_CustomersBalance.Text : null,
                    new object[] { l_UploadCustomers, l_AllCustomers },
                    cb_OwerwriteName.Checked,
                    new AsyncCallback(CallBackUpdateCustomers), 
                    null);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Затраченное время {stopWatch.ElapsedMilliseconds / 1000.0f} сек.\r\n Возникла ошибка при добавлении гостей \r\n" + ex.Message, "Ошибка");
            }
        }

        private void cb_OwerwriteBalance_CheckedChanged(object sender, EventArgs e)
        {
            tb_CustomersBalance.Enabled = !((CheckBox)sender).Checked;
        }
        #endregion
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------




        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                        ФОРМИРОВАНИЕ ОТЧЕТА С ТАБЕЛЬНЫМ НОМЕРОМ НА ОСНОВАНИИ ОТЧЕТА БИЗА
          ------------------------------------------------------------------------------------------------------------------------------------------------------------ */
        #region Отчет с табельными номерами
        string fileTabNumber = "";
        string fileReport = "";

        private void btn_fileTabNumber_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Файлы EXCEL|*.xlsx;*.xls|Файлы .cvs|*.csv";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            tb_fileTabNumber.Text = dialog.SafeFileName;
            fileTabNumber = dialog.FileName;
        }

        private void btn_fileReport_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Файлы EXCEL|*.xlsx;*.xls|Файлы .cvs|*.csv";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            tb_fileReport.Text = dialog.SafeFileName;
            fileReport = dialog.FileName;
        }
        /// <summary>
        /// Формирование отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                var save = new SaveFileDialog();
                save.Filter = "xls files (*.xls)|*.xls|All files|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    pb_load.Enabled = pb_load.Visible = true;
                    del_Report.BeginInvoke(
                        fileTabNumber, 
                        fileReport, 
                        save.FileName,
                        new AsyncCallback(CallBackCreateReport),
                        null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }





        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                        ФОРМИРОВАНИЕ ОТЧЕТА С ТАБЕЛЬНЫМ НОМЕРОМ ЗАПРОСОМ ИЗ БИЗА
          ------------------------------------------------------------------------------------------------------------------------------------------------------------ */

        #region Отчет из биза

        private void btn_Report_Create_Click(object sender, EventArgs e)
        {

        }

        #endregion
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
