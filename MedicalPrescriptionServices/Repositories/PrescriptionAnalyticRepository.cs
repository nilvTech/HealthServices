using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicalPrescriptionServices.Repositories
{
    public class PrescriptionAnalyticRepository : IPrescriptionAnalyticRepository
    {
        private readonly PrescriptionDbContext _context;

        public PrescriptionAnalyticRepository(PrescriptionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByDrugNameAsync(string drugName)
        {
            return await _context.PrescriptionAnalytics.Where(pa => pa.DrugName == drugName).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionAnalytic >> GetByPrescriptionTypeAsync(string prescriptionType)
        {
            return await _context.PrescriptionAnalytics.Where(pa => pa.PrescriptionType == prescriptionType).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByPrescriptionStatusAsync(string prescriptionStatus)
        {
            return await _context.PrescriptionAnalytics.Where(pa => pa.PrescriptionStatus == prescriptionStatus).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByDatePrescribedRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.PrescriptionAnalytics.Where(pa => pa.DatePrescribed >= startDate && pa.DatePrescribed <= endDate).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByPatientAgeRangeAsync(int minAge, int maxAge)
        {
            if (minAge < 0 || maxAge < 0 || minAge > maxAge)
            {
                throw new ArgumentException("Invalid age range");
            }
            DateTime endDate = DateTime.Today.AddYears(-minAge);
            DateTime startDate = DateTime.Today.AddYears(-maxAge - 1); // Subtract one year to include patients whose age is exactly maxAge

            // Retrieve the PrescriptionAnalytics records and filter them based on the patient's birthdate
            return await _context.PrescriptionAnalytics
                .Where(pa => _context.Patients.Any(p => p.PatientId == pa.PatientId && p.DateOfBirth >= startDate && p.DateOfBirth <= endDate))
                .ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByQuantityRangeAsync(int minQuantity, int maxQuantity)
        {
            return await _context.PrescriptionAnalytics.Where(pa => pa.Quantity >= minQuantity && pa.Quantity <= maxQuantity).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionAnalytic>> GetByTotalCostRangeAsync(decimal minCost, decimal maxCost)
        {
            return await _context.PrescriptionAnalytics.Where(pa => pa.TotalCost >= minCost && pa.TotalCost <= maxCost).ToListAsync();
        }
        public async Task<IEnumerable<PrescriptionAnalytic>> GetAllAsync()
        {
            return await _context.PrescriptionAnalytics.ToListAsync();
        }

        public async Task<PrescriptionAnalytic> GetByIdAsync(int id)
        {
            return await _context.PrescriptionAnalytics.FindAsync(id);
        }

        public async Task<PrescriptionAnalytic> AddAsync(PrescriptionAnalytic entity)
        {
            _context.PrescriptionAnalytics.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(int id, PrescriptionAnalytic entity)
        {
            var existingEntity = await _context.PrescriptionAnalytics.FindAsync(id);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PrescriptionAnalytics.FindAsync(id);
            if (entity == null)
                return false;

            _context.PrescriptionAnalytics.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
