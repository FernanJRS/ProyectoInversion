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
    public partial class frmNuevoProyecto : Form
    {
        public frmNuevoProyecto()
        {
            InitializeComponent();
            CargarValoresPorDefecto();
            txtBoxTasaDescuento_Leave(txtBoxTasaDescuento, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxTasaImpuesto, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxIncrAnio2, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxIncrAnio3, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxIncrPrecio, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxIncrCostoVar, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxIncrCostoFijo, EventArgs.Empty);
            txtBoxTasaDescuento_Leave(txtBoxValorResidualActivosDepreciados, EventArgs.Empty);
        }

        private void CargarValoresPorDefecto()
        {
            // Simulación
            txtBoxNombreSim.Text = "Proyecto Evaluación Riesgo e Incertidumbre";
            txtBoxDescripcion.Text = "Modelo de Hertz";
            txtBoxTasaDescuento.Text = "20";     // en %
            txtBoxTasaImpuesto.Text = "30";     // en %
            txtBoxPlazo.Text = "10";
            txtBoxVentas.Text = "10000";
            txtBoxIncrAnio2.Text = "20";
            txtBoxIncrAnio3.Text = "30";
            txtBoxIncrPrecio.Text = "10";
            txtBoxAnioIncrPrecio.Text = "3";
            txtBoxLimiteCostoVar.Text = "15000";
            txtBoxIncrCostoVar.Text = "20";
            txtBoxIncrCostoFijo.Text = "10";
            txtBoxAnioIncrCostoFijo.Text = "3";
            txtBoxMesesCT.Text = "4";

            // Alternativa Base
            txtBoxNombreBase.Text = "Escenario Base";
            txtBoxPrecioBase.Text = "25";
            txtBoxDemandaBase.Text = "10000";
            txtBoxCostoVarBase.Text = "10";
            txtBoxCostoFijoBase.Text = "30000";
            txtBoxConstruccion.Text = "400000";
            txtBoxVidaContConst.Text = "40";
            txtBoxVidaUtilConst.Text = "40";
            txtBoxMaquinaA.Text = "140000";
            txtBoxVidaUtilMaqA.Text = "4";
            txtBoxVidaContMaqA.Text = "10";
            txtBoxRecompra1MaqA.Text = "4";
            txtBoxRecompra2MaqA.Text = "8";
            txtBoxMaquinaB.Text = "160000";
            txtBoxVidaUtilMaqB.Text = "6";
            txtBoxVidaContMaqB.Text = "5";
            txtBoxRecompraMaqB.Text = "6";
            txtBoxTerreno.Text = "80000";
            txtBoxValorResidualActivosDepreciados.Text = "10";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!TryGetValores(out var datos)) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                var db = new ConexionDB();

                // 1. Crear simulación
                int simID = db.CrearSimulacion(
                    nombre: datos.NombreSim,
                    descripcion: datos.Descripcion,
                    tasaDescuento: datos.TasaDescuento,
                    tasaImpuesto: datos.TasaImpuesto,
                    horizonteAnios: datos.Horizonte,
                    ventasAnio1: datos.VentasAnio1,
                    incrAnio2: datos.IncrAnio2,
                    incrAnio3: datos.IncrAnio3,
                    precioBase: datos.PrecioBase,
                    incrPrecio: datos.IncrPrecio,
                    anioIncrPrecio: datos.AnioIncrPrecio,
                    costoVarBase: datos.CostoVarBase,
                    limiteCostoVar: datos.LimiteCostoVar,
                    incrCostoVarExtra: datos.IncrCostoVarExtra,
                    costoFijoBase: datos.CostoFijoBase,
                    incrCostoFijo: datos.IncrCostoFijo,
                    anioIncrCostoFijo: datos.AnioIncrCostoFijo,
                    mesesCapitalTrabajo: datos.MesesCT
                );

                if (simID < 0) return;

                // 2. Guardar alternativa base
                int altBaseID = db.GuardarAlternativaBase(
                    simulacionID: simID,
                    nombre: datos.NombreBase,
                    tasaDescuento: datos.TasaDescuento,
                    ventasAnio1: datos.VentasAnio1,
                    precioBase: datos.PrecioBase,
                    costoVarBase: datos.CostoVarBase,
                    costoFijoBase: datos.CostoFijoBase,
                    terreno: datos.Terreno,
                    construccion: datos.Construccion,
                    depConst: datos.VidaContConstruccion,
                    vidaUtilConst: datos.VidaUtilConstruccion,
                    maquinaA: datos.MaquinaA,
                    vidaUtilMaqA: datos.VidaUtilMaqA,
                    vidaContableMaqA: datos.VidaContMaqA,
                    recompra1MaqA: datos.Recompra1MaqA,
                    recompra2MaqA: datos.Recompra2MaqA,
                    maquinaB: datos.MaquinaB,
                    vidaUtilMaqB: datos.VidaUtilMaqB,
                    vidaContableMaqB: datos.VidaContMaqB,
                    recompraMaqB: datos.RecompraMaqB,
                    tasaImpuestoActivos: datos.ValorResidualActDep
                );

                if (altBaseID < 0) return;

                // 3. Guardar en sesión global
                //SesionProyecto.IniciarSesion(simID, altBaseID);

                MessageBox.Show(
                    $"Proyecto creado exitosamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { Cursor = Cursors.Default; }
        }

        private bool TryGetValores(out DatosNuevoProyecto datos)
        {
            datos = null;
            try
            {
                datos = new DatosNuevoProyecto
                {
                    NombreSim = txtBoxNombreSim.Text.Trim(),
                    Descripcion = txtBoxDescripcion.Text.Trim(),
                    TasaDescuento = double.Parse(txtBoxTasaDescuento.Text.Replace("%", "").Trim()) / 100.0,
                    TasaImpuesto = double.Parse(txtBoxTasaImpuesto.Text.Replace("%", "").Trim()) / 100.0,
                    Horizonte = int.Parse(txtBoxPlazo.Text),
                    VentasAnio1 = double.Parse(txtBoxVentas.Text),
                    IncrAnio2 = double.Parse(txtBoxIncrAnio2.Text.Replace("%","").Trim()) / 100.0,
                    IncrAnio3 = double.Parse(txtBoxIncrAnio3.Text.Replace("%", "").Trim()) / 100.0,
                    PrecioBase = double.Parse(txtBoxPrecioBase.Text),
                    IncrPrecio = double.Parse(txtBoxIncrPrecio.Text.Replace("%", "").Trim()) / 100.0,
                    AnioIncrPrecio = int.Parse(txtBoxAnioIncrPrecio.Text),
                    CostoVarBase = double.Parse(txtBoxCostoVarBase.Text),
                    LimiteCostoVar = double.Parse(txtBoxLimiteCostoVar.Text),
                    IncrCostoVarExtra = double.Parse(txtBoxIncrCostoVar.Text.Replace("%", "").Trim()) / 100.0,
                    CostoFijoBase = double.Parse(txtBoxCostoFijoBase.Text),
                    IncrCostoFijo = double.Parse(txtBoxIncrCostoFijo.Text.Replace("%", "").Trim()) / 100.0,
                    AnioIncrCostoFijo = int.Parse(txtBoxAnioIncrCostoFijo.Text),
                    MesesCT = int.Parse(txtBoxMesesCT.Text),
                    // Alternativa Base
                    NombreBase = txtBoxNombreBase.Text.Trim(),
                    DemandaBase = double.Parse(txtBoxDemandaBase.Text),
                    Construccion = double.Parse(txtBoxConstruccion.Text),
                    VidaUtilConstruccion = int.Parse(txtBoxVidaUtilConst.Text),
                    VidaContConstruccion = int.Parse(txtBoxVidaContConst.Text),
                    MaquinaA = double.Parse(txtBoxMaquinaA.Text),
                    VidaUtilMaqA = int.Parse(txtBoxVidaUtilMaqA.Text),
                    VidaContMaqA = int.Parse(txtBoxVidaContMaqA.Text),
                    Recompra1MaqA = int.Parse(txtBoxRecompra1MaqA.Text),
                    Recompra2MaqA = int.Parse(txtBoxRecompra2MaqA.Text),
                    MaquinaB = double.Parse(txtBoxMaquinaB.Text),
                    VidaUtilMaqB = int.Parse(txtBoxVidaUtilMaqB.Text),
                    VidaContMaqB = int.Parse(txtBoxVidaContMaqB.Text),
                    RecompraMaqB = int.Parse(txtBoxRecompraMaqB.Text),
                    Terreno = double.Parse(txtBoxTerreno.Text),
                    ValorResidualActDep = double.Parse(txtBoxValorResidualActivosDepreciados.Text.Replace("%", "").Trim()) / 100.0
                };
                return true;
            }
            catch
            {
                MessageBox.Show("Todos los campos numéricos deben tener valores válidos.",
                    "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        internal class DatosNuevoProyecto
        {
            public string NombreSim, Descripcion, NombreBase;
            public double TasaDescuento, TasaImpuesto, VentasAnio1, IncrAnio2, IncrAnio3;
            public double PrecioBase, IncrPrecio, CostoVarBase, LimiteCostoVar, IncrCostoVarExtra;
            public double CostoFijoBase, IncrCostoFijo, DemandaBase;
            public double Construccion, MaquinaA, MaquinaB, Terreno, ValorResidualActDep;
            public int VidaUtilConstruccion, VidaContConstruccion, VidaUtilMaqA, VidaContMaqA;
            public int VidaUtilMaqB, VidaContMaqB, Recompra1MaqA, Recompra2MaqA, RecompraMaqB;
            public int Horizonte, AnioIncrPrecio, AnioIncrCostoFijo, MesesCT;
        }


        private void txtBoxTasaDescuento_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (double.TryParse(textBox.Text, out double valor))
            {
                textBox.Text = (valor / 100).ToString("P2");
            }
        }
    }
}
