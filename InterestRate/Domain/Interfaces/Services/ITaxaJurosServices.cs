using InterestRate.Domain.Entities;
using System.Threading.Tasks;

namespace InterestRate.Domain.Interfaces
{
    public interface ITaxaJurosServices
    {
        Task<TaxaJuros> GetTaxaJuros();
    }
}
