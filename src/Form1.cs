using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Globalization;

namespace EthoVisionTrackMissingSamples
{
	/// <summary>
	/// EthoVisionTrackMissingSamples Main Form
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btOpen;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Label lbGuess;
		private System.Windows.Forms.Label lbDefine;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Label lbHz;
		private System.Windows.Forms.Button btCompute;
		private System.Windows.Forms.Button btAbout;
		private System.Windows.Forms.Button btQuit;
		private System.Windows.Forms.StatusBarPanel sbPanel1;
		private System.Windows.Forms.TextBox tbSR;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.DataGrid myDG;

		private sampleCount sc; // This is the sampleCount object we'll need
		// To fill in the table
		private DataTable myTable;
		private DataColumn colItem;
		private DataRow NewRow;
		private DataView myView;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormMain));
			this.btOpen = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.lbGuess = new System.Windows.Forms.Label();
			this.lbDefine = new System.Windows.Forms.Label();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.tbSR = new System.Windows.Forms.TextBox();
			this.lbHz = new System.Windows.Forms.Label();
			this.btCompute = new System.Windows.Forms.Button();
			this.myDG = new System.Windows.Forms.DataGrid();
			this.btAbout = new System.Windows.Forms.Button();
			this.btQuit = new System.Windows.Forms.Button();
			this.sbPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.myDG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// btOpen
			// 
			this.btOpen.Location = new System.Drawing.Point(16, 8);
			this.btOpen.Name = "btOpen";
			this.btOpen.TabIndex = 0;
			this.btOpen.Text = "&Open track";
			this.toolTip.SetToolTip(this.btOpen, "Open track");
			this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
			// 
			// lbGuess
			// 
			this.lbGuess.Location = new System.Drawing.Point(96, 8);
			this.lbGuess.Name = "lbGuess";
			this.lbGuess.Size = new System.Drawing.Size(176, 23);
			this.lbGuess.TabIndex = 1;
			this.lbGuess.Text = "lbGuess";
			this.lbGuess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbDefine
			// 
			this.lbDefine.Location = new System.Drawing.Point(16, 40);
			this.lbDefine.Name = "lbDefine";
			this.lbDefine.Size = new System.Drawing.Size(104, 23);
			this.lbDefine.TabIndex = 2;
			this.lbDefine.Text = "Define sample rate:";
			this.lbDefine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 153);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.sbPanel1});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(458, 22);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 3;
			this.statusBar.Text = "statusBar";
			// 
			// tbSR
			// 
			this.tbSR.Location = new System.Drawing.Point(120, 40);
			this.tbSR.Name = "tbSR";
			this.tbSR.Size = new System.Drawing.Size(56, 20);
			this.tbSR.TabIndex = 4;
			this.tbSR.Text = "tbSR";
			this.toolTip.SetToolTip(this.tbSR, "Change sample rate");
			// 
			// lbHz
			// 
			this.lbHz.Location = new System.Drawing.Point(184, 40);
			this.lbHz.Name = "lbHz";
			this.lbHz.Size = new System.Drawing.Size(24, 23);
			this.lbHz.TabIndex = 5;
			this.lbHz.Text = "Hz";
			this.lbHz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btCompute
			// 
			this.btCompute.Location = new System.Drawing.Point(240, 40);
			this.btCompute.Name = "btCompute";
			this.btCompute.TabIndex = 6;
			this.btCompute.Text = "&Compute";
			this.toolTip.SetToolTip(this.btCompute, "Find missed samples");
			this.btCompute.Click += new System.EventHandler(this.btCompute_Click);
			// 
			// myDG
			// 
			this.myDG.CaptionVisible = false;
			this.myDG.DataMember = "";
			this.myDG.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.myDG.Location = new System.Drawing.Point(8, 72);
			this.myDG.Name = "myDG";
			this.myDG.PreferredColumnWidth = 85;
			this.myDG.RowHeadersVisible = false;
			this.myDG.Size = new System.Drawing.Size(430, 48);
			this.myDG.TabIndex = 7;
			// 
			// btAbout
			// 
			this.btAbout.Location = new System.Drawing.Point(280, 128);
			this.btAbout.Name = "btAbout";
			this.btAbout.TabIndex = 8;
			this.btAbout.Text = "&About";
			this.toolTip.SetToolTip(this.btAbout, "About software");
			this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
			// 
			// btQuit
			// 
			this.btQuit.Location = new System.Drawing.Point(363, 128);
			this.btQuit.Name = "btQuit";
			this.btQuit.TabIndex = 9;
			this.btQuit.Text = "&Quit";
			this.toolTip.SetToolTip(this.btQuit, "Quit application");
			this.btQuit.Click += new System.EventHandler(this.btQuit_Click);
			// 
			// sbPanel1
			// 
			this.sbPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbPanel1.Text = "sbPanel1";
			this.sbPanel1.Width = 458;
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(458, 175);
			this.Controls.Add(this.btQuit);
			this.Controls.Add(this.btAbout);
			this.Controls.Add(this.myDG);
			this.Controls.Add(this.btCompute);
			this.Controls.Add(this.lbHz);
			this.Controls.Add(this.tbSR);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.lbDefine);
			this.Controls.Add(this.lbGuess);
			this.Controls.Add(this.btOpen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Find missed samples in EthoVision exported tracks";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.myDG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbPanel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			lbGuess.Text = "";
			tbSR.Text = "";
			tbSR.Enabled = false;
			statusBar.Panels[0].Text = "";
			btCompute.Enabled = false;
			sc = new sampleCount();
		}

		private void btQuit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void FormMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			statusBar.Panels[0].Text = "(c) Jean-Etienne Poirrier, CRC ULg, 2006";
		}

		private double getSeconds(string thetime, string theformat)
		{
			// Parse thetime (string) with theformat (string) and returns the number of seconds in thetime (double)
			// BIG ASSUMPTION: example 0000:00:00:49.520 <- dd:HH:mm:ss
			// So we don't need theformat but I leave it there in case I find a way
			double sec;
			string delimStr = ":";
			char [] delimiter = delimStr.ToCharArray();
			string [] split = null;

			split = thetime.Split(delimiter);

            sec = Convert.ToDouble(split[3]);
			sec = sec + (Convert.ToDouble(split[2]) * 60); // minutes
			sec = sec + (Convert.ToDouble(split[1]) * 3600); // hours
			sec = sec + (Convert.ToDouble(split[1]) * 86400); // days

			// MessageBox.Show(sec.ToString());
			return sec;
		}

		private void btOpen_Click(object sender, System.EventArgs e)
		{
			StreamReader csvfile;

			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*" ;
			openFileDialog.FilterIndex = 1 ;
			openFileDialog.RestoreDirectory = true ;

			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if((csvfile = new StreamReader(openFileDialog.FileName))!=null)
				{
					int counter = 0;
					Boolean inSamples = false; //
					string line;

					sc.resetNMissed();
					myDG.Enabled = false;

					// Some variables to split strings and change window title
					string delimStrF = "\\";
					char [] delimiterF = delimStrF.ToCharArray();
					string [] split = null;

					split = openFileDialog.FileName.Split(delimiterF);
					Text = "EMS - Opened " + split[split.Length-1];

					string delimStr = ",";
					char [] delimiter = delimStr.ToCharArray();

					// Read the csvfile
					while((line = csvfile.ReadLine()) != null)
					{
						counter++;

						if(line.StartsWith("Samples,"))
						{
							split = line.Split(delimiter);
							sc.setTotalSamples(Convert.ToInt32(split[1])); // provided this line is like "Samples,619"
						}

						split = null;

						if(line.StartsWith("Trial duration,"))
						{
							split = line.Split(delimiter);
							sc.setTheoreticalDuration(getSeconds(split[1], split[2])); // provided this line is like "Trial duration,0000:00:00:49.520,dd:HH:mm:ss"
						}

						if(line.StartsWith("Sample no."))
						{
							inSamples = true;
							lbGuess.Text = "(Guessed sample rate: " + sc.getGuessedSampleRate().ToString() + "Hz)";
							tbSR.Text = sc.getGuessedSampleRate().ToString();
							tbSR.Enabled = true;
							btCompute.Enabled = true; // Enable btCompute
						}

						if(inSamples)
						{
							// Process samples
							split = line.Split(delimiter);
							if(split[2] == "-")
								sc.addOneMissed();
						}
					}

					csvfile.Close();
				}
			}

		}

		private void btCompute_Click(object sender, System.EventArgs e)
		{
			// We can compute straight after the file is open but we need to let the user change the sample rate

			// Some computation

			try
			{
				sc.setSR(Convert.ToDouble(tbSR.Text));
			} 
			catch(Exception exc)
			{
				MessageBox.Show("Please check your sample rate\nValid sample rate is 12.5, e.g.", "Check sample rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
				tbSR.Text = sc.getGuessedSampleRate().ToString();
				return;
			}

			// Then Display

			myTable = new DataTable("myTable");
			colItem = new DataColumn("Tot.Samples",Type.GetType("System.String"));
			myTable.Columns.Add(colItem);
			colItem = new DataColumn("Samples missed",Type.GetType("System.String"));
			myTable.Columns.Add(colItem);
			colItem = new DataColumn("Tot. Duration (s)",Type.GetType("System.String"));
			myTable.Columns.Add(colItem);
			colItem = new DataColumn("Mis. Duration (s)",Type.GetType("System.String"));
			myTable.Columns.Add(colItem);
			colItem = new DataColumn("% of missed",Type.GetType("System.String"));
			myTable.Columns.Add(colItem);

			NewRow = myTable.NewRow();
			NewRow["Tot.Samples"] = sc.getTotalSamples().ToString();
			NewRow["Samples missed"] = sc.getNMissed().ToString();
			NewRow["Tot. Duration (s)"] = sc.getTotalDuration().ToString();
			NewRow["Mis. Duration (s)"] = sc.getMissedDuration().ToString();
			NewRow["% of missed"] = sc.getPercentageMissed().ToString();
			myTable.Rows.Add(NewRow);

			myView = new DataView(myTable);
			myView.AllowDelete = false;
			myView.AllowEdit = false;
			myView.AllowNew = false;

			Text = "EMS - Found " + sc.getNMissed().ToString() + " missed samples";
			myDG.Enabled = true;
			myDG.SetDataBinding(myView, "");
		}

		private void btAbout_Click(object sender, System.EventArgs e)
		{
			// TODO a proper About box
			MessageBox.Show("Find missed samples in Ethovision exported tracks\n(c) Jean-Etienne Poirrier, 2006\nCyclotron Reseach Centre, University of Liege\n\nhttp://www.poirrier.be/~jean-etienne/software/ems", "About...", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
