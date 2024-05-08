using PatientServices.Models.Patient;
using PatientServices.Repositories.Interfaces;
using PatientServices.Services.Interfaces;

namespace PatientServices.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _repository;

        public MedicalRecordService(IMedicalRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MedicalRecord>> GetMedicalRecordsAsync()
        {
            return await _repository.GetMedicalRecordsAsync();
        }

        public async Task<MedicalRecord> GetMedicalRecordByIdAsync(int id)
        {
            return await _repository.GetMedicalRecordByIdAsync(id);
        }

        public async Task<int> AddMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            return await _repository.AddMedicalRecordAsync(medicalRecord);
        }

        public async Task UpdateMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            await _repository.UpdateMedicalRecordAsync(medicalRecord);
        }

        public async Task DeleteMedicalRecordAsync(int id)
        {
            await _repository.DeleteMedicalRecordAsync(id);
        }

        public bool MedicalRecordExists(int id)
        {
            return _repository.MedicalRecordExists(id);
        }
    }
}
