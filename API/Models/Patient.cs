using System;
using System.ComponentModel.DataAnnotations;
using API.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.API.Models
{
	public class Patient : BaseEntity
	{
		[Required]
		[StringLength(150)]
		public string FullName { get; set; }
		[Required]
		[MinLength(11)]
		[MaxLength(11)]
		public string Cpf { get; set; }
		[Required]
		[MinLength(8)]
		[MaxLength(8)]
		public string ZipCode { get; set; }
		[Required]
		[StringLength(150)]
		public string Address { get; set; }
		[Required] 
		public int Number { get; set; }
		[StringLength(100)]
		public string AddressComplement { get; set; }
		[Required]
		[StringLength (100)] 
		public string District { get; set; }
		[Required]
		[StringLength(100)]
		public string City { get; set; }
		[Required]
		[StringLength(100)]
		public string State { get; set; }
		public ICollection<Doctor> Doctors { get; set; }
	}
}
