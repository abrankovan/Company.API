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
		public async Task<Department?> GetDepartmentAsync(int departmentId)
		{
			
			return await _context
				.Department
				.Where(d => d.Id == departmentId)
				.FirstOrDefaultAsync();
		}
		public async Task<bool> DepartmentExistAsync(int departmentId)
		{
			return await _context.Department.AnyAsync(d => d.Id == departmentId);
		}
		public async Task AddDepartmentAsync(Department newDepartment)
		{
			await _context.Department.AddAsync(newDepartment);
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
