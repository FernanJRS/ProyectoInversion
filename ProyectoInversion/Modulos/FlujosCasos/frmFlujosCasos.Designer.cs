namespace ProyectoInversion.Modulos.FlujosCasos
{
    partial class frmFlujosCasos
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
            this.dvgFlujos = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFila = new System.Windows.Forms.Panel();
            this.cboOptimista = new System.Windows.Forms.ComboBox();
            this.cboPesimista = new System.Windows.Forms.ComboBox();
            this.cboBase = new System.Windows.Forms.ComboBox();
            this.lblOptLabel = new System.Windows.Forms.Label();
            this.lblPesLabel = new System.Windows.Forms.Label();
            this.lblBaseLabel = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFlujos)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFila.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgFlujos
            // 
            this.dvgFlujos.AllowUserToAddRows = false;
            this.dvgFlujos.AllowUserToDeleteRows = false;
            this.dvgFlujos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgFlujos.BackgroundColor = System.Drawing.Color.White;
            this.dvgFlujos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgFlujos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dvgFlujos.ColumnHeadersHeight = 26;
            this.dvgFlujos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dvgFlujos.EnableHeadersVisualStyles = false;
            this.dvgFlujos.Location = new System.Drawing.Point(0, 131);
            this.dvgFlujos.Name = "dvgFlujos";
            this.dvgFlujos.ReadOnly = true;
            this.dvgFlujos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgFlujos.Size = new System.Drawing.Size(782, 467);
            this.dvgFlujos.TabIndex = 0;
            this.dvgFlujos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dvgFlujos_CellFormatting);
            this.dvgFlujos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dvgFlujos_RowPrePaint);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(782, 32);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(200, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(381, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "COMPARACIÓN DE ALTERNATIVAS - FLUJO DE CAJA";
            // 
            // pnlFila
            // 
            this.pnlFila.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlFila.Controls.Add(this.cboOptimista);
            this.pnlFila.Controls.Add(this.cboPesimista);
            this.pnlFila.Controls.Add(this.cboBase);
            this.pnlFila.Controls.Add(this.lblOptLabel);
            this.pnlFila.Controls.Add(this.lblPesLabel);
            this.pnlFila.Controls.Add(this.lblBaseLabel);
            this.pnlFila.Location = new System.Drawing.Point(0, 29);
            this.pnlFila.Name = "pnlFila";
            this.pnlFila.Size = new System.Drawing.Size(782, 55);
            this.pnlFila.TabIndex = 2;
            // 
            // cboOptimista
            // 
            this.cboOptimista.FormattingEnabled = true;
            this.cboOptimista.Location = new System.Drawing.Point(598, 19);
            this.cboOptimista.Name = "cboOptimista";
            this.cboOptimista.Size = new System.Drawing.Size(145, 21);
            this.cboOptimista.TabIndex = 5;
            // 
            // cboPesimista
            // 
            this.cboPesimista.FormattingEnabled = true;
            this.cboPesimista.Location = new System.Drawing.Point(344, 19);
            this.cboPesimista.Name = "cboPesimista";
            this.cboPesimista.Size = new System.Drawing.Size(145, 21);
            this.cboPesimista.TabIndex = 4;
            // 
            // cboBase
            // 
            this.cboBase.FormattingEnabled = true;
            this.cboBase.Location = new System.Drawing.Point(92, 19);
            this.cboBase.Name = "cboBase";
            this.cboBase.Size = new System.Drawing.Size(145, 21);
            this.cboBase.TabIndex = 3;
            // 
            // lblOptLabel
            // 
            this.lblOptLabel.AutoSize = true;
            this.lblOptLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.lblOptLabel.Location = new System.Drawing.Point(509, 21);
            this.lblOptLabel.Name = "lblOptLabel";
            this.lblOptLabel.Size = new System.Drawing.Size(83, 15);
            this.lblOptLabel.TabIndex = 2;
            this.lblOptLabel.Text = "Alternativa B:";
            // 
            // lblPesLabel
            // 
            this.lblPesLabel.AutoSize = true;
            this.lblPesLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.lblPesLabel.Location = new System.Drawing.Point(255, 21);
            this.lblPesLabel.Name = "lblPesLabel";
            this.lblPesLabel.Size = new System.Drawing.Size(83, 15);
            this.lblPesLabel.TabIndex = 1;
            this.lblPesLabel.Text = "Alternativa A:";
            // 
            // lblBaseLabel
            // 
            this.lblBaseLabel.AutoSize = true;
            this.lblBaseLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.lblBaseLabel.Location = new System.Drawing.Point(50, 21);
            this.lblBaseLabel.Name = "lblBaseLabel";
            this.lblBaseLabel.Size = new System.Drawing.Size(36, 15);
            this.lblBaseLabel.TabIndex = 0;
            this.lblBaseLabel.Text = "Base:";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.btnExportar);
            this.pnlGrid.Controls.Add(this.btnActualizar);
            this.pnlGrid.Location = new System.Drawing.Point(0, 81);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(782, 44);
            this.pnlGrid.TabIndex = 3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(204, 9);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(140, 28);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(428, 9);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(140, 28);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmFlujosCasos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFila);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dvgFlujos);
            this.Name = "frmFlujosCasos";
            this.Text = "Flujos de Caja";
            this.Load += new System.EventHandler(this.frmFlujosCasos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgFlujos)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFila.ResumeLayout(false);
            this.pnlFila.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgFlujos;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFila;
        private System.Windows.Forms.ComboBox cboPesimista;
        private System.Windows.Forms.ComboBox cboBase;
        private System.Windows.Forms.Label lblOptLabel;
        private System.Windows.Forms.Label lblPesLabel;
        private System.Windows.Forms.Label lblBaseLabel;
        private System.Windows.Forms.ComboBox cboOptimista;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnExportar;
    }
}