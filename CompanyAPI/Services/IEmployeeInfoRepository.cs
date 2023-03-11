using CompanyAPI.Entities;

namespace CompanyAPI.Services
{
	public interface IEmployeeInfoRepository
	{
		Task<IEnumerable<Employee>>GetEmployeesAsync();
		Task<Employee?>GetEmployeeAsync(int employeeId, bool includeTasks);
		Task AddEmployeeAsync(Employee newEmployee);
		Task<bool>EmployeeExistsAsync(int employeeId);
		void DeleteEmployee(Employee employeeForDeleteemployee);
		Task<bool> SaveChangesAsync();
	}
}
