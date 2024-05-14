using MedicalPrescription.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalPrescriptionServices.Repositories
{
    public class DrugInteractionRepository : IDrugInteractionRepository
    {
        private readonly PrescriptionDbContext _context;

        public DrugInteractionRepository(PrescriptionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DrugInteraction>> GetAllAsync()
        {
            return await _context.DrugInteractions.ToListAsync();
        }

        public async Task<DrugInteraction> GetByIdAsync(int id)
        {
            return await _context.DrugInteractions.FindAsync(id);
        }

        public async Task AddAsync(DrugInteraction drugInteraction)
        {
            _context.DrugInteractions.Add(drugInteraction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DrugInteraction drugInteraction)
        {
            _context.Entry(drugInteraction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var drugInteraction = await _context.DrugInteractions.FindAsync(id);
            if (drugInteraction != null)
            {
                _context.DrugInteractions.Remove(drugInteraction);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<DrugInteraction> GetByNameAsync(string drugName)
        {
            var result = await _context.DrugInteractions.FirstOrDefaultAsync(d => d.DrugName == drugName);
            return result;
        }
    }
}
