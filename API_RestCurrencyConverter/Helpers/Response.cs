using API_RestCurrencyConverter.Models;
using Newtonsoft.Json;

namespace API_RestCurrencyConverter.Helpers
{
	public class Response
	{
		public EState State { get; set; }
		public String? MessageText { get; set; }
		public Object? ResponseText { get; set; }

		// Método para establecer datos dinámicos en ResponseText
		public void SetResponseText(Object data)
		{
			ResponseText = data;
		}
	}
}
