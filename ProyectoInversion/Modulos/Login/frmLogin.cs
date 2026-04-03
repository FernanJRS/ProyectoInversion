using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public bool Conectado { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        
        }
    }
}
