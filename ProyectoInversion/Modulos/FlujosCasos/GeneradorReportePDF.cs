using System;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ProyectoInversion.Modulos.FlujosCasos
{
    internal class GeneradorReportePDF
    {
        private readonly Color COLOR_HEADER = new DeviceRgb(10, 10, 10);
        private readonly Color COLOR_SECCION = new DeviceRgb(85, 78, 78);
        private readonly Color COLOR_INV_BG = new DeviceRgb(255, 235, 238);
        private readonly Color COLOR_INV_FG = new DeviceRgb(183, 28, 28);
        private readonly Color COLOR_IND_BG = new DeviceRgb(255, 253, 231);
        private readonly Color COLOR_FLUJO_POS = new DeviceRgb(10, 10, 10);
        private readonly Color COLOR_FLUJO_NEG = new DeviceRgb(183, 28, 28);
        private readonly Color COLOR_GRIS_CLARO = new DeviceRgb(245, 245, 245);

        public void Generar(string rutaArchivo, DataGridView grid, string nombreSimulacion)
        {
            string rutaLogo = System.IO.Path.Combine(Application.StartupPath, "Resources", "Images", "Logo_Finanzas.png");

            using (var writer = new PdfWriter(rutaArchivo))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4))
            {
                PdfFont fontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                PdfFont fontHelveticaBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                document.SetFont(fontHelvetica);
                document.SetMargins(40, 40, 40, 40);

                // ── 1. ENCABEZADO: Logo y Títulos a la par ────────
                var headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 2, 8 }))
                    .UseAllAvailableWidth();

                // LOGO
                var logoCell = new Cell()
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);

                if (System.IO.File.Exists(rutaLogo))
                {
                    var imageData = ImageDataFactory.Create(rutaLogo);
                    var img = new Image(imageData).ScaleToFit(130, 55);
                    logoCell.Add(img);
                }
                else
                {
                    logoCell.Add(new Paragraph("ProyectoInversión").SetFontSize(14).SetFontColor(COLOR_HEADER));
                }

                // ── 2. TÍTULO PRINCIPAL ───────────────────────────────────
                var titleCell = new Cell().SetBorder(Border.NO_BORDER).SetVerticalAlignment(VerticalAlignment.MIDDLE);
                
                titleCell.Add(new Paragraph("REPORTE DE FLUJOS DE CAJA")
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(20).SetFont(fontHelveticaBold)
                    .SetFontColor(COLOR_HEADER)
                    .SetMarginBottom(0));

                titleCell.Add(new Paragraph(nombreSimulacion)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(12).SetFont(fontHelveticaBold)
                    .SetFontColor(new DeviceRgb(80, 80, 80))
                    .SetMarginBottom(10));

                headerTable.AddCell(logoCell);
                headerTable.AddCell(titleCell);
                document.Add(headerTable);

                // ── Línea separadora ─────────────────────────────────────
                document.Add(new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine(1f))
                        .SetMarginTop(5).SetMarginBottom(15));

                // ── 3. TABLA DE DATOS ─────────────────────────────────────
                int colsVisibles = grid.Columns.Count - 1;

                float[] anchos = colsVisibles == 4
                    ? new float[] { 3f, 2f, 2f, 2f }
                    : new float[] { 3f, 2f, 2f };

                var tabla = new Table(UnitValue.CreatePercentArray(anchos))
                    .UseAllAvailableWidth();

                // Cabecera de la tabla
                for (int i = 1; i < grid.Columns.Count; i++)
                {
                    tabla.AddHeaderCell(new Cell()
                        .Add(new Paragraph(grid.Columns[i].HeaderText)
                            .SetFontSize(9)).SetFont(fontHelveticaBold)
                        .SetBackgroundColor(COLOR_HEADER)
                        .SetFontColor(ColorConstants.WHITE)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPaddingTop(6).SetPaddingBottom(6));
                }

                // Filas de datos
                bool filaAlterna = false;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;

                    string tipo = row.Cells[0].Value?.ToString() ?? "";

                    if (tipo == "SECCION")
                    {
                        string textoSeccion = row.Cells[1].Value?.ToString() ?? "";

                        var celdaSeccion = new Cell(1, colsVisibles)
                            .Add(new Paragraph(textoSeccion)
                                .SetFontSize(9)).SetFont(fontHelveticaBold)
                            .SetBackgroundColor(COLOR_SECCION)
                            .SetFontColor(ColorConstants.WHITE)
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetPaddingTop(5).SetPaddingBottom(5);

                        tabla.AddCell(celdaSeccion);
                        filaAlterna = false;
                        continue;
                    }

                    Color bgFila = tipo == "INVERSION" ? COLOR_INV_BG
                                 : tipo == "INDICADOR" ? COLOR_IND_BG
                                 : filaAlterna ? COLOR_GRIS_CLARO
                                 : ColorConstants.WHITE;

                    if (tipo == "FLUJO") filaAlterna = !filaAlterna;

                    for (int i = 1; i < grid.Columns.Count; i++)
                    {
                        string valor = row.Cells[i].Value?.ToString() ?? "";
                        bool esCelda0 = (i == 1); // columna Concepto

                        var celda = new Cell()
                            .Add(new Paragraph(valor).SetFontSize(9))
                            .SetBackgroundColor(bgFila)
                            .SetPaddingTop(4).SetPaddingBottom(4)
                            .SetTextAlignment(esCelda0
                                ? TextAlignment.LEFT
                                : TextAlignment.CENTER);

                        // Estilos adicionales por tipo
                        switch (tipo)
                        {
                            case "INVERSION":
                                celda.SetFontColor(COLOR_INV_FG);
                                if (esCelda0);
                                break;

                            case "FLUJO":
                                if (!esCelda0)
                                {
                                    bool negativo = valor.Contains("-");
                                    celda.SetFontColor(negativo ? COLOR_FLUJO_NEG : COLOR_FLUJO_POS);
                                }
                                break;

                            case "INDICADOR":
                                if (esCelda0);
                                break;
                        }

                        tabla.AddCell(celda);
                    }
                }

                document.Add(tabla);

                int totalPaginas = pdf.GetNumberOfPages();
                for (int i = 1; i <= totalPaginas; i++)
                {
                    document.ShowTextAligned(
                        new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}").SetFontSize(9).SetFontColor(new DeviceRgb(100, 100, 100)),
                        40, 20, i, TextAlignment.LEFT, VerticalAlignment.BOTTOM, 0
                    );

                    document.ShowTextAligned(
                    new Paragraph($"Página: {totalPaginas}").SetFontSize(9).SetFontColor(new DeviceRgb(100, 100, 100)),
                    pdf.GetDefaultPageSize().GetWidth() - 40, 20, totalPaginas, TextAlignment.RIGHT, VerticalAlignment.BOTTOM, 0);
                }    
            }
        }
    }
}
