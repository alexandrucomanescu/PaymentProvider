using System;
using Moq;
using PaymentProvider.Application.Common.Interfaces;
using PaymentProvider.Application.Payments.Commands.CreatePayment;
using Shouldly;
using Xunit;

namespace PaymentProvider.Application.UnitTests.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentCommandValidatorTests : CommandTestBase 
    {
        [Fact]
        public void IsValid_ShouldBeTrue_WhenAllParametersAreCorrect()
        {
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(2001, 1, 1));

            var command = new Application.Payments.Commands.CreatePayment.CreatePaymentCommand
            {
                Amount = 30,
                SecurityCode = "123",
                ExpirationDate = DateTime.Today,
                CardHolder = "test",
                CreditCardNumber = "379354508162306"
            };
          

            var validator = new CreatePaymentCommandValidator(Context, dateTimeMock.Object);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenMissingMandatoryFields()
        {
            var command = new Application.Payments.Commands.CreatePayment.CreatePaymentCommand
            {
                Amount = 30,
                ExpirationDate = DateTime.Today,
                CardHolder = "test",
            };
            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var validator = new CreatePaymentCommandValidator(Context, dateTimeMock.Object);

            var result = validator.Validate(command);

            result.IsValid.ShouldBe(false);
        }
    }
}
