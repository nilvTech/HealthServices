using AppointmentServices.Models;

namespace AppointmentServices.Repositories.IRepository
{
    public interface IAppointmentSchedulingRepository
    {
        void CreateAppointment(Appointment appointment);
    }
}
