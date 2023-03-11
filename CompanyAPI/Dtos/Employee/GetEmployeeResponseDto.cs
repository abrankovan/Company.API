using System.Security.Cryptography.X509Certificates;
using CompanyAPI.Dtos.Tasks;

namespace CompanyAPI.Dtos.Employee
{
    public class GetEmployeeResponseDto : EmployeeDto
    {
        public int Id { get; set; }
        public int NumberOfTasks
        {
            get
            {
                return Task.Count;
            }
        }


        public ICollection<GetTaskResponseDto> Task { get; set; }
            = new List<GetTaskResponseDto>();
    }
}
