using InterestRate.Domain.Entities;
using InterestRate.Domain.Interfaces;
using InterestRate.Infra.Repository;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace InterestRate.Services
{
    public class TaxaJurosServices : ITaxaJurosServices
    {
        const string key = "TaxaJuros";
        private readonly ITaxaJurosRepository _repository;
        private readonly IMemoryCache _cache;

        public TaxaJurosServices(ITaxaJurosRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public async Task<TaxaJuros> GetTaxaJuros()
        {
            var result = await _repository.GetTaxaJuros();
            if (result != null)
                _cache.Set(key, result);

            return result;
        }
    }
}
