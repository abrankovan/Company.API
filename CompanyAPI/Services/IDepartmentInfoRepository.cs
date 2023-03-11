using CompanyAPI.Entities;

namespace CompanyAPI.Services
{
	public interface IDepartmentInfoRepository
	{
		Task<IEnumerable<Department>> GetDepartmentsAsync();
		Task<Department?> GetDepartmentAsync(int departmentId, bool includeEmployee);
		Task AddDepartmentAsync(Department newDepartment);
		void DeleteDepartment(Department departmentForDelete);
		Task<bool> SaveChangesAsync();
	}
}
