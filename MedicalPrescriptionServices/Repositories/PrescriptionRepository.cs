using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionServices.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly PrescriptionDbContext _context;

        public PrescriptionRepository(PrescriptionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsAsync()
        {
            return await _context.Prescriptions.ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions.FindAsync(id);
        }

        public async Task<int> AddPrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription.Id;
        }

        public async Task UpdatePrescriptionAsync(Prescription prescription)
        {
            _context.Entry(prescription).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePrescriptionAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            _context.Prescriptions.Remove(prescription);
            await _context.SaveChangesAsync();
        }

        public bool PrescriptionExists(int id)
        {
            return _context.Prescriptions.Any(e => e.Id == id);
        }
    }
}
