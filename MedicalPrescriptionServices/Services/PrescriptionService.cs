using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services.Interfaces;
using NuGet.Protocol.Core.Types;

namespace MedicalPrescriptionServices.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _prescriptionRepository = repository;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsAsync()
        {
            return await _prescriptionRepository.GetPrescriptionsAsync();
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _prescriptionRepository.GetPrescriptionByIdAsync(id);
        }

        public async Task<int> AddPrescriptionAsync(Prescription prescription)
        {
            return await _prescriptionRepository.AddPrescriptionAsync(prescription);
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            await _prescriptionRepository.UpdatePrescriptionAsync(prescription);
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            await _prescriptionRepository.DeletePrescriptionAsync(id);
        }
        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId)
        {
            return await _prescriptionRepository.GetPrescriptionsByPatientIdAsync(patientId);
        }
        public async Task<bool> ValidatePrescription(int id)
        {
            return await _prescriptionRepository.ValidatePrescription(id);
        }
    }
}
