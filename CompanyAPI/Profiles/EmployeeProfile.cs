using AutoMapper;
using CompanyAPI.Entities;
using CompanyAPI.Models;

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
