using System;
using PaymentProvider.Application.Payments.Commands.CreatePayment;
using Shouldly;
using Xunit;

namespace PaymentProvider.Application.UnitTests.Payments.Commands
{
    public class CreatePaymentCommandValidatorTests : CommandTestBase 
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenAllParametersAreCorrect()
        {
            var command = new CreatePaymentCommand
            {
                Amount = 30,
                SecurityCode = "123",
                ExpirationDate = DateTime.Today,
                CardHolder = "test",
                CreditCardNumber = "379354508162306"
            };

            var validator = new CreatePaymentCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenMissingMandatoryFields()
        {
            var command = new CreatePaymentCommand
            {
                Amount = 30,
                ExpirationDate = DateTime.Today,
                CardHolder = "test",
            };

            var validator = new CreatePaymentCommandValidator(Context);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
