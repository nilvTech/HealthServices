using AppointmentServices.Models;
using AppointmentServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AppointmentServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentSchedulingController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentSchedulingController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            await _appointmentService.CreateAppointmentAsync(appointment);
            return Ok("Appointment Created and Sent to Kafka Successfully");
        }

        // GET method to retrieve all appointments
        [HttpGet]
        public IActionResult GetAppointments()
        {
            var appointments = _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        // GET method to retrieve a specific appointment by ID
        [HttpGet("{id}")]
        public IActionResult GetAppointmentById(int id)
        {
            var appointment = _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
    }
}
