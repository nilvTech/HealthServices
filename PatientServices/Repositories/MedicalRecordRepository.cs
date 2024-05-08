using Microsoft.EntityFrameworkCore;
using PatientServices.Models.Patient;
using PatientServices.Repositories.Interfaces;

namespace PatientServices.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly DbContext _context;

        public MedicalRecordRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalRecord>> GetMedicalRecordsAsync()
        {
            return await _context.Set<MedicalRecord>().ToListAsync();
        }

        public async Task<MedicalRecord> GetMedicalRecordByIdAsync(int id)
        {
            return await _context.Set<MedicalRecord>().FindAsync(id);
        }

        public async Task<int> AddMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            _context.Set<MedicalRecord>().Add(medicalRecord);
            await _context.SaveChangesAsync();
            return medicalRecord.RecordId;
        }

        public async Task UpdateMedicalRecordAsync(MedicalRecord medicalRecord)
        {
            _context.Entry(medicalRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicalRecordAsync(int id)
        {
            var medicalRecord = await _context.Set<MedicalRecord>().FindAsync(id);
            if (medicalRecord != null)
            {
                _context.Set<MedicalRecord>().Remove(medicalRecord);
                await _context.SaveChangesAsync();
            }
        }

        public bool MedicalRecordExists(int id)
        {
            return _context.Set<MedicalRecord>().Any(e => e.RecordId == id);
        }
    }
}
