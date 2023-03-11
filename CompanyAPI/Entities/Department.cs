using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Entities
{
	public class Department
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public ICollection<Employee> Employees { get; set; }
			= new List<Employee>();
	}
}
