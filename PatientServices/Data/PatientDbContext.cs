using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientServices.Models.Patient;
using PatientServices.Models.Provider;

namespace HealthServices.Data
{
    public class PatientDbContext : IdentityDbContext
    {
        public PatientDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Notification> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicalRecord>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(m => m.PatientId);

            modelBuilder.Entity<Notification>()
                .HasOne<Patient>()
                .WithMany()
                .HasForeignKey(n => n.PatientId);
        }
    }
}
