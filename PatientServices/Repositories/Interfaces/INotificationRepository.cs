using PatientServices.Models;
using PatientServices.Models.Patient;

namespace PatientServices.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetNotificationsAsync();
        Task<Notification> GetNotificationByIdAsync(int id);
        Task<int> AddNotificationAsync(Notification notification);
        Task UpdateNotificationAsync(Notification notification);
        Task DeleteNotificationAsync(int id);
        bool NotificationExists(int id);
        Task<bool> SendNotificationAsync(NotificationRequest notificationRequest);
    }
}