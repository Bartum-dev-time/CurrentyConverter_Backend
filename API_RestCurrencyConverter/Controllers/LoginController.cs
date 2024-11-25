using API_RestCurrencyConverter.Helpers;
using API_RestCurrencyConverter.Models;
using API_RestCurrencyConverter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_RestCurrencyConverter.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class LoginController : ControllerBase
	{
		[HttpPost]
		public ActionResult<Response> Login([FromBody] UserLoginDto loginDto)
		{
			var response = new Response();
			try
			{
				var user = UsersDataStore.Current.Users
					.FirstOrDefault(u => u.Username == loginDto.UserName && u.Password == loginDto.PassUser);

				if (user == null)
				{
					response.State = EState.Abortado;
					response.MessageText = "Usuario o contraseña incorrectos";
					response.ResponseText = "";
					return response;

				}
				else
				{
					response.State = EState.Aceptado;
					response.MessageText = "Bienvenido";
					response.SetResponseText(new { user.Name, user.Role });					
				}
			}
			catch (Exception e)
			{
				response.State = EState.Rechazado;
				response.MessageText = e.Message;
				response.ResponseText = "";				
			}
			return response;
		}

		[HttpPost("currencies")]
		public List<string>? Currencies()
		{
			Response response = new Response();
			try
			{
				GetCurrencies currencies = new GetCurrencies();
				response = currencies.Process().Result;
				var listNameCurrencies = response.ResponseText as List<string>;

				return listNameCurrencies ?? new List<string>();
			}
			catch (Exception e)
			{
				response.State = EState.Rechazado;
				response.MessageText = e.Message;
				response.ResponseText = "";
				return new List<string>();
			}
		}

		//  No se porque cuando uso String me sale error
		[HttpPost("convert")]
		public Response Convert([FromBody] CurrencyConvertDto convertDto)
		{
			Response response = new();
			try
			{
				if (convertDto == null) 				
				{
					response.State = EState.Abortado;
					response.MessageText = "Faltan datos por llenar";
					response.ResponseText = "";
				}
				else
				{
					response = ConvertHelper.Process(convertDto.Amount, convertDto.FinalCurrency);
				}				
			}
			catch (Exception e)
			{
				response.State = EState.Rechazado;
				response.MessageText = e.Message;
				response.ResponseText = "";
			}
			return response;
		}
	}
}
