namespace CompanyAPI.Models
{
	public class DepartmentStatistics
	{
		public int DepartmentId { get; set; }
		public int NumOfTotalEmployees { get; set; }
		public int NumOfTotalTasks { get; set; }
		public int NumOfDoneTasks { get; set; }
		public int NumOfFailedTasks { get; set; }
		public int NumOfInProgressTasks { get; set; }

	}
}
