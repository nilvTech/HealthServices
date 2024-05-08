using PatientServices.Models.Authentication;

namespace PatientServices.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(LoginUser user);
        Task<bool> LoginUser(LoginUser user);
        string GenerateTokenString(LoginUser user);
    }
}