namespace ProyectoInversion.Modulos.Riesgo_e_Incertidumbre
{
    partial class frmFormula
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoxFormula = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFormula)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxFormula
            // 
            this.picBoxFormula.Location = new System.Drawing.Point(3, 1);
            this.picBoxFormula.Name = "picBoxFormula";
            this.picBoxFormula.Size = new System.Drawing.Size(289, 124);
            this.picBoxFormula.TabIndex = 0;
            this.picBoxFormula.TabStop = false;
            this.picBoxFormula.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 128);
            this.Controls.Add(this.picBoxFormula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sigma";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFormula)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxFormula;
    }
}