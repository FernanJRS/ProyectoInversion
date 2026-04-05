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
                        cmd.Parameters.AddWithValue("@simulacionID", 1);
                        cmd.Parameters.AddWithValue("@alternativaID", alternativaID);

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

        public DataTable PrevisualizarAlternativa(string nombre, double tasa, double precio, double demanda, double costoV, double constr, double maqA, double maqB, double costoF, double terreno)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("proy.sp_PrevisualizarAlternativa", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SimulacionID", 1);
                    cmd.Parameters.AddWithValue("@AlternativaBaseID", 1);
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@TasaInt", tasa);
                    cmd.Parameters.AddWithValue("@Precio", precio);
                    cmd.Parameters.AddWithValue("@Demanda", demanda);
                    cmd.Parameters.AddWithValue("@CostoVarriable", costoV);
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

        public bool GuardarNuevaAlternativa(string nombre, double tasa, double precio, double demanda, double costoV, double constr, double maqA, double maqB, double costoF, double terreno)
        {
            int altID = new Int32;
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
                        cmd.Parameters.AddWithValue("@TipoAlternativa", "Personalizada")
                        cmd.Parameters.AddWithValue("@TasaInt", tasa);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@Demanda", demanda);
                        cmd.Parameters.AddWithValue("@CostoVarriable", costoV);
                        cmd.Parameters.AddWithValue("@Construccion", constr);
                        cmd.Parameters.AddWithValue("@MaquinaA", maqA);
                        cmd.Parameters.AddWithValue("@MaquinaB", maqB);
                        cmd.Parameters.AddWithValue("@CostoFijo", costoF);
                        cmd.Parameters.AddWithValue("@Terreno", terreno);
                        cmd.Parameters.AddWithValue("@AlternativaID", altID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
                return false;
            }
        }

        public DataTable ObtenerVariablesInput(int alternativaID)
        {
            DataTable dt = new DataTable();
            // Ajustado según el esquema del archivo SQL: Joins para obtener cada variable por su ID
            string query = @"
        SELECT 
            a.Nombre,
            a.TasaDescuento,
            MAX(CASE WHEN v.VariableID = 1 THEN v.ValorActual END) AS Precio,
            MAX(CASE WHEN v.VariableID = 2 THEN v.ValorActual END) AS Demanda,
            MAX(CASE WHEN v.VariableID = 3 THEN v.ValorActual END) AS CostoVar,
            MAX(CASE WHEN v.VariableID = 4 THEN v.ValorActual END) AS CostoFijo,
            MAX(CASE WHEN v.VariableID = 5 THEN v.ValorActual END) AS Construccion,
            MAX(CASE WHEN v.VariableID = 6 THEN v.ValorActual END) AS MaquinaA,
            MAX(CASE WHEN v.VariableID = 7 THEN v.ValorActual END) AS Terreno,
            MAX(CASE WHEN v.VariableID = 8 THEN v.ValorActual END) AS MaquinaB
        FROM proy.Alternativas a
        LEFT JOIN proy.VariablesAlternativa v ON a.AlternativaID = v.AlternativaID
        WHERE a.AlternativaID = @id
        GROUP BY a.Nombre, a.TasaDescuento";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", alternativaID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}
