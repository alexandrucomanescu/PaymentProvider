using System;
using System.Collections.Generic;
using System.Text;
using PaymentProvider.Domain.Entities;

namespace PaymentProvider.Application.Common.Interfaces
{
    public interface IPaymentGateway
    {
        bool Process();
    }
}
