using AutoMapper;
using CompanyAPI.Dtos.Employee;
using CompanyAPI.Entities;

namespace CompanyAPI.Profiles
{
    public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Employee, GetEmployeeResponseDto>();
			CreateMap<PostEmployeeRequestDto, Employee>();
			CreateMap<PutEmployeeRequestDto, Employee>();

		}
	}
}
