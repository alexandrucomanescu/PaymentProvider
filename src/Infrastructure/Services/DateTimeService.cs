using PaymentProvider.Application.Common.Interfaces;
using System;

namespace PaymentProvider.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
