using AutoMapper;
using Healphy.API.DTOs;
using Healphy.API.Interfaces;
using Healphy.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healphy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("appointment")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointmentsTemp = await _appointmentRepository.Get();
            return Ok(appointmentsTemp);
        }

        [HttpPost]
        [Route("appointment")]
        public async Task<ActionResult<Appointment>> RegisterApppointment(Appointment appointmentObj)
        {
            string doctorCrm = appointmentObj.Doctor.Crm;
            var doctorTemp = await _doctorRepository.GetDoctorByCrm(doctorCrm);

            if (doctorTemp is null)
                return BadRequest($"Médico com CRM {doctorCrm} não foi encontrado");

            appointmentObj.Doctor = doctorTemp;
            await _appointmentRepository.Create(appointmentObj);

            return Created("Consulta registrada", appointmentObj);
        }

        [HttpPut]
        [Route("appointment")]
        public async Task<ActionResult> ChangeAppointment(Appointment appointmentObj)
        {
            await _appointmentRepository.Update(appointmentObj);
            return Ok();
        }

        [HttpDelete]
        [Route("appointment/{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var appointmentTemp = await _appointmentRepository.GetAppointmentById(id);

            if (appointmentTemp == null)
                return NotFound("Consulta não encontrada");

            await _appointmentRepository.Delete(appointmentTemp);
            return Ok();
        }

        [HttpGet]
        [Route("appointment/{id}")]
        public async Task<ActionResult> GetAppointmentId(int id)
        {
            var appointmentTemp = await _appointmentRepository.GetAppointmentById(id);

            if (appointmentTemp == null)
                return NotFound("Consulta não encontrada");

            return Ok(appointmentTemp);
        }
    }
}
