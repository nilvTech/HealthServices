using AppointmentServices.Models;
using AppointmentServices.Repository;
using PatientSatisfactionFeedback.Services.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentServices.Services
{
    public class PatientSatisfactionService : IPatientSatisfactionService
    {
        private readonly IPatientSatisfactionRepository _repository;

        public PatientSatisfactionService(IPatientSatisfactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientSatisfaction> AddSurvey(PatientSatisfaction survey)
        {
            return await _repository.CreatePatientSatisfaction(survey);
        }

        public async Task<IEnumerable<PatientSatisfaction>> GetAllSurveys()
        {
            return await _repository.GetAllPatientSatisfactions();
        }

        public async Task<PatientSatisfaction> GetSurveyById(int id)
        {
            return await _repository.GetPatientSatisfactionById(id);
        }

        public async Task DeleteSurvey(int id)
        {
            await _repository.DeletePatientSatisfaction(id);
        }
    }
}
