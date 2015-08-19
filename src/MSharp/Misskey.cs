using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MSharp.Core;
using MSharp.Core.Utility;

namespace MSharp
{
	/// <summary>
	/// リクエストメソッドの種類を表します
	/// </summary>
	public enum MethodType
	{
		GET,
		POST
	}

	public class Misskey
	{
		public string AppKey { private set; get; }
		public string UserKey { private set; get; }
		public string UserId { private set; get; }
		private string AuthenticationSessionKey { set; get; }

		public Misskey(string appKey)
		{
			this.AppKey = appKey;
		}

		public Misskey(
			string appKey,
			string userKey,
			string userId)
		{
			this.AppKey = appKey;
			this.UserKey = userKey;
			this.UserId = userId;
		}

		public async Task StartAuthorize()
		{
			var res = await new MisskeyRequest(this, MethodType.GET, "https://api.misskey.xyz/sauth/get-authentication-session-key").Request();

			var json = Json.Parse(res);
			if (json != null)
				this.AuthenticationSessionKey = json.AuthenticationSessionKey;
			else
				throw new RequestException("AuthenticationSessionKey の取得に失敗しました。");

			try
			{
				System.Diagnostics.Process.Start("https://api.misskey.xyz/authorize@" + this.AuthenticationSessionKey);
			}
			catch (Exception ex)
			{
				throw new RequestException("アプリ連携ページの表示に失敗しました。", ex);
			}
		}

		public async Task<Misskey> AuthorizePIN(string pinCode)
		{
			var ret = await new MisskeyRequest(this, MethodType.GET, "sauth/get-user-key",
				new Dictionary<string, string> {
					{ "authentication-session-key", AuthenticationSessionKey },
					{ "pin-code", pinCode}
				}).Request();

			var json = Json.Parse(ret);

			return new Misskey(this.AppKey, (string)json.userKey, (string)json.userId);
		}

		public async Task<string> Request(
			MethodType method,
			string endPoint,
			Dictionary<string, string> parameters = null,
			string baseUrl = null)
		{
			return await new MisskeyRequest(this, method, endPoint, parameters, baseUrl).Request();
		}
	}
}
