using AppointmentServices.Context;
using AppointmentServices.Models;
using AppointmentServices.Repositories.IRepository;

namespace AppointmentServices.Repositories
{
    public class AppointmentSchedulingRespository : IAppointmentSchedulingRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentSchedulingRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }
    }
}
