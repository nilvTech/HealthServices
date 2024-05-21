using PatientSatisfactionFeedback.Context;
using PatientSatisfactionFeedback.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PatientSatisfactionFeedback.Repository
{
    public class PatientSatisfactionRepository : IPatientSatisfactionRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientSatisfactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientSatisfaction>> GetAllPatientSatisfactions()
        {
            return await _context.PatientSatisfactions.ToListAsync();
        }

        public async Task<PatientSatisfaction> GetPatientSatisfactionById(int id)
        {
            return await _context.PatientSatisfactions.FindAsync(id);
        }

        public async Task<PatientSatisfaction> CreatePatientSatisfaction(PatientSatisfaction patientSatisfaction)
        {
            _context.PatientSatisfactions.Add(patientSatisfaction);
            await _context.SaveChangesAsync();
            return patientSatisfaction;
        }

        public async Task<PatientSatisfaction> UpdatePatientSatisfaction(int id, PatientSatisfaction patientSatisfaction)
        {
            var existingPatientSatisfaction = await _context.PatientSatisfactions.FindAsync(id);
            if (existingPatientSatisfaction == null)
            {
                return null;
            }

            existingPatientSatisfaction.Name= patientSatisfaction.Name; // Update other properties as needed

            await _context.SaveChangesAsync();
            return existingPatientSatisfaction;
        }

        public async Task<bool> DeletePatientSatisfaction(int id)
        {
            var patientSatisfaction = await _context.PatientSatisfactions.FindAsync(id);
            if (patientSatisfaction == null)
            {
                return false;
            }

            _context.PatientSatisfactions.Remove(patientSatisfaction);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
