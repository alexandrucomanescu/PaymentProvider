using System.Collections.Generic;
using PaymentProvider.Domain.Common;
using PaymentProvider.Domain.Exceptions;

namespace PaymentProvider.Domain.ValueObjects
{
    public class Amount : ValueObject
    {
        public decimal Value { get; private set; }

        private Amount() { }

        public static Amount For(decimal value)
        {
            var amount = new Amount();

            if (value <= 0)
            {
                throw new AmountInvalidException(value, null);
            }

            amount.Value = value;
            return amount;
        }


        public static implicit operator string(Amount amount)
        {
            return amount.ToString();
        }

        public static explicit operator Amount(decimal value)
        {
            return For(value);
        }
        public override string ToString()
        {
            return $"{Value}";
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}

