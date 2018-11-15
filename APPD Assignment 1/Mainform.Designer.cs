namespace APPD_Assignment_1
{
	partial class Mainform
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.StartStation = new System.Windows.Forms.ComboBox();
			this.EndStation = new System.Windows.Forms.ComboBox();
			this.SearchStations = new System.Windows.Forms.Button();
			this.CalcRoute = new System.Windows.Forms.Button();
			this.SwitchInputs = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(128, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Start station";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(128, 168);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "End station";
			// 
			// StartStation
			// 
			this.StartStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.StartStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.StartStation.FormattingEnabled = true;
			this.StartStation.Location = new System.Drawing.Point(216, 70);
			this.StartStation.Name = "StartStation";
			this.StartStation.Size = new System.Drawing.Size(325, 21);
			this.StartStation.TabIndex = 2;
			// 
			// EndStation
			// 
			this.EndStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.EndStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.EndStation.FormattingEnabled = true;
			this.EndStation.Location = new System.Drawing.Point(213, 165);
			this.EndStation.Name = "EndStation";
			this.EndStation.Size = new System.Drawing.Size(325, 21);
			this.EndStation.TabIndex = 3;
			// 
			// SearchStations
			// 
			this.SearchStations.Location = new System.Drawing.Point(646, 28);
			this.SearchStations.Name = "SearchStations";
			this.SearchStations.Size = new System.Drawing.Size(75, 38);
			this.SearchStations.TabIndex = 4;
			this.SearchStations.Text = "Search stations";
			this.SearchStations.UseVisualStyleBackColor = true;
			this.SearchStations.Click += new System.EventHandler(this.SearchStations_Click);
			// 
			// CalcRoute
			// 
			this.CalcRoute.Location = new System.Drawing.Point(213, 308);
			this.CalcRoute.Name = "CalcRoute";
			this.CalcRoute.Size = new System.Drawing.Size(328, 80);
			this.CalcRoute.TabIndex = 5;
			this.CalcRoute.Text = "Calculate Route";
			this.CalcRoute.UseVisualStyleBackColor = true;
			this.CalcRoute.Click += new System.EventHandler(this.CalcRoute_Click);
			// 
			// SwitchInputs
			// 
			this.SwitchInputs.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SwitchInputs.Location = new System.Drawing.Point(329, 112);
			this.SwitchInputs.Name = "SwitchInputs";
			this.SwitchInputs.Size = new System.Drawing.Size(96, 28);
			this.SwitchInputs.TabIndex = 6;
			this.SwitchInputs.Text = "Swap Stations";
			this.SwitchInputs.UseVisualStyleBackColor = true;
			this.SwitchInputs.Click += new System.EventHandler(this.SwitchInputs_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(291, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Enter a station name or station code";
			// 
			// Mainform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SwitchInputs);
			this.Controls.Add(this.CalcRoute);
			this.Controls.Add(this.SearchStations);
			this.Controls.Add(this.EndStation);
			this.Controls.Add(this.StartStation);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Mainform";
			this.Text = "MRT Navigation Guide";
			this.Load += new System.EventHandler(this.Mainform_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox StartStation;
		private System.Windows.Forms.ComboBox EndStation;
		private System.Windows.Forms.Button SearchStations;
		private System.Windows.Forms.Button CalcRoute;
		private System.Windows.Forms.Button SwitchInputs;
		private System.Windows.Forms.Label label3;
	}
}

