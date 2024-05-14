using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Models.Patient;
using MedicalPrescription.Models;

namespace MedicalPrescriptionServices
{
    public class PrescriptionDbContext : IdentityDbContext
    {
        public PrescriptionDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<PrescriptionHistory> PrescriptionHistories { get; set; }
        public DbSet<PrescriptionValidation> PrescriptionValidations { get; set; }
        public DbSet<DrugInteraction> DrugInteractions { get; set; }
        public DbSet<PrescriptionAnalytic> PrescriptionAnalytics { get; set; }




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
                .HasForeignKey(m => m.PrescriptionId);

            modelBuilder.Entity<PrescriptionValidation>()
                .HasOne<Prescription>()
                .WithMany()
                .HasForeignKey(m => m.PrescriptionId);

            modelBuilder.Entity<PrescriptionValidation>()
                .HasOne<Specialist>()
                .WithMany()
                .HasForeignKey(m => m.SpecialistId);

            modelBuilder.Entity<DrugInteraction>()
                .HasOne<Medication>()
                .WithMany()
                .HasForeignKey(m => m.MedicationId);

            modelBuilder.Entity<PrescriptionAnalytic>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(m => m.PatientId);

            modelBuilder.Entity<PrescriptionAnalytic>()
                .HasOne<DrugInteraction>()
                .WithMany()
                .HasForeignKey(m => m.DrugInteractionId);
        }




    }
}
