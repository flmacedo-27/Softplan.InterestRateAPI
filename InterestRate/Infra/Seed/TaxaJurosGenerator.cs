using InterestRate.Domain.Entities;
using InterestRate.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterestRate.Infra.Seed
{
    public class TaxaJurosGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (context.TaxaJuros.Any())
                {
                    return;
                }

                context.TaxaJuros.AddRange(
                    new TaxaJuros
                    {
                        Id = 1,
                        Valor = 0.01M
                    });

                context.SaveChanges();
            }
        }
    }
}
