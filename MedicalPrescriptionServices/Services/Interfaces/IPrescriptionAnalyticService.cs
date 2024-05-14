using MedicalPrescriptionServices.Models;

namespace MedicalPrescriptionServices.Services.Interfaces
{
    public interface IPrescriptionAnalyticService
    {
        Task<IEnumerable<PrescriptionAnalytic>> GetByDrugNameAsync(string drugName);
        Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionTypeAsync(string prescriptionType);
        Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionStatusAsync(string prescriptionStatus);
        Task<IEnumerable<PrescriptionAnalytic>> GetByDatePrescribedRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<PrescriptionAnalytic>> GetByPatientAgeRangeAsync(int minAge, int maxAge);
        Task<IEnumerable<PrescriptionAnalytic>> GetByQuantityRangeAsync(int minQuantity, int maxQuantity);
        Task<IEnumerable<PrescriptionAnalytic>> GetByTotalCostRangeAsync(decimal minCost, decimal maxCost);
        Task<IEnumerable<PrescriptionAnalytic>> GetAllPrescriptionAnalytics();
        Task<PrescriptionAnalytic> GetPrescriptionAnalyticsById(int id);
        Task<PrescriptionAnalytic> AddPrescriptionAnalytics(PrescriptionAnalytic entity);
        Task<bool> UpdatePrescriptionAnalytics(int id, PrescriptionAnalytic entity);
        Task<bool> DeletePrescriptionAnalytics(int id);
    }
}