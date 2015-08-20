using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MSharp;
using MSharp.Core.Utility;

namespace MSharpSample
{
	public partial class SampleForm : Form
	{
		private Misskey mi { set; get; }

		public SampleForm()
		{
			InitializeComponent();
		}

		private void SampleForm_Load(object sender, EventArgs e)
		{
			var authForm = new AuthForm();

			if (authForm.ShowDialog() == System.Windows.Forms.DialogResult.OK && authForm.Result.IsAuthorized)
				mi = authForm.Result;
			else
				this.Close();
		}

		private async void StatusUpdateButton_Click(object sender, EventArgs e)
		{
			try
			{
				var res = await mi.Request(
					MethodType.POST,
					"status/update",
					new Dictionary<string, string> {
						{ "text", StatusUpdateBox.Text }
					});

				StatusUpdateBox.Text = "";
			}
			catch (MSharp.Core.RequestException ex)
			{
				if (ex.Message == "Misskeyからエラーが返されました。")
				{
					var json = Json.Parse((string)ex.Data["Error"]);
					string message = json.message;
					MessageBox.Show(message);
				}
				else
				{
					MessageBox.Show(ex.Message);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void GetTimeLineButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("未実装項目です。");
		}
	}
}
