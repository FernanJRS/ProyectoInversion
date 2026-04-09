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

        private void frmMenu_Load(object sender, EventArgs e)
        {

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
            using (frmSeleccionarSimulacion frm = new frmSeleccionarSimulacion("EscenarioBase"))
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
                
        }

        private void comparaciónEscenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSeleccionarSimulacion frm = new frmSeleccionarSimulacion("FlujosCasos"))
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void compararEscenariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmSeleccionarSimulacion frm = new frmSeleccionarSimulacion("CompararEscenarios"))
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void ingresarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoProyecto frm = new frmNuevoProyecto();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            this.Close();
        }
    }
}
