using ClinicManagement.API.DTOs;
using ClinicManagement.API.Models;
using ClinicManagement.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.API.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class DoctorController : ControllerBase
	{
		private IPatientRepository _patientRepository;
		private IDoctorPatientRepository _doctorPatientRepository;
		private readonly UserManager<Doctor> _userManager;

		public DoctorController(IPatientRepository patientRepository, IDoctorPatientRepository doctorRepository, UserManager userManager)
		{
			_patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
			_doctorPatientRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
			_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Doctor>>> FindAllDoctorPatients(long id)
		{
			IEnumerable<Doctor> doctors = await _doctorPatientRepository.FindAllDoctorPatients(id);
			if (doctors == null) return NotFound();
			return Ok(doctors);
		}

		[HttpPost]
		public async Task<ActionResult> Register([FromBody] DoctorDto registerDto)
		{
			if (registerDto == null) return BadRequest();
			return Ok();
		}

		[HttpPost]
		public async Task<ActionResult<DoctorPatientDto>> AddPatient([FromBody] DoctorPatientDto doctorPatientDto)
		{
			if (doctorPatientDto == null) BadRequest();
			var doctorPatient = _doctorPatientRepository.AddDoctor(doctorPatientDto);
			return Ok(doctorPatient);

		}
	}
}
