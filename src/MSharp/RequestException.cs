using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSharp
{
	public class RequestException : ApplicationException
	{
		public RequestException(string message)
			: base(message) { }

		public RequestException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}
