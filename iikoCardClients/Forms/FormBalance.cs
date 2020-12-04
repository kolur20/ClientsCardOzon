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
        public FormBalance()
        {
            InitializeComponent();
            CountClick = 0;
            timer_settings.Start();


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
    }
}
