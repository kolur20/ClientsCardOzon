using iikoCardClients.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iikoCardClients
{

    public partial class FormBalance : Form
    {
        NLog.Logger logger = null;
        private int CountClick;
        ManagerAPI deliveryAPI = null;
        string OrganizationId = "";
        string WalletID = "";
        public FormBalance()
        {
            InitializeComponent();
            CountClick = 0;
            timer_settings.Start();
            l_Description.Text = string.Empty;
            logger = NLog.LogManager.GetCurrentClassLogger();

            Reader.Reader.SetFiel(l_Card);
            ManagerAPI.Initialization();
            logger.Info("Старт приложения...");
            //ускоряем подключение путем использования таймера при отвале
            timer_readerConnection_Tick(null, null);

        }

        private bool ConnectToBiz()
        {
            try
            {
                deliveryAPI = new ManagerAPI(Properties.Settings.Default.LoginAPI, Properties.Settings.Default.PasswordAPI);
                OrganizationId = Task.Run(() => deliveryAPI.GetOrganizations())
                    .Result
                    .Where(data => data.IsActive == true && data.Name == Properties.Settings.Default.Organization)
                    .Select(data => data.Id)
                    .FirstOrDefault();

                WalletID = Task.Run(() => deliveryAPI.GetCorporateNutritions())
                    .Result
                    .Where(data => data.Name == Properties.Settings.Default.CorporateNutritions)
                    .Select(data => data.IdWallet)
                    .FirstOrDefault();
                if (WalletID is null || OrganizationId is null)
                    throw new ArgumentNullException("Не задана организация или акция", "");

                return true;
            }
            catch (AggregateException)
            {
                
                timer_readerConnection.Start();
                return false;
            }
            catch (Exception ex)
            {
                timer_readerConnection.Stop();
                MessageBox.Show(ex.Message + "\n Приложение будет закрыто \n Укажите данные при следующем запуске.", "Ошибка подключения API");
                
                Properties.Settings.Default.ManagerCard = false;
                Properties.Settings.Default.Save();
                Close();
                return false;
            }
        }
        private bool ConnectToRead()
        {
            try
            {
                Reader.Reader.InitializaeZ2(l_stat);
                return true;
            }
            catch (Reader.ReaderExceptions)
            {
                Reader.Reader.LoggerMessage($"Повторная попытка через {timer_readerConnection.Interval} ms");
                timer_readerConnection.Start();
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            CountClick++;

            if (CountClick == 7)
            {
                CountClick = 0;
                timer_settings.Stop();
                new FormMain().ShowDialog();
                this.Close();
                
            }
        }

        private void timer_settings_Tick(object sender, EventArgs e)
        {
            CountClick = 0;
        }

        private void timer_readerConnection_Tick(object sender, EventArgs e)
        {
            var reader = ConnectToRead();
            var biz = ConnectToBiz();

            logger.Info(string.Format("Подключение к ридеру... {0}", reader ? "Успешно" : "Не успешно"));
            logger.Info(string.Format("Подключение к iiko.biz... {0}", biz ? "Успешно" : "Не успешно"));
            if (reader & biz)
            {
                l_stat.BackColor = Color.LightGreen;
            }
            else
            {

                l_stat.BackColor = reader | biz ? Color.Yellow : Color.Red;
            }
            

        }

        private void FormBalance_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Info("Закрытие приложения");
            Reader.Reader.LoggerMessage("Закрытие приложения");
            Reader.Reader.Dispose();
        }

        private void l_Card_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text != string.Empty)
            {
                logger.Info($"Карта {((Label)sender).Text} поднесена к считывателю");
                try
                {
                    var customer = Task.Run(() => deliveryAPI.GetCustomerInfoByCard(((Label)sender).Text, OrganizationId, WalletID)).Result;
                    l_Name.Text = customer.Name;
                    l_Balance.Text = customer.Wallet.Balance.ToString();
                    l_Description.Text = "Организация: ";
                    foreach (var i in customer.Category)
                        l_Description.Text += i + ", ";
                    if (l_Description.Text.Contains("Удален"))
                    {
                        l_Description.Text = "Гость - " + customer.Name + ", удален из программы корпоративного питания!";
                    }
                    else
                        l_Description.Text = l_Description.Text.Remove(l_Description.Text.Length - 2);

                    logger.Info($"Гость - {customer.Name} баланс: {l_Balance.Text} {l_Description.Text}");
                }
                catch (AggregateException ex)
                {
                    l_Description.Text= "Гость с такой картой не найден";
                    logger.Warn("Гость с такой картой не найден");
                }
                catch (Exception ex)
                {
                    l_Description.Text = ex.Message;
                    logger.Error(ex.Message);
                }
            }
            else
            {
                l_Name.Text = l_Balance.Text = string.Empty;
                l_Description.Text = string.Empty;
            }
        }

        
    }
}
