using CompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.DbContexts
{
	public class CompanyContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; } 
		public DbSet<EmployeeTask> Tasks { get; set; }
		public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
		{

		}
		
	}
}
	
