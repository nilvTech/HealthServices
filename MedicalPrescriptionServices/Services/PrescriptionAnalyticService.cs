using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace MedicalPrescriptionServices.Services
{
    public class PrescriptionAnalyticService : IPrescriptionAnalyticService
    {
        private readonly IPrescriptionAnalyticRepository _repository;

        public PrescriptionAnalyticService(IPrescriptionAnalyticRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByDrugNameAsync(string drugName)
        {
            return await _repository.GetByDrugNameAsync(drugName);
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionTypeAsync(string prescriptionType)
        {
            return await _repository.GetByPrescriptionTypeAsync(prescriptionType);
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionStatusAsync(string prescriptionStatus)
        {
            return await _repository.GetByPrescriptionStatusAsync(prescriptionStatus);
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByDatePrescribedRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _repository.GetByDatePrescribedRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByPatientAgeRangeAsync(int minAge, int maxAge)
        {
            return await _repository.GetByPatientAgeRangeAsync(minAge, maxAge);
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByQuantityRangeAsync(int minQuantity, int maxQuantity)
        {
            return await _repository.GetByQuantityRangeAsync(minQuantity, maxQuantity);
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByTotalCostRangeAsync(decimal minCost, decimal maxCost)
        {
            return await _repository.GetByTotalCostRangeAsync(minCost, maxCost);
        }
        public async Task<IEnumerable<PrescriptionAnalytic>> GetAllPrescriptionAnalytics()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PrescriptionAnalytic> GetPrescriptionAnalyticsById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<PrescriptionAnalytic> AddPrescriptionAnalytics(PrescriptionAnalytic entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdatePrescriptionAnalytics(int id, PrescriptionAnalytic entity)
        {
            return await _repository.UpdateAsync(id, entity);
        }

        public async Task<bool> DeletePrescriptionAnalytics(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
