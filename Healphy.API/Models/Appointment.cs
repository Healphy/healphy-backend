namespace Healphy.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PacientName { get; set; }
        public int AddressId { get; set; } // Foreign Key
        public Address Address { get; set; } // Navigation Property
        public DateTime DateTime { get; set; }
        public string HealthInsurance { get; set; }
        public string AppointmentDescription { get; set; }
        public string Diagnostic {  get; set; }
        public string AppointmentPrice { get; set; }
        public string Status { get; set; }
        public int DoctorCrm { get; set; } //Foreign Key
        public Doctor? Doctor { get; set; } // Navegation Property
    }
}
