using CompanyAPI.DbContexts;
using CompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
	public class EmployeeInfoRepository : IEmployeeInfoRepository
	{
		private readonly CompanyContext _context;
		private readonly IDepartmentInfoRepository _departmentInfoRepository;
		public EmployeeInfoRepository(CompanyContext context, IDepartmentInfoRepository departmentInfoRepository)
		{
			_context = context;
			_departmentInfoRepository = departmentInfoRepository;
		}
		public async Task<IEnumerable<Employee>> GetEmployeesFromDepartmentAsync(int departmentId)
		{
			return await _context
				.Employees
				.Where(e => e.DepartmentId == departmentId)
				.OrderBy(e => e.FirstName)
				.ToListAsync();
		}
		public async Task<Employee?> GetEmployeeAsync(int employeeId, bool includeTasks)
		{
			if (includeTasks)
			{
				return await _context
					.Employees
					.Include(e => e.Tasks)
					.Where(e => e.Id == employeeId)
					.FirstOrDefaultAsync();
			}
			return await _context
				.Employees
				.Where(e => e.Id == employeeId)
				.FirstOrDefaultAsync();
		}
		public async Task<bool> EmployeeExistsAsync(int employeeId)
		{
			return await _context.Employees.AnyAsync(e => e.Id == employeeId);
		}
		public async Task AddEmployeeAsync(Employee newEmployee)
		{
			_context.Employees.Add(newEmployee);
		}
		public async Task AddEmployeeForDepartmentAsync(int departmentId, Employee newEmployee)
		{
			var department = await _departmentInfoRepository.GetDepartmentAsync(departmentId);
			if (department != null)
			{
				department.Employees.Add(newEmployee);
			}
		}
		
		public void DeleteEmployee(Employee employeeForDelete)
		{
			_context.Employees.Remove(employeeForDelete);
		}
		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync() >= 0);
		}
	}
}
