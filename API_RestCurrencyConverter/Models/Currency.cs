using API_RestCurrencyConverter.Helpers;
using API_RestCurrencyConverter.Services;

namespace API_RestCurrencyConverter.Models
{
	public class Currency
	{
		public String? Name { get; set; }
		public Decimal Rate { get; set; }
		public DateTime CurrentDate { get; set; } = DateTime.Now;


		// Método para convertir un valor a la tasa de cambio especificada
		public Decimal Convert(Decimal amount, String targetCurrency )
		{
			Decimal total = 0;
			try
			{			
				GetCurrencies getCurrencies = new GetCurrencies();
				Response response = getCurrencies.Process().Result;
			
				if (GetCurrencies.Currencies != null)
				{
					List<Currency> currencies = GetCurrencies.Currencies;

					var currency = currencies?.FirstOrDefault(c => c.Name == targetCurrency.ToUpper());


					if (currency != null)
					{
						total = amount * currency.Rate;
					}
					else
					{
						total = amount;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}			
			return total;		
		}

	}
}
