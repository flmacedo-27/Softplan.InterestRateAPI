using InterestRate.Domain.Entities;
using InterestRate.Infra.Repository;
using InterestRate.Services;
using InterestRate.Tests.Mocks;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace InterestRate.Tests.Services
{
    public class TaxaJurosTests
    {
        private const decimal Valor = 0.01M;
        private Mock<ITaxaJurosRepository> mockTaxaJurosRepository = new Mock<ITaxaJurosRepository>();
        private Mock<IMemoryCache> mockMemoryCache;

        public TaxaJurosTests()
        {
            mockMemoryCache = MockDefault.MockedMemoryCache();
        }

        [Fact]
        public async void Validar_Retorno_TaxaJuros()
        {
            mockTaxaJurosRepository.Setup(x => x.GetTaxaJuros()).Returns(Task.FromResult(new TaxaJuros()));
            TaxaJurosServices taxaJurosServices = new TaxaJurosServices(mockTaxaJurosRepository.Object, mockMemoryCache.Object);
            
            await taxaJurosServices.GetTaxaJuros();

            mockTaxaJurosRepository.Verify(mock => mock.GetTaxaJuros(), Times.Once());
        }
    }
}
