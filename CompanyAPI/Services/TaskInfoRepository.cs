using CompanyAPI.DbContexts;
using CompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
	public class TaskInfoRepository : ITaskInfoRepository 
	{
		private readonly IEmployeeInfoRepository _employeeInfoRepository;
		private readonly CompanyContext _context;
		public TaskInfoRepository(CompanyContext context, IEmployeeInfoRepository employeeInfoRepository)
		{
			_context = context;
			_employeeInfoRepository = employeeInfoRepository;
		}
		public async Task<IEnumerable<EmployeeTask>> GetTasksAsync()
		{
			return await _context.Tasks.OrderBy(t => t.Id).ToListAsync();
		}
		public async Task<EmployeeTask> GetTaskAsync(int taskId)
		{
			return await _context.Tasks.Where(t => t.Id == taskId).FirstOrDefaultAsync();
		}
		public async Task AddTaskAsync(EmployeeTask newTask)
		{
			_context.Tasks.Add(newTask);
		}
		public async Task AddTaskForEmployeeAsync(int employeeId, EmployeeTask newTask)
		{
			var employee = await _employeeInfoRepository.GetEmployeeAsync(employeeId, true);
			if (employee != null)
			{
				employee.Tasks.Add(newTask);
			}
		}
		public void DeleteTask(EmployeeTask taskForDelete)
		{
			_context.Tasks.Remove(taskForDelete);
		}
		public async Task<bool> SaveChangesAsync()
		{
			return (await _context.SaveChangesAsync() >= 0);
		}
	}
}
