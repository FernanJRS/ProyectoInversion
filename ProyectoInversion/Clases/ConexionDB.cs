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
                    alt.Nombre = r["Alternativa"].ToString();
                    alt.TasaDescuento = Convert.ToDecimal(r["TasaDescuento"]);
                    alt.PrecioBase = Convert.ToDecimal(r["PrecioBase"]);
                    alt.VentasAnio1 = Convert.ToDecimal(r["VentasAnio1"]);
                    alt.CostoVarBase = Convert.ToDecimal(r["CostoVarBase"]);
                    alt.CostoFijoBase = Convert.ToDecimal(r["CostoFijoBase"]);
                    alt.Construccion = Convert.ToDecimal(r["Construccion"]);
                    alt.MaquinaA = Convert.ToDecimal(r["MaquinaA"]);
                    alt.MaquinaB = Convert.ToDecimal(r["MaquinaB"]);
                    alt.Terreno = Convert.ToDecimal(r["Terreno"]);
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

        // Guarda la Alternativa Base (EsBase=1) y sus 4 activos
        public int GuardarAlternativaBase(int simulacionID, string nombre,
            double tasaDescuento, double tasaImpuesto,
            double ventasAnio1, double precioBase, double costoVarBase, double costoFijoBase,
            double terreno, double construccion, int vidaContableConst, 
            double maquinaA, int vidaUtilMaqA, int vidaContableMaqA, double maquinaB,
            int vidaUtilMaqB, int vidaContableMaqB, double tasaImpuestoActivos, double probabilidad = 0.40)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // 1. Guardar la alternativa base
                    using (SqlCommand cmd = new SqlCommand("proy.sp_GuardarAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", simulacionID);
                        cmd.Parameters.AddWithValue("@AlternativaBaseID", DBNull.Value);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@TipoAlternativa", "Base");
                        cmd.Parameters.AddWithValue("@EsBase", true);
                        cmd.Parameters.AddWithValue("@Probabilidad", probabilidad);
                        cmd.Parameters.AddWithValue("@TasaDescuento", tasaDescuento);
                        cmd.Parameters.AddWithValue("@TasaImpuesto", tasaImpuesto);
                        cmd.Parameters.AddWithValue("@VentasAnio1", ventasAnio1);
                        cmd.Parameters.AddWithValue("@PrecioBase", precioBase);
                        cmd.Parameters.AddWithValue("@CostoVarBase", costoVarBase);
                        cmd.Parameters.AddWithValue("@CostoFijoBase", costoFijoBase);

                        SqlParameter pOut = new SqlParameter("@AlternativaID", SqlDbType.Int)
                        { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(pOut);

                        cmd.ExecuteNonQuery();
                        int altBaseID = (int)pOut.Value;

                        // 2. Insertar los 4 activos
                        InsertarActivo(altBaseID, "Terreno", terreno, null, null, 0, tasaImpuestoActivos);
                        InsertarActivo(altBaseID, "Construccion", construccion, 0, vidaContableConst, 0, tasaImpuestoActivos);
                        InsertarActivo(altBaseID, "Maquina A", maquinaA, vidaUtilMaqA, vidaContableMaqA, 0, tasaImpuestoActivos);
                        InsertarActivo(altBaseID, "Maquina B", maquinaB, vidaUtilMaqB, vidaContableMaqB, 0, tasaImpuestoActivos);

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

        private void InsertarActivo(int altID, string nombre,
            double valor, int? vidaUtil, int? vidaContable, double valorResidual, double tasaImpuesto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 1. Guardar la alternativa base
                using (SqlCommand cmd = new SqlCommand("proy.sp_InsertarActivo", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AlternativaID", altID);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Costo", valor);
                    cmd.Parameters.AddWithValue("@AniosDepreciacion", (object)vidaUtil ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@VidaUtilAnios", (object)vidaContable ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@AnioAdquisicion", valorResidual);
                    cmd.Parameters.AddWithValue("@ValorResidualPct", tasaImpuesto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Guarda una alternativa derivada (A, B, etc.) con parámetros dinámicos
        public DataSet GuardarAlternativaDerivada(int simulacionID, int altBaseID,
            string nombre, string tipoAlternativa, String notas,
            double precio, double tasaInteres, double demanda,
            double costoVariable, double construccion, double maquinaA,
            double maquinaB, double costoFijo, double terreno)
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
                        cmd.Parameters.AddWithValue("@Probabilidad", 0.30);
                        cmd.Parameters.AddWithValue("@Notas", notas);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@TasaInteres", tasaInteres);
                        cmd.Parameters.AddWithValue("@Demanda", demanda);
                        cmd.Parameters.AddWithValue("@CostoVariable", costoVariable);
                        cmd.Parameters.AddWithValue("@Construccion", construccion);
                        cmd.Parameters.AddWithValue("@MaquinaA", maquinaA);
                        cmd.Parameters.AddWithValue("@MaquinaB", maquinaB);
                        cmd.Parameters.AddWithValue("@CostoFijo", costoFijo);
                        cmd.Parameters.AddWithValue("@Terreno", terreno);

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
