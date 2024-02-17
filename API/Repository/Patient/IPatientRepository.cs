using ClinicManagement.API.DTOs.Patient;

namespace ClinicManagement.API.Repository.Patient
{
	public interface IPatientRepository
	{
		Task<IEnumerable<PatientDto>> FindAll();
		Task<PatientDto> FindById(long id);
		Task<PatientDto> Create(PatientDto patient);
		Task<PatientDto> Update(PatientDto patient);
		Task<PatientDto> Delete(long id);
	}
}
