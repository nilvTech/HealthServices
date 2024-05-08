using Microsoft.EntityFrameworkCore;
using PatientServices.Models.Provider;
using PatientServices.Repositories.Interfaces;

namespace PatientServices.Repositories
{
    public class ProviderRepository: IProviderRepository
    {
        private readonly DbContext _context;

        public ProviderRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Provider>> GetProvidersAsync()
        {
            return await _context.Set<Provider>().ToListAsync();
        }

        public async Task<Provider> GetProviderByIdAsync(int id)
        {
            return await _context.Set<Provider>().FindAsync(id);
        }

        public async Task<int> AddProviderAsync(Provider provider)
        {
            _context.Set<Provider>().Add(provider);
            await _context.SaveChangesAsync();
            return provider.ProviderId;
        }

        public async Task UpdateProviderAsync(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProviderAsync(int id)
        {
            var provider = await _context.Set<Provider>().FindAsync(id);
            if (provider != null)
            {
                _context.Set<Provider>().Remove(provider);
                await _context.SaveChangesAsync();
            }
        }

        public bool ProviderExists(int id)
        {
            return _context.Set<Provider>().Any(e => e.ProviderId == id);
        }
    }
}
