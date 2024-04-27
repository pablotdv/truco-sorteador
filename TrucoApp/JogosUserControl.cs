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

namespace TrucoApp
{
    public partial class JogosUserControl : UserControl
    {
        private readonly TrucoContext _context;

        [Obsolete("Designer only", true)]
        public JogosUserControl()
        {
            InitializeComponent();
        }

        public JogosUserControl(TrucoContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void sortearButton_Click(object sender, EventArgs e)
        {
            var proximoEtapa = 0;
            var ultimaEtapa = _context.Jogos.OrderByDescending(a => a.Etapa).FirstOrDefault();
            if (ultimaEtapa != null)
            {
                proximoEtapa = ultimaEtapa.Etapa + 1;
            }
            else
            {
                proximoEtapa = 1;
            }

            // if Questionar: Gerar jogos da etapa atual?
            if (MessageBox.Show($"Gerar jogos da etapa {proximoEtapa}?\nEssa ação é irreversível", "Sortear Jogos", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var trucoService = new TrucoService(_context);      
                if (proximoEtapa == 1)
                {
                    trucoService.SortearTrios();
                }
                trucoService.GerarJogos(proximoEtapa, 3);
                CarregarJogos();
            }
        }

        private void TriosUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode || _context == null) return;
            CarregarJogos();
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
            //excluirButton.Enabled = dataGridView1.SelectedRows.Count > 0;
            //editarButton.Enabled = dataGridView1.SelectedRows.Count > 0;
        }

        private void CarregarJogos()
        {
            dataGridView1.DataSource = _context.Jogos
                            .OrderBy(a => a.Etapa)
                            .ThenBy(a => a.Rodada)
                            .ThenBy(a => a.Numero)
                            .Select(a => new JogoView
                            {
                                JogoId = a.JogoId,
                                Etapa = a.Etapa,
                                Rodada = a.Rodada,
                                Numero = a.Numero,
                                TrioA = a.TrioA.Nome,
                                TrioB = a.TrioB != null ? a.TrioB.Nome : "Folga"
                            })
                            .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewParaExcel(dataGridView1, "jogos.xlsx");
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

        private void button2_Click(object sender, EventArgs e)
        {
            var ultimaEtapa = _context.Jogos.OrderByDescending(a => a.Etapa).FirstOrDefault();

            if (ultimaEtapa != null)
            {
                if (MessageBox.Show($"Excluir jogos da etapa {ultimaEtapa.Etapa}?\nEssa ação é irreversível", "Excluir Etapa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var jogos = _context.Jogos.Where(a => a.Etapa == ultimaEtapa.Etapa).ToList();
                    foreach (var jogo in jogos)
                    {
                        _context.Jogos.Remove(jogo);
                    }
                    _context.SaveChanges();
                    CarregarJogos();
                }
            }
            else
            {
                MessageBox.Show("Não há etapas para excluir", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

    public class JogoView
    {
        public Guid JogoId { get; set; }
        public int Etapa { get; set; }
        public int Rodada { get; set; }
        public int Numero { get; set; }
        public string TrioA { get; set; }
        public string TrioB { get; set; }
    }
}
