using System;

namespace PaymentProvider.Domain.Exceptions.InvalidExceptions
{
    public class CreditCardNumberInvalidException : Exception, InvalidException
    {
        public CreditCardNumberInvalidException(string cardNumber, Exception ex)
            : base($"Card number \"{cardNumber}\" is invalid.", ex)
        {
        }
    }
}