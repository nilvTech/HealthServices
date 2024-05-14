using MedicalPrescription.Models;

namespace MedicalPrescriptionServices.Services.Interfaces
{
    public interface IDrugInteractionService
    {
        Task<IEnumerable<DrugInteraction>> GetAllDrugInteractionsAsync();
        Task<DrugInteraction> GetDrugInteractionByIdAsync(int id);
        Task<bool> UpdateDrugInteractionAsync(int id, DrugInteraction drugInteraction);
        Task<DrugInteraction> CreateDrugInteractionAsync(DrugInteraction drugInteraction);
        Task<bool> DeleteDrugInteractionAsync(int id);
        Task<int> CheckDrugAvailability(string drugName);
    }
}