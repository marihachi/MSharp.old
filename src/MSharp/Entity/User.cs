using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using MSharp.Core.Utility;

namespace MSharp.Entity
{
	/// <summary>
	/// ユーザーオブジェクトを表します。
	/// </summary>
	public class User
	{
		/// <summary>
		/// 新しいインスタンスを生成します。
		/// </summary>
		/// <param name="jsonString">UserオブジェクトのJSON文字列</param>
		public User(string jsonString)
		{
			var j = Json.Parse(jsonString);

			this.BannerImageUrl = !string.IsNullOrEmpty(j.bannerImageUrl.Value) ? new Uri(j.bannerImageUrl.Value) : null;
			this.Bio = j.bio.Value;
			this.Color = ColorTranslator.FromHtml(j.color.Value);
			this.Comment = j.comment.Value;
			this.CreatedAt = null; //TODO
			this.FollowersCount = j.followersCount.Value;
			this.FollowingsCount = j.followingsCount.Value;
			this.IconImageUrl = !string.IsNullOrEmpty(j.iconImageUrl.Value) ? new Uri(j.iconImageUrl.Value) : null;
			this.Id = j.id.Value;
			this.IsDisplayNotFollowUserMention = j.isDisplayNotFollowUserMention.Value;
			this.IsPlus = j.isPlus.Value;
			this.IsSuspended = j.isSuspended.Value;
			this.IsVerified = j.isVerified.Value;
			this.Lang = j.lang.Value;
			this.Links = new List<Uri>();
			foreach (var link in j.links)
				this.Links.Add(new Uri(link.Value));
			this.Location = j.location.Value;
			this.Name = j.name.Value;
			this.ScreenName = j.screenName.Value;
			this.StatusesCount = j.statusesCount.Value;
			this.StatusFavoritesCount = j.statusFavoritesCount.Value;
			this.Tags = new List<string>();
			foreach (var tag in j.tags)
				this.Tags.Add(tag.Value);
			this.Url = !string.IsNullOrEmpty(j.url.Value) ? new Uri(j.url.Value) : null;
			this.WallpaperImageUrl = !string.IsNullOrEmpty(j.wallpaperImageUrl.Value) ? new Uri(j.wallpaperImageUrl.Value) : null;
		}

		/// <summary>
		/// ヘッダー画像のURL
		/// </summary>
		public Uri BannerImageUrl { set; get; }

		/// <summary>
		/// プロフィール
		/// </summary>
		public string Bio { set; get; }

		/// <summary>
		/// カラー
		/// </summary>
		public System.Drawing.Color? Color { set; get; }

		/// <summary>
		/// コメント
		/// </summary>
		public string Comment { set; get; }

		/// <summary>
		/// アカウントの生成日時
		/// </summary>
		public DateTime? CreatedAt { set; get; }

		/// <summary>
		/// フォロワー数
		/// </summary>
		public int? FollowersCount { set; get; }

		/// <summary>
		/// フォロー数
		/// </summary>
		public int? FollowingsCount { set; get; }

		/// <summary>
		/// アイコン画像のURL
		/// </summary>
		public Uri IconImageUrl { set; get; }

		/// <summary>
		/// ID
		/// </summary>
		public string Id { set; get; }

		/// <summary>
		/// フォローしていないユーザーからのメンションを表示するかどうか
		/// </summary>
		public bool IsDisplayNotFollowUserMention { set; get; }

		/// <summary>
		/// PlusAccountであるかどうか
		/// </summary>
		public bool IsPlus { set; get; }

		/// <summary>
		/// 凍結されているかどうか
		/// </summary>
		public bool IsSuspended { set; get; }

		/// <summary>
		/// 認証済みアカウントであるかどうか
		/// </summary>
		public bool IsVerified { set; get; }

		/// <summary>
		/// 言語
		/// </summary>
		public string Lang { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public List<Uri> Links { set; get; }

		/// <summary>
		/// 場所
		/// </summary>
		public string Location { set; get; }

		/// <summary>
		/// 名前
		/// </summary>
		public string Name { set; get; }

		/// <summary>
		/// ユーザー名
		/// </summary>
		public string ScreenName { set; get; }

		/// <summary>
		/// お気に入り数
		/// </summary>
		public int? StatusFavoritesCount { set; get; }

		/// <summary>
		/// 投稿数
		/// </summary>
		public int? StatusesCount { set; get; }

		/// <summary>
		/// タグ
		/// </summary>
		public List<string> Tags { set; get; }

		/// <summary>
		/// URL
		/// </summary>
		public Uri Url { set; get; }

		/// <summary>
		/// 背景画像のURL
		/// </summary>
		public Uri WallpaperImageUrl { set; get; }

		//public DateTime birthday;
		//public string FirstName { set; get; }
		//public string Gender { set; get; }
		//public string LastName { set; get; }
		//public string mobileHeaderDesignId { set; get; }
		//public string ScreenNameLower { set; get; }
		//public string UsingWebthemeId { set; get; }
	}
}
