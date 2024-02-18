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

			List<IdentityRole<long>> roles = new List<IdentityRole<long>>
			{
				new IdentityRole<long>
				{
					Id = 1,
					Name = "Doctor",
					NormalizedName = "DOCTOR"
				}
				,
				new IdentityRole<long>
				{
					Id = 2,
					Name = "Patient",
					NormalizedName = "PATIENT"
				}
			};

			modelBuilder.Entity<IdentityRole<long>>().HasData(roles);

			base.OnModelCreating(modelBuilder);
		}
	}
}
