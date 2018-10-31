﻿namespace APPD_Assignment_1
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.startStation = new System.Windows.Forms.ComboBox();
			this.endStation = new System.Windows.Forms.ComboBox();
			this.SearchStations = new System.Windows.Forms.Button();
			this.calcRoute = new System.Windows.Forms.Button();
			this.switchInputs = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
			// startStation
			// 
			this.startStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.startStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.startStation.FormattingEnabled = true;
			this.startStation.Location = new System.Drawing.Point(216, 70);
			this.startStation.Name = "startStation";
			this.startStation.Size = new System.Drawing.Size(325, 21);
			this.startStation.TabIndex = 2;
			// 
			// endStation
			// 
			this.endStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.endStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.endStation.FormattingEnabled = true;
			this.endStation.Location = new System.Drawing.Point(213, 165);
			this.endStation.Name = "endStation";
			this.endStation.Size = new System.Drawing.Size(325, 21);
			this.endStation.TabIndex = 3;
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
			// calcRoute
			// 
			this.calcRoute.Location = new System.Drawing.Point(213, 308);
			this.calcRoute.Name = "calcRoute";
			this.calcRoute.Size = new System.Drawing.Size(328, 80);
			this.calcRoute.TabIndex = 5;
			this.calcRoute.Text = "Calculate Route";
			this.calcRoute.UseVisualStyleBackColor = true;
			this.calcRoute.Click += new System.EventHandler(this.CalcRoute_Click);
			// 
			// switchInputs
			// 
			this.switchInputs.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.switchInputs.Location = new System.Drawing.Point(329, 112);
			this.switchInputs.Name = "switchInputs";
			this.switchInputs.Size = new System.Drawing.Size(96, 28);
			this.switchInputs.TabIndex = 6;
			this.switchInputs.Text = "Swap Stations";
			this.switchInputs.UseVisualStyleBackColor = true;
			this.switchInputs.Click += new System.EventHandler(this.SwitchInputs_Click);
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
			this.Controls.Add(this.switchInputs);
			this.Controls.Add(this.calcRoute);
			this.Controls.Add(this.SearchStations);
			this.Controls.Add(this.endStation);
			this.Controls.Add(this.startStation);
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
		private System.Windows.Forms.ComboBox startStation;
		private System.Windows.Forms.ComboBox endStation;
		private System.Windows.Forms.Button SearchStations;
		private System.Windows.Forms.Button calcRoute;
		private System.Windows.Forms.Button switchInputs;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Label label3;
	}
}

