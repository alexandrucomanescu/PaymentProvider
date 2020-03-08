using System;
using PaymentProvider.Application.Common.Interfaces;
using PaymentProvider.Domain.Entities;

namespace PaymentProvider.Infrastructure.Services
{
    public class PremiumPaymentService : IPremiumPaymentService
    {
        public bool Process()
        {
            var rand = new Random();
            return rand.NextDouble() > 0.5;
        }
    }
}
