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

            //очищаем вся поля, которые будут использоваться
            ClearAllFields();
            pb_info_logo.BackgroundImage = Properties.Resources.info_logo_failed;



              logger = NLog.LogManager.GetCurrentClassLogger();

            Reader.Reader.SetFiel(l_Customer_Card);
            ManagerAPI.Initialization();
            logger.Info("Старт приложения...");
            //ускоряем подключение путем использования таймера при отвале
            timer_readerConnection_Tick(null, null);

        }

        private void ClearAllFields()
        {
            l_Customer_Balance.Text = string.Empty;
            l_Customer_Fname.Text = string.Empty;
            //l_Customer_Sname.Text = string.Empty;
            l_Customer_Card.Text = string.Empty;
            pb_info_field.BackgroundImage = null;
            pb_info_field.Image = null;
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
                Reader.Reader.InitializaeZ2(new Label());
                return true;
            }
            catch (Reader.ReaderExceptions)
            {
                Reader.Reader.LoggerMessage($"Повторная попытка через {timer_readerConnection.Interval} ms");
                timer_readerConnection.Start();
                return false;
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
                pb_info_logo.BackgroundImage = Properties.Resources.info_logo_ok;
            }
            else if (reader || biz)
            {
                pb_info_logo.BackgroundImage = Properties.Resources.info_logo_failed;
            }
            else
            {
                pb_info_logo.BackgroundImage = Properties.Resources.info_logo_error;
            }
            

        }

        private void FormBalance_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Info("Закрытие приложения");
            Reader.Reader.LoggerMessage("Закрытие приложения");
            Reader.Reader.Dispose();
        }

        

        private void l_Customer_Card_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text != string.Empty)
            {
                logger.Info($"Карта {((Label)sender).Text} поднесена к считывателю");
                try
                {
                    var customer = Task.Run(() => deliveryAPI.GetCustomerInfoByCard(((Label)sender).Text, OrganizationId, WalletID)).Result;
                    l_Customer_Fname.Text = customer.Name;
                    //var fielName = customer.Name.Split(' ');
                    ////защита от хуевого имени
                    //try
                    //{
                    //    l_Customer_Fname.Text = fielName.First();
                    //    l_Customer_Sname.Text = customer.Name.Remove(0, fielName.First().Length + 1);
                    //}
                    //catch (Exception) { }
                    l_Customer_Balance.Text = customer.Wallet.Balance.ToString();

                    //проверяем удален ли гость
                    if (customer.Category.Any(data => data.Contains("Удален")))
                    {
                        pb_info_field.BackgroundImage = Properties.Resources.info_logo_field_error;
                        pb_info_field.Image = Properties.Resources.text_deleted;
                    }
                    else
                    {
                        pb_info_field.BackgroundImage = Properties.Resources.info_logo_field_ok;
                        pb_info_field.Image = Properties.Resources.text_ok;
                    }


                    logger.Info($"Гость - {customer.Name} баланс: {customer.Wallet.Balance.ToString()}");
                }
                catch (AggregateException)
                {
                    pb_info_field.BackgroundImage = Properties.Resources.info_logo_field_error;
                    pb_info_field.Image = Properties.Resources.text_failed;
                    logger.Warn("Гость с такой картой не найден");
                }
                catch (Exception ex)
                {
                    
                    logger.Error(ex.Message);
                }
            }
            else
            {
                ClearAllFields();
            }
        }

        private void pb_info_logo_Click(object sender, EventArgs e)
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
    }
}
