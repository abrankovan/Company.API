using AutoMapper;
using CompanyAPI.Dtos.Tasks;
using CompanyAPI.Entities;

namespace CompanyAPI.Profiles
{
	public class TaskProfile : Profile
	{
		public TaskProfile()
		{
			CreateMap<EmployeeTask, GetTaskResponseDto>();
			CreateMap<PutTaskRequestDto, EmployeeTask>();
			CreateMap<PostTaskRequestDto, EmployeeTask>();
		}
	}
}
