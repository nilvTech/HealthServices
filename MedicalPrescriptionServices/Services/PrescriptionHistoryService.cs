using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Services
{
    public class PrescriptionHistoryService : IPrescriptionHistoryService
    {
        private readonly IPrescriptionHistoryRepository _repository;

        public PrescriptionHistoryService(IPrescriptionHistoryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<PrescriptionHistory>> GetPrescriptionHistoriesAsync()
        {
            return _repository.GetPrescriptionHistoriesAsync();
        }

        public Task<PrescriptionHistory> GetPrescriptionHistoryByIdAsync(int id)
        {
            return _repository.GetPrescriptionHistoryByIdAsync(id);
        }

        public Task<int> AddPrescriptionHistoryAsync(PrescriptionHistory prescriptionHistory)
        {
            return _repository.AddPrescriptionHistoryAsync(prescriptionHistory);
        }

        public Task UpdatePrescriptionHistoryAsync(PrescriptionHistory prescriptionHistory)
        {
            return _repository.UpdatePrescriptionHistoryAsync(prescriptionHistory);
        }

        public Task DeletePrescriptionHistoryAsync(int id)
        {
            return _repository.DeletePrescriptionHistoryAsync(id);
        }

        public bool PrescriptionHistoryExists(int id)
        {
            return _repository.PrescriptionHistoryExists(id);
        }
    }
}
