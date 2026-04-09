using ProyectoInversion.Clases;
using ProyectoInversion.Modulos.Base;
using ProyectoInversion.Modulos.FlujosCasos;
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

namespace ProyectoInversion.Modulos.Menu
{
    public partial class frmSeleccionarSimulacion : Form
    {
        private string formulario;
        public frmSeleccionarSimulacion(String formulario)
        {
            InitializeComponent();
            ConexionDB db = new ConexionDB();
            DataTable dt = db.ObtenerSimulaciones();
            this.formulario = formulario;

            cmbSimulacion.DataSource = dt;
            cmbSimulacion.DisplayMember = "Nombre";
            cmbSimulacion.ValueMember = "SimulacionID";
        }

        private void cmbSimulacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbSimulacion.SelectedValue != null)
            {
                int simulacionID = Convert.ToInt32(cmbSimulacion.SelectedValue);
                string nombreSimulacion = ((DataRowView)cmbSimulacion.SelectedItem)["Nombre"].ToString();
                this.DialogResult = DialogResult.OK;
                if (formulario == "CompararEscenarios")
                {
                    frmCompararEscenarios frm = new frmCompararEscenarios(simulacionID);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                }
                
                if (formulario == "EscenarioBase")
                {
                    frmBase frm = new frmBase(simulacionID);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                }

                if (formulario == "FlujosCasos")
                {
                    var frm = new frmFlujosCasos(simulacionID, nombreSimulacion);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una simulación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
