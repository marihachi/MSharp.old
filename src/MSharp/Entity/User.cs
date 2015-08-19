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

			this.BannerImageUrl = new Uri(j.bannerImageUrl.Value);
			this.Bio = j.bio.Value;
			this.Color = ColorTranslator.FromHtml(j.color.Value);
			this.Comment = j.comment.Value;
			this.CreatedAt = null; //TODO
			this.FollowersCount = j.followersCount.Value;
			this.FollowingsCount = j.followingsCount.Value;
			this.IconImageUrl = new Uri(j.iconImageUrl.Value);
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
			this.Url = new Uri(j.url.Value);
			this.WallpaperImageUrl = new Uri(j.wallpaperImageUrl.Value);
		}

		/// <summary>
		/// 
		/// </summary>
		public Uri BannerImageUrl { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string Bio { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public System.Drawing.Color? Color { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string Comment { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreatedAt { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public int? FollowersCount { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public int? FollowingsCount { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public Uri IconImageUrl { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string Id { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsDisplayNotFollowUserMention { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsPlus { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsSuspended { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsVerified { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string Lang { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public List<Uri> Links { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string Location { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string Name { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public string ScreenName { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public int? StatusFavoritesCount { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public int? StatusesCount { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public List<string> Tags { set; get; }

		/// <summary>
		/// 
		/// </summary>
		public Uri Url { set; get; }

		/// <summary>
		/// 
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
