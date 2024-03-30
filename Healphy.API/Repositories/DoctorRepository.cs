using Healphy.API.Data;
using Healphy.API.Interfaces;
using Healphy.API.Models;

namespace Healphy.API.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealphyDbContext _doctorContext;

        public DoctorRepository(HealphyDbContext context)
        {
            _doctorContext = context;
        }

        public Task<Doctor> Create(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> Delete(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> Get(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetDoctorByCrm(string? crm)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetDoctorById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> GetDoctorBySpeciality(string? speciality)
        {
            throw new NotImplementedException();
        }

        public Task<Doctor> Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
