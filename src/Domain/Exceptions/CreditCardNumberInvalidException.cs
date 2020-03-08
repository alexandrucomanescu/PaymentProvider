using System;

namespace PaymentProvider.Domain.Exceptions
{
    public class CreditCardNumberInvalidException : Exception
    {
        public CreditCardNumberInvalidException(string cardNumber, Exception ex)
            : base($"Card number \"{cardNumber}\" is invalid.", ex)
        {
        }
    }
}