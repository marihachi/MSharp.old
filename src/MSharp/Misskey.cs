using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MSharp.Core;
using MSharp.Entity;
using MSharp.Core.Utility;

namespace MSharp
{
	/// <summary>
	/// リクエストメソッドの種類を表します
	/// </summary>
	public enum MethodType
	{
		/// <summary>
		/// GETメソッド
		/// </summary>
		GET,
		/// <summary>
		/// POSTメソッド
		/// </summary>
		POST
	}

	/// <summary>
	/// Misskeyオブジェクトを表します。
	/// </summary>
	public class Misskey
	{
		/// <summary>
		/// アプリ連携のキーを取得します。
		/// </summary>
		public string AppKey { private set; get; }

		/// <summary>
		/// アプリの利用に必要なユーザー毎のキーを取得します。
		/// </summary>
		public string UserKey { private set; get; }

		/// <summary>
		/// ユーザーオブジェクトを取得または設定します。
		/// </summary>
		public User User { set; get; }

		private string AuthenticationSessionKey { set; get; }

		/// <summary>
		/// 新しいMisskeyオブジェクトを生成します
		/// </summary>
		/// <param name="appKey">アプリ連携のキー</param>
		public Misskey(string appKey)
		{
			if (appKey == null)
				throw new ArgumentNullException("appKey");

			this.AppKey = appKey;
		}

		/// <summary>
		/// 新しいMisskeyオブジェクトを生成します
		/// </summary>
		/// <param name="appKey">アプリ連携のキー</param>
		/// <param name="userKey">アプリの利用に必要なユーザー毎のキー</param>
		/// <param name="user">ユーザーオブジェクト</param>
		public Misskey(
			string appKey,
			string userKey,
			User user)
		{
			if (appKey == null)
				throw new ArgumentNullException("appKey");
			if (userKey == null)
				throw new ArgumentNullException("userKey");
			if (user == null)
				throw new ArgumentNullException("user");

			this.AppKey = appKey;
			this.UserKey = userKey;
			this.User = user;
		}

		/// <summary>
		/// 認証されたMisskeyオブジェクトであるかどうかを示す値を取得します。
		/// </summary>
		public bool IsAuthorized
		{
			get
			{
				return UserKey != null;
			}
		}

		/// <summary>
		/// 現在のMisskeyオブジェクトを使用してアプリ連携ページを表示します。
		/// </summary>
		/// <exception cref="MSharpException"></exception>
		/// <exception cref="RequestException"></exception>
		public async Task StartAuthorize()
		{
			var res = await new MisskeyRequest(this, MethodType.GET, "https://api.misskey.xyz/sauth/get-authentication-session-key").Request();

			var json = Json.Parse(res);
			if (json != null)
				this.AuthenticationSessionKey = json.authenticationSessionKey;
			else
				throw new MSharpException("AuthenticationSessionKey の取得に失敗しました。");

			try
			{
				System.Diagnostics.Process.Start("https://api.misskey.xyz/authorize@" + this.AuthenticationSessionKey);
			}
			catch (Exception ex)
			{
				throw new MSharpException("アプリ連携ページの表示に失敗しました。", ex);
			}
		}

		/// <summary>
		/// ユーザーから入力されたPINコードを検証し、認証されたMisskeyオブジェクトの取得を試行します。
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		/// <exception cref="MSharpException"></exception>
		/// <exception cref="RequestException"></exception>
		public async Task<Misskey> AuthorizePIN(string pinCode)
		{
			if(this.AuthenticationSessionKey == null)
				throw new MSharpException("StartAuthorizeメソッドが呼び出されていません。");

			var ret = await new MisskeyRequest(this, MethodType.GET, "sauth/get-user-key",
				new Dictionary<string, string> {
					{ "authentication-session-key", this.AuthenticationSessionKey },
					{ "pin-code", pinCode}
				}).Request();

			var json = Json.Parse(ret);
			if(json == null)
				throw new MSharpException("PINコードの検証に失敗しました。");

			return new Misskey(this.AppKey, json.userKey.Value, new User(json.user.ToString()));
		}

		/// <summary>
		/// 現在のMisskeyオブジェクトを使用してリクエストを送信します。
		/// </summary>
		/// <param name="method">リクエストメソッド</param>
		/// <param name="endPoint">リクエストのエンドポイント</param>
		/// <param name="parameters">リクエストのパラメータ</param>
		/// <param name="baseUrl">リクエストの基となる Url</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="MSharpException"></exception>
		/// <exception cref="RequestException"></exception>
		public async Task<string> Request(
			MethodType method,
			string endPoint,
			Dictionary<string, string> parameters = null,
			string baseUrl = null)
		{
			if (!IsAuthorized)
				throw new MSharpException("このMisskeyオブジェクトは認証されていません。");

			return await new MisskeyRequest(this, method, endPoint, parameters, baseUrl).Request();
		}
	}
}
