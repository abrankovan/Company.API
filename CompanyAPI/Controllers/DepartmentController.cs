using AutoMapper;
using CompanyAPI.Dtos.Department;
using CompanyAPI.Dtos.Employee;
using CompanyAPI.Entities;
using CompanyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyAPI.Controllers
{
	[ApiController]
	[Route("api/department")]
	[Produces("application/json")]
	public class DepartmentController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IDepartmentInfoRepository _departmentInfoRepository;
		public DepartmentController (IMapper mapper, IDepartmentInfoRepository departmentInfoRepository)
		{
			_mapper = mapper;
			_departmentInfoRepository = departmentInfoRepository;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartments()
		{
			var allDepartmets = await _departmentInfoRepository.GetDepartmentsAsync();
			return Ok(_mapper.Map<IEnumerable<GetAllDepartmentsDto>>(allDepartmets));
		}
		[HttpGet("{departmentId}", Name ="GetDepartment")]
		public async Task<ActionResult> GetDepartment(int departmentId)
		{
			var department = await _departmentInfoRepository.GetDepartmentAsync(departmentId);
			if (department == null)
			{
				return NotFound();
			}
			
			return Ok(_mapper.Map<GetDepartmentResponseDto>(department));
		}

		[HttpPost]

		public async Task <ActionResult> AddDepartmentAsync(PostDepartmentRequestDto newDepartment)
		{
			var createdDepartment = _mapper.Map<Department>(newDepartment);
			await _departmentInfoRepository.AddDepartmentAsync(createdDepartment);
			await _departmentInfoRepository.SaveChangesAsync();
			var createdDepartmentToReturn = _mapper.Map<GetDepartmentResponseDto>(createdDepartment);
			return CreatedAtRoute("GetDepartment",
				new
				{
					departmentId = createdDepartmentToReturn.Id
				},
				createdDepartmentToReturn);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateDepartment(int id, PutDepartmentRequestDto department)
		{
			var departmentForUpdate = await _departmentInfoRepository.GetDepartmentAsync(id);
			if (departmentForUpdate == null)
			{
				return NotFound();
			}
			_mapper.Map(department, departmentForUpdate);

			await _departmentInfoRepository.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("{departmentId}")]
		public async Task<ActionResult> DeleteDepartment(int departmentId, bool includeEmployee)
		{
			var departmentForDelete = await _departmentInfoRepository.GetDepartmentAsync(departmentId);
			if (departmentForDelete == null)
			{
				return NotFound();
			}
			_departmentInfoRepository.DeleteDepartment(departmentForDelete);
			await _departmentInfoRepository.SaveChangesAsync();
			return NoContent();
		}
	}
}
