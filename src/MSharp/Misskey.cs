using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;

namespace MSharp
{
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
			var ret = await new MisskeyRequest(this, HttpRequest.MethodType.GET, "sauth/get-authentication-session-key").Request();

			var json = JsonObject.Parse(ret).AsDynamic();
			this.AuthenticationSessionKey = json.authenticationSessionKey;

			System.Diagnostics.Process.Start("https://api.misskey.xyz/authorize@" + this.AuthenticationSessionKey);
		}

		public async Task<Misskey> AuthorizePIN(string pinCode)
		{
			var ret = await new MisskeyRequest(this, HttpRequest.MethodType.GET, "sauth/get-user-key",
				new Dictionary<string, string> {
					{ "authentication-session-key", AuthenticationSessionKey },
					{ "pin-code", pinCode}
				}).Request();

			var json = JsonObject.Parse(ret).AsDynamic();

			return new Misskey(this.AppKey, (string)json.userKey, (string)json.userId);
		}

		public async Task<string> Request(
			HttpRequest.MethodType method,
			string endPoint,
			Dictionary<string, string> parameters = null,
			string baseUrl = null)
		{
			return await new MisskeyRequest(this, method, endPoint, parameters, baseUrl).Request();
		}
	}
}
