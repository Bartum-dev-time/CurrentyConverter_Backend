using API_RestCurrencyConverter.Helpers;
using API_RestCurrencyConverter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace API_RestCurrencyConverter.Services
{
	public class GetCurrencies
	{
		public static List<Currency>? Currencies { get; set; }
		public GetCurrencies()
		{		

		}

		public async Task<Response> Process()
		{
			var response = new Response();
			try
			{
				using (var client = new HttpClient())
				{
					String url = "https://api.coinbase.com/v2/exchange-rates?currency=USD";
					var resultHttp = await client.GetAsync(url);
					String jsonString = await resultHttp.Content.ReadAsStringAsync();

					var resultCurrenciesJson = JObject.Parse(jsonString);

					var rates = resultCurrenciesJson?["data"]?["rates"]?.ToObject<Dictionary<String, String>>();
					var nameCurrency = new List<String>();
							
					if (rates != null)
					{
						Currencies = rates
							.Where(r => r.Key != "USD")
							.Select(r => new Currency
							{
								Name = r.Key,
								Rate = Decimal.TryParse(r.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out Decimal rate) ? rate : 0m,

							}).ToList();

						//Lista de solo nombres de divisas
						var currencyNames = Currencies.Select(c => c.Name).ToList();
						

						response.State = EState.Aceptado;
						response.MessageText = "Aceptado";
						response.SetResponseText(currencyNames);
					}
					else
					{
						response.State = EState.Abortado;
						response.MessageText = "No se pudieron obtener las tasas de cambio.";
						response.ResponseText = "";
					}
				}
			}
			catch (Exception e)
			{
				response.State = EState.Rechazado;
				response.MessageText = $"Error al precesar las tasas de cambio: {e.Message}";
				response.ResponseText = "";
			}
			return response;
		}
	}
}
