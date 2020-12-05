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

            Reader.Reader.SetFiel(l_Card);
            ManagerAPI.Initialization();

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
                    .Where(data => data.Active == true && data.Name == Properties.Settings.Default.Organization)
                    .Select(data => data.Id)
                    .FirstOrDefault();

                WalletID = Task.Run(() => deliveryAPI.GetCorporateNutritions())
                    .Result
                    .Where(data => data.Name == Properties.Settings.Default.CorporateNutritions)
                    .Select(data => data.Wallets)
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
                new Main().ShowDialog();
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
            
            l_stat.BackColor = reader & biz ? Color.LightGreen : Color.Red;
            if (reader | biz) l_stat.BackColor = Color.Yellow;

        }

        private void FormBalance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reader.Reader.LoggerMessage("Закрытие приложения");
            Reader.Reader.Dispose();
        }

        private void l_Card_TextChanged(object sender, EventArgs e)
        {
            if (((Label)sender).Text != string.Empty)
            {
                deliveryAPI.GetCastomerInfoByCard(((Label)sender).Text, OrganizationId, WalletID);
            }
            else
            {
                l_Name.Text = l_Balance.Text = string.Empty;
            }
        }

        
    }
}
