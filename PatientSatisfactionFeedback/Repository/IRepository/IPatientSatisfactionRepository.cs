using AppointmentServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentServices.Repository
{
    public interface IPatientSatisfactionRepository
    {
        Task<IEnumerable<PatientSatisfaction>> GetAllPatientSatisfactions();
        Task<PatientSatisfaction> GetPatientSatisfactionById(int id);
        Task<PatientSatisfaction> CreatePatientSatisfaction(PatientSatisfaction patientSatisfaction);
        Task<PatientSatisfaction> UpdatePatientSatisfaction(int id, PatientSatisfaction patientSatisfaction); // Add this method
        Task<bool> DeletePatientSatisfaction(int id);
    }
}
