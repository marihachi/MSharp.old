using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using MSharp;
using MSharp.Core.Utility;
using MSharp.Entity;
using System;
using System.Diagnostics;

namespace MSharpSample
{
	class StatusStorage
	{
		public Misskey Account { private set; get; }
		public List<MSharp.Entity.Status> Items { set; get; }

		public StatusStorage(Misskey account)
		{
			Items = new List<MSharp.Entity.Status>();
			Account = account;
        }

		/// <summary>
		/// タイムラインを取得して登録されていないステータスを昇順で取得します
		/// </summary>
		public async Task<List<MSharp.Entity.Status>> GetNewTimelineStatuses(int count = 15)
		{
			var statuses = new List<Status>();

			try
			{
				var res = await Account.Request(
					MethodType.GET,
					"status/timeline",
					new Dictionary<string, string>()
					{
						{ "count", count.ToString() }
					});

				var jsonArray = Json.Parse(res);
				if (jsonArray != null)
				{
					foreach (var json in jsonArray)
					{
						var status = new Status(json.ToString());
						if (Items.Find(i => ((i.IsRepostToStatus ? i.Source.Id : i.Id) == (status.IsRepostToStatus ? status.Source.Id : status.Id))) == null)
						{
							Items.Add(status);
							statuses.Add(status);
						}
						else
							Console.WriteLine("既にその項目は存在します");
					}
					statuses.Sort();
				}
			}
			catch (MSharp.Core.RequestException ex)
			{
				MessageBox.Show(ex.Message, "リクエストエラー");
			}
			catch (MSharp.Core.ApiException ex)
			{
				MessageBox.Show(ex.Message, "APIエラー");
			}

			return statuses;
        }

		/// <summary>
		/// ListViewの項目として構築します
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static ListViewItem BuildListViewItem(MSharp.Entity.Status item)
		{
			ListViewItem result;

			if (item.IsRepostToStatus)
			{
				result = new ListViewItem(
					new string[] {
						string.Format("@{0} (@{1}によってRP)", item.User.ScreenName, item.Source.User.ScreenName),
						item.Text });
				result.ForeColor = Color.Lime;
			}
			else
				result = new ListViewItem(
					new string[] {
						string.Format("@{0}", item.User.ScreenName),
						item.Text });

			return result;
        }
	}
}
