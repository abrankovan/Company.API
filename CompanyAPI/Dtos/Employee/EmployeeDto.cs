using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Dtos.Employee
{
	public class EmployeeDto
	{
		[Required(ErrorMessage = "You should provide a value")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "You should provide a value")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "You should provide a value")]
		public string Email { get; set; }
		[Required(ErrorMessage = "You should provide a value")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "You should provide a value")]
		public DateTime DateOfBirth { get; set; }
		[Required(ErrorMessage = "You should provide a value")]
		public float MonthlySalary { get; set; }
	}
}
