using System.Collections.ObjectModel;
using API.Model.Context;
using AutoMapper;
using ClinicManagement.API.DTOs;
using ClinicManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Repository
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

		public async Task<IEnumerable<PatientDto>> FindAll()
		{
			List<Patient> patients = await _context.Patients.ToListAsync();
			return _mapper.Map<List<PatientDto>>(patients);
		}
		public async Task<PatientDto> FindAllPatientDoctors(long id)
		{
			Patient? patient = await _context.Patients
				.Where(p => p.Id == id)
				.Include(p => p.Doctors)
				.FirstOrDefaultAsync();

			return _mapper.Map<PatientDto>(patient);
		}

		public async Task<PatientDto> FindById(long id)
		{
			Patient? patient = await _context.Patients
					.Where(p => p.Id == id)
					.FirstOrDefaultAsync();
			return _mapper.Map<PatientDto>(patient);
		}

		public async Task<PatientDto> Create(PatientDto dto)
		{
			Patient patient = _mapper.Map<Patient>(dto);
			_context.Add(patient);
			await _context.SaveChangesAsync();
			return _mapper.Map<PatientDto>(patient);
		}

		public async Task<PatientDto> Update(PatientDto dto)
		{
			Patient patient = _mapper.Map<Patient>(dto);
			_context.Patients.Update(patient);
			await _context.SaveChangesAsync();
			return _mapper.Map<PatientDto>(patient);
		}

		public async Task<bool> Delete(long id)
		{
			try
			{
				Patient patient = await _context.Patients
					.Where(p => p.Id == id)
					.FirstOrDefaultAsync();
				if (patient == null) return false;
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
