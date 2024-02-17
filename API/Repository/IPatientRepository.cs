using ClinicManagement.API.DTOs;

namespace ClinicManagement.API.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientDto>> FindAll();
		Task<PatientDto> FindAllPatientDoctors(long id);
		Task<PatientDto> FindById(long id);
        Task<PatientDto> Create(PatientDto patient);
        Task<PatientDto> Update(PatientDto patient);
        Task<bool> Delete(long id);
    }
}
