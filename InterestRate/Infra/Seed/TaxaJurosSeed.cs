using InterestRate.Domain.Base;
using InterestRate.Infra.Contexts;
using InterestRate.Infra.CrossCutting;

namespace InterestRate.Infra.Seed
{
    public class TaxaJurosSeed
    {
        private readonly DataContext _dataContext;

        public TaxaJurosSeed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Execute()
        {
            var taxaJuros = new TaxaJurosBase(TaxaJurosContants.ValorTaxaJuros);
            _dataContext.TaxaJuros.Add(taxaJuros);

            _dataContext.SaveChanges();
        }
    }
}
