using PatientServices.Models.Patient;

namespace PatientServices.Repositories.Interfaces
{
    public interface IMedicalRecordRepository
    {
        Task<IEnumerable<MedicalRecord>> GetMedicalRecordsAsync();
        Task<MedicalRecord> GetMedicalRecordByIdAsync(int id);
        Task<int> AddMedicalRecordAsync(MedicalRecord medicalRecord);
        Task UpdateMedicalRecordAsync(MedicalRecord medicalRecord);
        Task DeleteMedicalRecordAsync(int id);
        bool MedicalRecordExists(int id);
    }
}