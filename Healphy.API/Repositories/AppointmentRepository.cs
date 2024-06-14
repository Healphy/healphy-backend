using Healphy.API.Data;
using Healphy.API.Interfaces;
using Healphy.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Healphy.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealphyDbContext _appointmentContext;

        public AppointmentRepository(HealphyDbContext context) 
        {
            _appointmentContext = context;
        }

        public async Task<Appointment> Create(Appointment appointment)
        {
            string doctorCrm = appointment.Doctor.Crm;
            Doctor existingDoctor = await _appointmentContext.Doctor.FirstOrDefaultAsync(x => x.Crm == doctorCrm);

            _appointmentContext.Add(appointment);
            await _appointmentContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> Delete(Appointment appointment)
        {
            _appointmentContext.Remove(appointment);
            await _appointmentContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> Get()
        {
            return await _appointmentContext.Appointment.ToListAsync();
        }
 
        public async Task<Appointment> Update(Appointment appointment)
        {
            _appointmentContext.Update(appointment);
            await _appointmentContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> GetAppointmentById(int? id)
        {
            return await _appointmentContext.Appointment.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
