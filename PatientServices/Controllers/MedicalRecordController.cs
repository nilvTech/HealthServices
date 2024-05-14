using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthServices.Data;
using PatientServices.Models.Patient;
using PatientServices.Services.Interfaces;

namespace PatientServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        // GET: api/MedicalRecord
        [HttpGet("GetAllMedicalRecords")]
        public async Task<ActionResult<IEnumerable<MedicalRecord>>> GetMedicalRecords()
        {
            try
            {
                var medicalRecords = await _medicalRecordService.GetMedicalRecordsAsync();
                return Ok(medicalRecords);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: api/MedicalRecord/5
        [HttpGet("GetMedicalRecordById/{id}")]
        public async Task<ActionResult<MedicalRecord>> GetMedicalRecord(int id)
        {
            try
            {
                var medicalRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
                if (medicalRecord == null)
                {
                    return NotFound();
                }
                return Ok(medicalRecord);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/MedicalRecord/5
        [HttpPut("UpdateMedicalRecord/{id}")]
        public async Task<IActionResult> PutMedicalRecord(int id, MedicalRecord medicalRecord)
        {
            try
            {
                if (id != medicalRecord.RecordId)
                {
                    return BadRequest();
                }

                await _medicalRecordService.UpdateMedicalRecordAsync(medicalRecord);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // POST: api/MedicalRecord
        [HttpPost("CreateMedicalRecord")]
        public async Task<ActionResult<MedicalRecord>> PostMedicalRecord(MedicalRecord medicalRecord)
        {
            try
            {
                var id = await _medicalRecordService.AddMedicalRecordAsync(medicalRecord);

                return CreatedAtAction(nameof(GetMedicalRecord), new { id }, medicalRecord);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE: api/MedicalRecord/5
        [HttpDelete("DeleteMedicalRecords/{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(int id)
        {
            try
            {
                var medicalRecord = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
                if (medicalRecord == null)
                {
                    return NotFound();
                }

                await _medicalRecordService.DeleteMedicalRecordAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }

}
