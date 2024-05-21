// Context/ApplicationDbContext.cs
using PatientSatisfactionFeedback.Models;
using PatientSatisfactionFeedback.Models;
using Microsoft.EntityFrameworkCore;

namespace PatientSatisfactionFeedback.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
            
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
