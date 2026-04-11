using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInversion.Modulos.Riesgo_e_Incertidumbre
{
    public partial class frmFormula : Form
    {
        public frmFormula(string formula)
        {
            InitializeComponent();
            ShowFormula(formula);
        }

        public void ShowFormula(string formula)
        {
            if (formula == "IR")
            {
                picBoxFormula.Image = Properties.Resources.FormulaIR;
                picBoxFormula.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
            if (formula == "VAN")
            {
                picBoxFormula.Image = Properties.Resources.FormulaVAN;
                picBoxFormula.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
