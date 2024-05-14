using PatientServices.Models;
using PatientServices.Models.Patient;
using PatientServices.Repositories.Interfaces;
using PatientServices.Services.Interfaces;

namespace PatientServices.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task<IEnumerable<Notification>> GetNotificationsAsync()
        {
            return _notificationRepository.GetNotificationsAsync();
        }

        public Task<Notification> GetNotificationByIdAsync(int id)
        {
            return _notificationRepository.GetNotificationByIdAsync(id);
        }

        public Task<int> AddNotificationAsync(Notification notification)
        {
            return _notificationRepository.AddNotificationAsync(notification);
        }

        public Task UpdateNotificationAsync(Notification notification)
        {
            return _notificationRepository.UpdateNotificationAsync(notification);
        }

        public Task DeleteNotificationAsync(int id)
        {
            return _notificationRepository.DeleteNotificationAsync(id);
        }

        public bool NotificationExists(int id)
        {
            return _notificationRepository.NotificationExists(id);
        }
        public async Task<bool> SendNotificationToPatientAsync(NotificationRequest notificationRequest)
        {
            return await _notificationRepository.SendNotificationAsync(notificationRequest);
        }
    }
}
