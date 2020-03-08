using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProvider.Application.Payments.Queries.GetPayments
{
    public class PaymentsVm
    {
        public IList<PaymentDto> Payments { get; set; }
    }
}
