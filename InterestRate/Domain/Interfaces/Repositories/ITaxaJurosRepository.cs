using InterestRate.Domain.Entities;
using System.Threading.Tasks;

namespace InterestRate.Infra.Repository
{
    public interface ITaxaJurosRepository
    {
        Task<TaxaJuros> GetTaxaJuros();
    }
}
