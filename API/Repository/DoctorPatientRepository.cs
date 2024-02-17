using System;
using API.Model.Context;
using AutoMapper;
using ClinicManagement.API.DTOs;
using ClinicManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Repository
{
	public class DoctorPatientRepository : IDoctorPatientRepository
	{
		private readonly MySQLContext _context;
		private IMapper _mapper;

		public DoctorPatientRepository(MySQLContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IEnumerable<Doctor>> FindAllDoctorPatients(long id)
		{
			List<Doctor> doctors = await _context.Users
				.Where(p => p.Id == id)
				.Include(p => p.Patients)
				.ToListAsync();
			return _mapper.Map<List<Doctor>>(doctors);
		}

		public async Task<DoctorPatientDto> AddDoctor(DoctorPatientDto doctorPatient)
		{
			Patient? patient = await _context.Patients
				.Where(p => p.Id == doctorPatient.PatientId)
				.FirstOrDefaultAsync();

			Doctor doctor = _context.Users.Single(d => d.Id == doctorPatient.DoctorId);

			if (patient != null && doctor != null)
			{
				doctor.Patients.Add(patient);
				_context.Users.Add(doctor);
				_context.SaveChanges();
			}
			return doctorPatient;
		}

		public Task<bool> DeleteDoctor(DoctorPatientDto doctorPatient)
		{
			throw new NotImplementedException();
		}

	}
}
