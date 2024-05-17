using AppointmentServices.Models;
using System.Collections.Generic;

namespace AppointmentServices.Repositories.IRepository
{
    public interface IAppointmentSchedulingRepository
    {
        void CreateAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
    }
}
