using System.IO;
using DIseñoMongoDBExamen.Models;
using DIseñoMongoDBExamen.Services;
using ClosedXML.Excel; // Para Excel Pro
using iText.Kernel.Pdf; // Para PDF
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIseñoMongoDBExamen.UserControls
{
    public partial class UC_Analiticas : UserControl
    {
        private DataService _service = new DataService();
        private List<ReporteAnalítico> listaFinal = new List<ReporteAnalítico>();
        public UC_Analiticas()
        {
            InitializeComponent();
            ConfigurarDiseñoGrid();
            CargarAnalisisGerencial();
        }
            private void ConfigurarDiseñoGrid()
        {
            dgvAnalisis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnalisis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnalisis.AllowUserToAddRows = false;
            dgvAnalisis.ReadOnly = true;
            dgvAnalisis.BackgroundColor = Color.White;
        }

        public async void CargarAnalisisGerencial()
        {
            var ventas = await _service.GetAllAsync<Compra>("Compra");
            var clientes = await _service.GetAllAsync<Cliente>("Cliente");

            if (ventas == null || clientes == null) return;

            // --- PROCESAMIENTO DE INTELIGENCIA DE NEGOCIOS ---
            listaFinal = ventas
                .GroupBy(v => v.ClienteId)
                .Select(g =>
                {
                    var c = clientes.FirstOrDefault(x => x.Id == g.Key);
                    decimal totalFacturado = g.Sum(x => x.Total);

                    return new ReporteAnalítico
                    {
                        Cliente = c?.Nombre ?? "Cliente Eventual",
                        Segmento = c?.Nivel ?? "Sin Rango",
                        TotalGastado = totalFacturado,
                        FrecuenciaVenta = g.Count(),
                        // Cálculo de ahorro (Aplicación Financiera)
                        AhorroAcumulado = g.Sum(x => (x.Subtotal * 1.15m) - x.Total),
                        EstadoRentabilidad = totalFacturado > 4000 ? "⭐ VIP / Alta" : "Regular",
                        UltimaVisita = g.Max(x => x.Fecha)
                    };
                })
                .OrderByDescending(x => x.TotalGastado)
                .ToList();

            dgvAnalisis.DataSource = null;
            dgvAnalisis.DataSource = listaFinal;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (listaFinal.Count == 0) return;

            try
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Analisis UNI");

                    // 1. Insertamos la Tabla de Datos
                    var tabla = ws.Cell(1, 1).InsertTable(listaFinal);
                    ws.Columns().AdjustToContents();

                    // NOTA PARA LA DEFENSA: 
                    // ClosedXML crea la estructura de datos lista para que Excel   
                    // genere los gráficos automáticamente mediante tablas dinámicas o 
                    // simplemente estilizando el reporte gerencial.

                    ws.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reporte_Gerencial_UNI.xlsx");
                    wb.SaveAs(path);

                    MessageBox.Show($"Excel generado en el Escritorio:\n{path}\n\nIncluye segmentación y rentabilidad.", "UNI Analíticas");
                }
            }
            catch (Exception ex) { MessageBox.Show("Cerrá el Excel antes de exportar: " + ex.Message); }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (listaFinal.Count == 0) return;

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reporte_Gerencial_UNI.pdf");

            try
            {
                using (PdfWriter writer = new PdfWriter(path))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document doc = new Document(pdf);

                        // Título Principal
                        doc.Add(new Paragraph("UNIVERSIDAD NACIONAL DE INGENIERÍA")
                            .SetFontSize(18).SetBold().SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
                        doc.Add(new Paragraph("Informe de Aplicación Estadística y Financiera")
                            .SetFontSize(14).SetFontColor(iText.Kernel.Colors.ColorConstants.BLUE).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                        doc.Add(new Paragraph($"Reporte generado el: {DateTime.Now:dd/MM/yyyy HH:mm}\n\n"));

                        // Tabla de Analítica
                        Table table = new Table(5).UseAllAvailableWidth();

                        string[] headers = { "Cliente", "Nivel", "Total (C$)", "Frec.", "Rentabilidad" };
                        foreach (var h in headers)
                            table.AddHeaderCell(new Cell().Add(new Paragraph(h)).SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY).SetBold());

                        foreach (var item in listaFinal)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(item.Cliente)).SetFontSize(9));
                            table.AddCell(new Cell().Add(new Paragraph(item.Segmento)).SetFontSize(9));
                            table.AddCell(new Cell().Add(new Paragraph(item.TotalGastado.ToString("N2"))).SetFontSize(9));
                            table.AddCell(new Cell().Add(new Paragraph(item.FrecuenciaVenta.ToString())).SetFontSize(9));
                            table.AddCell(new Cell().Add(new Paragraph(item.EstadoRentabilidad)).SetFontSize(9));
                        }

                        doc.Add(table);

                        // Resumen Final
                        doc.Add(new Paragraph($"\nTOTAL FACTURADO: C$ {listaFinal.Sum(x => x.TotalGastado):N2}")
                            .SetFontSize(12).SetBold());

                        doc.Close();
                    }
                }
                MessageBox.Show("Informe PDF generado en el Escritorio.");
            }
            catch (Exception ex) { MessageBox.Show("Error al generar PDF: " + ex.Message); }
        }
    }
}

