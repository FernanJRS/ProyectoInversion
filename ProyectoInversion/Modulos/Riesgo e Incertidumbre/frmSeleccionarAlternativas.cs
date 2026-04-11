using ProyectoInversion.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInversion.Modulos.Riesgo_e_Incertidumbre
{
    public partial class frmSeleccionarAlternativas : Form
    {
        public int simulacionID { get; set; }
        public string nombreSimulacion { get; set; }
        public int[] alternativasIDs { get; set; }
        public double[] probabilidades { get; set; }

        private DataTable _alternativas;
        public frmSeleccionarAlternativas()
        {
            InitializeComponent();
            CargarSimulaciones();
        }

        private void CargarSimulaciones()
        {
            try
            {
                ConexionDB db = new ConexionDB();
                DataTable simulaciones = db.ObtenerSimulaciones();

                cmbSimulacion.DataSource = simulaciones.Copy();
                cmbSimulacion.ValueMember = "SimulacionID";
                cmbSimulacion.DisplayMember = "Nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar simulaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetSystemMenu(IntPtr hWnd, bool bRevert);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DeleteMenu(int hMenu, int nPosition, int wFlags);

        private const int SC_CLOSE = 0xF060;
        private const int MF_BYCOMMAND = 0x0000;
        private void frmSeleccionarAlternativas_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Esto deshabilita el botón X físicamente
            int menu = GetSystemMenu(this.Handle, false);
            DeleteMenu(menu, SC_CLOSE, MF_BYCOMMAND);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbSimulacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSimulacion.SelectedValue != null)
            {   
                try
                {
                    int simulacionID = Convert.ToInt32(cmbSimulacion.SelectedValue);
                    ConexionDB db = new ConexionDB();
                    _alternativas = db.ObtenerAlternativas(simulacionID);

                    cmbEscenarioBase.DataSource = _alternativas.Copy();
                    cmbEscenarioBase.DisplayMember = "Nombre";
                    cmbEscenarioBase.ValueMember = "AlternativaID";
                }
                catch(Exception)
                {
                }

                try
                {
                    DataView alternativasSinBaseA = new DataView(_alternativas);
                    alternativasSinBaseA.RowFilter = "TipoAlternativa <> 'Base'";

                    cmbEscenarioA.DataSource = alternativasSinBaseA;
                    cmbEscenarioA.DisplayMember = "Nombre";
                    cmbEscenarioA.ValueMember = "AlternativaID";
                    if (cmbEscenarioA.Items.Count > 0) cmbEscenarioA.SelectedIndex = 0;
                }
                catch (Exception)
                {
                }

                try
                {
                    DataView alternativasSinBaseB = new DataView(_alternativas);
                    alternativasSinBaseB.RowFilter = "TipoAlternativa <> 'Base'";

                    cmbEscenarioB.DataSource = alternativasSinBaseB;
                    cmbEscenarioB.DisplayMember = "Nombre";
                    cmbEscenarioB.ValueMember = "AlternativaID";
                    if (cmbEscenarioB.Items.Count > 1) cmbEscenarioB.SelectedIndex = 1;
                }
                catch (Exception)
                {
                }
            }

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (cmbSimulacion.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una simulación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbEscenarioBase.SelectedValue == null || cmbEscenarioA.SelectedValue == null || cmbEscenarioB.SelectedValue == null)
            {
                MessageBox.Show("Seleccione alternativas válidas para todos los escenarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double ProbabilidadBase = Convert.ToDouble(txtBoxProb1.Text.Replace("%","").Trim()) / 100;
            double ProbabilidadA = Convert.ToDouble(txtBoxProb2.Text.Replace("%", "").Trim()) / 100;
            double ProbabilidadB = Convert.ToDouble(txtBoxProb3.Text.Replace("%", "").Trim()) / 100;

            if (ProbabilidadBase + ProbabilidadA + ProbabilidadB != 1)
            {
                MessageBox.Show("La suma de las probabilidades debe ser igual a 100%.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            simulacionID = (int)cmbSimulacion.SelectedValue;
            nombreSimulacion = cmbSimulacion.Text;

            int alternativaBaseID = (int)cmbEscenarioBase.SelectedValue;
            int alternativaAID = (int)cmbEscenarioA.SelectedValue;
            int alternativaBID = (int)cmbEscenarioB.SelectedValue;

            if (alternativaBaseID == alternativaAID || alternativaBaseID == alternativaBID || alternativaAID == alternativaBID)
            {
                MessageBox.Show("Las alternativas seleccionadas deben ser diferentes entre sí.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            alternativasIDs = new[] { alternativaBaseID, alternativaAID, alternativaBID };
            probabilidades = new[] { ProbabilidadBase, ProbabilidadA, ProbabilidadB };

            this.Close();

            this.DialogResult = DialogResult.OK;
            frmRiesgoComparación frm = new frmRiesgoComparación(simulacionID, nombreSimulacion, alternativasIDs, probabilidades);
            frm.ShowDialog();

        }

        private void txtBoxProb1_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (double.TryParse(textBox.Text, out double valor))
            {
                textBox.Text = (valor / 100).ToString("P2");
            }
        }
    }
}
