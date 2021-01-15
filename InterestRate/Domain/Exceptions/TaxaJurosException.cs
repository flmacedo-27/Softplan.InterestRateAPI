using System;

namespace InterestRate.Domain.Exceptions
{
    public class TaxaJurosException : Exception
    {
        public TaxaJurosException(string message) : base(message) { }
    }
}
