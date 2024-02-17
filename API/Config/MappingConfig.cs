using AutoMapper;
using ClinicManagement.API.DTOs.Patient;
using ClinicManagement.API.Models;

namespace ClinicManagement.API.Config
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<PatientDto, Patient>();
				config.CreateMap<Patient, PatientDto>();
			});
			return mappingConfig;
		}
	}
}
