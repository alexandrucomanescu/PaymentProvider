using System;

namespace PaymentProvider.Domain.Exceptions
{
    public class SecurityCodeInvalidException : Exception
    {
        public SecurityCodeInvalidException(string code, Exception ex)
            : base($"Security code \"{code}\" is invalid.", ex)
        {
        }
    }
}
