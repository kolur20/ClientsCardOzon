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
        public FormBalance()
        {
            InitializeComponent();
            CountClick = 0;
            timer_settings.Start();
            l_Description.Text = string.Empty;

            Reader.Reader.SetFiel(l_Card);
            ManagerAPI.Initialization();

            ConnectToRead();
            ConnectToBiz();

        }

        private void ConnectToBiz()
        {
            try
            {
                deliveryAPI = new ManagerAPI(Properties.Settings.Default.LoginAPI, Properties.Settings.Default.PasswordAPI);
                OrganizationId = Task.Run(() => deliveryAPI.GetOrganizations())
                    .Result
                    .Where(data => data.Active == true)
                    .Select(data => data.Id)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n Приложение будет закрыто", "Ошибка подключения API");
                Properties.Settings.Default.ManagerCard = false;
                Properties.Settings.Default.Save();
                Close();
            }
        }
        private void ConnectToRead()
        {
            try
            {
                Reader.Reader.InitializaeZ2(l_stat);
            }
            catch (Reader.ReaderExceptions)
            {
                Reader.Reader.LoggerMessage($"Повторная попытка через {timer_readerConnection.Interval} ms");
                timer_readerConnection.Start();
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
            ConnectToRead();
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
            }
            else
            {
                l_Name.Text = l_Balance.Text = string.Empty;
            }
        }

        
    }
}
