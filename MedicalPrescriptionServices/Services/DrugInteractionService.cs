using MedicalPrescription.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Services
{
    public class DrugInteractionService : IDrugInteractionService
    {
        private readonly IDrugInteractionRepository _drugInteractionRepository;

        public DrugInteractionService(IDrugInteractionRepository drugInteractionRepository)
        {
            _drugInteractionRepository = drugInteractionRepository;
        }

        public async Task<IEnumerable<DrugInteraction>> GetAllDrugInteractionsAsync()
        {
            return await _drugInteractionRepository.GetAllAsync();
        }

        public async Task<DrugInteraction> GetDrugInteractionByIdAsync(int id)
        {
            return await _drugInteractionRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateDrugInteractionAsync(int id, DrugInteraction drugInteraction)
        {
            if (id != drugInteraction.Id)
            {
                return false;
            }

            await _drugInteractionRepository.UpdateAsync(drugInteraction);

            return true;
        }

        public async Task<DrugInteraction> CreateDrugInteractionAsync(DrugInteraction drugInteraction)
        {
            await _drugInteractionRepository.AddAsync(drugInteraction);

            return drugInteraction;
        }

        public async Task<bool> DeleteDrugInteractionAsync(int id)
        {
            await _drugInteractionRepository.DeleteAsync(id);

            return true;
        }
        public async Task<int> CheckDrugAvailability(string drugName)
        {
            var drugInteraction = await _drugInteractionRepository.GetByNameAsync(drugName);
            
            return drugInteraction.Quantity;
        }
    }
}
