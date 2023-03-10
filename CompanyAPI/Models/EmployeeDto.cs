using System.Security.Cryptography.X509Certificates;
namespace CompanyAPI.Models
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public DateTime DateOfBirth { get; set; }
		public float MonthlySalary { get; set; }
		public int NumberOfTasks
		{
			get
			{
				return Task.Count;
			}
		}
		
			
		public ICollection<TaskDto> Task { get; set; }
			=new List<TaskDto>();
	}
}
