using AppointmentServices.Context;
using AppointmentServices.Models;
using AppointmentServices.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentServices.Repositories
{
    public class AppointmentSchedulingRepository : IAppointmentSchedulingRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentSchedulingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
        }
    }
}
