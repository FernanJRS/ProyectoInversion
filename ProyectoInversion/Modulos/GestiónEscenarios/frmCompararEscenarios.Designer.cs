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
            this.pnlAltBase = new System.Windows.Forms.Panel();
            this.lbl1Panel1 = new System.Windows.Forms.Label();
            this.lbl5Panel1 = new System.Windows.Forms.Label();
            this.lbl4Panel1 = new System.Windows.Forms.Label();
            this.lbl3Panel1 = new System.Windows.Forms.Label();
            this.lbl2Panel1 = new System.Windows.Forms.Label();
            this.pnlAltA = new System.Windows.Forms.Panel();
            this.lbl1Panel2 = new System.Windows.Forms.Label();
            this.lbl5Panel2 = new System.Windows.Forms.Label();
            this.lbl2Panel2 = new System.Windows.Forms.Label();
            this.lbl4Panel2 = new System.Windows.Forms.Label();
            this.lbl3Panel2 = new System.Windows.Forms.Label();
            this.pnlAltB = new System.Windows.Forms.Panel();
            this.lbl1Panel3 = new System.Windows.Forms.Label();
            this.lbl5Panel3 = new System.Windows.Forms.Label();
            this.lbl2Panel3 = new System.Windows.Forms.Label();
            this.lbl4Panel3 = new System.Windows.Forms.Label();
            this.lbl3Panel3 = new System.Windows.Forms.Label();
            this.GrafPlot = new ScottPlot.WinForms.FormsPlot();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.rdoBtnVAN = new System.Windows.Forms.RadioButton();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.rdoBtnIR = new System.Windows.Forms.RadioButton();
            this.rdoBtnTIR = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pnlAltBase.SuspendLayout();
            this.pnlAltA.SuspendLayout();
            this.pnlAltB.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbEscenarioBase
            // 
            this.cmbEscenarioBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEscenarioBase.Enabled = false;
            this.cmbEscenarioBase.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbEscenarioBase.FormattingEnabled = true;
            this.cmbEscenarioBase.Location = new System.Drawing.Point(21, 72);
            this.cmbEscenarioBase.Name = "cmbEscenarioBase";
            this.cmbEscenarioBase.Size = new System.Drawing.Size(200, 21);
            this.cmbEscenarioBase.TabIndex = 0;
            this.cmbEscenarioBase.SelectedIndexChanged += new System.EventHandler(this.cmbEscenarioBase_SelectedIndexChanged);
            // 
            // cmbAlternativaA
            // 
            this.cmbAlternativaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlternativaA.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbAlternativaA.FormattingEnabled = true;
            this.cmbAlternativaA.Location = new System.Drawing.Point(272, 72);
            this.cmbAlternativaA.Name = "cmbAlternativaA";
            this.cmbAlternativaA.Size = new System.Drawing.Size(200, 21);
            this.cmbAlternativaA.TabIndex = 1;
            // 
            // cmbAlternativaB
            // 
            this.cmbAlternativaB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlternativaB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbAlternativaB.FormattingEnabled = true;
            this.cmbAlternativaB.Location = new System.Drawing.Point(519, 72);
            this.cmbAlternativaB.Name = "cmbAlternativaB";
            this.cmbAlternativaB.Size = new System.Drawing.Size(200, 21);
            this.cmbAlternativaB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(73, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Escenario Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(332, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alternativa A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(580, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alternativa B";
            // 
            // pnlAltBase
            // 
            this.pnlAltBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(158)))));
            this.pnlAltBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAltBase.Controls.Add(this.lbl1Panel1);
            this.pnlAltBase.Controls.Add(this.lbl5Panel1);
            this.pnlAltBase.Controls.Add(this.lbl4Panel1);
            this.pnlAltBase.Controls.Add(this.lbl3Panel1);
            this.pnlAltBase.Controls.Add(this.lbl2Panel1);
            this.pnlAltBase.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.pnlAltBase.Location = new System.Drawing.Point(21, 110);
            this.pnlAltBase.Name = "pnlAltBase";
            this.pnlAltBase.Size = new System.Drawing.Size(200, 159);
            this.pnlAltBase.TabIndex = 6;
            this.pnlAltBase.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.pnlAltBase.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.pnlAltBase.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // lbl1Panel1
            // 
            this.lbl1Panel1.AutoSize = true;
            this.lbl1Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl1Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl1Panel1.Location = new System.Drawing.Point(3, 14);
            this.lbl1Panel1.Name = "lbl1Panel1";
            this.lbl1Panel1.Size = new System.Drawing.Size(119, 17);
            this.lbl1Panel1.TabIndex = 4;
            this.lbl1Panel1.Text = "Tasa de Inversión:";
            // 
            // lbl5Panel1
            // 
            this.lbl5Panel1.AutoSize = true;
            this.lbl5Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl5Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl5Panel1.Location = new System.Drawing.Point(3, 124);
            this.lbl5Panel1.Name = "lbl5Panel1";
            this.lbl5Panel1.Size = new System.Drawing.Size(69, 17);
            this.lbl5Panel1.TabIndex = 3;
            this.lbl5Panel1.Text = "Inversión:";
            // 
            // lbl4Panel1
            // 
            this.lbl4Panel1.AutoSize = true;
            this.lbl4Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl4Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl4Panel1.Location = new System.Drawing.Point(3, 96);
            this.lbl4Panel1.Name = "lbl4Panel1";
            this.lbl4Panel1.Size = new System.Drawing.Size(24, 17);
            this.lbl4Panel1.TabIndex = 2;
            this.lbl4Panel1.Text = "IR:";
            // 
            // lbl3Panel1
            // 
            this.lbl3Panel1.AutoSize = true;
            this.lbl3Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl3Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl3Panel1.Location = new System.Drawing.Point(3, 68);
            this.lbl3Panel1.Name = "lbl3Panel1";
            this.lbl3Panel1.Size = new System.Drawing.Size(32, 17);
            this.lbl3Panel1.TabIndex = 1;
            this.lbl3Panel1.Text = "TIR:";
            // 
            // lbl2Panel1
            // 
            this.lbl2Panel1.AutoSize = true;
            this.lbl2Panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl2Panel1.ForeColor = System.Drawing.Color.White;
            this.lbl2Panel1.Location = new System.Drawing.Point(3, 41);
            this.lbl2Panel1.Name = "lbl2Panel1";
            this.lbl2Panel1.Size = new System.Drawing.Size(39, 17);
            this.lbl2Panel1.TabIndex = 0;
            this.lbl2Panel1.Text = "VAN:";
            // 
            // pnlAltA
            // 
            this.pnlAltA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(158)))));
            this.pnlAltA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAltA.Controls.Add(this.lbl1Panel2);
            this.pnlAltA.Controls.Add(this.lbl5Panel2);
            this.pnlAltA.Controls.Add(this.lbl2Panel2);
            this.pnlAltA.Controls.Add(this.lbl4Panel2);
            this.pnlAltA.Controls.Add(this.lbl3Panel2);
            this.pnlAltA.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.pnlAltA.Location = new System.Drawing.Point(272, 110);
            this.pnlAltA.Name = "pnlAltA";
            this.pnlAltA.Size = new System.Drawing.Size(200, 159);
            this.pnlAltA.TabIndex = 7;
            this.pnlAltA.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.pnlAltA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            this.pnlAltA.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.pnlAltA.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // lbl1Panel2
            // 
            this.lbl1Panel2.AutoSize = true;
            this.lbl1Panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl1Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl1Panel2.Location = new System.Drawing.Point(3, 14);
            this.lbl1Panel2.Name = "lbl1Panel2";
            this.lbl1Panel2.Size = new System.Drawing.Size(119, 17);
            this.lbl1Panel2.TabIndex = 9;
            this.lbl1Panel2.Text = "Tasa de Inversión:";
            // 
            // lbl5Panel2
            // 
            this.lbl5Panel2.AutoSize = true;
            this.lbl5Panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl5Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl5Panel2.Location = new System.Drawing.Point(3, 124);
            this.lbl5Panel2.Name = "lbl5Panel2";
            this.lbl5Panel2.Size = new System.Drawing.Size(69, 17);
            this.lbl5Panel2.TabIndex = 8;
            this.lbl5Panel2.Text = "Inversión:";
            // 
            // lbl2Panel2
            // 
            this.lbl2Panel2.AutoSize = true;
            this.lbl2Panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl2Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl2Panel2.Location = new System.Drawing.Point(3, 41);
            this.lbl2Panel2.Name = "lbl2Panel2";
            this.lbl2Panel2.Size = new System.Drawing.Size(39, 17);
            this.lbl2Panel2.TabIndex = 5;
            this.lbl2Panel2.Text = "VAN:";
            // 
            // lbl4Panel2
            // 
            this.lbl4Panel2.AutoSize = true;
            this.lbl4Panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl4Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl4Panel2.Location = new System.Drawing.Point(3, 96);
            this.lbl4Panel2.Name = "lbl4Panel2";
            this.lbl4Panel2.Size = new System.Drawing.Size(24, 17);
            this.lbl4Panel2.TabIndex = 7;
            this.lbl4Panel2.Text = "IR:";
            // 
            // lbl3Panel2
            // 
            this.lbl3Panel2.AutoSize = true;
            this.lbl3Panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl3Panel2.ForeColor = System.Drawing.Color.White;
            this.lbl3Panel2.Location = new System.Drawing.Point(3, 68);
            this.lbl3Panel2.Name = "lbl3Panel2";
            this.lbl3Panel2.Size = new System.Drawing.Size(32, 17);
            this.lbl3Panel2.TabIndex = 6;
            this.lbl3Panel2.Text = "TIR:";
            // 
            // pnlAltB
            // 
            this.pnlAltB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(158)))));
            this.pnlAltB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAltB.Controls.Add(this.lbl1Panel3);
            this.pnlAltB.Controls.Add(this.lbl5Panel3);
            this.pnlAltB.Controls.Add(this.lbl2Panel3);
            this.pnlAltB.Controls.Add(this.lbl4Panel3);
            this.pnlAltB.Controls.Add(this.lbl3Panel3);
            this.pnlAltB.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.pnlAltB.Location = new System.Drawing.Point(519, 110);
            this.pnlAltB.Name = "pnlAltB";
            this.pnlAltB.Size = new System.Drawing.Size(200, 159);
            this.pnlAltB.TabIndex = 7;
            this.pnlAltB.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.pnlAltB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            this.pnlAltB.MouseEnter += new System.EventHandler(this.panel3_MouseEnter);
            this.pnlAltB.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            // 
            // lbl1Panel3
            // 
            this.lbl1Panel3.AutoSize = true;
            this.lbl1Panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl1Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl1Panel3.Location = new System.Drawing.Point(3, 14);
            this.lbl1Panel3.Name = "lbl1Panel3";
            this.lbl1Panel3.Size = new System.Drawing.Size(119, 17);
            this.lbl1Panel3.TabIndex = 14;
            this.lbl1Panel3.Text = "Tasa de Inversión:";
            // 
            // lbl5Panel3
            // 
            this.lbl5Panel3.AutoSize = true;
            this.lbl5Panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl5Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl5Panel3.Location = new System.Drawing.Point(3, 124);
            this.lbl5Panel3.Name = "lbl5Panel3";
            this.lbl5Panel3.Size = new System.Drawing.Size(69, 17);
            this.lbl5Panel3.TabIndex = 13;
            this.lbl5Panel3.Text = "Inversión:";
            // 
            // lbl2Panel3
            // 
            this.lbl2Panel3.AutoSize = true;
            this.lbl2Panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl2Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl2Panel3.Location = new System.Drawing.Point(3, 41);
            this.lbl2Panel3.Name = "lbl2Panel3";
            this.lbl2Panel3.Size = new System.Drawing.Size(39, 17);
            this.lbl2Panel3.TabIndex = 10;
            this.lbl2Panel3.Text = "VAN:";
            // 
            // lbl4Panel3
            // 
            this.lbl4Panel3.AutoSize = true;
            this.lbl4Panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl4Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl4Panel3.Location = new System.Drawing.Point(3, 96);
            this.lbl4Panel3.Name = "lbl4Panel3";
            this.lbl4Panel3.Size = new System.Drawing.Size(24, 17);
            this.lbl4Panel3.TabIndex = 12;
            this.lbl4Panel3.Text = "IR:";
            // 
            // lbl3Panel3
            // 
            this.lbl3Panel3.AutoSize = true;
            this.lbl3Panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl3Panel3.ForeColor = System.Drawing.Color.White;
            this.lbl3Panel3.Location = new System.Drawing.Point(3, 68);
            this.lbl3Panel3.Name = "lbl3Panel3";
            this.lbl3Panel3.Size = new System.Drawing.Size(32, 17);
            this.lbl3Panel3.TabIndex = 11;
            this.lbl3Panel3.Text = "TIR:";
            // 
            // GrafPlot
            // 
            this.GrafPlot.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.GrafPlot.Location = new System.Drawing.Point(76, 297);
            this.GrafPlot.Name = "GrafPlot";
            this.GrafPlot.Size = new System.Drawing.Size(485, 263);
            this.GrafPlot.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(749, 35);
            this.panel4.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(200, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(361, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "COMPARACIÓN DE ALTERNATIVAS";
            // 
            // rdoBtnVAN
            // 
            this.rdoBtnVAN.AutoSize = true;
            this.rdoBtnVAN.Checked = true;
            this.rdoBtnVAN.Location = new System.Drawing.Point(4, 17);
            this.rdoBtnVAN.Margin = new System.Windows.Forms.Padding(2);
            this.rdoBtnVAN.Name = "rdoBtnVAN";
            this.rdoBtnVAN.Size = new System.Drawing.Size(46, 17);
            this.rdoBtnVAN.TabIndex = 10;
            this.rdoBtnVAN.TabStop = true;
            this.rdoBtnVAN.Text = "VAN";
            this.rdoBtnVAN.UseVisualStyleBackColor = true;
            this.rdoBtnVAN.CheckedChanged += new System.EventHandler(this.rbIndicador_CheckedChanged);
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.rdoBtnIR);
            this.grpBox1.Controls.Add(this.rdoBtnTIR);
            this.grpBox1.Controls.Add(this.rdoBtnVAN);
            this.grpBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grpBox1.Location = new System.Drawing.Point(574, 298);
            this.grpBox1.Margin = new System.Windows.Forms.Padding(2);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Padding = new System.Windows.Forms.Padding(2);
            this.grpBox1.Size = new System.Drawing.Size(100, 112);
            this.grpBox1.TabIndex = 11;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "Indicador";
            // 
            // rdoBtnIR
            // 
            this.rdoBtnIR.AutoSize = true;
            this.rdoBtnIR.Location = new System.Drawing.Point(4, 59);
            this.rdoBtnIR.Margin = new System.Windows.Forms.Padding(2);
            this.rdoBtnIR.Name = "rdoBtnIR";
            this.rdoBtnIR.Size = new System.Drawing.Size(35, 17);
            this.rdoBtnIR.TabIndex = 12;
            this.rdoBtnIR.Text = "IR";
            this.rdoBtnIR.UseVisualStyleBackColor = true;
            this.rdoBtnIR.CheckedChanged += new System.EventHandler(this.rbIndicador_CheckedChanged);
            // 
            // rdoBtnTIR
            // 
            this.rdoBtnTIR.AutoSize = true;
            this.rdoBtnTIR.Location = new System.Drawing.Point(4, 38);
            this.rdoBtnTIR.Margin = new System.Windows.Forms.Padding(2);
            this.rdoBtnTIR.Name = "rdoBtnTIR";
            this.rdoBtnTIR.Size = new System.Drawing.Size(40, 17);
            this.rdoBtnTIR.TabIndex = 11;
            this.rdoBtnTIR.Text = "TIR";
            this.rdoBtnTIR.UseVisualStyleBackColor = true;
            this.rdoBtnTIR.CheckedChanged += new System.EventHandler(this.rbIndicador_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.button1.Location = new System.Drawing.Point(576, 506);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnEliminar.Location = new System.Drawing.Point(576, 535);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(143, 24);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmCompararEscenarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 570);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.GrafPlot);
            this.Controls.Add(this.pnlAltB);
            this.Controls.Add(this.pnlAltA);
            this.Controls.Add(this.pnlAltBase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAlternativaB);
            this.Controls.Add(this.cmbAlternativaA);
            this.Controls.Add(this.cmbEscenarioBase);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompararEscenarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar Escenarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCompararEscenarios_FormClosing);
            this.Load += new System.EventHandler(this.frmCompararEscenarios_Load);
            this.Shown += new System.EventHandler(this.frmCompararEscenarios_Shown);
            this.pnlAltBase.ResumeLayout(false);
            this.pnlAltBase.PerformLayout();
            this.pnlAltA.ResumeLayout(false);
            this.pnlAltA.PerformLayout();
            this.pnlAltB.ResumeLayout(false);
            this.pnlAltB.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grpBox1.ResumeLayout(false);
            this.grpBox1.PerformLayout();
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
        private System.Windows.Forms.Panel pnlAltBase;
        private System.Windows.Forms.Panel pnlAltA;
        private System.Windows.Forms.Panel pnlAltB;
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoBtnVAN;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.RadioButton rdoBtnIR;
        private System.Windows.Forms.RadioButton rdoBtnTIR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEliminar;
    }
}