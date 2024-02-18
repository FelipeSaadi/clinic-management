using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.API.DTOs
{
	public class DoctorDto
	{
		[Required]
		public string? Username { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set;}
		[Required]
		public string? Password { get; set; }
	}
}
