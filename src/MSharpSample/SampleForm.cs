using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MSharp;
using MSharp.Core.Utility;
using MSharp.Entity;
using System.Drawing;

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

		private async void GetTimeLineButton_Click(object sender, EventArgs e)
		{
			

			try
			{
				var res = await mi.Request(
					MethodType.GET,
					"status/timeline");

				var json = Json.Parse(res);
				if (json != null)
				{
					var statusObjList = new List<Status>();
					foreach (var status in json)
						statusObjList.Add(new Status(status.ToString()));

					listView1.Items.Clear();

					foreach (var statusObj in statusObjList)
					{
						ListViewItem item;

						if (statusObj.IsRepostToStatus)
						{
							item = new ListViewItem(
								new string[] {
									string.Format("@{0} (@{1}によってRP)", statusObj.User.ScreenName, statusObj.Source.User.ScreenName),
									statusObj.Text });
							item.ForeColor = Color.Lime;
						}
						else
						{
							item = new ListViewItem(new string[] { statusObj.User.ScreenName, statusObj.Text });
						}

						listView1.Items.Add(item);
					}
				}

			}
			catch (MSharp.Core.RequestException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
