﻿namespace MSharpSample
{
	partial class SampleForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.StartAuthButton = new System.Windows.Forms.Button();
			this.PinOKButton = new System.Windows.Forms.Button();
			this.PinBox = new System.Windows.Forms.TextBox();
			this.PinLabel = new System.Windows.Forms.Label();
			this.StatusUpdateButton = new System.Windows.Forms.Button();
			this.StatusUpdateBox = new System.Windows.Forms.TextBox();
			this.PostLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// StartAuthButton
			// 
			this.StartAuthButton.BackColor = System.Drawing.Color.Transparent;
			this.StartAuthButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.StartAuthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StartAuthButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.StartAuthButton.Location = new System.Drawing.Point(14, 14);
			this.StartAuthButton.Margin = new System.Windows.Forms.Padding(5);
			this.StartAuthButton.Name = "StartAuthButton";
			this.StartAuthButton.Size = new System.Drawing.Size(186, 28);
			this.StartAuthButton.TabIndex = 0;
			this.StartAuthButton.Text = "認証開始";
			this.StartAuthButton.UseVisualStyleBackColor = false;
			this.StartAuthButton.Click += new System.EventHandler(this.StartAuthButton_Click);
			// 
			// PinOKButton
			// 
			this.PinOKButton.BackColor = System.Drawing.Color.Transparent;
			this.PinOKButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.PinOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PinOKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.PinOKButton.Location = new System.Drawing.Point(130, 104);
			this.PinOKButton.Margin = new System.Windows.Forms.Padding(5);
			this.PinOKButton.Name = "PinOKButton";
			this.PinOKButton.Size = new System.Drawing.Size(70, 29);
			this.PinOKButton.TabIndex = 1;
			this.PinOKButton.Text = "OK";
			this.PinOKButton.UseVisualStyleBackColor = false;
			this.PinOKButton.Click += new System.EventHandler(this.PinOKButton_Click);
			// 
			// PinBox
			// 
			this.PinBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.PinBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PinBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.PinBox.Location = new System.Drawing.Point(14, 71);
			this.PinBox.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
			this.PinBox.Name = "PinBox";
			this.PinBox.Size = new System.Drawing.Size(186, 25);
			this.PinBox.TabIndex = 3;
			// 
			// PinLabel
			// 
			this.PinLabel.AutoSize = true;
			this.PinLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.PinLabel.Location = new System.Drawing.Point(14, 50);
			this.PinLabel.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.PinLabel.Name = "PinLabel";
			this.PinLabel.Size = new System.Drawing.Size(70, 18);
			this.PinLabel.TabIndex = 4;
			this.PinLabel.Text = "PINコード:";
			// 
			// StatusUpdateButton
			// 
			this.StatusUpdateButton.BackColor = System.Drawing.Color.Transparent;
			this.StatusUpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.StatusUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StatusUpdateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.StatusUpdateButton.Location = new System.Drawing.Point(130, 194);
			this.StatusUpdateButton.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
			this.StatusUpdateButton.Name = "StatusUpdateButton";
			this.StatusUpdateButton.Size = new System.Drawing.Size(70, 28);
			this.StatusUpdateButton.TabIndex = 5;
			this.StatusUpdateButton.Text = "Update";
			this.StatusUpdateButton.UseVisualStyleBackColor = false;
			this.StatusUpdateButton.Click += new System.EventHandler(this.StatusUpdateButton_Click);
			// 
			// StatusUpdateBox
			// 
			this.StatusUpdateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.StatusUpdateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StatusUpdateBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.StatusUpdateBox.Location = new System.Drawing.Point(14, 161);
			this.StatusUpdateBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.StatusUpdateBox.Name = "StatusUpdateBox";
			this.StatusUpdateBox.Size = new System.Drawing.Size(186, 25);
			this.StatusUpdateBox.TabIndex = 10;
			// 
			// PostLabel
			// 
			this.PostLabel.AutoSize = true;
			this.PostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.PostLabel.Location = new System.Drawing.Point(14, 140);
			this.PostLabel.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.PostLabel.Name = "PostLabel";
			this.PostLabel.Size = new System.Drawing.Size(37, 18);
			this.PostLabel.TabIndex = 11;
			this.PostLabel.Text = "投稿:";
			// 
			// SampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(214, 236);
			this.Controls.Add(this.PostLabel);
			this.Controls.Add(this.StatusUpdateBox);
			this.Controls.Add(this.StatusUpdateButton);
			this.Controls.Add(this.PinLabel);
			this.Controls.Add(this.PinBox);
			this.Controls.Add(this.PinOKButton);
			this.Controls.Add(this.StartAuthButton);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SampleForm";
			this.Text = "MSharpSample";
			this.Load += new System.EventHandler(this.SampleForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StartAuthButton;
		private System.Windows.Forms.Button PinOKButton;
		private System.Windows.Forms.TextBox PinBox;
		private System.Windows.Forms.Label PinLabel;
		private System.Windows.Forms.Button StatusUpdateButton;
		private System.Windows.Forms.TextBox StatusUpdateBox;
		private System.Windows.Forms.Label PostLabel;
	}
}
