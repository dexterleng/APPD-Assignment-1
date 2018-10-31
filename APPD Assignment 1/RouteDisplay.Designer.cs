namespace APPD_Assignment_1
{
	partial class RouteDisplay
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
			this.RouteBox = new System.Windows.Forms.RichTextBox();
			this.BestRoute = new System.Windows.Forms.RadioButton();
			this.Max1 = new System.Windows.Forms.RadioButton();
			this.MaxNone = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// RouteBox
			// 
			this.RouteBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RouteBox.Location = new System.Drawing.Point(12, 122);
			this.RouteBox.Name = "RouteBox";
			this.RouteBox.Size = new System.Drawing.Size(776, 316);
			this.RouteBox.TabIndex = 0;
			this.RouteBox.Text = "";
			// 
			// BestRoute
			// 
			this.BestRoute.AutoSize = true;
			this.BestRoute.Checked = true;
			this.BestRoute.Location = new System.Drawing.Point(116, 48);
			this.BestRoute.Name = "BestRoute";
			this.BestRoute.Size = new System.Drawing.Size(78, 17);
			this.BestRoute.TabIndex = 1;
			this.BestRoute.TabStop = true;
			this.BestRoute.Text = "Best Route";
			this.BestRoute.UseVisualStyleBackColor = true;
			this.BestRoute.CheckedChanged += new System.EventHandler(this.SelectionChanged);
			// 
			// Max1
			// 
			this.Max1.AutoSize = true;
			this.Max1.Location = new System.Drawing.Point(212, 48);
			this.Max1.Name = "Max1";
			this.Max1.Size = new System.Drawing.Size(99, 17);
			this.Max1.TabIndex = 2;
			this.Max1.Text = "Max. 1 Transfer";
			this.Max1.UseVisualStyleBackColor = true;
			this.Max1.CheckedChanged += new System.EventHandler(this.SelectionChanged);
			// 
			// MaxNone
			// 
			this.MaxNone.AutoSize = true;
			this.MaxNone.Location = new System.Drawing.Point(328, 48);
			this.MaxNone.Name = "MaxNone";
			this.MaxNone.Size = new System.Drawing.Size(76, 17);
			this.MaxNone.TabIndex = 3;
			this.MaxNone.Text = "Direct Line";
			this.MaxNone.UseVisualStyleBackColor = true;
			this.MaxNone.CheckedChanged += new System.EventHandler(this.SelectionChanged);
			// 
			// RouteDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.MaxNone);
			this.Controls.Add(this.Max1);
			this.Controls.Add(this.BestRoute);
			this.Controls.Add(this.RouteBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RouteDisplay";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RouteDisplay";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.RouteDisplay_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox RouteBox;
		private System.Windows.Forms.RadioButton BestRoute;
		private System.Windows.Forms.RadioButton Max1;
		private System.Windows.Forms.RadioButton MaxNone;
	}
}