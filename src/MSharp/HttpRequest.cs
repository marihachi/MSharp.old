using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

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
		public MethodType Method { protected set; get; }

		/// <summary>
		/// リクエスト先のURL
		/// </summary>
		public string Url { protected set; get; }

		/// <summary>
		/// リクエストヘッダー
		/// </summary>
		public Dictionary<string, string> Headers { protected set; get; }

		/// <summary>
		/// リクエストパラメータ
		/// </summary>
		public Dictionary<string, string> Parameters { protected set; get; }

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
			this.Url = url ?? "";
			this.Headers = headers ?? new Dictionary<string, string>();
			this.Parameters = parameters ?? new Dictionary<string, string>();
		}

		/// <summary>
		/// リクエストを送信します。
		/// </summary>
		public async Task<string> Request()
		{
			var client = new HttpClient(new HttpClientHandler { ClientCertificateOptions = ClientCertificateOption.Automatic });
			foreach (var item in this.Headers)
				client.DefaultRequestHeaders.Add(item.Key, item.Value);
			if (this.Method == MethodType.GET && this.Parameters.Count != 0)
			{
				List<string> query = new List<string>();
				foreach (var item in this.Parameters)
					query.Add(item.Key + "=" + item.Value);
				var JoinedQuery = string.Join("&", query);
				this.Url += "?" + JoinedQuery;
			}
			string resStr = null;
			HttpResponseMessage res = null;

			if (this.Method == MethodType.GET)
			{
				try
				{
					res = await client.GetAsync(this.Url);
				}
				catch(InvalidOperationException)
				{
					throw new RequestException("URLが不正です。", ex);
				}
				catch (HttpRequestException ex)
				{
					if (ex.InnerException != null && ex.InnerException.GetType().Name == "WebException")
						throw new RequestException("HTTPエラーが発生しました。(" + ((WebException)ex.InnerException).Message + ")", ex);
					else
						throw new RequestException("HTTPエラーが発生しました。", ex);
				}
				catch (Exception ex)
				{
					throw new RequestException("想定外のエラーが発生しました", ex);
				}

				try
				{
					resStr = await res.Content.ReadAsStringAsync();
				}
				catch (Exception ex)
				{
					throw new RequestException("レスポンスの読み出しに失敗しました。", ex);
				}
			}
			else
			{
				try
				{
					res = await client.PostAsync(this.Url, new FormUrlEncodedContent(this.Parameters));
				}
				catch (InvalidOperationException)
				{
					throw new RequestException("URLもしくはパラメータが不正です。", ex);
				}
				catch (HttpRequestException ex)
				{
					if (ex.InnerException != null && ex.InnerException.GetType().Name == "WebException")
						throw new RequestException("HTTPエラーが発生しました。(" + ((WebException)ex.InnerException).Message + ")", ex);
					else
						throw new RequestException("HTTPエラーが発生しました。", ex);
				}
				catch (Exception ex)
				{
					throw new RequestException("想定外のエラーが発生しました", ex);
				}

				try
				{
					resStr = await res.Content.ReadAsStringAsync();
				}
				catch (Exception ex)
				{
					throw new RequestException("レスポンスの読み出しに失敗しました。", ex);
				}
			}
			return resStr;
		}
	}
}
