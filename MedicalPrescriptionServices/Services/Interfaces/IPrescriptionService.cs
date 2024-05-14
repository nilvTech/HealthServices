using MedicalPrescriptionServices.Models;

namespace MedicalPrescriptionServices.Services.Interfaces
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<Prescription>> GetPrescriptionsAsync();
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task<int> AddPrescriptionAsync(Prescription prescription);
        Task UpdatePrescriptionAsync(Prescription prescription);
        Task DeletePrescriptionAsync(int id);
        Task<IEnumerable<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId);
        Task<bool> ValidatePrescription(int id);


    }
}