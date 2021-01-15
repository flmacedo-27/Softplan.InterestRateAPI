namespace InterestRate.Domain.Entities
{
    public class TaxaJuros
    {
        public TaxaJuros()
        {
        }

        public TaxaJuros(decimal valor)
        {
            setValor(valor);
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }

        private void setValor(decimal valor) => Valor = valor;
    }
}
