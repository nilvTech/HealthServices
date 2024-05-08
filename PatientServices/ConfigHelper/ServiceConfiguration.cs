

using PatientServices.Repositories;
using PatientServices.Repositories.Interfaces;
using PatientServices.Services;
using PatientServices.Services.Interfaces;

namespace PatientServices.ConfigHelper
{
    public static class ServiceConfiguration
    {
        public static void RegisterAppServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IProviderService, ProviderService>();
            builder.Services.AddTransient<IPatientService, PatientService>();
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IMedicalRecordService, MedicalRecordService>();

            builder.Services.AddTransient<IMedicalRecordRepository, MedicalRecordRepository>();
            builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
            builder.Services.AddTransient<IPatientRepository, PatientRepository>();
            builder.Services.AddTransient<IProviderRepository, ProviderRepository>();

        }
    }
}
