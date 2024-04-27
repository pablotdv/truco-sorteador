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

namespace TrucoApp
{
    public partial class TrucoForm : Form
    {        
        private readonly TrucoContext _context;
        public TrucoForm(TrucoContext context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}
