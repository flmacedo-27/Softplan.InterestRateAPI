using InterestRate.Domain.Entities;
using InterestRate.Domain.Exceptions;
using InterestRate.Infra.Contexts;
using InterestRate.Infra.CrossCutting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InterestRate.Infra.Repository
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        private readonly DataContext _context;

        public TaxaJurosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TaxaJuros> GetTaxaJuros()
        {
            try
            {
                var taxaJuros = new TaxaJuros(TaxaJurosContants.ValorTaxaJuros);

                return await Task.FromResult(taxaJuros);

                //Usando um banco de dados In-Memory
                //return await _context.TaxaJuros.SingleAsync();
            }
            catch (Exception)
            {
                throw new TaxaJurosException("Não foi possível recuperar a informação. Possível causa:\r\n -A conexão com a base de dados não foi estabelecida.");
            }
        }
    }
}
