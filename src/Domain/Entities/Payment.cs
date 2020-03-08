using System;
using PaymentProvider.Domain.Common;
using PaymentProvider.Domain.Enums;
using PaymentProvider.Domain.ValueObjects;

namespace PaymentProvider.Domain.Entities
{
    public class Payment : AuditableEntity
    {
        public Guid Id { get; set; }

        public CreditCardNumber CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public SecurityCode SecurityCode { get; set; }

        public Amount Amount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public PaymentState PaymentState { get; set; }
    }
}
