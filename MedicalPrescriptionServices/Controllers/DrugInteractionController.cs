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
            var drugInteractions = await _drugInteractionService.GetAllDrugInteractionsAsync();
            return Ok(drugInteractions);
        }


        [HttpGet("GetDrugInteractionById/{id}")]
        public async Task<ActionResult<DrugInteraction>> GetDrugInteraction(int id)
        {
            var drugInteraction = await _drugInteractionService.GetDrugInteractionByIdAsync(id);
            if (drugInteraction == null)
            {
                return NotFound();
            }

            return Ok(drugInteraction);
        }


        [HttpPut("UpdateDrugInteraction/{id}")]
        public async Task<IActionResult> PutDrugInteraction(int id, DrugInteraction drugInteraction)
        {
            var result = await _drugInteractionService.UpdateDrugInteractionAsync(id, drugInteraction);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }


        [HttpPost("CreateDrugInteraction")]
        public async Task<ActionResult<DrugInteraction>> PostDrugInteraction(DrugInteraction drugInteraction)
        {
            var createdDrugInteraction = await _drugInteractionService.CreateDrugInteractionAsync(drugInteraction);
            return CreatedAtAction("GetDrugInteraction", new { id = createdDrugInteraction.Id }, createdDrugInteraction);
        }


        [HttpDelete("DeleteDrugInteraction/{id}")]
        public async Task<IActionResult> DeleteDrugInteraction(int id)
        {
            var result = await _drugInteractionService.DeleteDrugInteractionAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpGet("CheckAvailability/{drugName}")]
        public async Task<ActionResult<string>> CheckDrugAvailability(string drugName)
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

    }

}
