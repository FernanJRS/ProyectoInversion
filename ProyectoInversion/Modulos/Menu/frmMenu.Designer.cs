namespace ProyectoInversion.Modulos.Menu
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.escenarioBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compararEscenariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escenarioPesimistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escenarioOptimistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escenarioBaseToolStripMenuItem,
            this.escenarioPesimistaToolStripMenuItem,
            this.escenarioOptimistaToolStripMenuItem,
            this.sistemaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // escenarioBaseToolStripMenuItem
            // 
            this.escenarioBaseToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.escenarioBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compararEscenariosToolStripMenuItem});
            this.escenarioBaseToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioBaseToolStripMenuItem.Name = "escenarioBaseToolStripMenuItem";
            this.escenarioBaseToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.escenarioBaseToolStripMenuItem.Text = "Gestión de Escenarios";
            this.escenarioBaseToolStripMenuItem.Click += new System.EventHandler(this.escenarioBaseToolStripMenuItem_Click);
            // 
            // compararEscenariosToolStripMenuItem
            // 
            this.compararEscenariosToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compararEscenariosToolStripMenuItem.Name = "compararEscenariosToolStripMenuItem";
            this.compararEscenariosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.compararEscenariosToolStripMenuItem.Text = "Comparar Escenarios";
            this.compararEscenariosToolStripMenuItem.Click += new System.EventHandler(this.compararEscenariosToolStripMenuItem_Click);
            // 
            // escenarioPesimistaToolStripMenuItem
            // 
            this.escenarioPesimistaToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.escenarioPesimistaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioPesimistaToolStripMenuItem.Name = "escenarioPesimistaToolStripMenuItem";
            this.escenarioPesimistaToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.escenarioPesimistaToolStripMenuItem.Text = "Análisis Financiero";
            // 
            // escenarioOptimistaToolStripMenuItem
            // 
            this.escenarioOptimistaToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.escenarioOptimistaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioOptimistaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.escenarioOptimistaToolStripMenuItem.Name = "escenarioOptimistaToolStripMenuItem";
            this.escenarioOptimistaToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.escenarioOptimistaToolStripMenuItem.Text = "Riesgo e Incertidumbre";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.sistemaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold);
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(71, 26);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem escenarioBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escenarioPesimistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escenarioOptimistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compararEscenariosToolStripMenuItem;
    }
}