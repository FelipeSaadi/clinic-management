namespace ClinicManagement.API.DTOs
{
	public class DoctorPatientDto
	{
		public long Id { get; set; }
		public long DoctorId { get; set; }
		public long PatientId { get; set;}
	}
}
