using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorenie
{
    public partial class FrmReportGaz : Form
    {
        public FrmReportGaz()
        {
            InitializeComponent();
        }

        private void FrmReportGaz_Load(object sender, EventArgs e)
        {
            this.reportViewer2.RefreshReport();
        }
    }
}
