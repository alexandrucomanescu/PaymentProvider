using System;

namespace PaymentProvider.Domain.Exceptions.InvalidExceptions
{
    public class SecurityCodeInvalidException : Exception, InvalidException
    {
        public SecurityCodeInvalidException(string code, Exception ex)
            : base($"Security code \"{code}\" is invalid.", ex)
        {
        }
    }
}
