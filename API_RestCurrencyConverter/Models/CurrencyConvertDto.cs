using System.ComponentModel.DataAnnotations;

namespace API_RestCurrencyConverter.Models
{
	public class CurrencyConvertDto
	{
		[Required(ErrorMessage = "Agrega un valor")]
		public Decimal Amount { get; set; }
		[Required(ErrorMessage = "Agrega la moneda a la que quieres convertir")]
		public required String FinalCurrency { get; set; }
	}
}
