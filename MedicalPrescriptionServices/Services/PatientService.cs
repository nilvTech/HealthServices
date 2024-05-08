

using MedicalPrescriptionServices.Models.Patient;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return _patientRepository.GetPatientsAsync();
        }

        public Task<Patient> GetPatientByIdAsync(int id)
        {
            return _patientRepository.GetPatientByIdAsync(id);
        }

        public Task<int> AddPatientAsync(Patient patient)
        {
            return _patientRepository.AddPatientAsync(patient);
        }

        public Task UpdatePatientAsync(Patient patient)
        {
            return _patientRepository.UpdatePatientAsync(patient);
        }

        public Task DeletePatientAsync(int id)
        {
            return _patientRepository.DeletePatientAsync(id);
        }
        public async Task<Patient> GetPatientByNameAsync(string name)
        {
            return await _patientRepository.GetPatientByNameAsync(name);
        }

        public bool PatientExists(int id)
        {
            return _patientRepository.PatientExists(id);
        }
    }
}
