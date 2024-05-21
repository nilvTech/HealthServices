using PatientSatisfactionFeedback.Models;
using System.Collections.Generic;

namespace PatientSatisfactionFeedback.Repositories.IRepository
{
    public interface IAppointmentSchedulingRepository
    {
        void CreateAppointment(Appointment appointment);
        List<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
    }
}
