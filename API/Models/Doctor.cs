using Microsoft.AspNetCore.Identity;

namespace ClinicManagement.API.Models
{
	public class Doctor : IdentityUser<long>
	{
		public ICollection<Patient> Patients { get; set; }
	}
}
