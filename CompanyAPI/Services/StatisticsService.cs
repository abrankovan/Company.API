using CompanyAPI.Entities;
using CompanyAPI.Enums;
using CompanyAPI.Models;
using System.Linq.Expressions;

namespace CompanyAPI.Services
{
	public class StatisticsService : IStatisticsService
	{
		private readonly IDepartmentInfoRepository _departmentInfoRepository;
		private readonly IEmployeeInfoRepository _employeeInfoRepository;
		private readonly ITaskInfoRepository _taskInfoRepository;
		public StatisticsService(
			IDepartmentInfoRepository departmentInfoRepository, 
			IEmployeeInfoRepository employeeInfoRepository, 
			ITaskInfoRepository taskInfoRepository
			)
		{
			_departmentInfoRepository = departmentInfoRepository;
			_employeeInfoRepository = employeeInfoRepository;
			_taskInfoRepository = taskInfoRepository;
		}
		public async Task<DepartmentStatistics> GetDepartmentStatistics(int departmentId)
		{
			var department = await _departmentInfoRepository.GetDepartmentAsync(departmentId);
			var employees = await _employeeInfoRepository.GetEmployeesFromDepartmentAsync(departmentId);

			DepartmentStatistics departmentStatistic = new DepartmentStatistics()
			{
				DepartmentId = department.Id,
				NumOfTotalEmployees = employees.Count(),
				NumOfTotalTasks = 0,
				NumOfDoneTasks = 0,
				NumOfFailedTasks = 0,
				NumOfInProgressTasks = 0,
			};

			employees.ToList().ForEach(async e =>
			{
				var tasks = await _taskInfoRepository.GetTasksFromEmployeeAsync(e.Id);
				departmentStatistic.NumOfTotalTasks += tasks.Count();
				departmentStatistic.NumOfDoneTasks += tasks.Count(t => t.Status == TaskStatuses.Done);
				departmentStatistic.NumOfFailedTasks += tasks.Count(t => t.Status == TaskStatuses.Failed);
				departmentStatistic.NumOfInProgressTasks += tasks.Count(t => t.Status == TaskStatuses.InProgress);
			});

			return departmentStatistic;
		}

	}
}
