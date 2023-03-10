using AutoMapper;

namespace CompanyAPI.Profiles
{
	public class TaskProfile : Profile
	{
		public TaskProfile()
		{
			CreateMap<Entities.EmployeeTask, Models.TaskDto>();
		}
	}
}
