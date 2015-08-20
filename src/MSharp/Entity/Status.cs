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
			this.User = j.user != null ? new User(j.user.ToString()) : null;
			this.UserId = j.userId.Value;
		}

		/// <summary>
		/// アプリケーションID
		/// </summary>
		public string AppId { set; get; }

		/// <summary>
		/// 投稿日時
		/// </summary>
		public DateTime? CreatedAt { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public int? Cursor { private set; get; }

		/// <summary>
		/// 投稿日時(文字列)
		/// </summary>
		public string DisplayCreatedAt { set; get; }

		/// <summary>
		/// お気に入り数
		/// </summary>
		public int FavoritesCount { set; get; }

		/// <summary>
		/// ID
		/// </summary>
		public string Id { set; get; }

		/// <summary>
		/// 添付画像のURL
		/// </summary>
		public List<Uri> ImageUrls { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string InReplyToStatusId { set; get; }

		/// <summary>
		/// 画像が添付されているかどうか
		/// </summary>
		public bool IsImageAttached { set; get; }

		/// <summary>
		/// リプライであるかどうか
		/// </summary>
		public bool IsReply { set; get; }

		/// <summary>
		/// リポストであるかどうか
		/// </summary>
		public bool IsRepostToStatus { set; get; }

		/// <summary>
		/// 返信元のステータスID
		/// </summary>
		public List<string> Replies { set; get; }

		/// <summary>
		/// 返信された数
		/// </summary>
		public int RepliesCount { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string RepostFromStatusId { set; get; }

		/// <summary>
		/// リポストされた数
		/// </summary>
		public int RepostsCount { set; get; }

		/// <summary>
		/// タグ
		/// </summary>
		public List<string> Tags { set; get; }

		/// <summary>
		/// 投稿内容
		/// </summary>
		public string Text { private set; get; }

		/// <summary>
		/// 投稿したユーザー
		/// </summary>
		public User User { set; get; }

		/// <summary>
		/// 投稿したユーザーのID
		/// </summary>
		public string UserId { private set; get; }
	}
}
