using System;

namespace MSharp.Core
{
	/// <summary>
	/// MisskeyAPIから返されたエラーを表します。
	/// </summary>
	public class ApiException : ApplicationException
	{
		/// <summary>
		/// 新しいインスタンスを生成します
		/// </summary>
		public ApiException(string message)
			: base(message) { }
	}
}
