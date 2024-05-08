using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Models.Patient;

namespace MedicalPrescriptionServices
{
    public class PrescriptionDbContext : IdentityDbContext
    {
        public PrescriptionDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<PrescriptionHistory> PrescriptionHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Prescription>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(m => m.PatientId);

            modelBuilder.Entity<PrescriptionHistory>()
                .HasOne<Prescription>()
                .WithMany()
                .HasForeignKey(n => n.Id);
        }
    }
}
