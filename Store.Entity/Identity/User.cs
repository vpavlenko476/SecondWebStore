using Microsoft.AspNetCore.Identity;

namespace Store.Entities.Identity
{
	public class User : IdentityUser
	{
		/// <summary>
		/// Имя пользователя администратора
		/// </summary>
		public const string Administrator = "Admin";
		public const string DeafaultAdminPass = "Password0";
		public string Description { get; set; }
	}
}
