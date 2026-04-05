using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoInversion.Modulos.FlujosCasos
{
    public partial class frmFlujosCasos
    {
        private const string COL_TIPO = "TipoFila";
        private const string COL_CONCEPTO = "Concepto";
        private const string COL_BASE = "ColBase";
        private const string COL_PES = "ColPesimista";
        private const string COL_OPT = "ColOptimista";


        private static readonly Color C_HEADER_BG = Color.FromArgb(13, 71, 161);
        private static readonly Color C_HEADER_FG = Color.White;

        private static readonly Color C_SECCION_BG = Color.FromArgb(21, 41, 82);
        private static readonly Color C_SECCION_FG = Color.White;

        private static readonly Color C_INV_BG = Color.FromArgb(255, 235, 238);
        private static readonly Color C_INV_FG = Color.FromArgb(183, 28, 28);

        private static readonly Color C_FLUJO_FG_POS = Color.FromArgb(13, 71, 161);
        private static readonly Color C_FLUJO_FG_NEG = Color.FromArgb(183, 28, 28);

        private static readonly Color C_INDICADOR_BG = Color.FromArgb(255, 253, 231);
        private static readonly Color C_INDICADOR_FG = Color.FromArgb(33, 33, 33);


        private void ConfigurarDataGridView()
        {
            dvgFlujos.AutoGenerateColumns = false;
            dvgFlujos.Columns.Clear();

            dvgFlujos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_TIPO,
                DataPropertyName = COL_TIPO,
                Visible = false
            });

            dvgFlujos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = COL_CONCEPTO,
                DataPropertyName = COL_CONCEPTO,
                HeaderText = "Concepto",
                FillWeight = 30,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Padding   = new Padding(10, 0, 0, 0)
                }
            });
            dvgFlujos.Columns.Add(CrearColumnaValor(COL_BASE, "Escenario Base"));
            dvgFlujos.Columns.Add(CrearColumnaValor(COL_PES, "Escenario Pesimista"));
            dvgFlujos.Columns.Add(CrearColumnaValor(COL_OPT, "Escenario Optimista"));

            var hs = dvgFlujos.ColumnHeadersDefaultCellStyle;
            hs.BackColor = C_HEADER_BG;
            hs.ForeColor = C_HEADER_FG;
            hs.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            hs.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dvgFlujos.ColumnHeadersDefaultCellStyle = hs;

            dvgFlujos.Columns[COL_CONCEPTO].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dvgFlujos.Columns[COL_CONCEPTO].HeaderCell.Style.Padding =
                new Padding(10, 0, 0, 0);
        }
        private static DataGridViewTextBoxColumn CrearColumnaValor(string name, string header)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                DataPropertyName = name,
                HeaderText = header,
                FillWeight = 23,          // las 3 columnas tienen el mismo peso
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter  // ← centrado
                }
            };
        }

        private void dvgFlujos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            DataGridViewRow fila = dvgFlujos.Rows[e.RowIndex];
            string tipo = fila.Cells[COL_TIPO].Value?.ToString() ?? "";

            bool esColumnaValor = dvgFlujos.Columns[e.ColumnIndex].Name != COL_TIPO
                                  && dvgFlujos.Columns[e.ColumnIndex].Name != COL_CONCEPTO;

            if ((tipo == "FLUJO" || tipo == "INVERSION") && esColumnaValor && e.Value != null)
            {
                bool esNegativo = e.Value.ToString().Contains("-");
                e.CellStyle.ForeColor = esNegativo ? C_FLUJO_FG_NEG : C_FLUJO_FG_POS;
                e.FormattingApplied = true;
            }

            if (tipo == "INVERSION")
            {
                e.CellStyle.BackColor = C_INV_BG;
                e.CellStyle.ForeColor = C_INV_FG;
                e.CellStyle.Font = new Font(dvgFlujos.Font, FontStyle.Bold);
                e.FormattingApplied = true;
            }

            if (tipo == "INDICADOR")
            {
                e.CellStyle.BackColor = C_INDICADOR_BG;
                e.CellStyle.ForeColor = C_INDICADOR_FG;
                e.FormattingApplied = true;
            }
        }
        private void dvgFlujos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dvgFlujos.Rows[e.RowIndex];
            string tipo = fila.Cells[COL_TIPO].Value?.ToString() ?? "";

            if (tipo == "SECCION")
            {
                fila.DefaultCellStyle.BackColor = C_SECCION_BG;
                fila.DefaultCellStyle.ForeColor = C_SECCION_FG;
                fila.DefaultCellStyle.Font = new Font(dvgFlujos.Font, FontStyle.Bold);
                fila.DefaultCellStyle.SelectionBackColor = C_SECCION_BG;
                fila.DefaultCellStyle.SelectionForeColor = C_SECCION_FG;
            }
        }
        private static string FormatearMoneda(DataRow r, string col)
        {
            if (r[col] == DBNull.Value) return "—";
            decimal v = Convert.ToDecimal(r[col]);
            return $"${v:N2}";
        }
        private static string FormatearPorcentaje(DataRow r, string col)
        {
            if (r[col] == DBNull.Value) return "—";
            decimal v = Convert.ToDecimal(r[col]) * 100m; // BD guarda 0.146052
            return $"{v:N4} %";
        }
        private static string FormatearDecimal(DataRow r, string col)
        {
            if (r[col] == DBNull.Value) return "—";
            decimal v = Convert.ToDecimal(r[col]);
            return $"{v:N4}";
        }
    }
}
