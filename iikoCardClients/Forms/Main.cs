using iikoCardClients.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iikoCardClients
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

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
                var manager = new CsvManager(strFilePath, 
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
    }
}
