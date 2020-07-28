using Microsoft.AspNetCore.Identity;

namespace Store.Entities.Identity
{
	public class Role: IdentityRole
	{
		/// <summary>
		/// имя роли администратора
		/// </summary>
		public const string Administrator = "AdminRole";

		/// <summary>
		/// имя роли пользоватея
		/// </summary>
		public const string User = "UserRole";
	}
}
