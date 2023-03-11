using CompanyAPI.DbContexts;
using CompanyAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
	public class DepartmentInfoRepository : IDepartmentInfoRepository
	{
		private readonly CompanyContext _context;
		public DepartmentInfoRepository(CompanyContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Department>> GetDepartmentsAsync()
		{
			return await _context.Department.OrderBy(d => d.Name).ToListAsync();
		}
		public async Task<Department?> GetDepartmentAsync(int departmentId, bool includeEmployee)
		{
			if (includeEmployee)
			{
				return await _context
					.Department
					.Include(d => d.Employees)
					.Where(e => e.Id == departmentId)
					.FirstOrDefaultAsync();
			}
			return await _context
				.Department
				.Where(d => d.Id == departmentId)
				.FirstOrDefaultAsync();
		}
		public async Task AddDepartmentAsync(Department newDepartment)
		{
			_context.Department.Add(newDepartment);
		}

		public void DeleteDepartment(Department departmentForDelete)
		{
			_context.Department.Remove(departmentForDelete);
		}
		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync() >= 0);
		}

	}
}
