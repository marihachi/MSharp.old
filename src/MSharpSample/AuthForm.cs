using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MSharp;
using MSharp.Core.Utility;

namespace MSharpSample
{
	public partial class AuthForm : Form
	{
		public Misskey Result { private set; get; }
		private Misskey _Temp { set; get; }

		public AuthForm()
		{
			InitializeComponent();

			this._Temp = new Misskey("hmsk.eLHQBZXJmdKMqdzTbzdnIDsaifKcOIxj");
		}

		private void AuthForm_Load(object sender, EventArgs e)
		{
			PinOKButton.Enabled = false;
		}

		private async void StartAuthButton_Click(object sender, EventArgs e)
		{
			try
			{
				await this._Temp.StartAuthorize();
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
				this.Result = await this._Temp.AuthorizePIN(PinBox.Text);

				this.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
