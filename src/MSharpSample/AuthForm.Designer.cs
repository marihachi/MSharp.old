namespace MSharpSample
{
	partial class AuthForm
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
			this.PinLabel = new System.Windows.Forms.Label();
			this.PinBox = new System.Windows.Forms.TextBox();
			this.PinOKButton = new System.Windows.Forms.Button();
			this.StartAuthButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// PinLabel
			// 
			this.PinLabel.AutoSize = true;
			this.PinLabel.Location = new System.Drawing.Point(14, 66);
			this.PinLabel.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.PinLabel.Name = "PinLabel";
			this.PinLabel.Size = new System.Drawing.Size(70, 18);
			this.PinLabel.TabIndex = 8;
			this.PinLabel.Text = "PINコード:";
			// 
			// PinBox
			// 
			this.PinBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.PinBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PinBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.PinBox.Location = new System.Drawing.Point(84, 63);
			this.PinBox.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
			this.PinBox.Name = "PinBox";
			this.PinBox.Size = new System.Drawing.Size(98, 25);
			this.PinBox.TabIndex = 7;
			// 
			// PinOKButton
			// 
			this.PinOKButton.BackColor = System.Drawing.Color.Transparent;
			this.PinOKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.PinOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PinOKButton.Location = new System.Drawing.Point(187, 61);
			this.PinOKButton.Margin = new System.Windows.Forms.Padding(5);
			this.PinOKButton.Name = "PinOKButton";
			this.PinOKButton.Size = new System.Drawing.Size(70, 29);
			this.PinOKButton.TabIndex = 6;
			this.PinOKButton.Text = "OK";
			this.PinOKButton.UseVisualStyleBackColor = false;
			this.PinOKButton.Click += new System.EventHandler(this.PinOKButton_Click);
			// 
			// StartAuthButton
			// 
			this.StartAuthButton.BackColor = System.Drawing.Color.Transparent;
			this.StartAuthButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.StartAuthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StartAuthButton.Location = new System.Drawing.Point(14, 14);
			this.StartAuthButton.Margin = new System.Windows.Forms.Padding(5);
			this.StartAuthButton.Name = "StartAuthButton";
			this.StartAuthButton.Size = new System.Drawing.Size(243, 28);
			this.StartAuthButton.TabIndex = 5;
			this.StartAuthButton.Text = "認証開始";
			this.StartAuthButton.UseVisualStyleBackColor = false;
			this.StartAuthButton.Click += new System.EventHandler(this.StartAuthButton_Click);
			// 
			// AuthForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(271, 109);
			this.Controls.Add(this.PinLabel);
			this.Controls.Add(this.PinBox);
			this.Controls.Add(this.PinOKButton);
			this.Controls.Add(this.StartAuthButton);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "AuthForm";
			this.Text = "認証";
			this.Load += new System.EventHandler(this.AuthForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label PinLabel;
		private System.Windows.Forms.TextBox PinBox;
		private System.Windows.Forms.Button PinOKButton;
		private System.Windows.Forms.Button StartAuthButton;
	}
}