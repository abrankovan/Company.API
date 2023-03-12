using AutoMapper;
using CompanyAPI.Dtos.Employee;
using CompanyAPI.Entities;
using CompanyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyAPI.Controllers
{
	[ApiController]
	[Route("api/employee")]
	[Produces("application/json")]
	public class EmployeeController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IEmployeeInfoRepository _employeeInfoRepository;
		private readonly IDepartmentInfoRepository _departmentInfoRepository;
		public EmployeeController(IMapper mapper, IEmployeeInfoRepository employeeInfoRepository, IDepartmentInfoRepository departmentInfoRepository)
		{
			_mapper = mapper;
			_employeeInfoRepository = employeeInfoRepository;
			_departmentInfoRepository = departmentInfoRepository;
		}
		[HttpGet("all/{departmentId}")]
		public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesFromDepartment(int departmentId)
		{
			var department = await _departmentInfoRepository.GetDepartmentAsync(departmentId);
			if(department == null)
			{
				return NotFound();
			}
			var allemployees = await _employeeInfoRepository.GetEmployeesFromDepartmentAsync(departmentId);
			return Ok(_mapper.Map<IEnumerable<GetEmployeeResponseDto>>(allemployees));
			
		}

		[HttpGet("{employeeId}", Name = "GetEmployee")]
		public async Task<ActionResult> GetEmployee(int employeeId, bool includeTasks)
		{
			var employee = await _employeeInfoRepository.GetEmployeeAsync(employeeId, includeTasks);
			if (employee == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<GetEmployeeResponseDto>(employee));
		}
		[HttpPost]
		public async Task<ActionResult> AddEmployeeAsync(int departmentId, PostEmployeeRequestDto newEmployee)
		{
			if (!await _departmentInfoRepository.DepartmentExistAsync(departmentId))
			{
				return NotFound();
			}
			var createdEmployee = _mapper.Map<Entities.Employee>(newEmployee);
			await _employeeInfoRepository.AddEmployeeForDepartmentAsync(departmentId, createdEmployee);
			await _employeeInfoRepository.SaveChangesAsync();
			var createdEmployeeToReturn = _mapper.Map<GetEmployeeResponseDto>(createdEmployee);
			return CreatedAtRoute("GetEmployee",
				new
				{
					departmentId = departmentId,
					employeeId = createdEmployeeToReturn.Id
				},
				createdEmployeeToReturn);
		}
		[HttpPut("{employeeId}")]
		public async Task<ActionResult> UpdateEmployee(int employeeId, bool task, PutEmployeeRequestDto employee)
		{
			var employeeForUpdate = await _employeeInfoRepository.GetEmployeeAsync(employeeId, task);
			if(employeeForUpdate == null)
			{
				return NotFound();
			}
			_mapper.Map(employee, employeeForUpdate);

			await _employeeInfoRepository.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("{employeeId}")]
		public async Task<ActionResult> DeleteEmployee(int employeeId, bool task)
		{
			var employeeForDelete = await _employeeInfoRepository.GetEmployeeAsync(employeeId, task);
			if (employeeForDelete == null)
			{
				return NotFound();
			}
			_employeeInfoRepository.DeleteEmployee(employeeForDelete);
			await _employeeInfoRepository.SaveChangesAsync();
			return NoContent();
		}
	}
}
