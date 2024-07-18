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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        // GET: api/Medication
        [HttpGet("GetAllMedications")]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
        {
            var medications = await _medicationService.GetMedicationsAsync();
            return Ok(medications);
        }


        // GET: api/Medication/5
        [HttpGet("GetMedicationById/{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
            var medication = await _medicationService.GetMedicationByIdAsync(id);
            if (medication == null)
            {
                return NotFound();
            }
            return Ok(medication);
        }


        // PUT: api/Medication/5
        [HttpPut("UpdateMedication/{id}")]
        public async Task<IActionResult> PutMedication(int id, Medication medication)
        {
            if (id != medication.Id)
            {
                return BadRequest();
            }

            await _medicationService.UpdateMedicationAsync(medication);
            return NoContent();
        }


        // POST: api/Medication
        [HttpPost("CreateMedication")]
        public async Task<ActionResult<Medication>> PostMedication(Medication medication)
        {
            var id = await _medicationService.AddMedicationAsync(medication);
            return CreatedAtAction(nameof(GetMedication), new { id }, medication);
        }


        // DELETE: api/Medication/5
        [HttpDelete("DeleteMedication/{id}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            if (!_medicationService.MedicationExists(id))
            {
                return NotFound();
            }
            await _medicationService.DeleteMedicationAsync(id);
            return NoContent();
        }

    }
}
