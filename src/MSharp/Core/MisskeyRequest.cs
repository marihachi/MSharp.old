using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using MSharp.Core.Utility;
using System.IO;
using System.Drawing;

namespace MSharp.Core
{
	/// <summary>
	/// Misskey の仕様に沿ったHTTPリクエストを表します。
	/// </summary>
	public class MisskeyRequest : HttpRequest
	{
		/// <summary>
		/// このリクエストの基となる Url を取得します。
		/// </summary>
		public Uri BaseUrl { private set; get; }

		/// <summary>
		/// 新しいインスタンスを生成します
		/// </summary>
		/// <param name="misskey">対象となる Misskeyオブジェクト</param>
		/// <param name="method">リクエストメソッド</param>
		/// <param name="endPoint">リクエストのエンドポイント</param>
		/// <param name="parameters">リクエストのパラメータ</param>
		/// <param name="images">イメージデータ</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public MisskeyRequest(
			Misskey misskey,
			MethodType method,
			string endPoint,
			Dictionary<string, string> parameters = null,
			List<Image> images = null)
		{
			if (method != MethodType.GET && method != MethodType.POST)
				throw new ArgumentException("method が無効です。");

			if (string.IsNullOrEmpty(endPoint) || string.IsNullOrWhiteSpace(endPoint))
				throw new ArgumentException("endPoint を空にすることは出来ません。");

			var match = Regex.Match(endPoint, "^/?(.+)/?$");

			if (!match.Success)
				throw new ArgumentException("endPoint は相対パスの形式で入力してください。");

			if (misskey == null || misskey.AppKey == null)
				throw new ArgumentNullException("misskey.AppKey");

			this.Method = method;
			this.Parameters = parameters ?? new Dictionary<string, string>();
			this.Images = images ?? new List<Image>();

			// url
			this.BaseUrl = misskey.BaseUrl ?? new Uri("https://api.misskey.xyz/");
			endPoint = match.Groups[1].ToString();

			this.Url = BaseUrl + endPoint;

			// headers
			var headers = new Dictionary<string, string>();
			headers.Add("sauth-app-key", misskey.AppKey);
			if (misskey.UserKey != null)
				headers.Add("sauth-user-key", misskey.UserKey);

			this.Headers = headers;
		}

		/// <summary>
		/// 現在のMisskeyオブジェクトを使用してリクエストを送信します。
		/// </summary>
		/// <exception cref="RequestException"></exception>
		/// <exception cref="ApiException"></exception>
		public override async Task<string> Request()
		{
			var res = await base.Request();

			var json = Json.Parse(res);
			if (json.error != null)
			{
				throw new ApiException(json.error.message.Value);
			}

			return res;
		}
	}
}
