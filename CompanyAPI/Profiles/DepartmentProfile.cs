using AutoMapper;
using CompanyAPI.Dtos.Department;
using CompanyAPI.Entities;

namespace CompanyAPI.Profiles
{
	public class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			CreateMap<Department, GetAllDepartmentsDto>();
			CreateMap<Department, GetDepartmentResponseDto>();
			CreateMap<PostDepartmentRequestDto, Department>();
			CreateMap<PutDepartmentRequestDto, Department>();

		}
	}
}
