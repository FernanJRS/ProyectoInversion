using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.WinForms;

namespace ProyectoInversion.Modulos.Base
{
    public partial class frmBase : Form
    {
        private FormsPlot formsPlot;
        //private List<FlujoCajaAnual> datosActuales;
        private ToolTip toolTip = new ToolTip();
        public frmBase(int simulacionID)
        {
            InitializeComponent();
            InicializarGrafico();
            this.Load += async (s, e) => await CargarDatosAsync();
        }
        private void InicializarGrafico()
        {
            formsPlot = new FormsPlot() { Dock = DockStyle.Fill };
            pnlChartWrapper.Controls.Add(formsPlot);
            LlenarComboAlternativas();
            
        }
        private async Task CargarDatosAsync()
        {
            try
            {
                if (cmbAlternativa.SelectedValue == null) return;
                int id = Convert.ToInt32(cmbAlternativa.SelectedValue);

                var indicadores = await Task.Run(() => DatabaseHelper.ObtenerIndicadoresPorID(id));
                var flujos = await Task.Run(() => DatabaseHelper.ObtenerFlujoCajaPorID(id));

                ActualizarUI(indicadores);
                RenderizarGrafico(flujos);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void ActualizarUI(IndicadoresBase ind)
        {
            lblVAN_Valor.Text = ind.VANFormateado;
            lblTIR_Valor.Text = ind.TIRFormateado;
            lblIR_Valor.Text = ind.IRFormateado;
            lblPR_Valor.Text = ind.PeriodoRecupFormateado;
            lblInv_Valor.Text = ind.InversionFormateada;
        }

        private void RenderizarGrafico(List<FlujoCajaAnual> flujos)
        {
            formsPlot.Plot.Clear();
            if (flujos == null || !flujos.Any()) return;

            ScottPlot.Color colorBarra = ScottPlot.Color.FromHex("#007bff");

            var barras = flujos.Select(f => new ScottPlot.Bar
            {
                Position = f.Anio,
                Value = (double)f.FlujoPeriodo,
                FillColor = colorBarra,
                Label = f.FlujoPeriodo >= 1000 || f.FlujoPeriodo <= -1000
                ? $"{(f.FlujoPeriodo / 1000):N0}K"
                : f.FlujoPeriodo.ToString("N0")
            }).ToList();

            var barPlot = formsPlot.Plot.Add.Bars(barras);

            barPlot.ValueLabelStyle.IsVisible = true;
            barPlot.ValueLabelStyle.FontSize = 11;
            barPlot.ValueLabelStyle.Bold = true;

            var ticks = new ScottPlot.TickGenerators.NumericManual();
            foreach (var f in flujos)
            {
                ticks.AddMajor(f.Anio, $"A{f.Anio}");
            }
            formsPlot.Plot.Axes.Bottom.TickGenerator = ticks;

            formsPlot.Refresh();
        }
        private void LlenarComboAlternativas()
        {
            var dt = DatabaseHelper.ObtenerAlternativas();
            cmbAlternativa.DataSource = dt;
            cmbAlternativa.DisplayMember = "Nombre";
            cmbAlternativa.ValueMember = "AlternativaID";
            cmbAlternativa.SelectedIndex = 0;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {
            Form menuPrincipal = Application.OpenForms["frmMenu"];
            if (menuPrincipal != null) menuPrincipal.Show();
        }
    }
}