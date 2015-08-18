using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MSharp
{
	class MisskeyRequest
	{
		public string BaseUrl { private set; get; }

		private HttpRequest RequestInstance { private set; get; }

		public MisskeyRequest(
			Misskey misskey,
			HttpRequest.MethodType method,
			string endPoint,
			Dictionary<string, string> parameters = null, string baseUrl = null)
		{
			this.BaseUrl = baseUrl ?? "https://api.misskey.xyz/";

			var match = Regex.Match(endPoint, "^/?(.+)$");
			endPoint = match.Groups[1].ToString();

			var headers = new Dictionary<string, string> {
				{ "sauth-app-key", misskey.AppKey }
			};

			this.RequestInstance = new HttpRequest(method, BaseUrl + endPoint, headers, parameters);
		}

		public async Task<string> Request()
		{
			return await this.RequestInstance.Request();
		}
	}
}
