namespace APPD_Assignment_1
{
	partial class SearchForm
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
			this.SearchStation = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SearchButton = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.SearchTab = new System.Windows.Forms.TabControl();
			this.SearchTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// SearchStation
			// 
			this.SearchStation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.SearchStation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.SearchStation.FormattingEnabled = true;
			this.SearchStation.Location = new System.Drawing.Point(224, 43);
			this.SearchStation.Name = "SearchStation";
			this.SearchStation.Size = new System.Drawing.Size(325, 21);
			this.SearchStation.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(159, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Search for:";
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(332, 93);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(75, 23);
			this.SearchButton.TabIndex = 5;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(192, 74);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(731, 316);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// SearchTab
			// 
			this.SearchTab.Controls.Add(this.tabPage1);
			this.SearchTab.Controls.Add(this.tabPage2);
			this.SearchTab.Location = new System.Drawing.Point(12, 153);
			this.SearchTab.Name = "SearchTab";
			this.SearchTab.SelectedIndex = 0;
			this.SearchTab.Size = new System.Drawing.Size(739, 342);
			this.SearchTab.TabIndex = 6;
			// 
			// SearchForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 507);
			this.Controls.Add(this.SearchTab);
			this.Controls.Add(this.SearchButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SearchStation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SearchForm";
			this.Text = "SearchForm";
			this.SearchTab.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox SearchStation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl SearchTab;
	}
}