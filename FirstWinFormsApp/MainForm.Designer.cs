namespace FirstWinFormsApp
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			lblCounter = new Label();
			btnIncreaseCounter = new Button();
			SuspendLayout();
			// 
			// lblCounter
			// 
			lblCounter.AutoSize = true;
			lblCounter.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
			lblCounter.Location = new Point(55, 75);
			lblCounter.Name = "lblCounter";
			lblCounter.Size = new Size(33, 37);
			lblCounter.TabIndex = 0;
			lblCounter.Text = "0";
			// 
			// btnIncreaseCounter
			// 
			btnIncreaseCounter.Font = new Font("Segoe UI", 20F);
			btnIncreaseCounter.Location = new Point(189, 86);
			btnIncreaseCounter.Name = "btnIncreaseCounter";
			btnIncreaseCounter.Size = new Size(159, 46);
			btnIncreaseCounter.TabIndex = 1;
			btnIncreaseCounter.Text = "Click Me";
			btnIncreaseCounter.UseVisualStyleBackColor = true;
			btnIncreaseCounter.Click += btnIncreaseCounter_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnIncreaseCounter);
			Controls.Add(lblCounter);
			Name = "MainForm";
			Text = "Main Form";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblCounter;
		private Button btnIncreaseCounter;
	}
}
