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
    public class PrescriptionAnalyticController : ControllerBase
    { 
        private readonly IPrescriptionAnalyticService _analyticsService;

        public PrescriptionAnalyticController(IPrescriptionAnalyticService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("GetByDrugName/{drugName}")]
        public async Task<IActionResult> GetByDrugName(string drugName)
        {
            try
            {
                var analytics = await _analyticsService.GetByDrugNameAsync(drugName);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetByPrescriptionType/{prescriptionType}")]
        public async Task<IActionResult> GetByPrescriptionType(string prescriptionType)
        {
            try
            {
                var analytics = await _analyticsService.GetByPrescriptionTypeAsync(prescriptionType);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetByPrescriptionStatus/{prescriptionStatus}")]
        public async Task<IActionResult> GetByPrescriptionStatus(string prescriptionStatus)
        {
            try
            {
                var analytics = await _analyticsService.GetByPrescriptionStatusAsync(prescriptionStatus);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetByDatePrescribedRange")]
        public async Task<IActionResult> GetByDatePrescribedRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var analytics = await _analyticsService.GetByDatePrescribedRangeAsync(startDate, endDate);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetByPatientAgeRange")]
        public async Task<IActionResult> GetByPatientAgeRange([FromQuery] int minAge, [FromQuery] int maxAge)
        {
            try
            {
                var analytics = await _analyticsService.GetByPatientAgeRangeAsync(minAge, maxAge);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetByQuantityRange")]
        public async Task<IActionResult> GetByQuantityRange([FromQuery] int minQuantity, [FromQuery] int maxQuantity)
        {
            try
            {
                var analytics = await _analyticsService.GetByQuantityRangeAsync(minQuantity, maxQuantity);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetByTotalCostRange")]
        public async Task<IActionResult> GetByTotalCostRange([FromQuery] decimal minCost, [FromQuery] decimal maxCost)
        {
            try
            {
                var analytics = await _analyticsService.GetByTotalCostRangeAsync(minCost, maxCost);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetAllPrescriptionAnalytics")]
        public async Task<ActionResult<IEnumerable<PrescriptionAnalytic>>> GetPrescriptionAnalytics()
        {
            try
            {
                var analytics = await _analyticsService.GetAllPrescriptionAnalytics();
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetPrescriptionAnalyticsById/{id}")]
        public async Task<ActionResult<PrescriptionAnalytic>> GetPrescriptionAnalytics(int id)
        {
            try
            {
                var analytics = await _analyticsService.GetPrescriptionAnalyticsById(id);
                if (analytics == null)
                    return NotFound();

                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("CreatePrescriptionAnalytics")]
        public async Task<ActionResult<PrescriptionAnalytic>> PostPrescriptionAnalytics(PrescriptionAnalytic analytics)
        {
            try
            {
                var newAnalytics = await _analyticsService.AddPrescriptionAnalytics(analytics);
                return CreatedAtAction(nameof(GetPrescriptionAnalytics), new { id = newAnalytics.Id }, newAnalytics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("UpdatePrescriptionAnalytics/{id}")]
        public async Task<IActionResult> PutPrescriptionAnalytics(int id, PrescriptionAnalytic analytics)
        {
            try
            {
                var updated = await _analyticsService.UpdatePrescriptionAnalytics(id, analytics);
                if (!updated)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeletePrescriptionAnalytics/{id}")]
        public async Task<IActionResult> DeletePrescriptionAnalytics(int id)
        {
            try
            {
                var deleted = await _analyticsService.DeletePrescriptionAnalytics(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
