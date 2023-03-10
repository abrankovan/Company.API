using System.ComponentModel.DataAnnotations;
namespace CompanyAPI.Models
{
	public class PutEmployeeRequestDto
	{
		[Required(ErrorMessage = "You should provide a first name value")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "You should provide a last name value")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "You should provide a email value")]
		public string Email { get; set; }
		public string Phone { get; set; }

		[Required(ErrorMessage = "You should provide a date of birth value")]
		public DateTime DateOfBirth { get; set; }
		public float MonthlySalary { get; set; }
	}
}
