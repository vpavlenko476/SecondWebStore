using Microsoft.AspNet.Identity.EntityFramework;

namespace Store.Entities.Identity
{
	class User : IdentityUser
	{
		/// <summary>
		/// Имя пользователя администратора
		/// </summary>
		public const string Administrator = "Admin";
		public const string DeafaultAdminPass = "Password0";
		public string Description { get; set; }
	}
}
