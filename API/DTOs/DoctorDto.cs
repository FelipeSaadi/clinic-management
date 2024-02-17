using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.API.DTOs
{
	public class DoctorDto
	{
		[Required]
		public string? Username { get; set; }
		[Required]
		[EmailAddress]
		public string? EmailAddress { get; set;}
		[Required]
		public string? Password { get; set; }
	}
}
