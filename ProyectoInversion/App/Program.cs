using ProyectoInversion.Modulos.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInversion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();

            if (frmLogin.Conectado)
            {
                Application.Run(new frmMenu());
            }
        }
    }
}
