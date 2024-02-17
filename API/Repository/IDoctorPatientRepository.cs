using ClinicManagement.API.DTOs;
using ClinicManagement.API.Models;

namespace ClinicManagement.API.Repository
{
	public interface IDoctorPatientRepository
	{
		Task<IEnumerable<Doctor>> FindAllDoctorPatients(long id);
		Task<DoctorPatientDto> AddDoctor(DoctorPatientDto doctorPatient);
		Task<bool> DeleteDoctor(DoctorPatientDto doctorPatient);
	}
}
