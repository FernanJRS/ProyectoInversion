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
using ProyectoInversion.Modulos.Menu;

namespace ProyectoInversion
{
    public partial class frmLogin : Form
    {
        ToolTip toolTip;
        public bool Conectado { get; private set; }
        public SqlConnection Conexion { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
            toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.ToolTipTitle = "Información";
            toolTip.UseAnimation = true;

            toolTip.SetToolTip(btnIniciar, "Iniciar sesión");
            toolTip.SetToolTip(btnSalir, "Salir de la aplicación");
            Conectado = false;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetSystemMenu(IntPtr hWnd, bool bRevert);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DeleteMenu(int hMenu, int nPosition, int wFlags);

        private const int SC_CLOSE = 0xF060;
        private const int MF_BYCOMMAND = 0x0000;
        private void Login_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Esto deshabilita el botón X físicamente
            int menu = GetSystemMenu(this.Handle, false);
            DeleteMenu(menu, SC_CLOSE, MF_BYCOMMAND);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string servidor = "3.128.144.165";
            string baseDatos = "DB20212000849";
            string usuario = "carlos.rivera";
            string contraseña = "CR20212000849";

            string cadenaConexion = $"Server={servidor};Database={baseDatos};User Id={usuario};Password={contraseña};";

            try
            {
                Conexion = new SqlConnection(cadenaConexion);
                Conexion.Open();
                Conectado = true;
                MessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Conectado = false;
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                //MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Conectado)
            {
                frmMenu frm = new frmMenu();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                this.Close();
            }
            else 
            {
                MessageBox.Show("No se pudo establecer la conexión a la base de datos. Intenta nuevamente más tarde.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
