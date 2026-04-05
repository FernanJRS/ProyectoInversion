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
    public partial class frmCrearAlternativa : Form
    {
        public frmCrearAlternativa()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();

            DataTable dt = conexion.PrevisualizarAlternativa(
                txtBoxNombre.Text,
                Convert.ToDouble(txtBoxInteres.Text),
                Convert.ToDouble(txtBoxPrecio.Text),
                Convert.ToDouble(txtBoxDemanda.Text),
                Convert.ToDouble(txtBoxCostoVariable.Text),
                Convert.ToDouble(txtBoxConstruccion.Text),
                Convert.ToDouble(txtBoxMaquinaA.Text),
                Convert.ToDouble(txtBoxMaquinaB.Text),
                Convert.ToDouble(txtBoxCostoFijo.Text),
                Convert.ToDouble(txtBoxTerreno.Text)
            );

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                string msj = $"Resultados Proyectados:\n\n" +
                             $"VAN: {Convert.ToDouble(r["VAN"]):C2}\n" +
                             $"TIR: {Convert.ToDouble(r["TIR_Pct"]):N2}%\n" +
                             $"Viabilidad: {r["Viabilidad"]}";

                MessageBox.Show(msj, "Previsualización de Escenario");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();

            bool resultado = conexion.GuardarNuevaAlternativa(
                txtBoxNombre.Text,
                Convert.ToDouble(txtBoxInteres.Text),
                Convert.ToDouble(txtBoxPrecio.Text),
                Convert.ToDouble(txtBoxDemanda.Text),
                Convert.ToDouble(txtBoxCostoVariable.Text),
                Convert.ToDouble(txtBoxConstruccion.Text),
                Convert.ToDouble(txtBoxMaquinaA.Text),
                Convert.ToDouble(txtBoxMaquinaB.Text),
                Convert.ToDouble(txtBoxCostoFijo.Text),
                Convert.ToDouble(txtBoxTerreno.Text)
            );

            if (resultado)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar la alternativa. Intente nuevamente.", "Error");
            }
        }

        private bool ValidarEntradas()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox txt)
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        MessageBox.Show($"El campo '{txt.Name.Replace("txt", "")}' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt.Focus();
                        return false;
                    }

                    if (txt != txtBoxNombre && !double.TryParse(txt.Text, out _))
                    {
                        MessageBox.Show($"El campo '{txt.Name.Replace("txt", "")}' debe ser válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
