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
        public frmCompararEscenarios()
        {
            InitializeComponent();
            ConexionDB DB = new ConexionDB();
            DataTable dtAlternativas = DB.ObtenerAlternativas();

            // Configurar ComboBox Escenario Base (Solo lectura)
            cmbEscenarioBase.DataSource = dtAlternativas.Copy();
            cmbEscenarioBase.ValueMember = "AlternativaID";
            cmbEscenarioBase.DisplayMember = "Nombre";
            cmbEscenarioBase.SelectedIndex = 0; 

            cmbEscenarioBase.Enabled = false;   

            DataView dvFiltrado = new DataView(dtAlternativas);
            dvFiltrado.RowFilter = "Nombre <> 'Escenario Base'";

            // Configurar ComboBox Escenario A
            cmbAlternativaA.DataSource = dvFiltrado;
            cmbAlternativaA.ValueMember = "AlternativaID";
            cmbAlternativaA.DisplayMember = "Nombre";
            cmbAlternativaA.SelectedIndex = 0;

            DataView dvFiltrado2 = new DataView(dtAlternativas);
            dvFiltrado2.RowFilter = "Nombre <> 'Escenario Base'";

            // Configurar ComboBox Escenario B
            cmbAlternativaB.DataSource = dvFiltrado2;
            cmbAlternativaB.ValueMember = "AlternativaID";
            cmbAlternativaB.DisplayMember = "Nombre";
            cmbAlternativaB.SelectedIndex = 1;

            // Una vez cargados, disparar la primera comparativa
            CargarDatosComparativa();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#3BA5D9");
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#2C7A9E");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = ColorTranslator.FromHtml("#3BA5D9");
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = ColorTranslator.FromHtml("#2C7A9E");
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = ColorTranslator.FromHtml("#3BA5D9");
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = ColorTranslator.FromHtml("#2C7A9E");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            frmCrearAlternativa crearAlternativa = new frmCrearAlternativa();
            crearAlternativa.ShowDialog();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            frmCrearAlternativa crearAlternativa = new frmCrearAlternativa();
            crearAlternativa.ShowDialog();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            frmCrearAlternativa crearAlternativa = new frmCrearAlternativa();
            crearAlternativa.ShowDialog();
        }

        private void frmCompararEscenarios_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatosComparativa()
        {
            // 1. Validar que haya selecciones válidas para evitar errores de conversión
            if (cmbAlternativaA.SelectedValue == null || cmbAlternativaB.SelectedValue == null)
                return;

            // 2. Extraer los IDs (ValueMember) para SQL y los Nombres (DisplayMember) para la UI
            int idBase = 1; // ID fijo de la alternativa base según tu lógica
            int idA = Convert.ToInt32(cmbAlternativaA.SelectedValue);
            int idB = Convert.ToInt32(cmbAlternativaB.SelectedValue);


            string connectionString = "Server = 3.128.144.165; Database = DB20212000849; User ID = carlos.rivera; Password = CR20212000849;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // -----------------------------------------------------------
                    // A. LLENAR EL DATAGRIDVIEW (Usando tu SP de comparación)
                    // -----------------------------------------------------------
                    using (SqlCommand cmdGrid = new SqlCommand("proy.sp_CompararAlternativas", con))
                    {
                        cmdGrid.CommandType = CommandType.StoredProcedure;
                        cmdGrid.Parameters.AddWithValue("@SimulacionID", 1);
                        cmdGrid.Parameters.AddWithValue("@AltID_A", idBase);
                        cmdGrid.Parameters.AddWithValue("@AltID_B", idA);
                        cmdGrid.Parameters.AddWithValue("@AltID_C", idB);

                        SqlDataAdapter da = new SqlDataAdapter(cmdGrid);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dvgVariaciones.DataSource = dt;
                    }

                    // -----------------------------------------------------------
                    // B. OBTENER INDICADORES PARA LAS TARJETAS Y EL GRÁFICO
                    // -----------------------------------------------------------
                    // Usamos la vista que ya tienes en tu SQL
                    string query = "SELECT Alternativa, AlternativaID, TasaDescuento, VAN, TIR_Pct, IR, InversionInicial FROM proy.vw_IndicadoresPorAlternativa " +
                                   "WHERE AlternativaID IN (@base, @a, @b)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@base", idBase);
                        cmd.Parameters.AddWithValue("@a", idA);
                        cmd.Parameters.AddWithValue("@b", idB);

                        SqlDataReader reader = cmd.ExecuteReader();

                        // Variables para ScottPlot
                        double vanBase = 0, vanA = 0, vanB = 0;

                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["AlternativaID"]);
                            string tasa = $"{Convert.ToDouble(reader["TasaDescuento"]):N2}%";
                            double van = Convert.ToDouble(reader["VAN"]);
                            string tir = $"{Convert.ToDouble(reader["TIR_Pct"]):N2}%";
                            string ir = $"{Convert.ToDouble(reader["IR"]):N4}";
                            string inversion = $"{Convert.ToDouble(reader["InversionInicial"]):C}";

                            if (id == idBase)
                            {
                                lbl1Panel1.Text = "Tasa de Inversión: " + tasa;
                                lbl2Panel1.Text = "VAN: " + van.ToString("C");
                                lbl3Panel1.Text = "TIR: " + tir;
                                lbl4Panel1.Text = "IR: " +ir;
                                lbl5Panel1.Text = "Inversión: " + inversion;
                                vanBase = van;
                            }
                            else if (id == idA)
                            {
                                lbl1Panel2.Text = "Tasa de Inversión: " + tasa;
                                lbl2Panel2.Text = "VAN: " + van.ToString("C");
                                lbl3Panel2.Text = "TIR: " + tir;
                                lbl4Panel2.Text = "IR: " + ir;
                                lbl5Panel2.Text = "Inversión: " + inversion;
                                vanA = van;
                            }
                            else if (id == idB)
                            {
                                lbl1Panel3.Text = "Tasa de Inversión: " + tasa;
                                lbl2Panel3.Text = "VAN: " + van.ToString("C");
                                lbl3Panel3.Text = "TIR: " + tir;
                                lbl4Panel3.Text = "IR: " + ir;
                                lbl5Panel3.Text = "Inversión: " + inversion;
                                vanB = van;
                            }
                        }
                        reader.Close();

                        // 3. Actualizar Gráfico con los valores numéricos obtenidos
                        ActualizarGraficoComparativo(vanBase, vanA, vanB);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar comparativa: " + ex.Message);
                }
            }
        }


        private void ActualizarGraficoComparativo(double vBase, double vA, double vB)
        {
            GrafPlot.Plot.Clear();

            // Obtener nombres de forma segura
            // Usamos .Replace(" - ", "\n") para que "Escenario A - Pesimista" se convierta en dos líneas
            string nombreBase = ((DataRowView)cmbEscenarioBase.SelectedItem)["Nombre"].ToString().Replace(" - ", "\n");
            string nombreA = ((DataRowView)cmbAlternativaA.SelectedItem)["Nombre"].ToString().Replace(" - ", "\n");
            string nombreB = ((DataRowView)cmbAlternativaB.SelectedItem)["Nombre"].ToString().Replace(" - ", "\n");

            var barBase = new Bar { Position = 0, Value = vBase, FillColor = Colors.Gray };
            var barA = new Bar { Position = 1, Value = vA, FillColor = Colors.RoyalBlue};
            var barB = new Bar { Position = 2, Value = vB, FillColor = Colors.Navy};

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

            GrafPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // Ajustar el margen inferior para que el texto de dos líneas no se corte
            GrafPlot.Plot.Axes.Bottom.MinimumSize = 30;

            GrafPlot.Plot.Title("Comparativa de VAN por Escenario");
            GrafPlot.Plot.Axes.Margins(bottom: 0, top: 0.2);
            GrafPlot.Refresh();
        }

        private void cmbEscenarioBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
