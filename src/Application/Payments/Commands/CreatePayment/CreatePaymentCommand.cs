using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PaymentProvider.Application.Common.Interfaces;
using PaymentProvider.Domain.Entities;
using PaymentProvider.Domain.Enums;
using PaymentProvider.Domain.ValueObjects;

namespace PaymentProvider.Application.Payments.Commands.CreatePayment
{
    public partial class CreatePaymentCommand : IRequest
    {
        public string CreditCardNumber { get; set; }

        public string CardHolder { get; set; }

        public string SecurityCode { get; set; }

        public decimal Amount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IDateTime _dateTime;
            public CreatePaymentCommandHandler(IApplicationDbContext context, IDateTime dateTime)
            {
                _context = context;
                _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            }

            public async Task<Unit> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Payment
                {
                    Id = new Guid(),
                    CreditCardNumber = (CreditCardNumber) request.CreditCardNumber,
                    CardHolder = request.CardHolder,
                    SecurityCode = (SecurityCode) request.SecurityCode,
                    Amount = (Amount) request.Amount,
                    ExpirationDate = request.ExpirationDate,
                    Created = _dateTime.Now
                };

                var entityState = new PaymentState
                {
                    Id = new Guid(),
                    PaymentId = entity.Id,
                    Created = _dateTime.Now,
                    Status = PaymentStatus.Pending
                };

                entityState.PaymentId = entity.Id;

                _context.Payments.Add(entity);
                _context.PaymentStates.Add(entityState);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
