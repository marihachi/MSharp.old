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
			this.StatusUpdateButton = new System.Windows.Forms.Button();
			this.StatusUpdateBox = new System.Windows.Forms.TextBox();
			this.GetTimeLineButton = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// StatusUpdateButton
			// 
			this.StatusUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusUpdateButton.BackColor = System.Drawing.Color.Transparent;
			this.StatusUpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.StatusUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.StatusUpdateButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.StatusUpdateButton.Location = new System.Drawing.Point(294, 79);
			this.StatusUpdateButton.Margin = new System.Windows.Forms.Padding(10, 5, 5, 5);
			this.StatusUpdateButton.Name = "StatusUpdateButton";
			this.StatusUpdateButton.Size = new System.Drawing.Size(76, 29);
			this.StatusUpdateButton.TabIndex = 5;
			this.StatusUpdateButton.Text = "Update";
			this.StatusUpdateButton.UseVisualStyleBackColor = false;
			this.StatusUpdateButton.Click += new System.EventHandler(this.StatusUpdateButton_Click);
			// 
			// StatusUpdateBox
			// 
			this.StatusUpdateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StatusUpdateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.StatusUpdateBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StatusUpdateBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.StatusUpdateBox.Location = new System.Drawing.Point(14, 12);
			this.StatusUpdateBox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
			this.StatusUpdateBox.Multiline = true;
			this.StatusUpdateBox.Name = "StatusUpdateBox";
			this.StatusUpdateBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.StatusUpdateBox.Size = new System.Drawing.Size(356, 59);
			this.StatusUpdateBox.TabIndex = 10;
			// 
			// GetTimeLineButton
			// 
			this.GetTimeLineButton.BackColor = System.Drawing.Color.Transparent;
			this.GetTimeLineButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
			this.GetTimeLineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.GetTimeLineButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.GetTimeLineButton.Location = new System.Drawing.Point(14, 79);
			this.GetTimeLineButton.Margin = new System.Windows.Forms.Padding(5);
			this.GetTimeLineButton.Name = "GetTimeLineButton";
			this.GetTimeLineButton.Size = new System.Drawing.Size(104, 29);
			this.GetTimeLineButton.TabIndex = 12;
			this.GetTimeLineButton.Text = "Get TimeLine";
			this.GetTimeLineButton.UseVisualStyleBackColor = false;
			this.GetTimeLineButton.Click += new System.EventHandler(this.GetTimeLineButton_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(14, 118);
			this.listView1.Margin = new System.Windows.Forms.Padding(5);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(356, 131);
			this.listView1.TabIndex = 13;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ScreenName";
			this.columnHeader1.Width = 116;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Text";
			this.columnHeader2.Width = 252;
			// 
			// SampleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
			this.ClientSize = new System.Drawing.Size(384, 263);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.GetTimeLineButton);
			this.Controls.Add(this.StatusUpdateBox);
			this.Controls.Add(this.StatusUpdateButton);
			this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "SampleForm";
			this.Text = "MSharpSample";
			this.Load += new System.EventHandler(this.SampleForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button StatusUpdateButton;
		private System.Windows.Forms.TextBox StatusUpdateBox;
		private System.Windows.Forms.Button GetTimeLineButton;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}

