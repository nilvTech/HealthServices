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
            var notifications = await _notificationService.GetNotificationsAsync();
            return Ok(notifications);
        }

        // GET: api/Notification/5
        [HttpGet("GetNotificationById/{id}")]
        public async Task<ActionResult<Notification>> GetNotification(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        // PUT: api/Notification/5
        [HttpPut("UpdateNotification/{id}")]
        public async Task<IActionResult> PutNotification(int id, Notification notification)
        {
            if (id != notification.NotificationId)
            {
                return BadRequest();
            }
            await _notificationService.UpdateNotificationAsync(notification);
            return NoContent();
        }

        // POST: api/Notification
        [HttpPost("CreateNotification")]
        public async Task<ActionResult<Notification>> PostNotification(Notification notification)
        {
            await _notificationService.AddNotificationAsync(notification);
            return CreatedAtAction(nameof(GetNotification), new { id = notification.NotificationId }, notification);
        }

        // DELETE: api/Notification/5
        [HttpDelete("DeleteNotification/{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            if (!_notificationService.NotificationExists(id))
            {
                return NotFound();
            }
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}
