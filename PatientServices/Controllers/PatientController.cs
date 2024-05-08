using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthServices.Data;
using PatientServices.Models.Patient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using PatientServices.Services.Interfaces;

namespace PatientServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patients
        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientService.GetPatientsAsync();
            return Ok(patients);
        }

        // GET: api/Patients/5
        [HttpGet("GetPatientById/{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // PUT: api/Patients/5
        [HttpPut("UpdatePatient/{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }
            await _patientService.UpdatePatientAsync(patient);
            return NoContent();
        }

        // POST: api/Patients
        [HttpPost("CreatePatient")]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            await _patientService.AddPatientAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("DeletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (!_patientService.PatientExists(id))
            {
                return NotFound();
            }
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
        [HttpGet("GetPatientByName/{name}")]
        public async Task<ActionResult<Patient>> GetPatientByName(string name)
        {
            var patient = await _patientService.GetPatientByNameAsync(name);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
