using PatientServices.Models.Provider;
using PatientServices.Repositories.Interfaces;
using PatientServices.Services.Interfaces;

namespace PatientServices.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public Task<IEnumerable<Provider>> GetProvidersAsync()
        {
            return _providerRepository.GetProvidersAsync();
        }

        public Task<Provider> GetProviderByIdAsync(int id)
        {
            return _providerRepository.GetProviderByIdAsync(id);
        }

        public Task<int> AddProviderAsync(Provider provider)
        {
            return _providerRepository.AddProviderAsync(provider);
        }

        public Task UpdateProviderAsync(Provider provider)
        {
            return _providerRepository.UpdateProviderAsync(provider);
        }

        public Task DeleteProviderAsync(int id)
        {
            return _providerRepository.DeleteProviderAsync(id);
        }

        public bool ProviderExists(int id)
        {
            return _providerRepository.ProviderExists(id);
        }
    }
}
