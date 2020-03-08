using System;
using PaymentProvider.Domain.Common;

namespace PaymentProvider.Domain.Entities
{
    public class Payment : AuditableEntity
    {
        public long Id { get; set; }

        public string CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
