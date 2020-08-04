using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Store.ViewModels
{
	public class EmployeeViewModel
	{
		[HiddenInput(DisplayValue =false)]
		public int Id { get; set; }

		[Display(Name = "Имя")]
		[Required(ErrorMessage = "Введите Имя")]
		[StringLength(200, MinimumLength = 3, ErrorMessage = "Длина Имени должна быть от 3 до 200 символов")]		
		public string Name { get; set; }

		[Display(Name = "Фамилия")]
		[Required(ErrorMessage = "Введите Фамилию")]
		[StringLength(200, MinimumLength = 3, ErrorMessage = "Длина Фамилии должна быть от 3 до 200 символов")]
		public string SecondName { get; set; }

		[Display(Name = "Отчество")]
		public string Patronymic { get; set; } 
	}
}
