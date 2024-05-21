using PatientSatisfactionFeedback.Models;
using Microsoft.EntityFrameworkCore;
using PatientSatisfactionFeedback.Models;

namespace PatientSatisfactionFeedback.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
            
        public DbSet<PatientSatisfaction> PatientSatisfactions { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
