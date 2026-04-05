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

        public DataTable ObtenerAlternativas()
        {
            DataTable dt = new DataTable();

            try
            {
                // Consulta según tu esquema SQL para traer el ID y el Nombre
                string query = "SELECT AlternativaID, Nombre FROM proy.Alternativas WHERE SimulacionID = 1 ORDER BY AlternativaID ASC";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
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

        public DataTable ObtenerDetalleAlternativa(int alternativaID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_ObtenerAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", 1);
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

        public DataSet PrevisualizarAlternativa(string nombre, double tasa, double precio, double demanda, double costoV, double constr, double maqA, double maqB, double costoF, double terreno)
        {
            DataSet dt = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("proy.sp_PrevisualizarAlternativa", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SimulacionID", 1);
                    cmd.Parameters.AddWithValue("@AlternativaBaseID", 1);
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

        public DataSet GuardarNuevaAlternativa(string nombre, double tasa, double precio, double demanda, double costoV, double constr, double maqA, double maqB, double costoF, double terreno)
        {
            int altID = new Int32();
            DataSet dt = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("proy.sp_GuardarNuevaAlternativa", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SimulacionID", 1);
                        cmd.Parameters.AddWithValue("@AlternativaBaseID", 1);
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
    }
}
