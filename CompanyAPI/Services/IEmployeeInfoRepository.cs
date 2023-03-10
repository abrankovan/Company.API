using CompanyAPI.Entities;

namespace CompanyAPI.Services
{
	public interface IEmployeeInfoRepository
	{
		Task<IEnumerable<Employee>>GetEmployeesAsync();
		Task<Employee?>GetEmployeeAsync(int employeeId, bool includeTasks);
		Task<IEnumerable<EmployeeTask>>GetTasksAsync();
		Task<EmployeeTask?>GetTaskAsync(int employeeTaskId);
		Task AddEmployeeAsync(Employee newEmployee);
		void DeleteEmployee(Employee employeeForDeleteemployee);
		Task <bool> SaveChangesAsync();
	}
}
