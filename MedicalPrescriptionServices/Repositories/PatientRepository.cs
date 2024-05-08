using Microsoft.EntityFrameworkCore;
using MedicalPrescriptionServices.Models.Patient;
using MedicalPrescriptionServices;
using MedicalPrescriptionServices.Repositories.Interfaces;

namespace MedicalPrescriptionServices.Repositories
{
    public class PatientRepository:IPatientRepository
    {
        private readonly PrescriptionDbContext _context;

        public PatientRepository(PrescriptionDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient.PatientId;
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
        public async Task<Patient> GetPatientByNameAsync(string name)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.FirstName == name);
        }

        public bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}
