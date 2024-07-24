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
using MedicalPrescriptionServices.Services;

namespace MedicalPrescriptionServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        // GET: api/Prescription
        [HttpGet("GetAllPrescriptions")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
        {
            var prescriptions = await _prescriptionService.GetPrescriptionsAsync();
            return Ok(prescriptions);
        }


        // GET: api/Prescription/5
        [HttpGet("GetPrescriptionById/{id}")]
        public async Task<ActionResult<Prescription>> GetPrescription(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
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

            await _prescriptionService.UpdatePrescriptionAsync(prescription);
            return NoContent();
        }


        // POST: api/Prescription
        [HttpPost("CreatePrescription")]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        {
            var id = await _prescriptionService.AddPrescriptionAsync(prescription);
            return CreatedAtAction(nameof(GetPrescription), new { id }, prescription);
        }


        // DELETE: api/Prescription/5
        [HttpDelete("DeletePrescription/{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            try
            {
                await _prescriptionService.DeletePrescriptionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // Other methods...

        // Example of a more specific error message for BadRequest
        [HttpPost("ValidatePrescription/{id}")]
        public async Task<ActionResult> ValidatePrescription(int id)
        {
            try
            {
                var isValid = await _prescriptionService.ValidatePrescription(id);
                if (isValid)
                {
                    return Ok("Prescription is valid.");
                }
                else
                {
                    return BadRequest("Prescription is not valid.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }

}

