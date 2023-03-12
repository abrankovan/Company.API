using CompanyAPI.Enums;

namespace CompanyAPI.Dtos.Tasks
{
	public class TaskDto
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public TaskStatuses	Status { get; set; }
	}
}
