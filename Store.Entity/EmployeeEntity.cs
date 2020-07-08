using Store.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Entities
{
	[Table("Employees")]
	public class EmployeeEntity: BaseEntity
	{
		[StringLength(50)]
		public string FirstName { get; set; }
		[StringLength(50)]
		public string SecondName { get; set; }
		[StringLength(50)]
		public string Patronymic { get; set; }
		public string Email { get; set; }
		public string MobilePhone { get; set; }
		public int Age { get; set; }
	}
}
