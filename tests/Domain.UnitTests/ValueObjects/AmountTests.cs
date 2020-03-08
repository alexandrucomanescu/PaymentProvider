using PaymentProvider.Domain.Exceptions;
using PaymentProvider.Domain.Exceptions.InvalidExceptions;
using PaymentProvider.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace Domain.UnitTests.ValueObjects
{
    public class AmountTests
    {

        [Fact]
        public void ShouldHaveCorrectValue()
        {
            const decimal value = 123;

            var amount = Amount.For(value);

            amount.Value.ShouldBe(value);
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const decimal value = 123;
            const string valueString = "123";

            var amount = Amount.For(value);

            var result = amount.ToString();

            result.ShouldBe(valueString);
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const decimal value = 123;
            const string valueString = "123";

            var amount = Amount.For(value);

            string result = amount;

            result.ShouldBe(valueString);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            const decimal value = 123;

            var amount = Amount.For(value);

            amount.Value.ShouldBe(value);
        }

        [Fact]
        public void ShouldThrowSecurityCodeInvalidExceptionForCodeLessThan3Chars()
        {
            Assert.Throws<AmountInvalidException>(() => (Amount)(-5));
        }
    }
}
