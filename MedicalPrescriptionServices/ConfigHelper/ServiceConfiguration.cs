using MedicalPrescriptionServices.Models;
using MedicalPrescriptionServices.Repositories;
using MedicalPrescriptionServices.Repositories.Interfaces;
using MedicalPrescriptionServices.Services;
using MedicalPrescriptionServices.Services.Interfaces;

namespace MedicalPrescriptionServices.ConfigHelper
{
    public static class ServiceConfiguration
    {
        public static void RegisterAppServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IMedicationService, MedicationService>();
            builder.Services.AddTransient<IPatientService, PatientService>();
            builder.Services.AddTransient<IPrescriptionService, PrescriptionService>();
            builder.Services.AddTransient<IPrescriptionHistoryService, PrescriptionHistoryService>();
            builder.Services.AddTransient<IDrugInteractionService, DrugInteractionService>();
            builder.Services.AddTransient<IPrescriptionAnalyticService, PrescriptionAnalyticService>();

            builder.Services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();
            builder.Services.AddTransient<IMedicationRepository, MedicationRepository>();
            builder.Services.AddTransient<IPatientRepository, PatientRepository>();
            builder.Services.AddTransient<IDrugInteractionRepository, DrugInteractionRepository>();
            builder.Services.AddTransient<IPrescriptionHistoryRepository, PrescriptionHistoryRepository>();
            builder.Services.AddTransient<IPrescriptionAnalyticRepository, PrescriptionAnalyticRepository>();

        }
    }
}
