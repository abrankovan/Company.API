namespace CompanyAPI.Models
{
	public class TaskDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }	
		public bool Assigned { get; set; }
		public DateTime DueDate { get; set; }
	}
}
