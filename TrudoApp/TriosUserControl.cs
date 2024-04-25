using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrucoData;

namespace TrudoApp
{
    public partial class TriosUserControl : UserControl
    {
        private readonly TrucoContext _context;

        [Obsolete("Designer only", true)]
        public TriosUserControl()
        {
            InitializeComponent();
        }

        public TriosUserControl(TrucoContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new TrioForm(_context))
            {
                form.ShowDialog();
            }

            dataGridView1.DataSource = _context.Trios.ToList();
        }

        private void TriosUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode || _context == null) return;
            dataGridView1.DataSource = _context.Trios.ToList();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            Guid trioId = (Guid)dataGridView1.SelectedRows[0].Cells[0].Value;
            var trio = _context.Trios.Find(trioId);
            _context.Trios.Remove(trio!);
            _context.SaveChanges();
            dataGridView1.DataSource = _context.Trios.ToList();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            excluirButton.Enabled = dataGridView1.SelectedRows.Count > 0;
            editarButton.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        public void ExportarDataGridViewParaExcel(DataGridView dgv, string filePath)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet()
                {
                    Id = workbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                Row headerRow = new Row();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    Cell headerCell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(column.HeaderText)
                    };
                    headerRow.AppendChild(headerCell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataGridViewRow dgRow in dgv.Rows)
                {
                    Row newRow = new Row();
                    foreach (DataGridViewCell cell in dgRow.Cells)
                    {
                        Cell newCell = new Cell
                        {
                            DataType = CellValues.String,
                            CellValue = new CellValue(cell.Value?.ToString() ?? "")
                        };
                        newRow.AppendChild(newCell);
                    }
                    sheetData.AppendChild(newRow);
                }

                workbookPart.Workbook.Save();
            }

            // Verifica se o arquivo Excel existe antes de tentar abri-lo.
            if (System.IO.File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Arquivo não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ExportarDataGridViewParaExcel(dataGridView1, "trios.xlsx");
        }

        private void editarButton_Click(object sender, EventArgs e)
        {
            using (var form = new TrioForm(_context))
            {
                form.Editar((Guid)dataGridView1.SelectedRows[0].Cells[0].Value);
                form.ShowDialog();
            }

            dataGridView1.DataSource = _context.Trios.ToList();
        }
    }
}
