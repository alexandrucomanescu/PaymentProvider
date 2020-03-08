﻿using System;
using PaymentProvider.Domain.Common;
using PaymentProvider.Domain.Enums;

namespace PaymentProvider.Domain.Entities
{
    public class PaymentState :AuditableEntity
    {
        public Guid Id { get; set; }

        public PaymentStatus Status { get; set; }
        
        public Guid PaymentId { get; set; }
    }
}
