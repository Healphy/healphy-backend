using AutoMapper;
using Healphy.API.DTOs;
using Healphy.API.Helpers;
using Healphy.API.Interfaces;
using Healphy.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Healphy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [Route("doctors")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctorsTemp = await _doctorRepository.Get();

            if (doctorsTemp is null)
                return NotFound("Doctors not found!");

            return Ok(doctorsTemp);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult<Doctor>> Authenticate(Doctor doctorObj)
        {
            var doctorTemp = await _doctorRepository.GetDoctorByEmail(doctorObj.Email);

            if (doctorTemp is null)
                return NotFound("Doutor não encontrado");

            if (!PasswordHasher.VerifyPassword(doctorObj.Password, doctorTemp.Password))
                return BadRequest("Senha incorreta");

            var token = CreateJwt(doctorTemp);

            return Ok(new { token });
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Doctor>> Register(Doctor doctorObj)
        {
            var email = await _doctorRepository.GetDoctorByEmail(doctorObj.Email);
            var crm = await _doctorRepository.GetDoctorByCrm(doctorObj.Crm);

            if (crm != null)
                return BadRequest("CRM já cadastrado!");

            if (email != null)
                return BadRequest("Email já cadastrado");

            doctorObj.Password = PasswordHasher.HashPassword(doctorObj.Password);

            await _doctorRepository.Create(doctorObj);

            return Created("Doutor cadastrado!", doctorObj);
        }

        [HttpPut]
        [Route("doctor")]
        public async Task<ActionResult> Change(Doctor doctor)
        {
            if (doctor is null)
                return BadRequest("Dados inválidos");

            _doctorRepository.Update(doctor);

            return Ok();
        }

        [HttpDelete]
        [Route("doctor/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var doctorTemp = await _doctorRepository.GetDoctorById(id);

            if (doctorTemp is null)
                return NotFound("Médico não encontrado");

            await _doctorRepository.Delete(doctorTemp);
            return Ok();
        }

        [HttpGet]
        [Route("doctor/{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorId([FromRoute]int id)
        {
            var doctorTemp = await _doctorRepository.GetDoctorById(id);

            if (doctorTemp is null)
                return NotFound("Médico não encontrado");

            return doctorTemp;
        }

        [HttpGet]
        [Route("doctor/crm/{crm}")]
        public async Task<ActionResult<Doctor>> GetDoctorCRM([FromRoute]string crm)
        {
            var doctorTemp = await _doctorRepository.GetDoctorByCrm(crm);

            if (doctorTemp is null)
                return NotFound("Médico não encontrado");

            return doctorTemp;
        }

        [HttpGet]
        [Route("doctors/{speciality}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors(string speciality)
        {
            var doctorsTemp = await _doctorRepository.GetDoctorBySpeciality(speciality);

            return Ok(doctorsTemp);
        }

        private string CreateJwt(Doctor doctorObj)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("B4GSg^]]7g~ep7%*3Xob;dqM(Xlcy$uY");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, $"{doctorObj.Email}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var expirationTime = DateTime.Now.AddMinutes(30);
            var notbefore = DateTime.Now;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = expirationTime,
                NotBefore = notbefore,
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
