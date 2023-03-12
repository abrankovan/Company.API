using CompanyAPI.Entities;

namespace CompanyAPI.Services
{
	public interface IDepartmentInfoRepository
	{
		Task<IEnumerable<Department>> GetDepartmentsAsync();
		Task<Department?> GetDepartmentAsync(int departmentId);
		Task<bool> DepartmentExistAsync(int departmentId);
		Task AddDepartmentAsync(Department newDepartment);
		void DeleteDepartment(Department departmentForDelete);
		Task<bool> SaveChangesAsync();
	}
}
