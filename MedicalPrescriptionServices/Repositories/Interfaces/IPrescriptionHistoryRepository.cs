using MedicalPrescriptionServices.Models;

namespace MedicalPrescriptionServices.Repositories.Interfaces
{
    public interface IPrescriptionHistoryRepository
    {
        Task<IEnumerable<PrescriptionHistory>> GetPrescriptionHistoriesAsync();
        Task<PrescriptionHistory> GetPrescriptionHistoryByIdAsync(int id);
        Task<int> AddPrescriptionHistoryAsync(PrescriptionHistory prescriptionHistory);
        Task UpdatePrescriptionHistoryAsync(PrescriptionHistory prescriptionHistory);
        Task DeletePrescriptionHistoryAsync(int id);
        bool PrescriptionHistoryExists(int id);
    }
}