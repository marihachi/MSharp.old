using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MSharp;
using MSharp.Core.Utility;

namespace MSharpSample
{
	public partial class SampleForm : Form
	{
		public SampleForm()
		{
			InitializeComponent();
		}

		private Misskey mi { set; get; }

		private string AppKey = "hmsk.eLHQBZXJmdKMqdzTbzdnIDsaifKcOIxj";

		private async void StartAuthButton_Click(object sender, EventArgs e)
		{
			mi = new Misskey(AppKey);
			try
			{
				await mi.StartAuthorize();
				PinOKButton.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}

		private async void PinOKButton_Click(object sender, EventArgs e)
		{
			try
			{
				mi = await mi.AuthorizePIN(PinBox.Text);
				StatusUpdateButton.Enabled = true;
				PinOKButton.Enabled = false;
				StartAuthButton.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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

		private void SampleForm_Load(object sender, EventArgs e)
		{
			PinOKButton.Enabled = false;
			StatusUpdateButton.Enabled = false;
		}
	}
}
