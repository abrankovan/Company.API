using CompanyAPI.Entities;

namespace CompanyAPI.Services
{
	public interface ITaskInfoRepository
	{
		Task<IEnumerable<EmployeeTask>> GetTasksAsync();
		Task<EmployeeTask> GetTaskAsync(int taskId);
		Task<IEnumerable<EmployeeTask>> GetTasksFromEmployeeAsync(int employeeId);
		Task AddTaskAsync(EmployeeTask newTask);
		Task AddTaskForEmployeeAsync(int employeeId, EmployeeTask newTask);
		void DeleteTask(EmployeeTask taskForDelete);
		Task<bool> SaveChangesAsync();
	}
}
