using CompanyAPI.Dtos.Tasks;
using CompanyAPI.Enums;

namespace CompanyAPI.Dtos.Employee
{
	public class GetTopFiveEmployeesDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int NumOfDoneTasksInPastMonth { get; set; }
	}
}
