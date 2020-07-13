﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels.Identity
{
	public class LoginViewModel
	{
		[Required]
		[MaxLength(256)]
		[Display(Name = "Имя пользователя")]		
		public string UserName { get; set; }

		[Required]
		[Display(Name = "Пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Display(Name = "Запомнить меня")]		
		public bool RememberMe { get; set; }
		
		[HiddenInput(DisplayValue = false)]
		public string ReturnUrl { get; set; }
	}
}
