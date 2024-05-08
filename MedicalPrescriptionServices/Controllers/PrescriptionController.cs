using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalPrescriptionServices;
using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }

        // GET: api/Prescription
        [HttpGet("GetAllPrescriptions")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
        {
            var prescriptions = await _service.GetPrescriptionsAsync();
            return Ok(prescriptions);
        }

        // GET: api/Prescription/5
        [HttpGet("GetPrescriptionById/{id}")]
        public async Task<ActionResult<Prescription>> GetPrescription(int id)
        {
            var prescription = await _service.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }

        // PUT: api/Prescription/5
        [HttpPut("UpdatePrescription/{id}")]
        public async Task<IActionResult> PutPrescription(int id, Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return BadRequest();
            }
            await _service.UpdatePrescriptionAsync(prescription);
            return NoContent();
        }

        // POST: api/Prescription
        [HttpPost("CreatePrescription")]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        {
            var id = await _service.AddPrescriptionAsync(prescription);
            return CreatedAtAction(nameof(GetPrescription), new { id }, prescription);
        }

        // DELETE: api/Prescription/5
        [HttpDelete("DeletePrescription/{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _service.DeletePrescriptionAsync(id);
            return NoContent();
        }
    }
}

