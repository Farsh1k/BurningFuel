namespace Gorenie
{
    partial class FrmReportGaz
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cReportInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cReportOutputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.cReportInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cReportOutputBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cReportInputBindingSource
            // 
            this.cReportInputBindingSource.DataSource = typeof(Gorenie.cReportInput);
            // 
            // cReportOutputBindingSource
            // 
            this.cReportOutputBindingSource.DataSource = typeof(Gorenie.cReportOutput);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsReportInput";
            reportDataSource1.Value = this.cReportInputBindingSource;
            reportDataSource2.Name = "dsReportOutput";
            reportDataSource2.Value = this.cReportOutputBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Gorenie.Report1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(654, 388);
            this.reportViewer2.TabIndex = 0;
            // 
            // FrmReportGaz
            // 
            this.ClientSize = new System.Drawing.Size(654, 388);
            this.Controls.Add(this.reportViewer2);
            this.Name = "FrmReportGaz";
            this.Load += new System.EventHandler(this.FrmReportGaz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cReportInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cReportOutputBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        public System.Windows.Forms.BindingSource cReportInputBindingSource;
        public System.Windows.Forms.BindingSource cReportOutputBindingSource;
    }
}