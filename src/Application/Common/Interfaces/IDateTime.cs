using System;

namespace PaymentProvider.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
