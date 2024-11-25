using API_RestCurrencyConverter.Models;

namespace API_RestCurrencyConverter.Services
{
	public class UsersDataStore
	{
		public List<User> Users { get; set; }

		//Singleton - Para que solo exista una instancia de la lista Users
		public static UsersDataStore Current { get; } = new UsersDataStore();

		public UsersDataStore()
		{
			Users = new List<User>()
			{
				new User()
				{
					Username = "admin",
					Password = "1234",
					Name = "admin1",
					Role = "ADMIN"
				},
				new User()
				{
					Username = "Juan",
					Password = "1234",
					Name = "Juan",
					Role = "Cocinero"
				}, new User()
				{
					Username = "Roberto",
					Password = "1234",
					Name = "Roberto",
					Role = "Administrador contable"
				}, new User()
				{
					Username = "Camarero",
					Password = "1234",
					Name = "Camacho",
					Role = "Ingeniero"
				}, new User()
				{
					Username = "Natilla",
					Password = "1234",
					Name = "Natalia",
					Role = "Camarera"
				}
			};
		}

	}
}
