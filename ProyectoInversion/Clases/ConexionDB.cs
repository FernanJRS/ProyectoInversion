using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInversion.Clases
{
    public class ConexionDB
    {
        private readonly SqlConnection conexion;
        private readonly string connectionString = "Server = 3.128.144.165; Database = DB20212000849; User ID = carlos.rivera; Password = CR20212000849;";

        public ConexionDB()
        {
            try
            {
                conexion = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al conectar con la base de datos:\n" + ex.Message, "Conexión fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SqlConnection ObtenerConexion()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ No se pudo abrir la conexión a la base de datos:\n" + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return conexion;
        }

        public DataTable ObtenerAlternativas(int alternativaID)
        {
            DataTable dt = new DataTable();

            try
            {
                // Consulta según tu esquema SQL para traer el ID y el Nombre
                string query = "SELECT AlternativaID, TipoAlternativa, Nombre FROM proy.Alternativas WHERE SimulacionID = @alternativaID ORDER BY AlternativaID ASC";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@alternativaID", alternativaID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al obtener alternativas:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable ObtenerDetalleAlternativa(int simulacionID, int alternativaID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_ObtenerAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        cmd.Parameters.AddWithValue("@AlternativaID", alternativaID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener detalle: " + ex.Message);
            }
            return dt;
        }

        public int ObtenerAlternativaBaseID(int simulacionID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT AlternativaID FROM proy.Alternativas WHERE SimulacionID = @SimulacionID AND EsBase = 1", con))
                    {
                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Alternativa Base: " + ex.Message);
                return -1;
            }
        }

        public DataTable ObtenerSimulaciones()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SimulacionID, Nombre FROM proy.Simulaciones ORDER BY SimulacionID ASC", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener simulaciones: " + ex.Message);
            }
            return dt;
        }

        public int ObtenerSimulacionID(int alternativaID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SimulacionID FROM proy.Alternativas WHERE AlternativaID = @AlternativaID", con))
                    {
                        cmd.Parameters.AddWithValue("@AlternativaID", alternativaID);
                        con.Open();
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Simulación ID: " + ex.Message);
                return -1;
            }
        }

        public DataSet PrevisualizarAlternativa(int simulacionID, string nombre, double tasa, double precio, double demanda, double costoV, double constr, double maqA, double maqB, double costoF, double terreno)
        {
            DataSet dt = new DataSet();

            int alternativaBaseID = ObtenerAlternativaBaseID(simulacionID);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("proy.sp_PrevisualizarAlternativa", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                    cmd.Parameters.AddWithValue("@AlternativaBaseID", alternativaBaseID);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@TasaInteres", tasa);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Demanda", demanda);
                    cmd.Parameters.AddWithValue("@CostoVariable", costoV);
                    cmd.Parameters.AddWithValue("@Construccion", constr);
                    cmd.Parameters.AddWithValue("@MaquinaA", maqA);
                    cmd.Parameters.AddWithValue("@MaquinaB", maqB);
                    cmd.Parameters.AddWithValue("@CostoFijo", costoF);
                    cmd.Parameters.AddWithValue("@Terreno", terreno);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataSet GuardarNuevaAlternativa(int simulacionID, string nombre, double tasa, double precio, double demanda, double costoV, double constr, double maqA, double maqB, double costoF, double terreno)
        {
            DataSet dt = new DataSet();
            int alternativaBaseID = ObtenerAlternativaBaseID(simulacionID);
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_GuardarNuevaAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        cmd.Parameters.AddWithValue("@AlternativaBaseID", alternativaBaseID);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@TipoAlternativa", "Personalizada");
                        cmd.Parameters.AddWithValue("@TasaInteres", tasa);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@Demanda", demanda);
                        cmd.Parameters.AddWithValue("@CostoVariable", costoV);
                        cmd.Parameters.AddWithValue("@Construccion", constr);
                        cmd.Parameters.AddWithValue("@MaquinaA", maqA);
                        cmd.Parameters.AddWithValue("@MaquinaB", maqB);
                        cmd.Parameters.AddWithValue("@CostoFijo", costoF);
                        cmd.Parameters.AddWithValue("@Terreno", terreno);

                        SqlParameter paramAltID = new SqlParameter("@AlternativaID", SqlDbType.Int);
                        paramAltID.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(paramAltID);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            return dt;
        }

        public AlternativaModel ObtenerAlternativa(int simulacionID, int alternativaID)
        {
            AlternativaModel alt = new AlternativaModel();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_ObtenerAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        cmd.Parameters.AddWithValue("@AlternativaID", alternativaID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    alt.AlternativaID = alternativaID;
                    alt.SimulacionID = simulacionID;
                    alt.Nombre = r["Nombre"].ToString();
                    alt.TasaDescuento = Convert.ToDecimal(r["TasaInteres"]);
                    alt.TasaImpuesto = Convert.ToDecimal(r["TasaImpuesto"]);
                    alt.PrecioBase = Convert.ToDecimal(r["Precio"]);
                    alt.VentasAnio1 = Convert.ToDecimal(r["Demanda"]);
                    alt.CostoVarBase = Convert.ToDecimal(r["CostoVariable"]);
                    alt.CostoFijoBase = Convert.ToDecimal(r["CostoFijo"]);
                    alt.Terreno = Convert.ToDecimal(r["Terreno"]);
                    // Construcción
                    alt.Construccion = Convert.ToDecimal(r["Construccion"]);
                    alt.DepConst = Convert.ToInt32(r["DepConst"]);
                    alt.VidUtilConst = Convert.ToInt32(r["VidUtilConst"]);

                    // Máquina A
                    alt.MaquinaA = Convert.ToDecimal(r["MaquinaA"]);
                    alt.VidUtilMaqA = Convert.ToInt32(r["VidUtilMaqA"]);
                    alt.DepMaqA = Convert.ToInt32(r["DepMaqA"]);
                    alt.RecompraMaqA_2 = Convert.ToInt32(r["RecompraMaqA_2"]);
                    alt.RecompraMaqA_3 = Convert.ToInt32(r["RecompraMaqA_3"]);

                    // Máquina B
                    alt.MaquinaB = Convert.ToDecimal(r["MaquinaB"]);
                    alt.VidUtilMaqB = Convert.ToInt32(r["VidUtilMaqB"]);
                    alt.DepMaqB = Convert.ToInt32(r["DepMaqB"]);
                    alt.RecompraMaqB = Convert.ToInt32(r["RecompraMaqB"]);

                    // Indicadores
                    alt.VAN = Convert.ToDecimal(r["VAN"]);
                    alt.TIR = Convert.ToDecimal(r["TIR"]);
                    alt.IndiceRentabilidad = Convert.ToDecimal(r["IR"]);
                    alt.InversionInicial = Convert.ToDecimal(r["InversionInicial"]);
                    alt.ValorDesechoEcon = Convert.ToDecimal(r["ValorDesechoEcon"]);
                    alt.Viabilidad = r["Viabilidad"].ToString();
                    alt.EvalTIR = r["EvalTIR"].ToString();
                    alt.ValorResidual = Convert.ToDecimal(r["ValorResidual"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener alternativa: " + ex.Message);
            }
            return alt;
        }

        public void EliminarAlternativa(int alternativaID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_EliminarAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AlternativaID", alternativaID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar alternativa: " + ex.Message);
            }
        }

        // Crea una simulación nueva y devuelve su ID
        public int CrearSimulacion(string nombre, string descripcion,
            double tasaDescuento, double tasaImpuesto, int horizonteAnios,
            double ventasAnio1, double incrAnio2, double incrAnio3,
            double precioBase, double incrPrecio, int anioIncrPrecio,
            double costoVarBase, double limiteCostoVar, double incrCostoVarExtra,
            double costoFijoBase, double incrCostoFijo, int anioIncrCostoFijo,
            int mesesCapitalTrabajo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_InsertarSimulacion", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@TasaDescuento", tasaDescuento);
                        cmd.Parameters.AddWithValue("@TasaImpuesto", tasaImpuesto);
                        cmd.Parameters.AddWithValue("@HorizonteAnios", horizonteAnios);
                        cmd.Parameters.AddWithValue("@VentasAnio1", ventasAnio1);
                        cmd.Parameters.AddWithValue("@IncrementoAnio2", incrAnio2);
                        cmd.Parameters.AddWithValue("@IncrementoAnio3", incrAnio3);
                        cmd.Parameters.AddWithValue("@PrecioBase", precioBase);
                        cmd.Parameters.AddWithValue("@IncrementoPrecio", incrPrecio);
                        cmd.Parameters.AddWithValue("@AnioIncrPrecio", anioIncrPrecio);
                        cmd.Parameters.AddWithValue("@CostoVarBase", costoVarBase);
                        cmd.Parameters.AddWithValue("@LimiteCostoVar", limiteCostoVar);
                        cmd.Parameters.AddWithValue("@IncrCostoVarExtra", incrCostoVarExtra);
                        cmd.Parameters.AddWithValue("@CostoFijoBase", costoFijoBase);
                        cmd.Parameters.AddWithValue("@IncrCostoFijo", incrCostoFijo);
                        cmd.Parameters.AddWithValue("@AnioIncrCostoFijo", anioIncrCostoFijo);
                        cmd.Parameters.AddWithValue("@MesesCapitalTrabajo", mesesCapitalTrabajo);

                        SqlParameter pOut = new SqlParameter("@SimulacionID", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(pOut);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return (int)pOut.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear simulación: " + ex.Message);
                return -1;
            }
        }

        // Guarda la Alternativa Base
        public int GuardarAlternativaBase(int simulacionID, string nombre,
            double tasaDescuento, double ventasAnio1, double precioBase, 
            double costoVarBase, double costoFijoBase,
            double terreno, double construccion, int depConst, int vidaUtilConst, 
            double maquinaA, int vidaUtilMaqA, int vidaContableMaqA, int recompra1MaqA, int recompra2MaqA,
            double maquinaB, int vidaUtilMaqB, int vidaContableMaqB, int recompraMaqB,
            double tasaImpuestoActivos)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 1. Guardar la alternativa base
                    using (SqlCommand cmd = new SqlCommand("proy.sp_GuardarAlternativaBase", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 120;

                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Precio", precioBase);
                        cmd.Parameters.AddWithValue("@TasaInteres", tasaDescuento);
                        cmd.Parameters.AddWithValue("@Demanda", ventasAnio1);
                        cmd.Parameters.AddWithValue("@CostoVariable", costoVarBase);
                        cmd.Parameters.AddWithValue("@CostoFijo", costoFijoBase);
                        cmd.Parameters.AddWithValue("@Construccion", construccion);
                        cmd.Parameters.AddWithValue("@depConst", depConst);
                        cmd.Parameters.AddWithValue("@vidUtilConst", vidaUtilConst);
                        cmd.Parameters.AddWithValue("@MaquinaA", maquinaA);
                        cmd.Parameters.AddWithValue("@vidUtilMaqA", vidaUtilMaqA);
                        cmd.Parameters.AddWithValue("@depMaqA", vidaContableMaqA);
                        cmd.Parameters.AddWithValue("@recompraMaqA_2", recompra1MaqA);
                        cmd.Parameters.AddWithValue("@recompraMaqA_3", recompra2MaqA);
                        cmd.Parameters.AddWithValue("@MaquinaB", maquinaB);
                        cmd.Parameters.AddWithValue("@recompraMaqB", recompraMaqB);
                        cmd.Parameters.AddWithValue("@vidUtilMaqB", vidaUtilMaqB);
                        cmd.Parameters.AddWithValue("@depMaqB", vidaContableMaqB);
                        cmd.Parameters.AddWithValue("@Terreno", terreno);
                        cmd.Parameters.AddWithValue("@valorResidual", tasaImpuestoActivos);

                        SqlParameter pOut = new SqlParameter("@AlternativaID", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(pOut);

                        cmd.ExecuteNonQuery();
                        int altBaseID = (int)pOut.Value;

                        return altBaseID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar alternativa base: " + ex.Message);
                return -1;
            }
        }

        // Guarda una alternativa derivada (A, B, etc.) con parámetros dinámicos
        public DataSet GuardarAlternativaDerivada(int simulacionID, int altBaseID,
            string nombre, string tipoAlternativa,
            double precio, double tasaInteres, double demanda,
            double costoVariable, double construccion, double maquinaA,
            double maquinaB, double costoFijo, double terreno,
            int depConst, int depMaqA, int depMaqB, int vidaUtilConst,
            int vidaUtilMaqA, int vidaUtilMaqB, int recompra1MaqA, int recompraMaq2A, int recompraMaqB, 
            double valorResidual)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_GuardarNuevaAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        cmd.Parameters.AddWithValue("@AlternativaBaseID", altBaseID);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@TipoAlternativa", tipoAlternativa);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@TasaInteres", tasaInteres);
                        cmd.Parameters.AddWithValue("@Demanda", demanda);
                        cmd.Parameters.AddWithValue("@CostoVariable", costoVariable);
                        cmd.Parameters.AddWithValue("@Construccion", construccion);
                        cmd.Parameters.AddWithValue("@DepConst", depConst);
                        cmd.Parameters.AddWithValue("@VidaUtilConst", vidaUtilConst);
                        cmd.Parameters.AddWithValue("@MaquinaA", maquinaA);
                        cmd.Parameters.AddWithValue("@DepMaqA", depMaqA);
                        cmd.Parameters.AddWithValue("@VidaUtilMaqA", vidaUtilMaqA);
                        cmd.Parameters.AddWithValue("@Recompra1MaqA", recompra1MaqA);
                        cmd.Parameters.AddWithValue("@Recompra2MaqA", recompraMaq2A);
                        cmd.Parameters.AddWithValue("@MaquinaB", maquinaB);
                        cmd.Parameters.AddWithValue("@DepMaqB", depMaqB);
                        cmd.Parameters.AddWithValue("@VidaUtilMaqB", vidaUtilMaqB);
                        cmd.Parameters.AddWithValue("@Recompra1MaqB", recompraMaqB);
                        cmd.Parameters.AddWithValue("@CostoFijo", costoFijo);
                        cmd.Parameters.AddWithValue("@Terreno", terreno);
                        cmd.Parameters.AddWithValue("@ValorResidual", valorResidual);

                        SqlParameter pOut = new SqlParameter("@AlternativaID", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(pOut);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar alternativa derivada: " + ex.Message);
            }
            return ds;
        }
    }
}
