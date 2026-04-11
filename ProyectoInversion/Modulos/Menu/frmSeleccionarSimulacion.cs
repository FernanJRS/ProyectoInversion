using ProyectoInversion.Clases;
using ProyectoInversion.Modulos.Base;
using ProyectoInversion.Modulos.FlujosCasos;
using ProyectoInversion.Modulos.GestiónEscenarios;
using ProyectoInversion.Modulos.Simulaciones;
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
            try
            {
                ConexionDB db = new ConexionDB();
                DataTable dt = db.ObtenerSimulaciones();
                this.formulario = formulario;

                cmbSimulacion.DataSource = dt;
                cmbSimulacion.DisplayMember = "Nombre";
                cmbSimulacion.ValueMember = "SimulacionID";
            } catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar simulaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
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
                
                if (formulario == "CompararEscenarios")
                {
                    frmCompararEscenarios frm = new frmCompararEscenarios(simulacionID);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //this.Hide();
                    frm.ShowDialog();
                }
                
                if (formulario == "Escenarios")
                {
                    frmBase frm = new frmBase(simulacionID);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }

                if (formulario == "IngresarAlternativa")
                {
                    ConexionDB db = new ConexionDB();
                    int  altBase = db.ObtenerAlternativaBaseID(simulacionID);

                    frmNuevaAlternativa frm = new frmNuevaAlternativa(simulacionID, altBase);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //this.Hide();
                    frm.ShowDialog();
                }

                if (formulario == "FlujosCasos")
                {
                    var frm = new frmFlujosCasos(simulacionID, nombreSimulacion);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    //this.Hide();
                    frm.ShowDialog();
                }

                this.DialogResult = DialogResult.OK;
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
