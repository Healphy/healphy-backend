using AutoMapper;
using Healphy.API.DTOs;
using Healphy.API.Interfaces;
using Healphy.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healphy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("doctors")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return Ok(await _doctorRepository.Get());
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Doctor>> Register(Doctor doctorObj)
        {
            return Ok(await _doctorRepository.Create(doctorObj));
        }

        [HttpPut]
        [Route("doctor")]
        public async Task<ActionResult> Change(Doctor doctor)
        {
            await _doctorRepository.Update(doctor);
            return Ok();
        }

        [HttpDelete]
        [Route("doctor/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var doctorTemp = await _doctorRepository.GetDoctorById(id);

            if (doctorTemp == null)
                return NotFound("Médico não encontrado");

            await _doctorRepository.Delete(doctorTemp);
            return Ok();
        }

        [HttpGet]
        [Route("doctor/{id}")]
        public async Task<ActionResult> GetDoctor(int id)
        {
            var doctorTemp = await _doctorRepository.GetDoctorById(id);

            if (doctorTemp == null)
                return NotFound("Médico não encontrado");

            // Com DTO tu escolhe quais infos quer exibir na API
            var doctorDTO = _mapper.Map<DoctorDTO>(doctorTemp);

            return Ok(doctorDTO);
        }

    }
}
