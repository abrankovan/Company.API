using CompanyAPI.Models;

namespace CompanyAPI.Services
{
	public interface IStatisticsService
	{
		Task<DepartmentStatistics> GetDepartmentStatistics(int departmentId);
	}
}
