namespace MSharpSample
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
			this.APITestButton1 = new System.Windows.Forms.Button();
			this.ParameterBox1 = new System.Windows.Forms.TextBox();
			this.PostLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// StartAuthButton
			// 
			this.StartAuthButton.BackColor = System.Drawing.Color.Transparent;
			this.StartAuthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StartAuthButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.StartAuthButton.Location = new System.Drawing.Point(14, 14);
			this.StartAuthButton.Margin = new System.Windows.Forms.Padding(5);
			this.StartAuthButton.Name = "StartAuthButton";
			this.StartAuthButton.Size = new System.Drawing.Size(186, 28);
			this.StartAuthButton.TabIndex = 0;
			this.StartAuthButton.Text = "認証開始";
			this.StartAuthButton.UseVisualStyleBackColor = false;
			// 
			// PinOKButton
			// 
			this.PinOKButton.BackColor = System.Drawing.Color.Transparent;
			this.PinOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PinOKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.PinOKButton.Location = new System.Drawing.Point(130, 104);
			this.PinOKButton.Margin = new System.Windows.Forms.Padding(5);
			this.PinOKButton.Name = "PinOKButton";
			this.PinOKButton.Size = new System.Drawing.Size(70, 29);
			this.PinOKButton.TabIndex = 1;
			this.PinOKButton.Text = "OK";
			this.PinOKButton.UseVisualStyleBackColor = false;
			// 
			// PinBox
			// 
			this.PinBox.BackColor = System.Drawing.Color.White;
			this.PinBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PinBox.Location = new System.Drawing.Point(14, 71);
			this.PinBox.Margin = new System.Windows.Forms.Padding(5, 3, 0, 3);
			this.PinBox.Name = "PinBox";
			this.PinBox.Size = new System.Drawing.Size(186, 25);
			this.PinBox.TabIndex = 3;
			// 
			// PinLabel
			// 
			this.PinLabel.AutoSize = true;
			this.PinLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.PinLabel.Location = new System.Drawing.Point(14, 50);
			this.PinLabel.Margin = new System.Windows.Forms.Padding(5, 3, 3, 0);
			this.PinLabel.Name = "PinLabel";
			this.PinLabel.Size = new System.Drawing.Size(70, 18);
			this.PinLabel.TabIndex = 4;
			this.PinLabel.Text = "PINコード:";
			// 
			// APITestButton1
			// 
			this.APITestButton1.BackColor = System.Drawing.Color.Transparent;
			this.APITestButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.APITestButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.APITestButton1.Location = new System.Drawing.Point(130, 194);
			this.APITestButton1.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
			this.APITestButton1.Name = "APITestButton1";
			this.APITestButton1.Size = new System.Drawing.Size(70, 28);
			this.APITestButton1.TabIndex = 5;
			this.APITestButton1.Text = "Update";
			this.APITestButton1.UseVisualStyleBackColor = false;
			// 
			// ParameterBox1
			// 
			this.ParameterBox1.BackColor = System.Drawing.Color.White;
			this.ParameterBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ParameterBox1.Location = new System.Drawing.Point(14, 161);
			this.ParameterBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.ParameterBox1.Name = "ParameterBox1";
			this.ParameterBox1.Size = new System.Drawing.Size(186, 25);
			this.ParameterBox1.TabIndex = 10;
			// 
			// PostLabel
			// 
			this.PostLabel.AutoSize = true;
			this.PostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
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
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(214, 236);
			this.Controls.Add(this.PostLabel);
			this.Controls.Add(this.ParameterBox1);
			this.Controls.Add(this.APITestButton1);
			this.Controls.Add(this.PinLabel);
			this.Controls.Add(this.PinBox);
			this.Controls.Add(this.PinOKButton);
			this.Controls.Add(this.StartAuthButton);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SampleForm";
			this.Text = "MSharpSample";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StartAuthButton;
		private System.Windows.Forms.Button PinOKButton;
		private System.Windows.Forms.TextBox PinBox;
		private System.Windows.Forms.Label PinLabel;
		private System.Windows.Forms.Button APITestButton1;
		private System.Windows.Forms.TextBox ParameterBox1;
		private System.Windows.Forms.Label PostLabel;
	}
}

