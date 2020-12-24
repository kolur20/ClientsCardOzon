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
        public FormMain()
        {
            InitializeComponent();
            logger = NLog.LogManager.GetCurrentClassLogger();
            logger.Info("Запуск приложения...");

            Managers.ManagerAPI.Initialization();
            tb_LoginAPI.Text = Properties.Settings.Default.LoginAPI;
            tb_PasswordAPI.Text = Properties.Settings.Default.PasswordAPI;
            cb_ManagerCard.Checked = Properties.Settings.Default.ManagerCard;
            

            cb_organizations.SelectedItem = Properties.Settings.Default.Organization;
            cb_CorporateNutritions.SelectedItem = Properties.Settings.Default.CorporateNutritions;

            logger.Info("Приложение запущено");
        }
        string strFilePath = "";

        //C:\Users\Kirill\Desktop\Ложка + OZON 6.1.4011.0\Сотруд.csv

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

        private void btn_SaveAPI_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LoginAPI = tb_LoginAPI.Text;
            Properties.Settings.Default.PasswordAPI = tb_PasswordAPI.Text;
            Properties.Settings.Default.ManagerCard = cb_ManagerCard.Checked;

            Properties.Settings.Default.Organization = cb_organizations.Text;
            Properties.Settings.Default.CorporateNutritions = cb_CorporateNutritions.Text;
            Properties.Settings.Default.Save();
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
                var categoryes = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault())).Result;
                var corporateNutritions = Task.Run(() => deliveryAPI.GetCorporateNutritions(organizations.FirstOrDefault())).Result;

                cb_Categories.Items.Clear();
                cb_organizations.Items.Clear();
                cb_CorporateNutritions.Items.Clear();

                cb_CorporateNutritions.Items.AddRange(corporateNutritions.Select(data => data.Name).ToArray());
                cb_CorporateNutritions.SelectedIndex = 0;
                cb_organizations.Items.AddRange(organizations.Select(data => data.Name).ToArray());
                cb_organizations.SelectedIndex = 0;
                cb_Categories.Items.AddRange(categoryes.Select(data => data.Name).ToArray());
                cb_Categories.SelectedIndex = 0;

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
                    organizations.Where(data => data.Name == org).FirstOrDefault())
                    ).Result;

            if (result)
            {
                MessageBox.Show("Категория " + cat + " добавлена", "Успешно");
                var categoryes = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault())).Result;
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

        
        //ДЕЛЕГАТЫ
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DelegateCustomers(string org, string cat, string cor, string api, string login, string file, string balance);
        delegate void DelegateCustomer(string org, string cat, string cor, string api, string login, string name, string card, string balance);
        DelegateCustomers del_Customers = new DelegateCustomers(UpdateCustomers);
        DelegateCustomer del_Customer = new DelegateCustomer(UpdateCustomer);
        static Stopwatch stopWatch = new Stopwatch();
        static void UpdateCustomer(string org, string cat, string cor, string api, string login, string name, string card, string balance)
        {
            try
            {
                stopWatch.Start();
                var deliveryAPI = new Managers.ManagerAPI(api, login);
                var organizations = Task.Run(() => deliveryAPI.GetOrganizations()).Result;
                var categories = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault())).Result;
                var corporateNutritions = Task.Run(() => deliveryAPI.GetCorporateNutritions(organizations.FirstOrDefault())).Result;



                var managerCustomers = new ManagerCustomers(
                    organizations.Where(data => data.Name == org).FirstOrDefault(),
                    categories.Where(data => data.Name == cat).FirstOrDefault(),
                    corporateNutritions.Where(data => data.Name == cor).FirstOrDefault(),
                    deliveryAPI);

                var customer = new ShortCustomerInfo()
                {
                    Name = name,
                    Card = card
                };
                var customers = new List<ShortCustomerInfo>();
                customers.Add(customer);
                logger.Info($"Начата робота с категорией {cat} и программой {cor}");
                logger.Info($"Добавление одного гостя: {customer.Name} с картой {customer.Card} и балансом {balance}");
                managerCustomers.UploadCustomers(customers, balance);

                
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
        static void UpdateCustomers(string org, string cat, string cor, string api, string login, string file, string balance)
        {
            try
            {
                if (api == "" || login == "")
                    throw new NullReferenceException(message: "Не заполнены данные пользователя API");
                if (org == "" || cat == "" ||cor == "" ||balance == "")
                    throw new NullReferenceException(message: "Не заполнены данные для добавления гостей");
                stopWatch.Start();
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
                
                
                var deliveryAPI = new Managers.ManagerAPI(api, login);
                var organizations = Task.Run(() => deliveryAPI.GetOrganizations()).Result;
                var categories = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault())).Result;
                var corporateNutritions = Task.Run(() => deliveryAPI.GetCorporateNutritions(organizations.FirstOrDefault())).Result;

                managerCustomers = new ManagerCustomers(
                    organizations.Where(data => data.Name == org).FirstOrDefault(),
                    categories.Where(data => data.Name == cat).FirstOrDefault(),
                    corporateNutritions.Where(data => data.Name == cor).FirstOrDefault(),
                    deliveryAPI);
                logger.Info($"Начата робота с категорией {cat} и программой {cor}");
                logger.Info($"Запрошено массовое добавление {list.Count()} гостей с балансом {balance}");
                managerCustomers.UploadCustomers(list, balance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                logger.Warn(ex.Message);
            }
        }

        void CallBackFuncCustomers(IAsyncResult aRes)
        {
            del_Customers.EndInvoke(aRes);
            CallBackFunc();
        }
        void CallBackFuncCustomer(IAsyncResult aRes)
        {
            del_Customer.EndInvoke(aRes);
            CallBackFunc();
        }
        void CallBackFunc()
        {
            pb_load.Invoke(new Action(() => pb_load.Enabled = pb_load.Visible = false));
            stopWatch.Stop();
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

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                pb_load.Enabled = pb_load.Visible = true;


                del_Customer.BeginInvoke(
                    cb_organizations.SelectedItem.ToString(),
                    cb_Categories.SelectedItem.ToString(),
                    cb_CorporateNutritions.SelectedItem.ToString(),
                    tb_LoginAPI.Text,
                    tb_PasswordAPI.Text,
                    tb_NameCustomer.Text,
                    tb_CardCustomer.Text,
                    tb_CustomersBalance.Text,
                    new AsyncCallback(CallBackFuncCustomer),
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
                
                var org = cb_organizations.SelectedItem.ToString();
                var cat = cb_Categories.SelectedItem.ToString();
                var cor = cb_CorporateNutritions.SelectedItem.ToString();
                var api = tb_LoginAPI.Text;
                var login = tb_PasswordAPI.Text;
                var balance = tb_CustomersBalance.Text;
                pb_load.Enabled = pb_load.Visible = true;

                del_Customers.BeginInvoke(org, cat, cor, api, login, strFilePath, balance, new AsyncCallback(CallBackFuncCustomers), null);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Затраченное время {stopWatch.ElapsedMilliseconds / 1000.0f} сек.\r\n Возникла ошибка при добавлении гостей \r\n" + ex.Message, "Ошибка");
            }
        }



        /*------------------------------------------------------------------------------------------------------------------------------------------------------------
                        ФОРМИРОВАНИЕ ОТЧЕТА С ТАБЕЛЬНЫМ НОМЕРОМ НА ОСНОВАНИИ ОТЧЕТА БИЗА
          ------------------------------------------------------------------------------------------------------------------------------------------------------------ */

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
                var excelManager = new ManagerExcel(fileTabNumber);
                var list = excelManager.GetClients().ToArray();

                new ManagerExcel(fileReport).CreateReportWithTabNumber(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
