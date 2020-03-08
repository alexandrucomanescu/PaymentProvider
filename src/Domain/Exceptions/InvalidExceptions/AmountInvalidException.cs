using System;

namespace PaymentProvider.Domain.Exceptions.InvalidExceptions
{
    public class AmountInvalidException : Exception, InvalidException
    {
        public AmountInvalidException(decimal value, Exception ex)
            : base($"Amount of \"{value}\" is invalid.", ex)
        {
        }
    }
}
