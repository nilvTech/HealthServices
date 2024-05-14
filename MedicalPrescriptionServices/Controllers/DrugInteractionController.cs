using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalPrescription.Models;
using MedicalPrescriptionServices;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DrugInteractionController : ControllerBase
    {
        private readonly IDrugInteractionService _drugInteractionService;

        public DrugInteractionController(IDrugInteractionService drugInteractionService)
        {
            _drugInteractionService = drugInteractionService;
        }

        [HttpGet("GetAllDrugInteraction")]
        public async Task<ActionResult<IEnumerable<DrugInteraction>>> GetDrugInteractions()
        {
            try
            {
                var drugInteractions = await _drugInteractionService.GetAllDrugInteractionsAsync();
                return Ok(drugInteractions);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("GetDrugInteractionById/{id}")]
        public async Task<ActionResult<DrugInteraction>> GetDrugInteraction(int id)
        {
            try
            {
                var drugInteraction = await _drugInteractionService.GetDrugInteractionByIdAsync(id);
                if (drugInteraction == null)
                {
                    return NotFound();
                }

                return Ok(drugInteraction);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("UpdateDrugInteraction/{id}")]
        public async Task<IActionResult> PutDrugInteraction(int id, DrugInteraction drugInteraction)
        {
            try
            {
                var result = await _drugInteractionService.UpdateDrugInteractionAsync(id, drugInteraction);
                if (!result)
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("CreateDrugInteraction")]
        public async Task<ActionResult<DrugInteraction>> PostDrugInteraction(DrugInteraction drugInteraction)
        {
            try
            {
                var createdDrugInteraction = await _drugInteractionService.CreateDrugInteractionAsync(drugInteraction);
                return CreatedAtAction("GetDrugInteraction", new { id = createdDrugInteraction.Id }, createdDrugInteraction);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("DeleteDrugInteraction/{id}")]
        public async Task<IActionResult> DeleteDrugInteraction(int id)
        {
            try
            {
                var result = await _drugInteractionService.DeleteDrugInteractionAsync(id);
                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("CheckAvailability/{drugName}")]
        public async Task<ActionResult<string>> CheckDrugAvailability(string drugName)
        {
            try
            {
                var isAvailable = await _drugInteractionService.CheckDrugAvailability(drugName);

                if (isAvailable > 0)
                {
                    return Ok($"{drugName} is available with quantity {isAvailable}");
                }
                else
                {
                    return NotFound($"{drugName} is not available");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }

}
