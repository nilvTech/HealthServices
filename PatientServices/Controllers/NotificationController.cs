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
using PatientServices.Models;

namespace PatientServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/Notification
        [HttpGet("GetAllNotifications")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotifications()
        {
            try
            {
                var notifications = await _notificationService.GetNotificationsAsync();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // GET: api/Notification/5
        [HttpGet("GetNotificationById/{id}")]
        public async Task<ActionResult<Notification>> GetNotification(int id)
        {
            try
            {
                var notification = await _notificationService.GetNotificationByIdAsync(id);
                if (notification == null)
                {
                    return NotFound();
                }
                return Ok(notification);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/Notification/5
        [HttpPut("UpdateNotification/{id}")]
        public async Task<IActionResult> PutNotification(int id, Notification notification)
        {
            try
            {
                if (id != notification.NotificationId)
                {
                    return BadRequest();
                }
                await _notificationService.UpdateNotificationAsync(notification);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // POST: api/Notification
        [HttpPost("CreateNotification")]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            try
            {
                await _notificationService.AddNotificationAsync(notification);
                return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // DELETE: api/Notification/5
        [HttpDelete("DeleteNotification/{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            try
            {
                if (!_notificationService.NotificationExists(id))
                {
                    return NotFound();
                }
                await _notificationService.DeleteNotificationAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in some other way
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("NotifyPatient")]
        public async Task<IActionResult> SendNotificationToPatient([FromBody] NotificationRequest notificationRequest)
        {
            try
            {
                // Call the service method to send the notification
                bool notificationSent = await _notificationService.SendNotificationToPatientAsync(notificationRequest);
                if (notificationSent)
                {
                    return Ok("Notification sent successfully.");
                }
                else
                {
                    return BadRequest("Failed to send notification.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
