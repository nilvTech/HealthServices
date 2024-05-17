using AppointmentServices.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentService
{
    void CreateAppointment(Appointment appointment);
    Task CreateAppointmentAsync(Appointment appointment);
    List<Appointment> GetAllAppointments();
    Appointment GetAppointmentById(int id);
}
