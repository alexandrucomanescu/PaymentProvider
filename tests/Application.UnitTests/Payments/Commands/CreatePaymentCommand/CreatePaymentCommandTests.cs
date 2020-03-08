using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using PaymentProvider.Application.Common.Interfaces;
using PaymentProvider.Domain.Enums;
using Shouldly;
using Xunit;

namespace PaymentProvider.Application.UnitTests.Payments.Commands.CreatePaymentCommand
{
    public class CreatePaymentCommandTests : CommandTestBase
    {
        [Fact]
        public async Task Handle_ShouldPersistPayment()
        {
            var command = new Application.Payments.Commands.CreatePayment.CreatePaymentCommand
            {
                Amount = 80,
                ExpirationDate = DateTime.Today,
                CardHolder = "test",
                SecurityCode = "123",
                CreditCardNumber = "379354508162306"
            };

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var handler = new Application.Payments.Commands.CreatePayment.CreatePaymentCommand.CreatePaymentCommandHandler(Context, dateTimeMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Payments.First();
            entity.ShouldNotBeNull();
            entity.Amount.ToString().ShouldBe(command.Amount.ToString(CultureInfo.InvariantCulture));
            //entity.SecurityCode.ToString().ShouldBe(command.SecurityCode);
            entity.CreditCardNumber.ToString().ShouldBe(command.CreditCardNumber);
            entity.ExpirationDate.ShouldBe(command.ExpirationDate);
        }

        [Fact]
        public async Task Handle_ShouldPersistPaymentState()
        {
            var command = new Application.Payments.Commands.CreatePayment.CreatePaymentCommand
            {
                Amount = 80,
                ExpirationDate = DateTime.Today,
                CardHolder = "test",
                SecurityCode = "123",
                CreditCardNumber = "379354508162306"
            };

            var dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now)
                .Returns(new DateTime(3001, 1, 1));

            var handler = new Application.Payments.Commands.CreatePayment.CreatePaymentCommand.CreatePaymentCommandHandler(Context, dateTimeMock.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            var entity = Context.Payments.First();

            var paymentState = Context.PaymentStates.First();
            paymentState.ShouldNotBeNull();
            paymentState.PaymentId.ShouldBe(entity.Id.ToString());
            paymentState.Status.ShouldBe(PaymentStatus.Pending);
        }
    }
}
