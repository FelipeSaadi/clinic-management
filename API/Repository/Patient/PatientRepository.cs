using API.Model.Context;
using AutoMapper;
using ClinicManagement.API.DTOs.Patient;

namespace ClinicManagement.API.Repository.Patient
{
	public class PatientRepository : IPatientRepository
	{
		private readonly MySQLContext _context;
		private IMapper _mapper;

		public PatientRepository(MySQLContext context, IMapper mapper) 
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<PatientDto> Create(PatientDto patient)
		{
			throw new NotImplementedException();
		}

		public Task<PatientDto> Delete(long id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<PatientDto>> FindAll()
		{
			throw new NotImplementedException();
		}

		public Task<PatientDto> FindById(long id)
		{
			throw new NotImplementedException();
		}

		public Task<PatientDto> Update(PatientDto patient)
		{
			throw new NotImplementedException();
		}
	}
}
