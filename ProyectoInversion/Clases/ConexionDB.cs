using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInversion.Clases
{
    internal class ConexionDB
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
    }
}
