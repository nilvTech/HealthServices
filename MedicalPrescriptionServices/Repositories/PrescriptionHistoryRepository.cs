using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionServices.Repositories
{
    public class PrescriptionHistoryRepository : IPrescriptionHistoryRepository
    {
        private readonly PrescriptionDbContext _context;

        public PrescriptionHistoryRepository(PrescriptionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PrescriptionHistory>> GetPrescriptionHistoriesAsync()
        {
            return await _context.PrescriptionHistories.ToListAsync();
        }

        public async Task<PrescriptionHistory> GetPrescriptionHistoryByIdAsync(int id)
        {
            return await _context.PrescriptionHistories.FindAsync(id);
        }

        public async Task<int> AddPrescriptionHistoryAsync(PrescriptionHistory prescriptionHistory)
        {
            _context.PrescriptionHistories.Add(prescriptionHistory);
            await _context.SaveChangesAsync();
            return prescriptionHistory.Id;
        }

        public async Task UpdatePrescriptionHistoryAsync(PrescriptionHistory prescriptionHistory)
        {
            _context.Entry(prescriptionHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescriptionHistoryAsync(int id)
        {
            var prescriptionHistory = await _context.PrescriptionHistories.FindAsync(id);
            _context.PrescriptionHistories.Remove(prescriptionHistory);
            await _context.SaveChangesAsync();
        }

        public bool PrescriptionHistoryExists(int id)
        {
            return _context.PrescriptionHistories.Any(e => e.Id == id);
        }
    }
}
