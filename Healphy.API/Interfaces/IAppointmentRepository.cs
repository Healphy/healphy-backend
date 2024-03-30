using Healphy.API.Models;

namespace Healphy.API.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> Create(Appointment appointment);
        Task<Appointment> Update(Appointment appointment);
        Task<Appointment> Delete(Appointment appointment);
        Task<Appointment> Get(Appointment appointment);
    }
}
