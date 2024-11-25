using API_RestCurrencyConverter.Models;
using API_RestCurrencyConverter.Services;

namespace API_RestCurrencyConverter.Helpers
{
	public static class ConvertHelper
	{
		public static Response Process(Decimal amount, String finalCurrency)
		{
			Response response = new Response();
			try
			{	
				Currency currency = new Currency();
				Decimal Total = currency.Convert(amount, finalCurrency);

				if (Total == 0)
				{
					response.State = EState.Abortado;
					response.MessageText = "Error en las divisas";
					response.ResponseText = "";

					return response;
				}
				response.State = EState.Aceptado;
				response.MessageText = finalCurrency;
				response.ResponseText = Total;

				return response;
			}
			catch (Exception e)
			{
				response.State = EState.Rechazado;
				response.MessageText = $"Error al convertir moneda {e.Message}";
				response.ResponseText = "";
			}
			return response;

		}
	}
}
