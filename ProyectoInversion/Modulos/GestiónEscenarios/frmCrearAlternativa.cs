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
        private readonly int _simulacionID;
        private readonly int _altBaseID;
        private AlternativaModel _altActual;
        private readonly string _panelOrigen;

        //public event EventHandler<int> AlternativaGuardada;

        public frmCrearAlternativa(int simulacionID, int altBaseID, int alternativaID, string panelOrigen)
        {
            InitializeComponent();
            _simulacionID = simulacionID;
            _altBaseID = altBaseID;
            _panelOrigen = panelOrigen;

            CargarDesdeAlternativa(alternativaID);
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
            ConexionDB db = new ConexionDB();
            if (!TryGetValores(out var nombre, out var precio, out var interes, out var demanda, out var cv,
                out var constr, out var maqA, out var maqB, out var cf, out var terreno))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                var ds = db.PrevisualizarAlternativa(
                    _simulacionID, nombre, interes, precio, demanda, cv, constr, maqA, maqB, cf, terreno);

                if (ds.Tables.Count >= 2 && ds.Tables[1].Rows.Count > 0)
                {
                        MostrarIndicadoresEnVentanaPadre(ds.Tables[1]);
                }
                else
                {
                    MessageBox.Show("No se recibieron datos del servidor.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al previsualizar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }

            //this.Close();
        }

        private void MostrarIndicadoresEnVentanaPadre(DataTable dtIndicadores)
        {
            if (this.Owner is frmCompararEscenarios ventanaPadre && dtIndicadores.Rows.Count > 0)
                ventanaPadre.ActualizarPreview(dtIndicadores.Rows[0], _panelOrigen);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!TryGetValores(out var nombre, out var precio, out var interes, out var demanda,
            out var cv, out var constr, out var maqA, out var maqB, out var cf, out var terreno))
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                ConexionDB conexion = new ConexionDB();
                DataSet resultado = conexion.GuardarNuevaAlternativa(
                    _simulacionID, nombre, interes, precio, demanda, cv, constr, maqA, maqB, cf, terreno);

                if (resultado != null)
                {
                    var ds = resultado.Tables[2];
                    MostrarIndicadoresEnVentanaPadre(ds);
                    MessageBox.Show("Alternativa guardada correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Esto dispara el refresh en frmCompararEscenarios
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }

            this.Close();

        }

        private bool TryGetValores(out String nombre, out double precio, out double interes, out double demanda,
            out double cv, out double construccion, out double maqA,
            out double maqB, out double cf, out double terreno)
        {
            nombre = "";
            precio = interes = demanda = cv = construccion = maqA = maqB = cf = terreno = 0;
            try
            {
                nombre = txtBoxNombre.Text.Trim();
                precio = double.Parse(txtBoxPrecio.Text.Trim());
                interes = double.Parse(txtBoxInteres.Text.Trim());
                demanda = double.Parse(txtBoxDemanda.Text.Trim());
                cv = double.Parse(txtBoxCostoVariable.Text.Trim());
                construccion = double.Parse(txtBoxConstruccion.Text.Trim());
                maqA = double.Parse(txtBoxMaquinaA.Text.Trim());
                maqB = double.Parse(txtBoxMaquinaB.Text.Trim());
                cf = double.Parse(txtBoxCostoFijo.Text.Trim());
                terreno = double.Parse(txtBoxTerreno.Text.Trim());
                return true;
            }
            catch
            {
                MessageBox.Show(
                    "Todos los campos deben ser valores numéricos. A excepción del nombre.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void CargarDesdeAlternativa(int alternativaID)
        {
            ConexionDB db = new ConexionDB();
            _altActual = db.ObtenerAlternativa(_simulacionID, alternativaID);

            if (_altActual == null) return;

            // Precargar todos los campos del formulario
            txtBoxNombre.Text = _altActual.Nombre;
            txtBoxInteres.Text = _altActual.TasaDescuento.ToString("F2");
            txtBoxPrecio.Text = _altActual.PrecioBase.ToString("F2");
            txtBoxDemanda.Text = _altActual.VentasAnio1.ToString("F0");
            txtBoxCostoVariable.Text = _altActual.CostoVarBase.ToString("F2");
            txtBoxConstruccion.Text = _altActual.Construccion.ToString("F2");
            txtBoxMaquinaA.Text = _altActual.MaquinaA.ToString("F2");
            txtBoxMaquinaB.Text = _altActual.MaquinaB.ToString("F2");
            txtBoxCostoFijo.Text = _altActual.CostoFijoBase.ToString("F2");
            txtBoxTerreno.Text = _altActual.Terreno.ToString("F2");
        }
    }
}
