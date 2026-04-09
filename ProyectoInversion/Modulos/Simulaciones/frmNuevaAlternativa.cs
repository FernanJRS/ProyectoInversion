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

namespace ProyectoInversion.Modulos.Simulaciones
{
    public partial class frmNuevaAlternativa : Form
    {
        private readonly int _simulacionID;
        private readonly int _altBaseID;
        private AlternativaModel _base;

        // Evento que el formulario padre puede escuchar
        public event EventHandler<int> AlternativaGuardada;
        public frmNuevaAlternativa(int simulacionID, int altBaseID)
        {
            InitializeComponent();
            _simulacionID = simulacionID;
            _altBaseID = altBaseID;
            CargarAlternativaBase();
            txtBoxVidaRes_Leave(txtBoxTasaInteres, EventArgs.Empty);
            txtBoxVidaRes_Leave(txtBoxValorRes, EventArgs.Empty);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetSystemMenu(IntPtr hWnd, bool bRevert);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DeleteMenu(int hMenu, int nPosition, int wFlags);

        private const int SC_CLOSE = 0xF060;
        private const int MF_BYCOMMAND = 0x0000;
        private void frmCrearAlternativa_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Esto deshabilita el botón X físicamente
            int menu = GetSystemMenu(this.Handle, false);
            DeleteMenu(menu, SC_CLOSE, MF_BYCOMMAND);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!TryGetValores(out var v)) return;
            try
            {
                Cursor = Cursors.WaitCursor;
                ConexionDB db = new ConexionDB();

                var ds = db.GuardarAlternativaDerivada(_simulacionID, _altBaseID, v.Nombre, 
                    v.TipoAlternativa, v.Precio, v.TasaInteres, 
                    v.Demanda, v.CostoVariable, v.Construccion, v.MaquinaA, v.MaquinaB, 
                    v.CostoFijo, v.Terreno, (int)v.DepConst, (int)v.DepMaqA, 
                    (int)v.DepMaqB, (int)v.VidaUtilConst, (int)v.VidaUtilMaqA, 
                    (int)v.VidaUtilMaqB, v.Recompra1MaqA, v.Recompra2MaqA, 
                    v.RecompraMaqB, v.ValorResidual);

                if (ds != null && ds.Tables.Count > 0)
                {
                    MessageBox.Show("Alternativa guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }
        private void txtBoxVidaRes_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (double.TryParse(textBox.Text, out double valor))
            {
                textBox.Text = (valor / 100).ToString("P2");
            }
        }

        private void CargarAlternativaBase()
        {
            ConexionDB db = new ConexionDB();
            _base = db.ObtenerAlternativa(_simulacionID, _altBaseID);
            if (_base == null)
            {
                MessageBox.Show("No se pudo cargar la alternativa base.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Cargar valores base en los label
            lblNombreBase.Text = "Nombre: "+_base.Nombre;
            lblDemandaBase.Text = "Demanda: "+ _base.VentasAnio1.ToString();
            lblPrecioBase.Text = "Precio: "+ _base.PrecioBase.ToString("C2");
            lblTasaInteresBase.Text = "Tasa Interés: "+ _base.TasaDescuento.ToString("P2");
            lblTerrenoBase.Text = "Terreno: "+ _base.Terreno.ToString("C2");
            lblConstBase.Text = "Construcción: "+ _base.Construccion.ToString("C2");
            lblMaqABase.Text = "Máquina A: "+ _base.MaquinaA.ToString("C2");
            lblMabBBase.Text = "Máquina B: "+ _base.MaquinaB.ToString("C2");
            lblCostVarBase.Text = "Costo Variable: "+ _base.CostoVarBase.ToString("C2");
            lblCostoFijoBase.Text = "Costo Fijo: "+ _base.CostoFijoBase.ToString("C2");
            lblDepConstBase.Text = "Depreciación Construcción: "+ _base.DepConst.ToString() + " Años";
            lblVidaUtilConstBase.Text = "Vida Útil Construcción: "+ _base.VidUtilConst.ToString() + " Años";
            lblDepMaqABase.Text = "Depreciación Máquina A: "+ _base.DepMaqA.ToString() + " Años";
            lblVidaUtilMaqABase.Text = "Vida Útil Máquina A: "+ _base.VidUtilMaqA.ToString() + " Años";
            lblDepMaqBBase.Text = "Depreciación Máquina B: "+ _base.DepMaqB.ToString() + " Años";
            lblVidaUtilMaqBBase.Text = "Vida Útil Máquina B: "+ _base.VidUtilMaqB.ToString() + " Años";
            lblRecompraMaqBBase.Text = "Recompra Máquina B: " + _base.RecompraMaqB.ToString() + " Año";
            lblRecompra1MaqABase.Text = "Recompra Máquina A Año 1: " + _base.RecompraMaqA_2.ToString() + " Año";
            lblRecompra2MaqABase.Text = "Recompra Máquina A Año 2: "+ _base.RecompraMaqA_3.ToString() + " Año";
            lblValorResidualBase.Text = "Tasa Impuesto Activos: "+ _base.ValorResidual.ToString("P2");

            // Cargar valores base en los TextBox para referencia
            txtBoxPrecio.Text = _base.PrecioBase.ToString("C2");
            txtBoxDemanda.Text = _base.VentasAnio1.ToString();
            txtBoxTasaInteres.Text = _base.TasaDescuento.ToString("P2");
            txtBoxCostoFijo.Text = _base.CostoFijoBase.ToString("C2");
            txtBoxCostoVar.Text = _base.CostoVarBase.ToString("C2");
            txtBoxTerreno.Text = _base.Terreno.ToString("C2");
            txtBoxConst.Text = _base.Construccion.ToString("C2");
            txtBoxDepConst.Text = _base.DepConst.ToString();
            txtBoxVidaUtilConst.Text = _base.VidUtilConst.ToString();
            txtBoxMaqA.Text = _base.MaquinaA.ToString("C2");
            txtBoxVidaUtilMaqA.Text = _base.VidUtilMaqA.ToString();
            txtBoxDepMaqA.Text = _base.DepMaqA.ToString();
            txtBoxMaqB.Text = _base.MaquinaB.ToString("C2");
            txtBoxVidaUtilMaqB.Text = _base.VidUtilMaqB.ToString();
            txtBoxDepMaqB.Text = _base.DepMaqB.ToString();
            txtBoxRecompra1MaqA.Text = _base.RecompraMaqA_2.ToString();
            txtBoxRecompra2MaqA.Text = _base.RecompraMaqA_3.ToString();
            txtBoxRecompraMaqB.Text = _base.RecompraMaqB.ToString();
            txtBoxValorRes.Text = _base.ValorResidual.ToString("P2");
        }


        private bool TryGetValores(out ValoresForm v)
        {
            v = null;
            try
            {
                v = new ValoresForm
                {
                    Nombre = txtBoxNombre.Text.Trim(),
                    TipoAlternativa = cmbTipoAlternativa.SelectedItem?.ToString(),
                    TasaInteres = double.Parse(txtBoxTasaInteres.Text.Replace("%", "").Trim()) / 100.0,
                    Precio = double.Parse(txtBoxPrecio.Text.Replace("$", "").Trim()),
                    Demanda = double.Parse(txtBoxDemanda.Text.Trim()),
                    CostoVariable = double.Parse(txtBoxCostoVar.Text.Replace("$", "").Trim()),
                    CostoFijo = double.Parse(txtBoxCostoFijo.Text.Replace("$", "").Trim()),
                    Construccion = double.Parse(txtBoxConst.Text.Replace("$","").Trim()),
                    MaquinaA = double.Parse(txtBoxMaqA.Text.Replace("$","").Trim()),
                    MaquinaB = double.Parse(txtBoxMaqB.Text.Replace("$","").Trim()),
                    Terreno = double.Parse(txtBoxTerreno.Text.Replace("$","").Trim()),
                    DepConst = double.Parse(txtBoxDepConst.Text.Trim()),
                    VidaUtilConst = double.Parse(txtBoxVidaUtilConst.Text.Trim()),
                    DepMaqA = double.Parse(txtBoxDepMaqA.Text.Trim()),
                    VidaUtilMaqA = double.Parse(txtBoxVidaUtilMaqA.Text.Trim()),
                    DepMaqB = double.Parse(txtBoxDepMaqB.Text.Trim()),
                    VidaUtilMaqB = double.Parse(txtBoxVidaUtilMaqB.Text.Trim()),
                    RecompraMaqB = int.Parse(txtBoxRecompraMaqB.Text.Trim()),
                    Recompra1MaqA = int.Parse(txtBoxRecompra1MaqA.Text.Trim()),
                    Recompra2MaqA = int.Parse(txtBoxRecompra2MaqA.Text.Trim()),
                    ValorResidual = double.Parse(txtBoxValorRes.Text.Replace("%","").Trim()) / 100.0
                };

                if (string.IsNullOrEmpty(v.Nombre))
                    throw new Exception("El nombre de la alternativa no puede estar vacío.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos inválidos: " + ex.Message,
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private class ValoresForm
        {
            public string Nombre, TipoAlternativa;
            public double TasaInteres, Precio, Demanda;
            public double CostoVariable, CostoFijo, Construccion;
            public double MaquinaA, MaquinaB, Terreno;
            public double DepConst, VidaUtilConst, DepMaqA, VidaUtilMaqA, DepMaqB, VidaUtilMaqB;
            public int RecompraMaqB, Recompra1MaqA, Recompra2MaqA;
            public double ValorResidual;
        }

        private void frmNuevaAlternativa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form menuPrincipal = Application.OpenForms["frmMenu"];
            if (menuPrincipal != null) menuPrincipal.Show();
        }
    }
}
