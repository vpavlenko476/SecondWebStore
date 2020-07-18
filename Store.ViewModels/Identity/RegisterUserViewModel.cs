using System.ComponentModel.DataAnnotations;

namespace Store.ViewModels.Identity
{
	public class RegisterUserViewModel
	{
		[Required(ErrorMessage = "Введите имя пользователя")]
		[Display(Name = "Имя пользователя")]
		[MaxLength(256)]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Введите пароль")]
		[Display(Name = "Пароль")]
		[StringLength(20, MinimumLength = 6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Введите подтверждение пароля")]
		[Display(Name = "Подтверждение пароля")]
		[StringLength(20, MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Compare(nameof(Password))]
		public string PasswordConfirm { get; set; }
	}
}
