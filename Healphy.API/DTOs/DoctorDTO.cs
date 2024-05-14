using System.ComponentModel.DataAnnotations;

namespace Healphy.API.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string DoctorsName { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [StringLength(200)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(6)]
        public string Crm { get; set; }
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }
        [Required]
        public string Speciality { get; set; }
        public string DoctorsLastName { get; set; }
        public string? ProfilePhoto { get; set; }
    }
}
