using CompanyAPI.Dtos.Employee;
using CompanyAPI.Dtos.Tasks;

namespace CompanyAPI.Dtos.Department
{
	public class GetDepartmentResponseDto : DepartmentDto
	{
		public int Id { get; set; }

		public ICollection<GetEmployeeResponseDto> Employees { get; set; }
			= new List<GetEmployeeResponseDto>();
	}
}
