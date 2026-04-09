using ProyectoInversion.Modulos.GestiónEscenarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoInversion.Modulos.Base;
using ProyectoInversion.Modulos.FlujosCasos;
using ProyectoInversion.Modulos.Simulaciones;

namespace ProyectoInversion.Modulos.Menu
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetSystemMenu(IntPtr hWnd, bool bRevert);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DeleteMenu(int hMenu, int nPosition, int wFlags);

        private const int SC_CLOSE = 0xF060;
        private const int MF_BYCOMMAND = 0x0000;
        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Esto deshabilita el botón X físicamente
            int menu = GetSystemMenu(this.Handle, false);
            DeleteMenu(menu, SC_CLOSE, MF_BYCOMMAND);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void escenarioBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void escenarioBaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBase frm = new frmBase();
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog();
        }

        private void comparaciónEscenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFlujosCasos frm = new frmFlujosCasos();
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog();
        }

        private void compararEscenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarSimulacion frm = new frmSeleccionarSimulacion("CompararEscenarios");
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
            } else
            {
                this.Show();
            }

        }

        private void ingresarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoProyecto frm = new frmNuevoProyecto();
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog();
        }

        private void ingresarAlternativaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSeleccionarSimulacion frm = new frmSeleccionarSimulacion("IngresarAlternativa");
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
            } else
            {
                this.Show();
            }
        }
    }
}
