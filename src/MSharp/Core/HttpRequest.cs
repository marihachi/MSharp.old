using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Drawing;

namespace MSharp.Core
{
	/// <summary>
	/// HTTPリクエストを表します。
	/// </summary>
	public class HttpRequest
	{
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
		/// マルチパートのストリーム
		/// </summary>
		public List<Image> Images { protected set; get; }

		/// <summary>
		/// 新しいインスタンスを生成します
		/// </summary>
		/// <param name="method">リクエストメソッド</param>
		/// <param name="url">リクエストURL</param>
		/// <param name="headers">リクエストのヘッダー</param>
		/// <param name="parameters">リクエストのパラメータ</param>
		/// <param name="images">マルチパートのストリーム</param>
		/// <exception cref="ArgumentException"></exception>
		public HttpRequest(
			MethodType method,
			string url,
			Dictionary<string, string> headers = null,
			Dictionary<string, string> parameters = null,
			List<Image> images = null)
		{
			if (url == null || string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url))
				throw new ArgumentException("url を空にすることは出来ません。");

			if (method != MethodType.GET && method != MethodType.POST)
				throw new ArgumentException("method が無効です。");

			this.Method = method;
			this.Url = url;
			this.Headers = headers ?? new Dictionary<string, string>();
			this.Parameters = parameters ?? new Dictionary<string, string>();
			this.Images = images ?? new List<Image>();
		}

		/// <summary>
		/// 新しいインスタンスを生成します
		/// </summary>
		protected HttpRequest() { }

		/// <summary>
		/// リクエストを送信します。
		/// </summary>
		/// <exception cref="RequestException"></exception>
		/// <exception cref="MSharpException"></exception>
		public virtual async Task<string> Request()
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

			try
			{
				if (this.Method == MethodType.GET)
					res = await client.GetAsync(this.Url);
				else
				{
					if (this.Images.Count == 0)
					{
						res = await client.PostAsync(this.Url, new FormUrlEncodedContent(this.Parameters));
					}
					else
					{
						var content = new MultipartFormDataContent();

						foreach (var param in this.Parameters)
							content.Add(new StringContent(param.Value), param.Key);

						foreach (var image in this.Images)
						{
							MemoryStream ms = new MemoryStream();
							image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
							var sc = new ByteArrayContent(ms.ToArray());
							sc.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
							{
								FileName = "image.jpg",
								Name = "image"
							};
							sc.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

							content.Add(sc, "image");
						}

						res = await client.PostAsync(this.Url, content);
					}
				}
			}
			catch (InvalidOperationException ex)
			{
				throw new RequestException("URLが無効です。", ex);
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
				throw new MSharpException("リクエスト時に想定外のエラーが発生しました", ex);
			}

			try
			{
				resStr = await res.Content.ReadAsStringAsync();
			}
			catch (Exception ex)
			{
				throw new RequestException("レスポンスの読み出しに失敗しました。", ex);
			}

			return resStr;
		}
	}
}
