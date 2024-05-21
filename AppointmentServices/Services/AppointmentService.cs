using PatientSatisfactionFeedback.Models;
using PatientSatisfactionFeedback.Repositories.IRepository;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientSatisfactionFeedback.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentSchedulingRepository _appointmentRepository;
        private readonly ProducerConfig _kafkaConfig;

        public AppointmentService(IAppointmentSchedulingRepository appointmentRepository, IConfiguration configuration)
        {
            _appointmentRepository = appointmentRepository;
            _kafkaConfig = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };
        }

        public void CreateAppointment(Appointment appointment)
        {
            _appointmentRepository.CreateAppointment(appointment);
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            _appointmentRepository.CreateAppointment(appointment);

            var appointmentJson = JsonConvert.SerializeObject(appointment);

            // Send appointment data to Kafka
            using var producer = new ProducerBuilder<Null, string>(_kafkaConfig).Build();
            await producer.ProduceAsync(KafkaTopics.AppointmentTopic, new Message<Null, string> { Value = appointmentJson });
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAllAppointments();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.GetAppointmentById(id);
        }
    }
}
