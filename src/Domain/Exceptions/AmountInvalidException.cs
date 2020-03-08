using System;

namespace PaymentProvider.Domain.Exceptions
{
    public class AmountInvalidException : Exception
    {
        public AmountInvalidException(decimal value, Exception ex)
            : base($"Amount of \"{value}\" is invalid.", ex)
        {
        }
    }
}
