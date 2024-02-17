using ClinicManagement.API.DTOs;
using ClinicManagement.API.Models;
using ClinicManagement.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private IPatientRepository _patientRepository;
		private IDoctorPatientRepository _doctorPatientRepository;

		public PatientController(IPatientRepository patientRepository, IDoctorPatientRepository doctorPatientRepository)
		{
			_patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
			_doctorPatientRepository = doctorPatientRepository ?? throw new ArgumentNullException(nameof(doctorPatientRepository));
		}

		[HttpGet]
		public async Task<ActionResult<List<PatientDto>>> FindAllPatients()
		{
			var patients = await _patientRepository.FindAll();
			return Ok(patients);
		}

		[HttpGet("Doctors/{id}")]
		public async Task<ActionResult<PatientDto>> FindAllPatientDoctors(long id)
		{
			PatientDto patient = await _patientRepository.FindAllPatientDoctors(id);
			if (patient == null) return NotFound();
			return Ok(patient);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PatientDto>> FindPatientById(long id)
		{
			var patient = await _patientRepository.FindById(id);
			if (patient == null) return NotFound();
			return Ok(patient);
		}

		[HttpPost]
		public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] PatientDto patientDto)
		{
			if (patientDto == null) return BadRequest();
			var patient = await _patientRepository.Create(patientDto);
			return Ok(patient);
		}

		[HttpPut]
		public async Task<ActionResult<PatientDto>> UpdatePatient([FromBody] PatientDto patientDto)
		{
			if(patientDto == null) return BadRequest();
			var patient = await _patientRepository.Update(patientDto);
			return Ok(patient);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePatient(long id)
		{
			var status = await _patientRepository.Delete(id);
			if (!status) return BadRequest();
			return Ok(status);
		}
	}
}
