namespace ClinicManagement.API.DTOs.Patient
{
    public class PatientDto
    {
        public string FullName { get; set; }
        public string Cpf {  get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string AddressComplement { get; set; }
        public string District { get; set; }
		public string City { get; set; }
        public string State { get; set; }
    }
}
