using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MSharp
{
	public class HttpRequest
	{
		/// <summary>
		/// リクエストメソッドの種類を表します
		/// </summary>
		public enum MethodType
		{
			GET,
			POST
		}

		/// <summary>
		/// リクエストメソッド
		/// </summary>
		public MethodType Method { private set; get; }

		/// <summary>
		/// リクエスト先のURL
		/// </summary>
		public string Url { private set; get; }

		/// <summary>
		/// リクエストヘッダー
		/// </summary>
		public Dictionary<string, string> Headers { private set; get; }

		/// <summary>
		/// リクエストパラメータ
		/// </summary>
		public Dictionary<string, string> Parameters { private set; get; }

		/// <summary>
		/// 新しいインスタンスを生成します
		/// </summary>
		/// <param name="method">リクエストメソッド</param>
		/// <param name="url">リクエストURL</param>
		/// <param name="headers">リクエストのヘッダー</param>
		/// <param name="parameters">リクエストのパラメータ</param>
		public HttpRequest(
			MethodType method,
			string url,
			Dictionary<string, string> headers = null,
			Dictionary<string, string> parameters = null)
		{
			this.Method = method;
			this.Url = url;
			this.Headers = headers;
			this.Parameters = parameters;
		}

		/// <summary>
		/// HTTPのリクエストを送信します。
		/// </summary>
		/// <param name="method">リクエストメソッド</param>
		/// <param name="url">リクエストURL</param>
		/// <param name="header">リクエストヘッダーに付加する内容</param>
		/// <param name="body">リクエストの内容</param>
		/// <returns>レスポンス文字列</returns>
		public async Task<string> Request()
		{
			var client = new HttpClient(new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic });
			foreach (var item in this.Headers)
				client.DefaultRequestHeaders.Add(item.Key, item.Value);
			if (this.Method == MethodType.GET && this.Parameters != null && this.Parameters.Count != 0)
			{
				List<string> query = new List<string>();
				foreach (var item in this.Parameters)
					query.Add(item.Key + "=" + item.Value);
				var JoinedQuery = string.Join("&", query);
				this.Url += "?" + JoinedQuery;
			}
			string resStr;
			if (this.Method == MethodType.GET)
			{
				var res = await client.GetAsync(this.Url);
				resStr = await res.Content.ReadAsStringAsync();
			}
			else
			{
				var res = await client.PostAsync(this.Url, new FormUrlEncodedContent(this.Parameters));
				resStr = await res.Content.ReadAsStringAsync();
			}
			return resStr;
		}
	}
}
