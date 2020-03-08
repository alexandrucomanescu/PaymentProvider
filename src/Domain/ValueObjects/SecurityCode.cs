using System;
using System.Collections.Generic;
using PaymentProvider.Domain.Common;
using PaymentProvider.Domain.Exceptions;

namespace PaymentProvider.Domain.ValueObjects
{
    public class SecurityCode : ValueObject
    {
        public string Code { get; private set; }

        private SecurityCode()
        {

        }

        public static SecurityCode For(string code)
        {
            var securityCode = new SecurityCode();

            try
            {
                if (code.Length != 3 || !int.TryParse(code, out _))
                {
                    throw new SecurityCodeInvalidException(code, null);
                }

                securityCode.Code = code;
            }
            catch (Exception ex)
            {
                throw new SecurityCodeInvalidException(code, ex);
            }

            return securityCode;
        }


        public static implicit operator string(SecurityCode code)
        {
            return code.ToString();
        }

        public static explicit operator SecurityCode(string code)
        {
            return For(code);
        }
        public override string ToString()
        {
            return $"{Code}";
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
        }
    }
}