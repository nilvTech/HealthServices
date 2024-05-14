using MedicalPrescription.Models;

namespace MedicalPrescriptionServices.Repositories.Interfaces
{
    public interface IDrugInteractionRepository
    {
        Task<IEnumerable<DrugInteraction>> GetAllAsync();
        Task<DrugInteraction> GetByIdAsync(int id);
        Task AddAsync(DrugInteraction drugInteraction);
        Task UpdateAsync(DrugInteraction drugInteraction);
        Task DeleteAsync(int id);
        Task<DrugInteraction> GetByNameAsync(string drugName);

    }
}