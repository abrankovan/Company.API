using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyAPI.Entities
{
	public class Employee
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
		public float MonthlySalary { get; set; }
		public ICollection<EmployeeTask> Tasks { get; set; }
			=new List<EmployeeTask>();
	}
}
