// Context/ApplicationDbContext.cs
using AppointmentServices.Models;
using AppointmentServices.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentServices.Context
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
