using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PatientSatisfactionFeedback.Models;
using PatientSatisfactionFeedback.Services.IServices;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Exchange.WebServices.Data;
using PatientSatisfactionFeedback;

namespace PatientSatisfactionFeedback.Controllers
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
                BootstrapServers = "127.0.0.1:9092",
                GroupId = "satisfaction-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddSurvey([FromBody] PatientSatisfaction survey)
        {
            var addedSurvey = await _service.AddSurvey(survey);
            return CreatedAtAction(nameof(GetSurveyById), new { id = addedSurvey.Id }, addedSurvey);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            try
            {
                var appointments = new List<Appointment>();

                // Start Kafka consumer
                using var consumer = new ConsumerBuilder<Ignore, string>(_kafkaConfig).Build();
                consumer.Subscribe(KafkaTopics.AppointmentTopic);

                var cancellationTokenSource = new CancellationTokenSource();

                var consumerTask = System.Threading.Tasks.Task.Run(async () =>
                {
                    try
                    {
                        while (!cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            var consumeResult = consumer.Consume(cancellationTokenSource.Token);
                            var appointmentJson = consumeResult.Message.Value;

                            var appointment = JsonConvert.DeserializeObject<Appointment>(appointmentJson);

                            appointments.Add(appointment);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // OperationCanceledException will be thrown when cancellation is requested
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error consuming message: {ex.Message}");
                    }
                });

                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(30)); 

                cancellationTokenSource.Cancel();

                await consumerTask;

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