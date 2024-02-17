namespace ClinicManagement.API.DTOs
{
	public class PatientDto
	{
		public long Id { get; set; }
		public string FullName { get; set; }
		public string Cpf { get; set; }
		public string ZipCode { get; set; }
		public string Address { get; set; }
		public int Number { get; set; }
		public string AddressComplement { get; set; }
		public string District { get; set; }
		public string City { get; set; }
		public string State { get; set; }
	}
}
