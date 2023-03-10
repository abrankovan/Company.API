using CompanyAPI.DbContexts;
using CompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
	public class EmployeeInfoRepository : IEmployeeInfoRepository
	{
		private readonly CompanyContext _context;
		public EmployeeInfoRepository(CompanyContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Employee>> GetEmployeesAsync()
		{
			return await _context.Employees.OrderBy(e => e.FirstName).ToListAsync();
		}
		public async Task<Employee?> GetEmployeeAsync(int employeeId, bool includeTasks)
		{
			if (includeTasks)
			{
				return await _context.Employees.Include(e => e.Task)
			.Where(e => e.Id == employeeId).FirstOrDefaultAsync();
			}
			return await _context.Employees
				.Where(e => e.Id == employeeId).FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<EmployeeTask>> GetTasksAsync()
		{
			return await _context.Tasks.OrderBy(t => t.Id).ToListAsync();
		}
		public async Task<EmployeeTask?> GetTaskAsync(int employeeTaskId)
		{
			return await _context.Tasks.Where(t => t.Id == employeeTaskId).FirstOrDefaultAsync();
		}

		// odavde dalje

		public async Task AddEmployeeAsync(Employee newEmployee)
		{
			_context.Employees.Add(newEmployee);
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
