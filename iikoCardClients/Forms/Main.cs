using iikoCardClients.Data;
using iikoCardClients.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iikoCardClients
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


            Managers.ManagerAPI.Initialization();
            tb_LoginAPI.Text = Properties.Settings.Default.LoginAPI;
            tb_PasswordAPI.Text = Properties.Settings.Default.PasswordAPI;
        }
        string strFilePath = "";

        //C:\Users\Kirill\Desktop\Ложка + OZON 6.1.4011.0\Сотруд.csv

        private void btn_Open_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Файлы csv|*.csv";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;
            tb_file.Text = dialog.SafeFileName;
            strFilePath = dialog.FileName;
        }

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            try
            {
                string status = string.Empty;
                var manager = new ManagerCsv(strFilePath, 
                    string.Format($"{tb_group.Text} {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString().Replace(':','.')}"),
                    cb_isDeleted.Checked);
                manager.CreateClients();
                status += "Файл гостей создан" + '\n';
                if (!cb_isDeleted.Checked)
                {
                    manager.CreateBalanses(tb_balance.Text);
                    status += "Файл баланса гостей создан";
                }
                MessageBox.Show(status, "Успешно");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                

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
            Properties.Settings.Default.Save();
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

        private void btn_CreateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                var deliveryAPI = new Managers.ManagerAPI(tb_LoginAPI.Text, tb_PasswordAPI.Text);
                var organizations = Task.Run(() => deliveryAPI.GetOrganizations()).Result;
                var categories = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault())).Result;
                var corporateNutritions = Task.Run(() => deliveryAPI.GetCorporateNutritions(organizations.FirstOrDefault())).Result;



                var org = cb_organizations.SelectedItem.ToString();
                var cat = cb_Categories.SelectedItem.ToString();
                var cor = cb_CorporateNutritions.SelectedItem.ToString();

                var managerCustomers = new ManagerCustomers(
                    organizations.Where(data => data.Name == org).FirstOrDefault(),
                    categories.Where(data => data.Name == cat).FirstOrDefault(),
                    corporateNutritions.Where(data => data.Name == cor).FirstOrDefault(),
                    deliveryAPI);

                var customer = new ShortCustomerInfo()
                {
                    Name = tb_NameCustomer.Text,
                    Card = tb_CardCustomer.Text
                };
                var customers = new List<ShortCustomerInfo>();
                customers.Add(customer);
                managerCustomers.UploadCustomers(customers, tb_CustomersBalance.Text);


                MessageBox.Show("Гость \"" + customer.Name + "\" добавлен, баланс установлен", "Успешно");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка при добавлении гостя \r\n" + ex.Message, "Ошибка");
            }
        }

        private void btn_UploadCustomers_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                IEnumerable<ShortCustomerInfo> list = new List<ShortCustomerInfo>();
                if (strFilePath.Contains(".csv"))
                {
                    var csvManager = new ManagerCsv(strFilePath);
                    list = csvManager.GetClients()
                        .Select(data => new ShortCustomerInfo()
                        {
                            Name = data.Name,
                            Card = data.Number
                        })
                        .ToArray();
                }
                else if (strFilePath.Contains(".xls"))
                {
                    var excelManager = new ManagerExcel(strFilePath);
                    list = excelManager.GetClients().ToArray();
                }
                if (tb_LoginAPI.Text == "" || tb_PasswordAPI.Text == "")
                    throw new NullReferenceException(message:"Не заполнены данные пользователя API");

                var deliveryAPI = new Managers.ManagerAPI(tb_LoginAPI.Text, tb_PasswordAPI.Text);
                var organizations = Task.Run(() => deliveryAPI.GetOrganizations()).Result;
                var categories = Task.Run(() => deliveryAPI.GetCategories(organizations.FirstOrDefault())).Result;
                var corporateNutritions = Task.Run(() => deliveryAPI.GetCorporateNutritions(organizations.FirstOrDefault())).Result;



                var org = cb_organizations.SelectedItem.ToString();
                var cat = cb_Categories.SelectedItem.ToString();
                var cor = cb_CorporateNutritions.SelectedItem.ToString();

                var managerCustomers = new ManagerCustomers(
                    organizations.Where(data => data.Name == org).FirstOrDefault(),
                    categories.Where(data => data.Name == cat).FirstOrDefault(),
                    corporateNutritions.Where(data => data.Name == cor).FirstOrDefault(),
                    deliveryAPI);
                managerCustomers.UploadCustomers(list, tb_CustomersBalance.Text);


                stopWatch.Stop();
                MessageBox.Show(
                    $"Гостей обработано {managerCustomers.GetCountAll} \r\n" +
                    $"Гостей выгружено {managerCustomers.GetCountUpload} \r\n" +
                    $"У гостей обработан баланс {managerCustomers.GetCountBalance} \r\n" +
                    $"Гостей не обработано {managerCustomers.GetCountFail} \r\n" +
                    $"Затраченное время {stopWatch.ElapsedMilliseconds / 1000.0f} сек.",
                    "Выгружено"
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Затраченное время {stopWatch.ElapsedMilliseconds / 1000.0f} сек.\r\n Возникла ошибка при добавлении гостей \r\n" + ex.Message, "Ошибка");
            }
        }
    }
}
