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
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository appointmentRepository, IMapper mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("appointment")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointmentsTemp = await _appointmentRepository.Get();
            var appointmentsDTO = _mapper.Map<IEnumerable<AppointmentDTO>>(appointmentsTemp);
            return Ok(appointmentsDTO);
        }

        [HttpPost]
        [Route("appointment")]
        public async Task<ActionResult<Appointment>> RegisterApppointment(Appointment appointmentObj)
        {
            int doctorId = appointmentObj.Doctor.Id;
            var doctorTemp = await _doctorRepository.GetDoctorById(doctorId);

            if (doctorTemp is null)
                return BadRequest($"Médico com ID {doctorId} não foi encontrado");

            appointmentObj.Doctor = doctorTemp;

            return Ok(await _appointmentRepository.Create(appointmentObj));
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

            var appointmentDTO = _mapper.Map<AppointmentDTO>(appointmentTemp);

            return Ok(appointmentDTO);
        }
    }
}
