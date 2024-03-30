namespace Healphy.API.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string DoctorsName { get; set; }
        public string DoctorsLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Email { get; set; }
        public string Crm {  get; set; }
        public string Cnpj { get; set; }
        public string Speciality {  get; set; }
    }
}
