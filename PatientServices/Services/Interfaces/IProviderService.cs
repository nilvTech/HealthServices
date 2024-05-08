using PatientServices.Models.Provider;

namespace PatientServices.Services.Interfaces
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetProvidersAsync();
        Task<Provider> GetProviderByIdAsync(int id);
        Task<int> AddProviderAsync(Provider provider);
        Task UpdateProviderAsync(Provider provider);
        Task DeleteProviderAsync(int id);
        bool ProviderExists(int id);
    }
}