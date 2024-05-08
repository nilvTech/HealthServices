using PatientServices.Models.Provider;

namespace PatientServices.Repositories.Interfaces
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> GetProvidersAsync();
        Task<Provider> GetProviderByIdAsync(int id);
        Task<int> AddProviderAsync(Provider provider);
        Task UpdateProviderAsync(Provider provider);
        Task DeleteProviderAsync(int id);
        bool ProviderExists(int id);
    }
}