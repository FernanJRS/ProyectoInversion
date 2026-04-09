using ProyectoInversion.Clases;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInversion.Modulos.GestiónEscenarios
{
    public partial class frmCompararEscenarios : Form
    {
        // Variables para ScottPlot
        double vanBase = 0, vanA = 0, vanB = 0, tirBase = 0, tirA = 0, tirB = 0, irBase = 0, irA = 0, irB = 0;
        String metrica = "VAN";
        public frmCompararEscenarios(int simulacionID)
        {
            InitializeComponent();

            ConexionDB DB = new ConexionDB();
            DataTable dtAlternativas = DB.ObtenerAlternativas(simulacionID);

            // Configurar ComboBox Escenario Base (Solo lectura)
            cmbEscenarioBase.DataSource = dtAlternativas.Copy();
            cmbEscenarioBase.ValueMember = "AlternativaID";
            cmbEscenarioBase.DisplayMember = "Nombre";
            cmbEscenarioBase.SelectedIndex = 0;

            cmbEscenarioBase.Enabled = false;

            DataView dvFiltrado = new DataView(dtAlternativas);
            dvFiltrado.RowFilter = "TipoAlternativa <> 'Base'";

            if (dvFiltrado.Table.Rows.Count > 0)
            {
                // Configurar ComboBox Escenario A
                cmbAlternativaA.DataSource = dvFiltrado;
                cmbAlternativaA.ValueMember = "AlternativaID";
                cmbAlternativaA.DisplayMember = "Nombre";

                DataView dvFiltrado2 = new DataView(dtAlternativas);
                dvFiltrado2.RowFilter = "TipoAlternativa <> 'Base'";

                // Configurar ComboBox Escenario B
                cmbAlternativaB.DataSource = dvFiltrado2;
                cmbAlternativaB.ValueMember = "AlternativaID";
                cmbAlternativaB.DisplayMember = "Nombre";

                // Una vez cargados, disparar la primera comparativa
                //this.Shown += frmCompararEscenarios_Shown;
            }
                CargarDatosComparativa();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            pnlAltBase.BackColor = ColorTranslator.FromHtml("#3BA5D9");
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            pnlAltBase.BackColor = ColorTranslator.FromHtml("#2C7A9E");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            pnlAltA.BackColor = ColorTranslator.FromHtml("#3BA5D9");
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            pnlAltA.BackColor = ColorTranslator.FromHtml("#2C7A9E");
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            pnlAltB.BackColor = ColorTranslator.FromHtml("#3BA5D9");
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            pnlAltB.BackColor = ColorTranslator.FromHtml("#2C7A9E");
        }

        private void rbIndicador_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                // Guardamos cuál es la métrica seleccionada basándonos en el Tag o Name
                metrica = rb.Text; // "VAN", "TIR" o "IR"
                DeterminarMetricaYGraficar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatosComparativa();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            int alternativaID = Convert.ToInt32(cmbAlternativaA.SelectedValue);
            AbrirCrearAlternativa(alternativaID, "A");
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            int alternativaID = Convert.ToInt32(cmbAlternativaB.SelectedValue);
            AbrirCrearAlternativa(alternativaID, "B");
        }

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern int GetSystemMenu(IntPtr hWnd, bool bRevert);
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern bool DeleteMenu(int hMenu, int nPosition, int wFlags);

        //private const int SC_CLOSE = 0xF060;
        //private const int MF_BYCOMMAND = 0x0000;
        private void frmCompararEscenarios_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Esto deshabilita el botón X físicamente
            //int menu = GetSystemMenu(this.Handle, false);
            //DeleteMenu(menu, SC_CLOSE, MF_BYCOMMAND);
        }

        private void frmCompararEscenarios_Shown(object sender, EventArgs e)
        {   
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ConexionDB db = new ConexionDB();
            int simulacionID = db.ObtenerSimulacionID(Convert.ToInt32(cmbEscenarioBase.SelectedValue));
            using (frmEliminarAlternativa frm = new frmEliminarAlternativa(simulacionID))
            {
                frm.Owner = this;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    int idxA = cmbAlternativaA.SelectedIndex;
                    int idxB = cmbAlternativaB.SelectedIndex;

                    DataTable dtNuevas = db.ObtenerAlternativas(simulacionID);

                    cmbEscenarioBase.DataSource = dtNuevas.Copy();

                    DataView dvA = new DataView(dtNuevas);
                    dvA.RowFilter = "Nombre <> 'Escenario Base'";
                    cmbAlternativaA.DataSource = dvA;

                    DataView dvB = new DataView(dtNuevas);
                    dvB.RowFilter = "Nombre <> 'Escenario Base'";
                    cmbAlternativaB.DataSource = dvB;

                    cmbAlternativaA.SelectedIndex = (idxA < cmbAlternativaA.Items.Count) ? idxA : 0;
                    cmbAlternativaB.SelectedIndex = (idxB < cmbAlternativaB.Items.Count) ? idxB : 0;

                    CargarDatosComparativa();
                }
            }
        }

        private void cmbEscenarioBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmCompararEscenarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form menuPrincipal = Application.OpenForms["frmMenu"];
            if (menuPrincipal != null) menuPrincipal.Show();
        }

        private void CargarDatosComparativa()
        {

            // Extraer los IDs (ValueMember) para SQL y los Nombres (DisplayMember) para la UI
            int idBase = Convert.ToInt32(cmbEscenarioBase.SelectedValue);

            // Cargar detalles de la alternativas
            ConexionDB db = new ConexionDB();
            int simulacionID = db.ObtenerSimulacionID(idBase);
            DataTable dtBase = db.ObtenerDetalleAlternativa(simulacionID, idBase);

            if (dtBase.Rows.Count > 0)
            {
                DataRow row = dtBase.Rows[0];

                PoblarTarjetaDesdeIndicadores(pnlAltBase, row);
                //lbl1Panel1.Text = $"Tasa de Inversión: {Convert.ToDouble(row["TasaDescuento"]):P2}"; // P2 es formato porcentaje
                //lbl2Panel1.Text = $"VAN: {Convert.ToDouble(row["VAN"]):C2}"; // C2 es formato moneda
                //lbl3Panel1.Text = $"TIR: {Convert.ToDouble(row["TIR"]):P2}";
                //lbl4Panel1.Text = $"IR: {Convert.ToDouble(row["IR"]):N4}";
                //lbl5Panel1.Text = $"Inversión: {Convert.ToDouble(row["InversionInicial"]):C2}";
                vanBase = Convert.ToDouble(row["VAN"]);
                tirBase = Convert.ToDouble(row["TIR"]);
                irBase = Convert.ToDouble(row["IR"]);
            }

            // Validar que haya selecciones válidas para evitar errores de conversión
            if (cmbAlternativaA.SelectedValue == null || cmbAlternativaB.SelectedValue == null)
                return;
            
            int idA = Convert.ToInt32(cmbAlternativaA.SelectedValue);
            int idB = Convert.ToInt32(cmbAlternativaB.SelectedValue);
            
            DataTable dtA = db.ObtenerDetalleAlternativa(simulacionID,idA);

            if (dtA.Rows.Count > 0)
            {
                DataRow row = dtA.Rows[0];

                PoblarTarjetaDesdeIndicadores(pnlAltA, row);
                //lbl1Panel2.Text = $"Tasa de Inversión: {Convert.ToDouble(row["TasaDescuento"]):P2}";
                //lbl2Panel2.Text = $"VAN: {Convert.ToDouble(row["VAN"]):C2}";
                //lbl3Panel2.Text = $"TIR: {Convert.ToDouble(row["TIR"]):P2}";
                //lbl4Panel2.Text = $"IR: {Convert.ToDouble(row["IR"]):N4}";
                //lbl5Panel2.Text = $"Inversión: {Convert.ToDouble(row["InversionInicial"]):C2}";
                vanA = Convert.ToDouble(row["VAN"]);
                tirA = Convert.ToDouble(row["TIR"]);
                irA = Convert.ToDouble(row["IR"]);
            }

            DataTable dtB = db.ObtenerDetalleAlternativa(simulacionID, idB);

            if (dtB.Rows.Count > 0)
            {
                DataRow row = dtB.Rows[0];

                PoblarTarjetaDesdeIndicadores(pnlAltB, row);
                //lbl1Panel3.Text = $"Tasa de Inversión: {Convert.ToDouble(row["TasaDescuento"]):P2}";
                //lbl2Panel3.Text = $"VAN: {Convert.ToDouble(row["VAN"]):C2}";
                //lbl3Panel3.Text = $"TIR: {Convert.ToDouble(row["TIR"]):P2}";
                //lbl4Panel3.Text = $"IR: {Convert.ToDouble(row["IR"]):N4}";
                //lbl5Panel3.Text = $"Inversión: {Convert.ToDouble(row["InversionInicial"]):C2}";
                vanB = Convert.ToDouble(row["VAN"]);
                tirB = Convert.ToDouble(row["TIR"]);
                irB = Convert.ToDouble(row["IR"]);
            }

            // Graficar comparativa según la métrica seleccionada (VAN, TIR o IR)
            DeterminarMetricaYGraficar();
        }

        private void DeterminarMetricaYGraficar()
        {
            double vBase = 0, vA = 0, vB = 0;
            string formato = "C0"; // Formato moneda por defecto

            switch (metrica)
            {
                case "VAN":
                    vBase = vanBase; vA = vanA; vB = vanB;
                    formato = "C0";
                    break;
                case "TIR":
                    vBase = tirBase; vA = tirA; vB = tirB;
                    formato = "P2"; // Formato porcentaje
                    break;
                case "IR":
                    vBase = irBase; vA = irA; vB = irB;
                    formato = "N4"; // 4 decimales
                    break;
            }

            ActualizarGraficoComparativo(vBase, vA, vB, metrica, formato);
        }


        private void ActualizarGraficoComparativo(double vBase, double vA, double vB, String metrica, String formato)
        {
            GrafPlot.Plot.Clear();

            // Obtener nombres de forma segura
            // Usamos .Replace(" - ", "\n") para que "Escenario A - Pesimista" se convierta en dos líneas
            string nombreBase = ((DataRowView)cmbEscenarioBase.SelectedItem)["Nombre"].ToString().Replace(" ", "\n");
            string nombreA = ((DataRowView)cmbAlternativaA.SelectedItem)["Nombre"].ToString().Replace(" ", "\n");
            string nombreB = ((DataRowView)cmbAlternativaB.SelectedItem)["Nombre"].ToString().Replace(" ", "\n");

            var barBase = new Bar { Position = 0, Value = vBase, FillColor = Colors.Gray };
            var barA = new Bar { Position = 1, Value = vA, FillColor = Colors.RoyalBlue };
            var barB = new Bar { Position = 2, Value = vB, FillColor = Colors.Navy };

            List<Bar> misBarras = new List<Bar> { barBase, barA, barB };
            var barPlot = GrafPlot.Plot.Add.Bars(misBarras);

            // Configurar etiquetas de valor sobre las barras
            barPlot.ValueLabelStyle.IsVisible = true;
            barPlot.ValueLabelStyle.FontSize = 12;


            Tick[] ticks = new Tick[]
            {
                new Tick(0, nombreBase),
                new Tick(1, nombreA),
                new Tick(2, nombreB)
            };

            foreach (var bar in misBarras)
                bar.Label = bar.Value.ToString(formato);

            GrafPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // Ajustar el margen inferior para que el texto de dos líneas no se corte
            GrafPlot.Plot.Axes.Bottom.MinimumSize = 30;

            GrafPlot.Plot.Title($"Comparativa de {metrica} por Escenario");
            GrafPlot.Plot.Axes.Margins(bottom: 0, top: 0.2);
            GrafPlot.Refresh();
        }

        private void AbrirCrearAlternativa(int alternativaID, string panelOrigen)
        {
            using (frmCrearAlternativa fCrear = new frmCrearAlternativa(1, 1, alternativaID, panelOrigen))
            {
                fCrear.Owner = this;
                if (fCrear.ShowDialog() == DialogResult.OK)
                {
                    int idxA = cmbAlternativaA.SelectedIndex;
                    int idxB = cmbAlternativaB.SelectedIndex;

                    ConexionDB db = new ConexionDB();
                    int simulacionID = db.ObtenerSimulacionID(Convert.ToInt32(cmbEscenarioBase.SelectedValue));
                    DataTable dtNuevas = db.ObtenerAlternativas(simulacionID);

                    cmbEscenarioBase.DataSource = dtNuevas.Copy();

                    DataView dvA = new DataView(dtNuevas);
                    dvA.RowFilter = "Nombre <> 'Escenario Base'";
                    cmbAlternativaA.DataSource = dvA;

                    DataView dvB = new DataView(dtNuevas);
                    dvB.RowFilter = "Nombre <> 'Escenario Base'";
                    cmbAlternativaB.DataSource = dvB;

                    if (panelOrigen == "A")
                    {
                        cmbAlternativaB.SelectedIndex = (idxB < cmbAlternativaB.Items.Count) ? idxB : 0;
                        cmbAlternativaA.SelectedIndex = cmbAlternativaA.Items.Count - 1;
                    }
                    if (panelOrigen == "B")
                    {
                        cmbAlternativaA.SelectedIndex = (idxA < cmbAlternativaA.Items.Count) ? idxA : 0;
                        cmbAlternativaB.SelectedIndex = cmbAlternativaB.Items.Count - 1;
                    }

                    CargarDatosComparativa();
                }
            }
        }

        public void ActualizarPreview(DataRow rowIndicadores, string panelOrigen)
        {
            Panel panelDestino;

            switch (panelOrigen)
            {
                case "A":
                    panelDestino = pnlAltA;
                    vanA = rowIndicadores["VAN"] == DBNull.Value ? 0 : Convert.ToDouble(rowIndicadores["VAN"]);
                    tirA = rowIndicadores["TIR"] == DBNull.Value ? 0 : Convert.ToDouble(rowIndicadores["TIR"]);
                    irA = rowIndicadores["IR"] == DBNull.Value ? 0 : Convert.ToDouble(rowIndicadores["IR"]);
                    break;
                case "B":
                    panelDestino = pnlAltB;
                    vanB = rowIndicadores["VAN"] == DBNull.Value ? 0 : Convert.ToDouble(rowIndicadores["VAN"]);
                    tirB = rowIndicadores["TIR"] == DBNull.Value ? 0 : Convert.ToDouble(rowIndicadores["TIR"]);
                    irB = rowIndicadores["IR"] == DBNull.Value ? 0 : Convert.ToDouble(rowIndicadores["IR"]);
                    break;
                default:
                    return;
            }

            PoblarTarjetaDesdeIndicadores(panelDestino, rowIndicadores);
            DeterminarMetricaYGraficar(); // actualizar gráfico también
        }

        private void SetLabel(Panel pnl, string tag, string text)
        {
            // Mapeo de tag semántico → índice de label (lbl{N}Panel{X})
            Dictionary<string, int> tagAIndice = new Dictionary<string, int>
            {
                { "TasaInversion", 1 },
                { "VAN",           2 },
                { "TIR",           3 },
                { "IR",            4 },
                { "InversionTotal",5 }
            };

            if (!tagAIndice.TryGetValue(tag, out int indice)) return;

            // Detectar el número del panel según el objeto recibido
            string numPanel = "";
            if (pnl == pnlAltBase) numPanel = "1";
            else if (pnl == pnlAltA) numPanel = "2";
            else if (pnl == pnlAltB) numPanel = "3";
            else return;

            string nombreLabel = $"lbl{indice}Panel{numPanel}";

            Control encontrado = pnl.Controls.Find(nombreLabel, true).FirstOrDefault();
            if (encontrado is System.Windows.Forms.Label lbl)
                lbl.Text = text;
        }

        // Búsqueda recursiva por si hay controles anidados
        private IEnumerable<Control> ObtenerTodosControles(Control padre)
        {
            foreach (Control c in padre.Controls)
            {
                yield return c;
                foreach (Control hijo in ObtenerTodosControles(c))
                    yield return hijo;
            }
        }

        private void PoblarTarjetaDesdeIndicadores(Panel pnl, DataRow r)
        {
            string Fmt(string col, string fmt = "N2") =>
                r[col] == DBNull.Value ? "—" : Convert.ToDecimal(r[col]).ToString(fmt);

            SetLabel(pnl, "TasaInversion", $"Tasa de Inversión: {Fmt("TasaInteres", "P2")}");
            SetLabel(pnl, "VAN", $"VAN: {Fmt("VAN", "N2")}");
            SetLabel(pnl, "TIR", $"TIR: {Fmt("TIR", "P2")}%");
            SetLabel(pnl, "IR", $"IR: {Fmt("IR", "N6")}");
            SetLabel(pnl, "InversionTotal", $"Inversion: ${Fmt("InversionInicial")}");
        }

    }
}
