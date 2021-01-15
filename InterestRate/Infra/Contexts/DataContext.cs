using InterestRate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterestRate.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TaxaJuros> TaxaJuros { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
