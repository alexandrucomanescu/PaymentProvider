using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PaymentProvider.Application.Common.Mappings;
using PaymentProvider.Domain.Entities;
using PaymentProvider.Domain.ValueObjects;

namespace PaymentProvider.Application.Payments.Queries.GetPayments
{
    public class PaymentDto : IMapFrom<Payment>
    {
        public CreditCardNumber CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public SecurityCode SecurityCode { get; set; }

        public Amount Amount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public PaymentState PaymentState { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payment, PaymentDto>();
        }
    }
}
