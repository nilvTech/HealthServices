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
            var analytics = await _analyticsService.GetByDrugNameAsync(drugName);
            return Ok(analytics);
        }


        [HttpGet("GetByPrescriptionType/{prescriptionType}")]
        public async Task<IActionResult> GetByPrescriptionType(string prescriptionType)
        {
            var analytics = await _analyticsService.GetByPrescriptionTypeAsync(prescriptionType);
            return Ok(analytics);
        }

        [HttpGet("GetByPrescriptionStatus/{prescriptionStatus}")]
        public async Task<IActionResult> GetByPrescriptionStatus(string prescriptionStatus)
        {
            var analytics = await _analyticsService.GetByPrescriptionStatusAsync(prescriptionStatus);
            return Ok(analytics);
        }


        [HttpGet("GetByDatePrescribedRange")]
        public async Task<IActionResult> GetByDatePrescribedRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var analytics = await _analyticsService.GetByDatePrescribedRangeAsync(startDate, endDate);
            return Ok(analytics);
        }


        [HttpGet("GetByPatientAgeRange")]
        public async Task<IActionResult> GetByPatientAgeRange([FromQuery] int minAge, [FromQuery] int maxAge)
        {
            var analytics = await _analyticsService.GetByPatientAgeRangeAsync(minAge, maxAge);
            return Ok(analytics);
        }


        [HttpGet("GetByQuantityRange")]
        public async Task<IActionResult> GetByQuantityRange([FromQuery] int minQuantity, [FromQuery] int maxQuantity)
        {
            var analytics = await _analyticsService.GetByQuantityRangeAsync(minQuantity, maxQuantity);
            return Ok(analytics);
        }


        [HttpGet("GetByTotalCostRange")]
        public async Task<IActionResult> GetByTotalCostRange([FromQuery] decimal minCost, [FromQuery] decimal maxCost)
        {
            var analytics = await _analyticsService.GetByTotalCostRangeAsync(minCost, maxCost);
            return Ok(analytics);
        }


        [HttpGet("GetAllPrescriptionAnalytics")]
        public async Task<ActionResult<IEnumerable<PrescriptionAnalytic>>> GetPrescriptionAnalytics()
        {
            var analytics = await _analyticsService.GetAllPrescriptionAnalytics();
            return Ok(analytics);
        }


        [HttpGet("GetPrescriptionAnalyticsById/{id}")]
        public async Task<ActionResult<PrescriptionAnalytic>> GetPrescriptionAnalytics(int id)
        {
            var analytics = await _analyticsService.GetPrescriptionAnalyticsById(id);
            if (analytics == null)
                return NotFound();

            return Ok(analytics);
        }


        [HttpPost("CreatePrescriptionAnalytics")]
        public async Task<ActionResult<PrescriptionAnalytic>> PostPrescriptionAnalytics(PrescriptionAnalytic analytics)
        {
            var newAnalytics = await _analyticsService.AddPrescriptionAnalytics(analytics);
            return CreatedAtAction(nameof(GetPrescriptionAnalytics), new { id = newAnalytics.Id }, newAnalytics);
        }


        [HttpPut("UpdatePrescriptionAnalytics/{id}")]
        public async Task<IActionResult> PutPrescriptionAnalytics(int id, PrescriptionAnalytic analytics)
        {
            var updated = await _analyticsService.UpdatePrescriptionAnalytics(id, analytics);
            if (!updated)
                return NotFound();

            return NoContent();
        }


        [HttpDelete("DeletePrescriptionAnalytics/{id}")]
        public async Task<IActionResult> DeletePrescriptionAnalytics(int id)
        {
            var deleted = await _analyticsService.DeletePrescriptionAnalytics(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
