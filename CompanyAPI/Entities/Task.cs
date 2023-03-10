using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyAPI.Entities
{
	public class EmployeeTask
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Assigned { get; set; }
		public DateTime DueDate { get; set; }
		
		[ForeignKey("EmployeeId")]
		public Employee? Employee { get; set; }
		public int EmployeeId { get; set; }
	}
}
