namespace API_RestCurrencyConverter.Models
{
	public class User
	{
		private String? _username;
		private String? _password;
		private String? _name;
		private String? _role;

		public String? Username
		{
			get
			{
				return _username;
			}

			set
			{
				_username = value;
			}
		}
		public String? Password
		{
			get
			{
				return _password;
			}

			set
			{
				_password = value;
			}
		}
		public String? Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}
		public String? Role
		{
			get
			{
				return _role;
			}
			set
			{
				_role = value;
			}
		}
	}
}
