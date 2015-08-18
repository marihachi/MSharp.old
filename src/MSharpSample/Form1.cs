using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSharpSample
{
	public partial class SampleForm : Form
	{
		public SampleForm()
		{
			InitializeComponent();
		}

		private MSharp.Misskey mi { set; get; }

		private async void StartAuthButton_Click(object sender, EventArgs e)
		{
			mi = new MSharp.Misskey(Config.AppKey);
			await mi.StartAuthorize();
		}

		private async void PinOKButton_Click(object sender, EventArgs e)
		{
			mi = await mi.AuthorizePIN(PinBox.Text);
			Console.WriteLine("AppKey: " + mi.AppKey);
			Console.WriteLine("UserKey: " + mi.UserKey);
			Console.WriteLine("UserId: " + mi.UserId);

		}

		private async void StatusUpdateButton_Click(object sender, EventArgs e)
		{
			var res = await new MSharp.MisskeyRequest(mi, MSharp.HttpRequest.MethodType.POST, "status/update", new Dictionary<string, string> {
				{ "text", StatusUpdateBox.Text }
			}).Request();
			Console.WriteLine(res);
			StatusUpdateBox.Text = "";
		}
	}
}
