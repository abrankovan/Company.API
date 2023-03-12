using AutoMapper;
using CompanyAPI.Dtos.Tasks;
using CompanyAPI.Entities;
using CompanyAPI.Dtos;
using CompanyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CompanyAPI.Dtos.Employee;

namespace CompanyAPI.Controllers
{
	[ApiController]
	[Route("api/task")]
	[Produces("application/json")]
	public class TaskController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeInfoRepository _employeeInfoRepository;
		private readonly ITaskInfoRepository _taskInfoRepository;
		public TaskController(IMapper mapper, IEmployeeInfoRepository employeeInfoRepository, ITaskInfoRepository taskInfoRepository)
		{
			_mapper = mapper;
			_employeeInfoRepository = employeeInfoRepository;
			_taskInfoRepository = taskInfoRepository;
		}
		[HttpGet("all/{employeeId}")]
		public async Task<ActionResult<IEnumerable<TaskDto>>> GetETasksFromEmployee(int employeeId)
		{
			var employee = await _employeeInfoRepository.GetEmployeeAsync(employeeId, true);
			if (employee == null)
			{
				return NotFound("Employee with that Id dose not exist");
			}
			var alltasks = await _taskInfoRepository.GetTasksFromEmployeeAsync(employeeId);
			return Ok(_mapper.Map<IEnumerable<GetTaskResponseDto>>(alltasks));

		}
		[HttpGet("{taskId}", Name ="GetTask")]
		public async Task<ActionResult<GetTaskResponseDto>> GetTask(int taskId)
		{
			var task = await _taskInfoRepository.GetTaskAsync(taskId);
			if (task == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<GetTaskResponseDto>(task));
		}
		[HttpPost]
		public async Task<ActionResult> AddTaskAsync(int employeeId, PostTaskRequestDto newTask)
		{
			if(!await _employeeInfoRepository.EmployeeExistsAsync(employeeId))
			{
				return NotFound();
			}
			var createdTask = _mapper.Map<EmployeeTask>(newTask);
			await _taskInfoRepository.AddTaskForEmployeeAsync(employeeId, createdTask);
			await _taskInfoRepository.SaveChangesAsync();
			var createdTaskToReturn = _mapper.Map<GetTaskResponseDto>(createdTask);
			return CreatedAtRoute("GetTask",
				new
				{
					employeeId = employeeId,
					taskId = createdTaskToReturn.Id
				},
				createdTaskToReturn); 

		}

		[HttpPut("{taskId}")]
		public async Task<ActionResult> UpdateTask(int employeeId, int taskId, PutTaskRequestDto task)
		{
			if(!await _employeeInfoRepository.EmployeeExistsAsync(employeeId))
			{
				return NotFound();
			}
			var taskForUpdate = await _taskInfoRepository.GetTaskAsync(taskId);
			if(taskForUpdate == null)
			{
				return NotFound();
			}
			_mapper.Map(task, taskForUpdate);
			taskForUpdate.EmployeeId = employeeId;
			await _taskInfoRepository.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("{taskId}")]
		public async Task<ActionResult> DeleteTask(int taskId)
		{
			var taskForDelete = await _taskInfoRepository.GetTaskAsync(taskId);
			if (taskForDelete == null)
			{
				return NotFound();
			}
			_taskInfoRepository.DeleteTask(taskForDelete);
			await _taskInfoRepository.SaveChangesAsync();
			return NoContent();
		}
	}
	
}
