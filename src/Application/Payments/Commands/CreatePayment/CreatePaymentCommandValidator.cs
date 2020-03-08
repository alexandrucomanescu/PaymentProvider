using FluentValidation;
using PaymentProvider.Application.Common.Interfaces;

namespace PaymentProvider.Application.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTimeService;

        public CreatePaymentCommandValidator(IApplicationDbContext context, IDateTime dateTimeService)
        {
            _context = context;
            _dateTimeService = dateTimeService;
            RuleFor(v => v.Amount)
                .NotEmpty();

            RuleFor(v => v.CardHolder)
                .NotEmpty();

            RuleFor(v => v.CreditCardNumber)
                .NotEmpty();

            RuleFor(v => v.ExpirationDate)
                .NotEmpty()
                .GreaterThan(dateTimeService.Now);

        }
    }
}
