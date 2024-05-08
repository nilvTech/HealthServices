using PatientServices.Models.Patient;

namespace PatientServices.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task<int> AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
        bool PatientExists(int id);
        Task<Patient> GetPatientByNameAsync(string name);

    }
}