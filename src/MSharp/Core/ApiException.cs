using System;

namespace MSharp.Core
{
	/// <summary>
	/// MisskeyAPIから返されたエラーを表します。
	/// </summary>
	public class ApiException : ApplicationException
	{
		public ApiException(string message)
			: base(message) { }
	}
}
