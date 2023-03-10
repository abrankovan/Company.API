using CompanyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.DbContexts
{
	public class EmployeeInfoContext : DbContext
	{
		public DbSet<Employee> Employees { get; set; } 
		public DbSet<EmployeeTask> Tasks { get; set; }
		public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>().HasData(
				new Employee()
				{
					Id = 1,
					FirstName = "Aleksandra",
					LastName = "Brankovan",
					Email = "aleksandra@gmail.com",
					Phone = "018200200",
					DateOfBirth = new DateTime(1993, 06, 22),
					MonthlySalary = 323,
				});
			modelBuilder.Entity<EmployeeTask>().HasData(
				new EmployeeTask()
				{
					Id = 1,
					Title = "Cleaning",
					Description = "Clean work table",
					Assigned = true,
					DueDate = new DateTime(2023, 05, 05),
				});
			base.OnModelCreating(modelBuilder);
		}
	}
}
	
