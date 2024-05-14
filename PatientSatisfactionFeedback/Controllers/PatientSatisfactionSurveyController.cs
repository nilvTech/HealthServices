using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppointmentServices.Models;
using PatientSatisfactionFeedback.Services.IServices;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Exchange.WebServices.Data;
using PatientSatisfactionFeedback;

namespace AppointmentServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientSatisfactionController : ControllerBase
    {
        private readonly IPatientSatisfactionService _service;
        private readonly ConsumerConfig _kafkaConfig;

        public PatientSatisfactionController(IPatientSatisfactionService service)
        {
            _service = service;
            _kafkaConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "satisfaction-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddSurvey([FromBody] PatientSatisfaction survey)
        {
            try
            {
                var addedSurvey = await _service.AddSurvey(survey);
                return CreatedAtAction(nameof(GetSurveyById), new { id = addedSurvey.Id }, addedSurvey);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while processing your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            // Start Kafka consumer
            using var consumer = new ConsumerBuilder<Ignore, string>(_kafkaConfig).Build();
            consumer.Subscribe(KafkaTopics.AppointmentTopic);

            while (true)
            {
                var consumeResult = consumer.Consume();
                var appointmentDataJson = consumeResult.Message.Value;

                // Deserialize appointment data from JSON
                var appointmentData = JsonConvert.DeserializeObject<PatientSatisfaction>(appointmentDataJson);

                // Example: Process appointment data and handle patient satisfaction logic
                // _service.ProcessAppointmentData(appointmentData);
            }

            // Return data from service as needed
            var surveys = await _service.GetAllSurveys();
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurveyById(int id)
        {
            var survey = await _service.GetSurveyById(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _service.DeleteSurvey(id);
            return NoContent();
        }
    }
}