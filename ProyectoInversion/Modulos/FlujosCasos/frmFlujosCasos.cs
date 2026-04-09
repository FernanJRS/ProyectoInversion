using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProyectoInversion.Clases;

namespace ProyectoInversion.Modulos.FlujosCasos
{
    public partial class frmFlujosCasos : Form
    {
        private readonly int _simulacionID;
        private readonly string _nombreSimulacion;
        public frmFlujosCasos(int simulacionID, string nombreSimulacion)
        {
            InitializeComponent();
            _simulacionID = simulacionID;
            _nombreSimulacion = nombreSimulacion;
        }
        private void frmFlujosCasos_Load(object sender, EventArgs e)
        {
            CargarConfiguracionInicial();

            Form menuPrincipal = Application.OpenForms["frmMenu"];
            if (menuPrincipal != null) menuPrincipal.Show();
        }

        private void CargarConfiguracionInicial()
        {
            try
            {
                LlenarCombo(cboBase, soloBase: true);      
                LlenarCombo(cboPesimista, soloBase: false); 
                LlenarCombo(cboOptimista, soloBase: false);
                ConfigurarDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar configuraciones:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarCombo(ComboBox cbo, bool soloBase)
        {
            string sql = soloBase
        ? @"SELECT AlternativaID, Nombre FROM proy.Alternativas
            WHERE TipoAlternativa = 'Base' ORDER BY AlternativaID"
        : @"SELECT AlternativaID, Nombre FROM proy.Alternativas
            WHERE TipoAlternativa <> 'Base' ORDER BY AlternativaID";

            try
            {
                var dt = EjecutarConsulta(sql, new SqlParameter("@simID", _simulacionID));

                cbo.DataSource = dt;
                cbo.DisplayMember = "Nombre";
                cbo.ValueMember = "AlternativaID";

                if (cbo.Items.Count > 0)
                {
                    cbo.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al llenar el combo: \n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cboBase.SelectedValue == null ||
                cboPesimista.SelectedValue == null ||
                cboOptimista.SelectedValue == null)
            {
                MessageBox.Show("Selecciona las tres alternativas para comparar.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CargarTabla();
        }
        private void CargarTabla()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                int baseID = Convert.ToInt32(cboBase.SelectedValue);
                int pesID = Convert.ToInt32(cboPesimista.SelectedValue);
                int optID = Convert.ToInt32(cboOptimista.SelectedValue);

                ActualizarCabeceras(baseID, pesID, optID);

                DataTable dtFlujos = ObtenerFlujos(baseID, pesID, optID);
                DataTable dtIndicadores = ObtenerIndicadores(baseID, pesID, optID);
                DataTable dtFinal = ConstruirTablaFinal(dtFlujos, dtIndicadores);

                dvgFlujos.DataSource = dtFinal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void ActualizarCabeceras(int baseID, int pesID, int optID)
        {
            string sql = @"SELECT AlternativaID, Nombre FROM proy.Alternativas
                           WHERE AlternativaID IN (@b, @p, @o)";

            var dt = EjecutarConsulta(sql,
                new SqlParameter("@b", baseID),
                new SqlParameter("@p", pesID),
                new SqlParameter("@o", optID));

            foreach (DataRow r in dt.Rows)
            {
                int id = Convert.ToInt32(r["AlternativaID"]);
                string nombre = r["Nombre"].ToString();

                if (id == baseID) dvgFlujos.Columns[COL_BASE].HeaderText = $"{nombre} (ID {id})";
                else if (id == pesID) dvgFlujos.Columns[COL_PES].HeaderText = $"{nombre} (ID {id})";
                else if (id == optID) dvgFlujos.Columns[COL_OPT].HeaderText = $"{nombre} (ID {id})";
            }
        }
        private DataTable ObtenerFlujos(int baseID, int pesID, int optID)
        {
            const string sql = @"
                SELECT
                    f1.Anio,
                    f1.FlujoPeriodo AS Flujo_Base,
                    f2.FlujoPeriodo AS Flujo_Pesimista,
                    f3.FlujoPeriodo AS Flujo_Optimista
                FROM      proy.FlujoCajaAlternativa f1
                LEFT JOIN proy.FlujoCajaAlternativa f2
                       ON f1.Anio = f2.Anio AND f2.AlternativaID = @pesID
                LEFT JOIN proy.FlujoCajaAlternativa f3
                       ON f1.Anio = f3.Anio AND f3.AlternativaID = @optID
                WHERE f1.AlternativaID = @baseID
                ORDER BY f1.Anio";

            return EjecutarConsulta(sql,
                new SqlParameter("@baseID", baseID),
                new SqlParameter("@pesID", pesID),
                new SqlParameter("@optID", optID));
        }
        private DataTable ObtenerIndicadores(int baseID, int pesID, int optID)
        {
            const string sql = @"
                SELECT
                    ib.VAN                AS VAN_Base,
                    ib.TIR                AS TIR_Base,
                    ib.IndiceRentabilidad AS IR_Base,
                    ib.PeriodoRecupNormal AS PRN_Base,
                    ib.PeriodoRecupDesc   AS PRD_Base,
                    ib.InversionInicial   AS Inv_Base,
 
                    ip.VAN                AS VAN_Pes,
                    ip.TIR                AS TIR_Pes,
                    ip.IndiceRentabilidad AS IR_Pes,
                    ip.PeriodoRecupNormal AS PRN_Pes,
                    ip.PeriodoRecupDesc   AS PRD_Pes,
                    ip.InversionInicial   AS Inv_Pes,
 
                    io.VAN                AS VAN_Opt,
                    io.TIR                AS TIR_Opt,
                    io.IndiceRentabilidad AS IR_Opt,
                    io.PeriodoRecupNormal AS PRN_Opt,
                    io.PeriodoRecupDesc   AS PRD_Opt,
                    io.InversionInicial   AS Inv_Opt
                FROM      proy.IndicadoresAlternativa ib
                LEFT JOIN proy.IndicadoresAlternativa ip ON ip.AlternativaID = @pesID
                LEFT JOIN proy.IndicadoresAlternativa io ON io.AlternativaID = @optID
                WHERE ib.AlternativaID = @baseID";

            return EjecutarConsulta(sql,
                new SqlParameter("@baseID", baseID),
                new SqlParameter("@pesID", pesID),
                new SqlParameter("@optID", optID));
        }

        private DataTable ConstruirTablaFinal(DataTable dtFlujos, DataTable dtInd)
        {
            var dt = new DataTable();
            dt.Columns.Add(COL_TIPO, typeof(string));
            dt.Columns.Add(COL_CONCEPTO, typeof(string));
            dt.Columns.Add(COL_BASE, typeof(string));
            dt.Columns.Add(COL_PES, typeof(string));
            dt.Columns.Add(COL_OPT, typeof(string));

            if (dtInd.Rows.Count > 0)
            {
                DataRow ind = dtInd.Rows[0];
                dt.Rows.Add("INVERSION", "Inversión Inicial",
                    FormatearMoneda(ind, "Inv_Base"),
                    FormatearMoneda(ind, "Inv_Pes"),
                    FormatearMoneda(ind, "Inv_Opt"));
            }

            dt.Rows.Add("SECCION", "FLUJOS DE CAJA (Años 0 – 10)", "", "", "");

            foreach (DataRow r in dtFlujos.Rows)
            {
                int anio = Convert.ToInt32(r["Anio"]);
                dt.Rows.Add("FLUJO", $"Flujo — Año {anio}",
                    FormatearMoneda(r, "Flujo_Base"),
                    FormatearMoneda(r, "Flujo_Pesimista"),
                    FormatearMoneda(r, "Flujo_Optimista"));
            }

            dt.Rows.Add("SECCION", "INDICADORES FINANCIEROS", "", "", "");

            if (dtInd.Rows.Count > 0)
            {
                DataRow i = dtInd.Rows[0];
                dt.Rows.Add("INDICADOR", "VAN",
                    FormatearMoneda(i, "VAN_Base"),
                    FormatearMoneda(i, "VAN_Pes"),
                    FormatearMoneda(i, "VAN_Opt"));
                dt.Rows.Add("INDICADOR", "TIR (%)",
                    FormatearPorcentaje(i, "TIR_Base"),
                    FormatearPorcentaje(i, "TIR_Pes"),
                    FormatearPorcentaje(i, "TIR_Opt"));
                dt.Rows.Add("INDICADOR", "Índice de Rentabilidad",
                    FormatearDecimal(i, "IR_Base"),
                    FormatearDecimal(i, "IR_Pes"),
                    FormatearDecimal(i, "IR_Opt"));
                dt.Rows.Add("INDICADOR", "Período de Recupero (años)",
                    FormatearDecimal(i, "PRN_Base"),
                    FormatearDecimal(i, "PRN_Pes"),
                    FormatearDecimal(i, "PRN_Opt"));
            }

            return dt;
        }
        private DataTable EjecutarConsulta(string sql, params SqlParameter[] parametros)
        {
            var dt = new DataTable();
            using (SqlConnection conn = new ConexionDB().ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (parametros != null && parametros.Length > 0)
                    cmd.Parameters.AddRange(parametros);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(dt);
            }
            return dt;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dvgFlujos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Por favor, actualiza la tabla primero.",
                                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Documentos PDF (*.pdf)|*.pdf";
                sfd.FileName = "ReporteFlujosCaja_" + DateTime.Now.ToString("yyyyMMdd") + ".pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        // Instancia clase generadora
                        var generadorPdf = new ProyectoInversion.Modulos.FlujosCasos.GeneradorReportePDF();

                        // Metodo
                        generadorPdf.Generar(sfd.FileName, dvgFlujos, _nombreSimulacion);

                        MessageBox.Show("PDF exportado correctamente.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al generar el PDF:\n" + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
    }
}
