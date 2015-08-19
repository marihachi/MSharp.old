using System;

namespace MSharp.Core
{
	/// <summary>
	/// MSharpの全般的なエラーを表します。
	/// </summary>
	public class MSharpException : ApplicationException
	{
		public MSharpException(string message)
			: base(message) { }

		public MSharpException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}
