using MedicalPrescriptionServices.Models;

namespace MedicalPrescriptionServices.Repositories.Interfaces
{
    public interface IPrescriptionAnalyticRepository
    {
        Task<IEnumerable<PrescriptionAnalytic>> GetByDrugNameAsync(string drugName);
        Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionTypeAsync(string prescriptionType);
        Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionStatusAsync(string prescriptionStatus);
        Task<IEnumerable<PrescriptionAnalytic>> GetByDatePrescribedRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<PrescriptionAnalytic>> GetByPatientAgeRangeAsync(int minAge, int maxAge);
        Task<IEnumerable<PrescriptionAnalytic>> GetByQuantityRangeAsync(int minQuantity, int maxQuantity);
        Task<IEnumerable<PrescriptionAnalytic>> GetByTotalCostRangeAsync(decimal minCost, decimal maxCost);
        Task<IEnumerable<PrescriptionAnalytic>> GetAllAsync();
        Task<PrescriptionAnalytic> GetByIdAsync(int id);
        Task<PrescriptionAnalytic> AddAsync(PrescriptionAnalytic entity);
        Task<bool> UpdateAsync(int id, PrescriptionAnalytic entity);
        Task<bool> DeleteAsync(int id);
    }
}