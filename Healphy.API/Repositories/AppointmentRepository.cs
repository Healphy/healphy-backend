using Healphy.API.Data;
using Healphy.API.Interfaces;
using Healphy.API.Models;

namespace Healphy.API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealphyDbContext _appointmentContext;
        public AppointmentRepository(HealphyDbContext context) 
        {
            _appointmentContext = context;
        }

        public Task<Appointment> Create(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> Delete(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> Get(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> Update(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
