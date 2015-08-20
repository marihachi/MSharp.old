using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSharp.Core.Utility;

namespace MSharp.Entity
{
	/// <summary>
	/// ステータスオブジェクトを表します。
	/// </summary>
	public class Status
	{
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <param name="jsonString">UserオブジェクトのJSON文字列</param>
		public Status(string jsonString)
		{
			var j = Json.Parse(jsonString);

			this.AppId = j.appId.Value;
			this.CreatedAt = null;	//j.createdAt.Value;
			this.Cursor = j.cursor.Value;
			this.DisplayCreatedAt = j.displayCreatedAt.Value;
			this.FavoritesCount = j.favoritesCount.Value;
			this.Id = j.id.Value;
			this.ImageUrls = new List<Uri>();
			foreach (var imageUrl in j.imageUrls)
				this.ImageUrls.Add(new Uri(imageUrl.Value));
			this.InReplyToStatusId = j.inReplyToStatusId.Value;
			this.IsImageAttached = j.isImageAttached.Value;
			this.IsReply = j.isReply.Value;
			this.IsRepostToStatus = j.isRepostToStatus.Value;
			this.Replies = new List<string>();
			foreach (var replie in j.replies)
				if (replie.id != null)
					this.Replies.Add(replie.id.Value);
				else
					this.Replies.Add(replie.Value);
			this.RepliesCount = j.repliesCount.Value;
			this.RepostFromStatusId = j.repostFromStatusId.Value;
			this.RepostsCount = j.repostsCount.Value;
			this.Tags = new List<string>();
			foreach (var tag in j.tags)
				this.Tags.Add(tag.Value);
			this.Text = j.text.Value;
			this.User = j.user.Value != null ? new User(j.user.Value) : null;
			this.UserId = j.userId.Value;
		}

		public string AppId { set; get; }
		public DateTime? CreatedAt { set; get; }
		public int? Cursor { private set; get; }
		public string DisplayCreatedAt { set; get; }
		public int FavoritesCount { set; get; }
		public string Id { set; get; }
		public List<Uri> ImageUrls { set; get; }
		public string InReplyToStatusId { set; get; }
		public bool IsImageAttached { set; get; }
		public bool IsReply { set; get; }
		public bool IsRepostToStatus { set; get; }

		/// <summary>
		/// そのステータスへの返信ID
		/// </summary>
		public List<string> Replies { set; get; }

		public int RepliesCount { set; get; }
		public string RepostFromStatusId { set; get; }
		public int RepostsCount { set; get; }
		public List<string> Tags { set; get; }
		public string Text { private set; get; }
		public User User { set; get; }
		public string UserId { private set; get; }
	}
}
