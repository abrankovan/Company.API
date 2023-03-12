using AutoMapper;
using CompanyAPI.Dtos.Employee;
using CompanyAPI.Entities;
using CompanyAPI.Models;

namespace CompanyAPI.Profiles
{
    public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<EmployeeDto, Employee>();
			CreateMap<Employee, GetTopFiveEmployeesDto>();
			CreateMap<Employee, GetEmployeeResponseDto>();
			CreateMap<Employee, EmployeeDto>();
			CreateMap<PostEmployeeRequestDto, Employee>();
			CreateMap<PutEmployeeRequestDto, Employee>();
			CreateMap<Employee, GetTopFiveEmployees>();
			CreateMap<GetTopFiveEmployees, GetTopFiveEmployeesDto>();
		}
	}
}
