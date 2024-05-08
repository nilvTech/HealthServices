using MedicalPrescriptionServices.Models.Patient;

namespace MedicalPrescriptionServices.Repositories.Interfaces
{
    public interface IPatientRepository
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