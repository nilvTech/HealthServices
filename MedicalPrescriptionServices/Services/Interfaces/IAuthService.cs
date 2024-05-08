using MedicalPrescriptionServices.Models.Authentication;

namespace MedicalPrescriptionServices.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(LoginUser user);
        Task<bool> LoginUser(LoginUser user);
        string GenerateTokenString(LoginUser user);
    }
}