
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iikoCardClients
{
    static class program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try {
                if (Properties.Settings.Default.ManagerCard)
                    Application.Run(new FormBalance());
                else
                    Application.Run(new FormMain());
            }
            catch (Exception) { }
        }
    }
}
