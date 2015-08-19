using System.Json;

namespace MSharp.Core.Utility
{
	/// <summary>
	/// JSON形式のデータを扱うクラスです。
	/// </summary>
	public static class Json
	{
		/// <summary>
		/// JSON の形式にシリアライズされた文字列を動的なJSONオブジェクトに変換します。
		/// <para>また、このメソッドについては例外が発生しないことが保障されています。</para>
		/// </summary>
		/// <param name="json">JSON形式の文字列</param>
		public static dynamic Parse(string json)
		{
			dynamic res;

			if (json == null || string.IsNullOrEmpty(json) || string.IsNullOrWhiteSpace(json))
				res = null;

			try
			{
				res = JsonObject.Parse(json).AsDynamic();
			}
			catch
			{
				res = null;
			}

			return res;
		}
	}
}
