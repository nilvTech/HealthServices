using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public Task<IEnumerable<Medication>> GetMedicationsAsync()
        {
            return _medicationRepository.GetMedicationsAsync();
        }

        public Task<Medication> GetMedicationByIdAsync(int id)
        {
            return _medicationRepository.GetMedicationByIdAsync(id);
        }

        public Task<int> AddMedicationAsync(Medication medication)
        {
            return _medicationRepository.AddMedicationAsync(medication);
        }

        public Task UpdateMedicationAsync(Medication medication)
        {
            return _medicationRepository.UpdateMedicationAsync(medication);
        }

        public Task DeleteMedicationAsync(int id)
        {
            return _medicationRepository.DeleteMedicationAsync(id);
        }

        public bool MedicationExists(int id)
        {
            return _medicationRepository.MedicationExists(id);
        }
    }

}
