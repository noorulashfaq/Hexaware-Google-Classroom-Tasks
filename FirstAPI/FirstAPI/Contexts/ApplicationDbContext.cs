using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasKey(e => e.Id);

			modelBuilder.Entity<Department>()
				.HasKey(d => d.Id);

			modelBuilder.Entity<Employee>()
				.HasOne(e => e.Department)
				.WithMany(d => d.Employees)
				.HasForeignKey(e => e.DepartmentId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
