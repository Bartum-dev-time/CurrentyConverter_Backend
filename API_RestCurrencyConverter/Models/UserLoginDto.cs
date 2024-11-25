using System.ComponentModel.DataAnnotations;

namespace API_RestCurrencyConverter.Models
{
	public class UserLoginDto
	{
		[Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
		[StringLength(20, MinimumLength = 4, ErrorMessage = " Usuario debe tener minimo 4 caracteres.")]
		public  String UserName { get; set; }

		[Required(ErrorMessage = "La contraseña es obligatoria.")]
		[StringLength(20, MinimumLength = 4, ErrorMessage = " Contraseña debe tener minimo 4 caracteres.")]
		public required String PassUser { get; set; }
	}
}
