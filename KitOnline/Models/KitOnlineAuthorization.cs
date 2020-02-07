using System;

namespace KitOnline.Models
{
	/// <summary>
	/// Данные авторизации KitOnline
	/// </summary>
	public readonly struct KitOnlineAuthorization
	{
		public readonly string Login;
		public readonly string Password;
		public readonly int CompanyId;

		public KitOnlineAuthorization(string login, string password, int companyId)
		{
			Login = login ?? throw new ArgumentNullException(nameof(login));
			Password = password ?? throw new ArgumentNullException(nameof(password));
			CompanyId = companyId;
		}
	}
}