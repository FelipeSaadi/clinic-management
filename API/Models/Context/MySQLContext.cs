using ClinicManagement.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Model.Context
{
	public class MySQLContext : IdentityDbContext<Doctor, IdentityRole<long>, long>
	{
		public MySQLContext() { }
		public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

		public DbSet<Patient> Patients { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Patient>()
				.HasIndex(p => new { p.Cpf }).IsUnique();

			base.OnModelCreating(modelBuilder);
		}
	}
}
