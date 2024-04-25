using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrucoData;

namespace TrudoApp
{
    public partial class TrioForm : Form
    {
        private readonly TrucoContext _context;
        private Guid trioId;
        public TrioForm(TrucoContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public void Editar(Guid value)
        {
            trioId = value;
            var trio = _context.Trios.Find(trioId);
            nomeTextBox.Text = trio.Nome;
            entidadeTextBox.Text = trio.Entidade;
            sortearCheckBox.Checked = trio.Sortear;
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (trioId != Guid.Empty)
            {
                var trio = _context.Trios.Find(trioId);
                trio.Nome = nomeTextBox.Text;
                trio.Entidade = entidadeTextBox.Text;
                trio.Sortear = sortearCheckBox.Checked;
            }
            else
            {
                _context.Trios.Add(new Trio
                {
                    Nome = nomeTextBox.Text,
                    Entidade = entidadeTextBox.Text,
                    Sortear = sortearCheckBox.Checked
                });
            }
            _context.SaveChanges();
            this.Close();
        }
    }
}
