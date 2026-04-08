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

namespace ProyectoInversion.Modulos.GestiónEscenarios
{
    public partial class frmEliminarAlternativa : Form
    {
        public frmEliminarAlternativa(int simulacionID)
        {
            InitializeComponent();
            ConexionDB DB = new ConexionDB();
            DataTable dtAlternativas = DB.ObtenerAlternativas(simulacionID);
            
            DataView dvFiltrado = new DataView(dtAlternativas);
            dvFiltrado.RowFilter = "Nombre <> 'Escenario Base'";

            // Configurar ComboBox Escenarios
            cmbAlternativas.DataSource = dvFiltrado;
            cmbAlternativas.ValueMember = "AlternativaID";
            cmbAlternativas.DisplayMember = "Nombre";
        }

        private void frmEliminarAlternativa_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionDB db = new ConexionDB();

            if (cmbAlternativas.Items.Count > 0 && cmbAlternativas.SelectedIndex != -1)
            {
                string mensaje = "¿Estás seguro de que deseas eliminar esta alternativa?";
                string titulo = "Confirmar eliminación";

                // Mostramos el MessageBox con botones de Sí/No y un ícono de advertencia
                DialogResult resultado = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    db.EliminarAlternativa(Convert.ToInt32(cmbAlternativas.SelectedValue));
                    MessageBox.Show("Registro eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Console.WriteLine("Eliminación cancelada.");
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
