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

        public ConexionDB()
        {
            try 
            {
                string connectionString = "Server = 3.128.144.165; Database = DB20212000849; User ID = carlos.rivera; Password = CR20212000849;";
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
            string connectionString = "Server = 3.128.144.165; Database = DB20212000849; User ID = carlos.rivera; Password = CR20212000849;";

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


    }
}
