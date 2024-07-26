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
    public class PrescriptionHistoryController : ControllerBase
    {
        private readonly IPrescriptionHistoryService _service;

        public PrescriptionHistoryController(IPrescriptionHistoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPrescriptionHistories")]
        public async Task<ActionResult<IEnumerable<PrescriptionHistory>>> GetPrescriptionHistories()
        {
            var prescriptionHistories = await _service.GetPrescriptionHistoriesAsync();
            return Ok(prescriptionHistories);
        }


        [HttpGet("GetPrescriptionHistoryById/{id}")]
        public async Task<ActionResult<PrescriptionHistory>> GetPrescriptionHistory(int id)
        {
            var prescriptionHistory = await _service.GetPrescriptionHistoryByIdAsync(id);
            if (prescriptionHistory == null)
            {
                return NotFound();
            }
            return Ok(prescriptionHistory);
        }

        [HttpPut("UpdatePrescriptionHistory/{id}")]
        public async Task<IActionResult> PutPrescriptionHistory(int id, PrescriptionHistory prescriptionHistory)
        {
            if (id != prescriptionHistory.Id)
            {
                return BadRequest();
            }
            await _service.UpdatePrescriptionHistoryAsync(prescriptionHistory);
            return NoContent();
        }


        [HttpPost("CreatePrescriptionHistory")]
        public async Task<ActionResult<PrescriptionHistory>> PostPrescriptionHistory(PrescriptionHistory prescriptionHistory)
        {
            var id = await _service.AddPrescriptionHistoryAsync(prescriptionHistory);
            return CreatedAtAction(nameof(GetPrescriptionHistory), new { id }, prescriptionHistory);
        }


        [HttpDelete("DeletePrescriptionHistory/{id}")]
        public async Task<IActionResult> DeletePrescriptionHistory(int id)
        {
            try
            {
                if (!_service.PrescriptionHistoryExists(id))
                {
                    return NotFound();
                }
                await _service.DeletePrescriptionHistoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
