using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PaymentProvider.Application.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
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
