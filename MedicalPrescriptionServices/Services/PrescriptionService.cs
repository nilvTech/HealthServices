using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsAsync()
        {
            return await _repository.GetPrescriptionsAsync();
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _repository.GetPrescriptionByIdAsync(id);
        }

        public async Task<int> AddPrescriptionAsync(Prescription prescription)
        {
            return await _repository.AddPrescriptionAsync(prescription);
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            await _repository.UpdatePrescriptionAsync(prescription);
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            await _repository.DeletePrescriptionAsync(id);
        }
    }
}
