/*
NPlot - A plotting library for .NET

Main.cs
Copyright (C) 2003-2004
Matt Howlett, Paolo Pierini

Redistribution and use of NPlot or parts there-of in source and
binary forms, with or without modification, are permitted provided
that the following conditions are met:

1. Re-distributions in source form must retain at the head of each
   source file the above copyright notice, this list of conditions
   and the following disclaimer.

2. Any product ("the product") that makes use NPlot or parts 
   there-of must either:
  
    (a) allow any user of the product to obtain a complete machine-
        readable copy of the corresponding source code for the 
        product and the version of NPlot used for a charge no more
        than your cost of physically performing source distribution,
	on a medium customarily used for software interchange, or:

    (b) reproduce the following text in the documentation, about 
        box or other materials intended to be read by human users
        of the product that is provided to every human user of the
        product: 
   
              "This product includes software developed as 
              part of the NPlot library project available 
              from: http://www.nplot.com/" 

        The words "This product" may optionally be replace with 
        the actual name of the product.

------------------------------------------------------------------------

THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data;
using NPlot;
using System.IO;
using System.Reflection;
using GorenieDLL;


namespace Gorenie
{

	/// <summary>
	/// Главное окно
	/// </summary>
	public class PlotSurface2DDemo : System.Windows.Forms.Form
	{

		/// <summary>
		/// used to keep track of the current demo plot being displayed.
		/// </summary>
		private int currentPlot = 0;

		/// <summary>
		/// delegate for plot demo functions.
		/// </summary>
		private delegate void PlotDemoDelegate();

		/// <summary>
		///  Инициализация конструктора формы
		/// </summary>
		private PlotDemoDelegate [] PlotRoutines;

        private System.Windows.Forms.Button quitButton;
		private System.ComponentModel.IContainer components;
        private PrintDocument printDocument;
		private NPlot.Windows.PlotSurface2D plotSurface;
        private System.Windows.Forms.Timer qeExampleTimer;

        private double[] PlotQEExampleValues;
        private GroupBox groupBox1;
        private NumericUpDown nudOutMediumAlfa_Min;
        private Label label1;
        private NumericUpDown nudMediumAlfa_Max;
        private Label label3;
        private Label label2;
        private Button button1;
        private string[] PlotQEExampleTextValues;

		#region PlotWavelet
		public void PlotWavelet()
		{
            this.plotSurface.Clear();

			LinePlot lp = new LinePlot();
            
            double[] xs = new double[10];
            double[] ys = new double[10];
            
            for (int i = 0; i<10; i++)
            {
                xs[i] = (double)nudOutMediumAlfa_Min.Value + i * 0.1 * ((double)nudMediumAlfa_Max.Value - (double)nudOutMediumAlfa_Min.Value);
                //ys[i] = (double)_HeatC.GetQ((double)xs[i]);
            }

            lp.AbscissaData = xs;
            lp.OrdinateData = ys;

            lp.Color = Color.Green;
			
			Grid myGrid = new Grid();
			myGrid.VerticalGridType = Grid.GridType.Fine;
			myGrid.HorizontalGridType = Grid.GridType.Coarse;
			this.plotSurface.Add(myGrid);

			this.plotSurface.Add( lp );
            this.plotSurface.Title = "Зависимость плотности теплового потока" + "\n" + 
                                             "от коэффициента теплоотдачи окружающей среды";
            this.plotSurface.XAxis1.Label = "Коэффициент теплоотдачи, Вт/(м2*°С)";
            this.plotSurface.YAxis1.Label = "Плотность теплового потока, Вт/м2";

            LinearAxis myAxis = new LinearAxis( this.plotSurface.XAxis1);
			myAxis.NumberOfSmallTicks = 1;
            myAxis.WorldMin =(double)nudOutMediumAlfa_Min.Value;
            myAxis.WorldMax = (double)nudMediumAlfa_Max.Value;
			this.plotSurface.XAxis1 = myAxis;

            LinearAxis myAxisY = new LinearAxis(this.plotSurface.YAxis1);
            myAxisY.NumberOfSmallTicks = 1;
            //myAxisY.WorldMin = (double)_HeatC.GetQ((double)nudOutMediumAlfa_Min.Value);
            //myAxisY.WorldMax = (double)_HeatC.GetQ((double)nudMediumAlfa_Max.Value);
            this.plotSurface.YAxis1 = myAxisY;
            	
			this.plotSurface.PlotBackColor = Color.OldLace;
			this.plotSurface.XAxis1.Reversed = false ;
            this.plotSurface.YAxis1.Reversed = false;
		
			this.plotSurface.Refresh();
		}


        #endregion

        GorenieLibrary _HeatC = new GorenieLibrary();

        public PlotSurface2DDemo(GorenieLibrary HeatC)
        //public PlotSurface2DDemo()
		{
            InitializeComponent();
            CenterToScreen();
            _HeatC = HeatC;

			this.plotSurface.Anchor = 
				System.Windows.Forms.AnchorStyles.Left |
				System.Windows.Forms.AnchorStyles.Right |
				System.Windows.Forms.AnchorStyles.Top |
				System.Windows.Forms.AnchorStyles.Bottom;

			PlotRoutines = new PlotDemoDelegate [] {    
            										    new PlotDemoDelegate(PlotWavelet) 
            									};

			this.Resize += new System.EventHandler(this.ResizeHandler);

			printDocument = new PrintDocument();
			printDocument.PrintPage += new PrintPageEventHandler(pd_PrintPage);
			int id = currentPlot + 1;
			
			this.plotSurface.RightMenu = NPlot.Windows.PlotSurface2D.DefaultContextMenu;

            currentPlot = 0;
			PlotRoutines[currentPlot]();
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.quitButton = new System.Windows.Forms.Button();
            this.qeExampleTimer = new System.Windows.Forms.Timer(this.components);
            this.plotSurface = new NPlot.Windows.PlotSurface2D();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudMediumAlfa_Max = new System.Windows.Forms.NumericUpDown();
            this.nudOutMediumAlfa_Min = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMediumAlfa_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutMediumAlfa_Min)).BeginInit();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quitButton.Location = new System.Drawing.Point(530, 444);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 14;
            this.quitButton.Text = "Закрыть";
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // qeExampleTimer
            // 
            this.qeExampleTimer.Interval = 500;
            this.qeExampleTimer.Tick += new System.EventHandler(this.qeExampleTimer_Tick);
            // 
            // plotSurface
            // 
            this.plotSurface.AutoScaleAutoGeneratedAxes = false;
            this.plotSurface.AutoScaleTitle = false;
            this.plotSurface.BackColor = System.Drawing.SystemColors.Control;
            this.plotSurface.DateTimeToolTip = false;
            this.plotSurface.Legend = null;
            this.plotSurface.LegendZOrder = -1;
            this.plotSurface.Location = new System.Drawing.Point(8, 8);
            this.plotSurface.Name = "plotSurface";
            this.plotSurface.RightMenu = null;
            this.plotSurface.ShowCoordinates = false;
            this.plotSurface.Size = new System.Drawing.Size(616, 376);
            this.plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plotSurface.TabIndex = 13;
            this.plotSurface.Title = "";
            this.plotSurface.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plotSurface.XAxis1 = null;
            this.plotSurface.XAxis2 = null;
            this.plotSurface.YAxis1 = null;
            this.plotSurface.YAxis2 = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudMediumAlfa_Max);
            this.groupBox1.Controls.Add(this.nudOutMediumAlfa_Min);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 92);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Влияние параметров";
            // 
            // nudMediumAlfa_Max
            // 
            this.nudMediumAlfa_Max.Location = new System.Drawing.Point(157, 52);
            this.nudMediumAlfa_Max.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudMediumAlfa_Max.Name = "nudMediumAlfa_Max";
            this.nudMediumAlfa_Max.Size = new System.Drawing.Size(56, 20);
            this.nudMediumAlfa_Max.TabIndex = 1;
            this.nudMediumAlfa_Max.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudMediumAlfa_Max.ValueChanged += new System.EventHandler(this.nudMediumAlfa_Max_ValueChanged);
            // 
            // nudOutMediumAlfa_Min
            // 
            this.nudOutMediumAlfa_Min.Location = new System.Drawing.Point(70, 52);
            this.nudOutMediumAlfa_Min.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudOutMediumAlfa_Min.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudOutMediumAlfa_Min.Name = "nudOutMediumAlfa_Min";
            this.nudOutMediumAlfa_Min.Size = new System.Drawing.Size(56, 20);
            this.nudOutMediumAlfa_Min.TabIndex = 1;
            this.nudOutMediumAlfa_Min.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudOutMediumAlfa_Min.ValueChanged += new System.EventHandler(this.nudOutMediumAlfa_Min_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "до";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "от";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(391, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Построить";
            this.button1.Click += new System.EventHandler(this.prevPlotButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Коэффициент теплоотдачи окружающей среды, Вт(м2*К):";
            // 
            // PlotSurface2DDemo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(634, 495);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.plotSurface);
            this.Controls.Add(this.quitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 517);
            this.Name = "PlotSurface2DDemo";
            this.Text = "График";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMediumAlfa_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutMediumAlfa_Min)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion


		// The PrintPage event is raised for each page to be printed.
		private void pd_PrintPage(object sender, PrintPageEventArgs ev) 
		{
			// The windows.forms PlotSurface2D control can also be 
			// rendered to other Graphics surfaces. Here we output to a
			// printer. 
			plotSurface.Draw( ev.Graphics, ev.MarginBounds );
			ev.HasMorePages = false;
		}
	

		/// <summary>
		/// callback for quit button click
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void quitButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		/// <summary>
		/// callback for resize event.
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void ResizeHandler(object sender, System.EventArgs e)
		{
			//plotSurface.Width = this.Width - 28;
			//plotSurface.Height = this.Height - 100;

			//nplotLinkLabel.Top = this.Height - 60;
            /*
			nextPlotButton.Top = this.Height - 64;
			prevPlotButton.Top = this.Height - 64;
			printButton.Top = this.Height - 64;
			quitButton.Top = this.Height - 64;
			exampleNumberLabel.Top = this.Height - 60;
            */
		}


		/// <summary>
		/// callback for next button click
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void nextPlotButton_Click(object sender, System.EventArgs e)
		{
			currentPlot += 1;
			if (currentPlot == PlotRoutines.Length)
			{
				currentPlot = 0;
			}

			int id = currentPlot+1;
			qeExampleTimer.Enabled = false;
			//exampleNumberLabel.Text = "Plot " + id.ToString("0") + "/" + PlotRoutines.Length.ToString("0");
			this.plotSurface.DateTimeToolTip = false;
			PlotRoutines[currentPlot]();
		}


		/// <summary>
		/// Callback for NPlot link label click
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void nplotLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("www.netcontrols.org/NPlot");
		}


		/// <summary>
		/// callback for print button click
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void printButton_Click(object sender, System.EventArgs e)
		{
			PrintDialog dlg = new PrintDialog();
			dlg.Document = printDocument;
			if (dlg.ShowDialog() == DialogResult.OK) 
			{
				try
				{
					printDocument.Print();
				}
				catch
				{
					Console.WriteLine( "problem printing.\n" );
				}
			}	
		}


		/// <summary>
		/// Callback for prev button click.
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void prevPlotButton_Click(object sender, System.EventArgs e)
		{			            
			PlotRoutines[currentPlot]();
            plotSurface.Visible = true;
		}


		/// <summary>
		/// Callback for QE example timer tick.
		/// </summary>
		/// <param name="sender">unused</param>
		/// <param name="e">unused</param>
		private void qeExampleTimer_Tick(object sender, System.EventArgs e)
		{

			Random r = new Random();

			for (int i=0; i<PlotQEExampleValues.Length; ++i)
			{
				PlotQEExampleValues[i] = 8.0f + 12.0f * (double)r.Next(10000) / 10000.0f;
				if ( PlotQEExampleValues[i] > 18.0f )
				{
					PlotQEExampleTextValues[i] = "KCsTe";
				}
				else
				{
					PlotQEExampleTextValues[i] = "";
				}
			}

			plotSurface.Refresh();
		}

        private void nudOutMediumAlfa_Min_ValueChanged(object sender, EventArgs e)
        {
            plotSurface.Visible = false;
        }

        private void nudMediumAlfa_Max_ValueChanged(object sender, EventArgs e)
        {   
            plotSurface.Visible = false;
        }
                

	}
}
