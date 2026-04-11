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
    public partial class frmRiesgoComparación : Form
    {
        public int simulacionID { get; set; }
        public string nombreSimulacion { get; set; }
        public int[] alternativasIDs { get; set; }
        public double[] probabilidades { get; set; }
        public string conclusionRiesgo { get; set; }

        public frmRiesgoComparación(int simulacionID, string nombreSimulacion, int[] alternativasIDs, double[] probabilidades)
        {
            InitializeComponent();

            this.simulacionID = simulacionID;
            this.nombreSimulacion = nombreSimulacion;
            this.alternativasIDs = alternativasIDs;
            this.probabilidades = probabilidades;
        }

        private void frmRiesgoComparación_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Form menuPrincipal = Application.OpenForms["frmMenu"];
            if (menuPrincipal != null) menuPrincipal.Show();

            CargarTodo();
        }

        private void CargarTodo()
        {
            ConexionDB db = new ConexionDB();

            CargarTablaActivos(db);

            CargarRiesgo(db);

            CargarComparacion(db);

        }

        private void CargarTablaActivos(ConexionDB db)
        {
            try
            {
                DataTable dt = db.ObtenerActivos(simulacionID, alternativasIDs[0], alternativasIDs[1], alternativasIDs[2]);

                if (dt == null || dt.Rows.Count == 0) return;

                // Nombre de las alternativas en la primera fila
                string nombreBase = dt.Rows[0]["NombreBase"].ToString();
                string nombreAltA = dt.Rows[0]["NombreA"].ToString();
                string nombreAltB = dt.Rows[0]["NombreB"].ToString();

                // Quitar columnas adicionales
                dt.Columns.Remove("Orden");
                dt.Columns.Remove("NombreBase");
                dt.Columns.Remove("NombreA");
                dt.Columns.Remove("NombreB");

                // Renombrar columnas restantes
                dt.Columns["Variable"].ColumnName = "Variables";
                dt.Columns["ValorCasoBase"].ColumnName = nombreBase;
                dt.Columns["ValorA"].ColumnName = nombreAltA;
                dt.Columns["ValorB"].ColumnName = nombreAltB;

                dgvActivos.DataSource = dt;
                EstilizarGrid(dgvActivos, "Cambio de Ingreso");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los activos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // Calcular Riesgo
        private void CargarRiesgo(ConexionDB db)
        {
            try
            {
                DataSet ds = db.CalcularRiesgo(simulacionID, alternativasIDs, probabilidades);

                if (ds == null || ds.Tables.Count < 2) return;

                // RS1: resumen por método (Histórico / Probabilístico)
                dgvRiesgoResumen.DataSource = ds.Tables[0];
                EstilizarGrid(dgvRiesgoResumen, "Resumen de Riesgo");

                // RS2: detalle por alternativa
                ds.Tables[1].Columns.Remove("AlternativaID");
                dgvRiesgoDetalle.DataSource = ds.Tables[1];
                EstilizarGrid(dgvRiesgoDetalle, "Detalle por Alternativa");

                DataView dgvFiltradoIR = new DataView(ds.Tables[0]);
                dgvFiltradoIR.RowFilter = "MetricaBase = 'IR'";

                DataView dgvFiltradoVAN = new DataView(ds.Tables[0]);
                dgvFiltradoVAN.RowFilter = "MetricaBase = 'VAN'";

                conclusionRiesgo += $"En base a los resultados de las alternativas obtenemos un σ = {dgvFiltradoIR[0]["Sigma"]}\n";
                conclusionRiesgo += $"Lo que significa que existe un 67.5% de probabilidad de que la tasa interna de retorno para otro escenario se encuentre entre {dgvFiltradoIR[0]["IC68_Inferior"]} y {dgvFiltradoIR[0]["IC68_Superior"].ToString()}\n";
                conclusionRiesgo += $"Un 95% de probabilidad de que se encuentre entre {dgvFiltradoIR[0]["IC95_Inferior"]} y {dgvFiltradoIR[0]["IC95_Superior"]}\n";
                conclusionRiesgo += $"Y un 99% de probabilidad de que se encuentre entre {dgvFiltradoIR[0]["IC99_Inferior"]} y {dgvFiltradoIR[0]["IC99_Superior"]}\n";
                conclusionRiesgo += "\n";
                conclusionRiesgo += $"En cuanto al VAN, obtenemos un σ = {dgvFiltradoVAN[0]["SigmaFormateado"]}\n";
                conclusionRiesgo += $"Lo cual es que existe un 67.5% de probabilidad de que se encuentre entre {Convert.ToInt32(dgvFiltradoVAN[0]["IC68_Inferior"]).ToString("C2")} y {Convert.ToInt32(dgvFiltradoVAN[0]["IC68_Superior"]).ToString("C2")}\n";
                conclusionRiesgo += $"Un 95% de probabilidad de que se encuentre entre {Convert.ToInt32(dgvFiltradoVAN[0]["IC95_Inferior"]).ToString("C2")} y {Convert.ToInt32(dgvFiltradoVAN[0]["IC95_Superior"]).ToString("C2")}\n";
                conclusionRiesgo += $"Y un 99% de probabilidad de que se encuentre entre {Convert.ToInt32(dgvFiltradoVAN[0]["IC99_Inferior"]).ToString("C2")} y {Convert.ToInt32(dgvFiltradoVAN[0]["IC99_Superior"]).ToString("C2")}\n";

                lblConclusion.Text = conclusionRiesgo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al mostrar el riesgo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CargarComparacion(ConexionDB db)
        {
            try
            {
                DataSet ds = db.CompararAlternativas(simulacionID, alternativasIDs);

                if (ds == null || ds.Tables.Count < 1) return;

                // Pivotear en memoria: filas = indicadores, columnas = alternativas
                DataTable raw = ds.Tables[0];
                DataTable pivote = PivotarComparacion(raw);

                dgvComparacion.DataSource = pivote;
                EstilizarGrid(dgvComparacion, "Comparación de Indicadores");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al mostrar la comparación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private DataTable PivotarComparacion(DataTable raw)
        {
            DataTable pivote = new DataTable();
            pivote.Columns.Add("Indicador", typeof(string));

            // Agregar una columna por cada alternativa única
            foreach (DataRow r in raw.Rows)
            {
                string alt = r["NombreAlternativa"].ToString();
                if (!pivote.Columns.Contains(alt))
                    pivote.Columns.Add(alt, typeof(string));
            }

            // Llenar filas agrupadas por indicador
            var indicadores = new System.Collections.Generic.List<string>();
            foreach (DataRow r in raw.Rows)
            {
                string ind = r["Indicador"].ToString();
                if (!indicadores.Contains(ind)) indicadores.Add(ind);
            }

            foreach (string ind in indicadores)
            {
                DataRow fila = pivote.NewRow();
                fila["Indicador"] = ind;
                foreach (DataRow r in raw.Rows)
                {
                    if (r["Indicador"].ToString() == ind)
                    {
                        string alt = r["NombreAlternativa"].ToString();
                        if (pivote.Columns.Contains(alt))
                            fila[alt] = r["Valor"];
                    }
                }
                pivote.Rows.Add(fila);
            }
            return pivote;
        }

        private void EstilizarGrid(DataGridView dgv, string titulo)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(13, 71, 161);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.BorderStyle = BorderStyle.FixedSingle;
        }

        private void frmRiesgoComparación_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form menuPrincipal = Application.OpenForms["frmMenu"];
            if (menuPrincipal != null) menuPrincipal.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            frmFormula frm = new frmFormula("IR");
            frm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            frmFormula frm = new frmFormula("VAN");
            frm.Show();
        }
    }
}
