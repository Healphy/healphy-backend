using Healphy.API.Data;
using Healphy.API.Interfaces;
using Healphy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Healphy.API.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HealphyDbContext _doctorContext;

        public DoctorRepository(HealphyDbContext context)
        {
            _doctorContext = context;
        }

        public async Task<Doctor> Create(Doctor doctor)
        {
            _doctorContext.Add(doctor);
            await _doctorContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> Delete(Doctor doctor)
        {
            _doctorContext.Remove(doctor);
            await _doctorContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<IEnumerable<Doctor>> Get()
        {
            return await _doctorContext.Doctor.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByCrm(string? crm)
        {
            return await _doctorContext.Doctor.FirstOrDefaultAsync(x => x.Crm == crm);
        }

        public async Task<Doctor> GetDoctorById(int? id)
        {
            return await _doctorContext.Doctor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Doctor> GetDoctorBySpeciality(string? speciality)
        {
            return await _doctorContext.Doctor.FirstOrDefaultAsync(x => x.Speciality == speciality);
        }

        public async Task<Doctor> Update(Doctor doctor)
        {
            _doctorContext.Update(doctor);
            await _doctorContext.SaveChangesAsync();
            return doctor;
        }
    }
}
