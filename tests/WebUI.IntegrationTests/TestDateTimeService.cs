using PaymentProvider.Application.Common.Interfaces;
using System;

namespace PaymentProvider.WebUI.IntegrationTests
{
    public class TestDateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
