using System;
using System.Collections.Generic;
using System.Text;
using PaymentProvider.Domain.Enums;

namespace PaymentProvider.Domain.Entities
{
    public class PaymentState
    {
        public long Id { get; set; }

        public PaymentStatus Status { get; set; }
        
        public Payment Payment { get; set; }
    }
}
