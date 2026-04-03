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
            this.escenarioPesimistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escenarioOptimistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escenarioBaseToolStripMenuItem,
            this.escenarioPesimistaToolStripMenuItem,
            this.escenarioOptimistaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(220, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // escenarioBaseToolStripMenuItem
            // 
            this.escenarioBaseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(230)))), ((int)(((byte)(161)))));
            this.escenarioBaseToolStripMenuItem.Font = new System.Drawing.Font("Stack Sans Headline SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioBaseToolStripMenuItem.Name = "escenarioBaseToolStripMenuItem";
            this.escenarioBaseToolStripMenuItem.Size = new System.Drawing.Size(104, 33);
            this.escenarioBaseToolStripMenuItem.Text = "Escenario Base";
            // 
            // escenarioPesimistaToolStripMenuItem
            // 
            this.escenarioPesimistaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(243)))), ((int)(((byte)(232)))));
            this.escenarioPesimistaToolStripMenuItem.Font = new System.Drawing.Font("Stack Sans Headline SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioPesimistaToolStripMenuItem.Name = "escenarioPesimistaToolStripMenuItem";
            this.escenarioPesimistaToolStripMenuItem.Size = new System.Drawing.Size(132, 33);
            this.escenarioPesimistaToolStripMenuItem.Text = "Escenario Pesimista";
            // 
            // escenarioOptimistaToolStripMenuItem
            // 
            this.escenarioOptimistaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(205)))), ((int)(((byte)(251)))));
            this.escenarioOptimistaToolStripMenuItem.Font = new System.Drawing.Font("Stack Sans Headline SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escenarioOptimistaToolStripMenuItem.Name = "escenarioOptimistaToolStripMenuItem";
            this.escenarioOptimistaToolStripMenuItem.Size = new System.Drawing.Size(132, 33);
            this.escenarioOptimistaToolStripMenuItem.Text = "Escenario Optimista";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(313, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stack Sans Headline", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Evaluación de Proyectos";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem escenarioBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escenarioPesimistaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem escenarioOptimistaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}