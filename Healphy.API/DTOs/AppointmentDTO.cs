using Healphy.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Healphy.API.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(14)]
        public string PacientName { get; set; }
        [Required]
        [StringLength(200)]
        public int AddressId { get; set; }
        [Required]
        [StringLength(14)]
        public Address Address { get; set; }
        [Required]
        public string HealthInsurance { get; set; }
        [Required]
        public string AppointmentDescription{ get; set; }
        [Required]
        public string Diagnostic { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [StringLength(14)]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(14)]
        public Doctor Doctor { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public DateTime DateTime{ get; set; }
    }
}
