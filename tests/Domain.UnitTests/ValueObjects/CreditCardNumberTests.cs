using PaymentProvider.Domain.Exceptions;
using PaymentProvider.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace Domain.UnitTests.ValueObjects
    {
        public class CreditCardNumberTests
        {
            [Fact]
            public void ShouldHaveCorrectCardNumber()
            {
                const string cardNumber = "379354508162306";

                var creditCardNumber = CreditCardNumber.For(cardNumber);

                creditCardNumber.Number.ShouldBe(cardNumber);
            }

            [Fact]
            public void ToStringReturnsCorrectFormat()
            {
                const string cardNumber = "379354508162306";

                var creditCardNumber = CreditCardNumber.For(cardNumber);

                var result = creditCardNumber.ToString();

                result.ShouldBe(cardNumber);
            }

            [Fact]
            public void ImplicitConversionToStringResultsInCorrectString()
            {
                const string cardNumber = "379354508162306";

                var creditCardNumber = CreditCardNumber.For(cardNumber);

                string result = creditCardNumber;

                result.ShouldBe(cardNumber);
            }

            [Fact]
            public void ExplicitConversionFromStringSetsDomainAndName()
            {
                const string cardNumber = "379354508162306";

                var creditCardNumber = (CreditCardNumber)cardNumber;

                creditCardNumber.Number.ShouldBe(cardNumber);
            }

            [Fact]
            public void ShouldThrowCreditCardNumberInvalidExceptionForInvalidCreditCard()
            {
                Assert.Throws<CreditCardNumberInvalidException>(() => (CreditCardNumber)"failed");
            }
        }
    }


