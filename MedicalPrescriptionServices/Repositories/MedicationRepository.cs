using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionServices.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly PrescriptionDbContext _context;

        public MedicationRepository(PrescriptionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medication>> GetMedicationsAsync()
        {
            return await _context.Medications.ToListAsync();
        }

        public async Task<Medication> GetMedicationByIdAsync(int id)
        {
            return await _context.Medications.FindAsync(id);
        }

        public async Task<int> AddMedicationAsync(Medication medication)
        {
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();
            return medication.Id;
        }

        public async Task UpdateMedicationAsync(Medication medication)
        {
            _context.Entry(medication).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMedicationAsync(int id)
        {
            var medication = await _context.Medications.FindAsync(id);
            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync();
        }

        public bool MedicationExists(int id)
        {
            return _context.Medications.Any(e => e.Id == id);
        }
    }
}
