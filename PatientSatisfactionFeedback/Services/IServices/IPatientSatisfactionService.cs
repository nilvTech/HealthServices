using AppointmentServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientSatisfactionFeedback.Services.IServices
{
    public interface IPatientSatisfactionService
    {
        Task<PatientSatisfaction> AddSurvey(PatientSatisfaction survey);
        Task<IEnumerable<PatientSatisfaction>> GetAllSurveys();
        Task<PatientSatisfaction> GetSurveyById(int id);
        Task DeleteSurvey(int id);
    }
}
