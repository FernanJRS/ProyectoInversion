namespace ProyectoInversion.Modulos.GestiónEscenarios
{
    partial class frmCompararEscenarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompararEscenarios));
            this.cmbEscenarioBase = new System.Windows.Forms.ComboBox();
            this.cmbAlternativaA = new System.Windows.Forms.ComboBox();
            this.cmbAlternativaB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl2Panel1 = new System.Windows.Forms.Label();
            this.lbl3Panel1 = new System.Windows.Forms.Label();
            this.lbl4Panel1 = new System.Windows.Forms.Label();
            this.lbl5Panel1 = new System.Windows.Forms.Label();
            this.lbl1Panel1 = new System.Windows.Forms.Label();
            this.lbl1Panel2 = new System.Windows.Forms.Label();
            this.lbl5Panel2 = new System.Windows.Forms.Label();
            this.lbl4Panel2 = new System.Windows.Forms.Label();
            this.lbl3Panel2 = new System.Windows.Forms.Label();
            this.lbl2Panel2 = new System.Windows.Forms.Label();
            this.lbl1Panel3 = new System.Windows.Forms.Label();
            this.lbl5Panel3 = new System.Windows.Forms.Label();
            this.lbl4Panel3 = new System.Windows.Forms.Label();
            this.lbl3Panel3 = new System.Windows.Forms.Label();
            this.lbl2Panel3 = new System.Windows.Forms.Label();
            this.GrafPlot = new ScottPlot.WinForms.FormsPlot();
            this.dvgVariaciones = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVariaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEscenarioBase
            // 
            this.cmbEscenarioBase.Enabled = false;
            this.cmbEscenarioBase.FormattingEnabled = true;
            this.cmbEscenarioBase.Location = new System.Drawing.Point(149, 44);
            this.cmbEscenarioBase.Name = "cmbEscenarioBase";
            this.cmbEscenarioBase.Size = new System.Drawing.Size(200, 21);
            this.cmbEscenarioBase.TabIndex = 0;
            this.cmbEscenarioBase.SelectedIndexChanged += new System.EventHandler(this.cmbEscenarioBase_SelectedIndexChanged);
            // 
            // cmbAlternativaA
            // 
            this.cmbAlternativaA.FormattingEnabled = true;
            this.cmbAlternativaA.Location = new System.Drawing.Point(400, 44);
            this.cmbAlternativaA.Name = "cmbAlternativaA";
            this.cmbAlternativaA.Size = new System.Drawing.Size(200, 21);
            this.cmbAlternativaA.TabIndex = 1;
            // 
            // cmbAlternativaB
            // 
            this.cmbAlternativaB.FormattingEnabled = true;
            this.cmbAlternativaB.Location = new System.Drawing.Point(647, 44);
            this.cmbAlternativaB.Name = "cmbAlternativaB";
            this.cmbAlternativaB.Size = new System.Drawing.Size(200, 21);
            this.cmbAlternativaB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escenario Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alternativa A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(710, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alternativa B";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(158)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbl1Panel1);
            this.panel1.Controls.Add(this.lbl5Panel1);
            this.panel1.Controls.Add(this.lbl4Panel1);
            this.panel1.Controls.Add(this.lbl3Panel1);
            this.panel1.Controls.Add(this.lbl2Panel1);
            this.panel1.Location = new System.Drawing.Point(149, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 159);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(158)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbl1Panel2);
            this.panel2.Controls.Add(this.lbl5Panel2);
            this.panel2.Controls.Add(this.lbl2Panel2);
            this.panel2.Controls.Add(this.lbl4Panel2);
            this.panel2.Controls.Add(this.lbl3Panel2);
            this.panel2.Location = new System.Drawing.Point(400, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 159);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(158)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lbl1Panel3);
            this.panel3.Controls.Add(this.lbl5Panel3);
            this.panel3.Controls.Add(this.lbl2Panel3);
            this.panel3.Controls.Add(this.lbl4Panel3);
            this.panel3.Controls.Add(this.lbl3Panel3);
            this.panel3.Location = new System.Drawing.Point(647, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 159);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            this.panel3.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // lbl2Panel1
            // 
            this.lbl2Panel1.AutoSize = true;
            this.lbl2Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl2Panel1.Location = new System.Drawing.Point(3, 41);
            this.lbl2Panel1.Name = "lbl2Panel1";
            this.lbl2Panel1.Size = new System.Drawing.Size(32, 13);
            this.lbl2Panel1.TabIndex = 0;
            this.lbl2Panel1.Text = "VAN:";
            // 
            // lbl3Panel1
            // 
            this.lbl3Panel1.AutoSize = true;
            this.lbl3Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl3Panel1.Location = new System.Drawing.Point(3, 68);
            this.lbl3Panel1.Name = "lbl3Panel1";
            this.lbl3Panel1.Size = new System.Drawing.Size(28, 13);
            this.lbl3Panel1.TabIndex = 1;
            this.lbl3Panel1.Text = "TIR:";
            // 
            // lbl4Panel1
            // 
            this.lbl4Panel1.AutoSize = true;
            this.lbl4Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl4Panel1.Location = new System.Drawing.Point(3, 96);
            this.lbl4Panel1.Name = "lbl4Panel1";
            this.lbl4Panel1.Size = new System.Drawing.Size(21, 13);
            this.lbl4Panel1.TabIndex = 2;
            this.lbl4Panel1.Text = "IR:";
            // 
            // lbl5Panel1
            // 
            this.lbl5Panel1.AutoSize = true;
            this.lbl5Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl5Panel1.Location = new System.Drawing.Point(3, 124);
            this.lbl5Panel1.Name = "lbl5Panel1";
            this.lbl5Panel1.Size = new System.Drawing.Size(80, 13);
            this.lbl5Panel1.TabIndex = 3;
            this.lbl5Panel1.Text = "Inversión Total:";
            // 
            // lbl1Panel1
            // 
            this.lbl1Panel1.AutoSize = true;
            this.lbl1Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl1Panel1.Location = new System.Drawing.Point(3, 14);
            this.lbl1Panel1.Name = "lbl1Panel1";
            this.lbl1Panel1.Size = new System.Drawing.Size(95, 13);
            this.lbl1Panel1.TabIndex = 4;
            this.lbl1Panel1.Text = "Tasa de Inversión:";
            // 
            // lbl1Panel2
            // 
            this.lbl1Panel2.AutoSize = true;
            this.lbl1Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl1Panel2.Location = new System.Drawing.Point(3, 14);
            this.lbl1Panel2.Name = "lbl1Panel2";
            this.lbl1Panel2.Size = new System.Drawing.Size(95, 13);
            this.lbl1Panel2.TabIndex = 9;
            this.lbl1Panel2.Text = "Tasa de Inversión:";
            // 
            // lbl5Panel2
            // 
            this.lbl5Panel2.AutoSize = true;
            this.lbl5Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl5Panel2.Location = new System.Drawing.Point(3, 124);
            this.lbl5Panel2.Name = "lbl5Panel2";
            this.lbl5Panel2.Size = new System.Drawing.Size(80, 13);
            this.lbl5Panel2.TabIndex = 8;
            this.lbl5Panel2.Text = "Inversión Total:";
            // 
            // lbl4Panel2
            // 
            this.lbl4Panel2.AutoSize = true;
            this.lbl4Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl4Panel2.Location = new System.Drawing.Point(3, 96);
            this.lbl4Panel2.Name = "lbl4Panel2";
            this.lbl4Panel2.Size = new System.Drawing.Size(21, 13);
            this.lbl4Panel2.TabIndex = 7;
            this.lbl4Panel2.Text = "IR:";
            // 
            // lbl3Panel2
            // 
            this.lbl3Panel2.AutoSize = true;
            this.lbl3Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl3Panel2.Location = new System.Drawing.Point(3, 68);
            this.lbl3Panel2.Name = "lbl3Panel2";
            this.lbl3Panel2.Size = new System.Drawing.Size(28, 13);
            this.lbl3Panel2.TabIndex = 6;
            this.lbl3Panel2.Text = "TIR:";
            // 
            // lbl2Panel2
            // 
            this.lbl2Panel2.AutoSize = true;
            this.lbl2Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl2Panel2.Location = new System.Drawing.Point(3, 41);
            this.lbl2Panel2.Name = "lbl2Panel2";
            this.lbl2Panel2.Size = new System.Drawing.Size(32, 13);
            this.lbl2Panel2.TabIndex = 5;
            this.lbl2Panel2.Text = "VAN:";
            // 
            // lbl1Panel3
            // 
            this.lbl1Panel3.AutoSize = true;
            this.lbl1Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl1Panel3.Location = new System.Drawing.Point(3, 14);
            this.lbl1Panel3.Name = "lbl1Panel3";
            this.lbl1Panel3.Size = new System.Drawing.Size(95, 13);
            this.lbl1Panel3.TabIndex = 14;
            this.lbl1Panel3.Text = "Tasa de Inversión:";
            // 
            // lbl5Panel3
            // 
            this.lbl5Panel3.AutoSize = true;
            this.lbl5Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl5Panel3.Location = new System.Drawing.Point(3, 124);
            this.lbl5Panel3.Name = "lbl5Panel3";
            this.lbl5Panel3.Size = new System.Drawing.Size(80, 13);
            this.lbl5Panel3.TabIndex = 13;
            this.lbl5Panel3.Text = "Inversión Total:";
            // 
            // lbl4Panel3
            // 
            this.lbl4Panel3.AutoSize = true;
            this.lbl4Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl4Panel3.Location = new System.Drawing.Point(3, 96);
            this.lbl4Panel3.Name = "lbl4Panel3";
            this.lbl4Panel3.Size = new System.Drawing.Size(21, 13);
            this.lbl4Panel3.TabIndex = 12;
            this.lbl4Panel3.Text = "IR:";
            // 
            // lbl3Panel3
            // 
            this.lbl3Panel3.AutoSize = true;
            this.lbl3Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl3Panel3.Location = new System.Drawing.Point(3, 68);
            this.lbl3Panel3.Name = "lbl3Panel3";
            this.lbl3Panel3.Size = new System.Drawing.Size(28, 13);
            this.lbl3Panel3.TabIndex = 11;
            this.lbl3Panel3.Text = "TIR:";
            // 
            // lbl2Panel3
            // 
            this.lbl2Panel3.AutoSize = true;
            this.lbl2Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl2Panel3.Location = new System.Drawing.Point(3, 41);
            this.lbl2Panel3.Name = "lbl2Panel3";
            this.lbl2Panel3.Size = new System.Drawing.Size(32, 13);
            this.lbl2Panel3.TabIndex = 10;
            this.lbl2Panel3.Text = "VAN:";
            // 
            // GrafPlot
            // 
            this.GrafPlot.Location = new System.Drawing.Point(12, 267);
            this.GrafPlot.Name = "GrafPlot";
            this.GrafPlot.Size = new System.Drawing.Size(462, 263);
            this.GrafPlot.TabIndex = 8;
            // 
            // dvgVariaciones
            // 
            this.dvgVariaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgVariaciones.Location = new System.Drawing.Point(489, 280);
            this.dvgVariaciones.Name = "dvgVariaciones";
            this.dvgVariaciones.Size = new System.Drawing.Size(448, 236);
            this.dvgVariaciones.TabIndex = 9;
            this.dvgVariaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmCompararEscenarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 548);
            this.Controls.Add(this.dvgVariaciones);
            this.Controls.Add(this.GrafPlot);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAlternativaB);
            this.Controls.Add(this.cmbAlternativaA);
            this.Controls.Add(this.cmbEscenarioBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompararEscenarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar Escenarios";
            this.Load += new System.EventHandler(this.frmCompararEscenarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgVariaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbEscenarioBase;
        private System.Windows.Forms.ComboBox cmbAlternativaA;
        private System.Windows.Forms.ComboBox cmbAlternativaB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl5Panel1;
        private System.Windows.Forms.Label lbl4Panel1;
        private System.Windows.Forms.Label lbl3Panel1;
        private System.Windows.Forms.Label lbl2Panel1;
        private System.Windows.Forms.Label lbl1Panel1;
        private System.Windows.Forms.Label lbl1Panel2;
        private System.Windows.Forms.Label lbl5Panel2;
        private System.Windows.Forms.Label lbl2Panel2;
        private System.Windows.Forms.Label lbl4Panel2;
        private System.Windows.Forms.Label lbl3Panel2;
        private System.Windows.Forms.Label lbl1Panel3;
        private System.Windows.Forms.Label lbl5Panel3;
        private System.Windows.Forms.Label lbl2Panel3;
        private System.Windows.Forms.Label lbl4Panel3;
        private System.Windows.Forms.Label lbl3Panel3;
        private ScottPlot.WinForms.FormsPlot GrafPlot;
        private System.Windows.Forms.DataGridView dvgVariaciones;
    }
}