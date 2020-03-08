using FluentValidation;
using PaymentProvider.Application.Common.Interfaces;

namespace PaymentProvider.Application.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePaymentCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Amount)
                .NotEmpty();

            RuleFor(v => v.CardHolder)
                .NotEmpty();

            RuleFor(v => v.CreditCardNumber)
                .NotEmpty();

            RuleFor(v => v.ExpirationDate)
                .NotEmpty();

        }
    }
}
