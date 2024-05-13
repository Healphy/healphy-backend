using Healphy.API.Models;

namespace Healphy.API.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor> Create(Doctor doctor);
        Task<Doctor> Update(Doctor doctor);
        Task<Doctor> Delete(Doctor doctor);
        Task<IEnumerable<Doctor>> Get();
        Task<Doctor> GetDoctorById(int? id);
        Task<Doctor> GetDoctorByCrm(string? crm);
        Task<IEnumerable<Doctor>> GetDoctorBySpeciality(string? speciality);
    }
}
