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
    public partial class frmReportTverd : Form
    {
        public frmReportTverd()
        {
            InitializeComponent();
        }

        private void frmReportTverd_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
