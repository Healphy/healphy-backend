using Healphy.API.Models;

namespace Healphy.API.Interfaces
{
    public interface IDoctorRepository
    {
        Task<Doctor> Create(Doctor doctor);
        Task<Doctor> Update(Doctor doctor);
        Task<Doctor> Delete(Doctor doctor);
        Task<Doctor> Get(Doctor doctor);
        Task<Doctor> GetDoctorById(int? id);
        Task<Doctor> GetDoctorByCrm(string? crm);
        Task<Doctor> GetDoctorBySpeciality(string? speciality);
    }
}
