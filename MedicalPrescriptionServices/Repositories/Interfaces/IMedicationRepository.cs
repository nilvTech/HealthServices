using MedicalPrescriptionServices.Models;

namespace MedicalPrescriptionServices.Repositories.Interfaces
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetMedicationsAsync();
        Task<Medication> GetMedicationByIdAsync(int id);
        Task<int> AddMedicationAsync(Medication medication);
        Task UpdateMedicationAsync(Medication medication);
        Task DeleteMedicationAsync(int id);
        bool MedicationExists(int id);
    }
}