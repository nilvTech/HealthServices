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
            try
            {
                // List to store appointment data
                var appointments = new List<Appointment>();

                // Start Kafka consumer
                using var consumer = new ConsumerBuilder<Ignore, string>(_kafkaConfig).Build();
                consumer.Subscribe(KafkaTopics.AppointmentTopic);

                // Use a cancellation token source to control the consumer loop
                var cancellationTokenSource = new CancellationTokenSource();

                // Start a task to consume messages asynchronously
                var consumerTask = System.Threading.Tasks.Task.Run(async () =>
                {
                    try
                    {
                        while (!cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            var consumeResult = consumer.Consume(cancellationTokenSource.Token);
                            var appointmentDataJson = consumeResult.Message.Value;

                            // Deserialize appointment data from JSON
                            var appointmentData = JsonConvert.DeserializeObject<Appointment>(appointmentDataJson);

                            // Add appointment data to the list
                            appointments.Add(appointmentData);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // OperationCanceledException will be thrown when cancellation is requested
                    }
                    catch (Exception ex)
                    {
                        // Log or handle other exceptions
                        Console.WriteLine($"Error consuming message: {ex.Message}");
                    }
                });

                // Wait for a specific timeout or until a certain condition is met
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(30)); 

                // Cancel the consumer task after the timeout
                cancellationTokenSource.Cancel();

                // Wait for the consumer task to complete
                await consumerTask;

                // Now you have all appointment data in the 'appointments' list
                // You can process this data or return it directly

                return Ok(appointments);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return StatusCode(500, "An error occurred while processing the surveys.");
            }
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