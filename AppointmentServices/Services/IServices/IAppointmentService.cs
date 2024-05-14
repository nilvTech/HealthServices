using AppointmentServices.Models;

namespace AppointmentServices.Services
{
    public interface IAppointmentService
    {
        void CreateAppointment(Appointment appointment);
    }
}
