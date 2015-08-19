using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MSharp;

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
			await mi.StartAuthorize();
			PinOKButton.Enabled = true;
		}

		private async void PinOKButton_Click(object sender, EventArgs e)
		{
			try
			{
				mi = await mi.AuthorizePIN(PinBox.Text);
				StatusUpdateButton.Enabled = true;
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
					(MethodType)3,
					"status/update",
					new Dictionary<string, string> {
					{ "text", StatusUpdateBox.Text }
				});

				//var res = await mi.Request(
				//	MethodType.POST,
				//	"status/update",
				//	new Dictionary<string, string> {
				//	{ "text", StatusUpdateBox.Text }
				//});
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			StatusUpdateBox.Text = "";
		}

		private void SampleForm_Load(object sender, EventArgs e)
		{
			PinOKButton.Enabled = false;
			StatusUpdateButton.Enabled = false;
		}
	}
}
