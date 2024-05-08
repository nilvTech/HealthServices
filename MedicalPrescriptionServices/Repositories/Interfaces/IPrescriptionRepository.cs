using MedicalPrescriptionServices.Models;

namespace MedicalPrescriptionServices.Repositories.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetPrescriptionsAsync();
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task<int> AddPrescriptionAsync(Prescription prescription);
        Task UpdatePrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int id);
        bool PrescriptionExists(int id);
    }
}