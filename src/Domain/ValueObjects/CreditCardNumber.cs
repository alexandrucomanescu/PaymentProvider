using System.Collections.Generic;
using PaymentProvider.Domain.Common;

namespace PaymentProvider.Domain.ValueObjects
{
    public class CreditCardNumber : ValueObject
    {
        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new System.NotImplementedException();
        }
    }
}
