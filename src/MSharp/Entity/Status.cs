using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSharp.Core.Utility;
using System.Globalization;

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
		/// <param name="jsonString">ステータスオブジェクトのJSON文字列</param>
		public Status(string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
				throw new ArgumentException("jsonString を空にはできません。");

			dynamic j;

			if ((j = Json.Parse(jsonString)) == null)
				throw new ArgumentException("jsonString の内容が不正です。");

			try
			{
				this.AppId = j.appId.Value;
				this.CreatedAt = null;	//TODO
				this.Cursor = j.cursor.Value;
				this.DisplayCreatedAt = j.displayCreatedAt.Value;
				this.FavoritesCount = j.favoritesCount.Value;
				this.Id = j.id.Value;
				this.InReplyToStatusId = j.inReplyToStatusId.Value;
				this.IsImageAttached = j.isImageAttached.Value;
				this.IsReply = j.isReply.Value;
				this.IsRepostToStatus = j.isRepostToStatus.Value;
				this.RepliesCount = j.repliesCount.Value;
				this.RepostsCount = j.repostsCount.Value;
				this.Text = j.text.Value;
				this.User = j.user != null ? new User(j.user.ToString()) : null;
				this.UserId = j.userId.Value;

				this.ImageUrls = new List<Uri>();
				foreach (var imageUrl in j.imageUrls)
					this.ImageUrls.Add(new Uri(imageUrl.Value));

				this.Replies = new List<string>();
				foreach (var reply in j.replies)
				{
					if (reply.id != null)
						this.Replies.Add(reply.id.Value);
					else
						this.Replies.Add(reply.Value);
				}

				if (this.IsRepostToStatus && j.source != null && j.repostedByUser != null)
					this.Source = new RepostInfo(j.source.ToString(), j.repostedByUser.ToString());
				else
					this.Source = null;

				this.Tags = new List<string>();
				foreach (var tag in j.tags)
					this.Tags.Add(tag.Value);
			}
			catch (Exception ex)
			{
				throw new MSharp.Core.MSharpException("Statusのインスタンス生成時にエラーが発生しました。詳細はinnerExceptionより確認してください。", ex);
			}
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
		/// カーソル
		/// </summary>
		public int Cursor { private set; get; }

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
		/// 返信元のステータスID
		/// </summary>
		public List<string> Replies { set; get; }

		/// <summary>
		/// 返信された数
		/// </summary>
		public int RepliesCount { set; get; }

		///// <summary>
		///// リポスト元のid
		///// </summary>
		//public string RepostFromStatusId { set; get; }

		/// <summary>
		/// リポストされた数
		/// </summary>
		public int RepostsCount { set; get; }

		/// <summary>
		/// リポストであるかどうか
		/// </summary>
		public bool IsRepostToStatus { set; get; }

		/// <summary>
		/// リポスト内容
		/// </summary>
		public RepostInfo Source { set; get; }

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

	/// <summary>
	/// リポストの内容を表します。
	/// </summary>
	public class RepostInfo
	{
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <param name="statusSource">status.sourceのJSON文字列</param>
		/// <param name="repostUser">status.repostedByUserのJSON文字列</param>
		public RepostInfo(string statusSource, string repostUser)
		{
			dynamic j;

			if ((j = Json.Parse(statusSource)) == null)
				throw new ArgumentException("statusSource の内容が不正です。");

			this.Id = j.id.Value;
			this.RepostFromStatusId = j.repostFromStatusId.Value;
			this.Text = j.text.Value;
			this.UserId = j.userId.Value;
			this.User = new User(repostUser);
			this.AppId = j.appId.Value;
			this.CreatedAt = null;	//TODO
			this.DisplayCreatedAt = j.displayCreatedAt.Value;
			this.IsImageAttached = j.isImageAttached.Value;
		}

		/// <summary>
		/// ID
		/// </summary>
		public string Id { set; get; }

		/// <summary>
		/// リポスト元のid
		/// </summary>
		public string RepostFromStatusId { set; get; }

		/// <summary>
		/// コメントの内容
		/// </summary>
		public string Text { private set; get; }

		/// <summary>
		/// リポストしたユーザーのID
		/// </summary>
		public string UserId { private set; get; }

		/// <summary>
		/// リポストしたユーザーオブジェクト
		/// </summary>
		public User User { set; get; }

		/// <summary>
		/// アプリケーションID
		/// </summary>
		public string AppId { set; get; }

		/// <summary>
		/// 投稿日時
		/// </summary>
		public DateTime? CreatedAt { set; get; }

		/// <summary>
		/// 投稿日時(文字列)
		/// </summary>
		public string DisplayCreatedAt { set; get; }

		/// <summary>
		/// 画像が添付されているかどうか
		/// </summary>
		public bool IsImageAttached { set; get; }
	}
}
