using CompanyAPI.Dtos.Tasks;
using CompanyAPI.Enums;

namespace CompanyAPI.Models
{
	public class GetTopFiveEmployees
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int NumOfDoneTasksInPastMonth
		{
			get
			{
				return Tasks.Count(
							t => t.Status == TaskStatuses.Done &&
							t.DueDate.Year == DateTime.UtcNow.Year &&
							t.DueDate.Month == DateTime.UtcNow.AddMonths(-1).Month
						);
			}
		}

		public ICollection<GetTaskResponseDto> Tasks { get; set; }
			= new List<GetTaskResponseDto>();
	}
}
