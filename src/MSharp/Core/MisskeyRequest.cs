using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using MSharp.Core.Utility;

namespace MSharp.Core
{
	/// <summary>
	/// Misskey の仕様に沿ったリクエストを表します。
	/// </summary>
	public class MisskeyRequest : HttpRequest
	{
		/// <summary>
		/// リクエストの基となる Url を取得します。
		/// </summary>
		public string BaseUrl { private set; get; }

		/// <summary>
		/// 新しいインスタンスを生成します
		/// </summary>
		/// <param name="misskey">対象となる Misskeyオブジェクト</param>
		/// <param name="method">リクエストメソッド</param>
		/// <param name="endPoint">リクエストのエンドポイント</param>
		/// <param name="parameters">リクエストのパラメータ</param>
		/// <param name="baseUrl">リクエストの基となる Url</param>
		/// <exception cref="ArgumentException"></exception>
		/// <exception cref="ArgumentNullException"></exception>
		public MisskeyRequest(
			Misskey misskey,
			MethodType method,
			string endPoint,
			Dictionary<string, string> parameters = null,
			string baseUrl = null)
		{
			var match = Regex.Match(endPoint, "^/?(.+)/?$");

			if (!match.Success)
				throw new ArgumentException("エンドポイントは相対パスの形式で入力してください");

			if (misskey == null || misskey.AppKey == null)
				throw new ArgumentNullException("misskey.AppKey");

			this.Method = method;
			this.Parameters = parameters ?? new Dictionary<string, string>();

			// url
			this.BaseUrl = baseUrl ?? "https://api.misskey.xyz/";
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
		public override async Task<string> Request()
		{
			var res = await base.Request();

			var json = Json.Parse(res);
			if (json.error != null)
			{
				var ex = new RequestException("Misskeyからエラーが返されました。");
				ex.Data.Add("Error", json.error.ToString());
				throw ex;
			}

			return res;
		}
	}
}
