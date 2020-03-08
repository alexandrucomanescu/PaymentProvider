using PaymentProvider.Domain.Exceptions;
using PaymentProvider.Domain.Exceptions.InvalidExceptions;
using PaymentProvider.Domain.ValueObjects;
using Shouldly;
using Xunit;

namespace Domain.UnitTests.ValueObjects
{
    public class SecurityCodeTests
    {

        [Fact]
        public void ShouldHaveCorrectCode()
        {
            const string code = "123";

            var securityCode = SecurityCode.For(code);

            securityCode.Code.ShouldBe(code);
        }

        [Fact]
        public void ToStringReturnsCorrectFormat()
        {
            const string code = "123";

            var securityCode = SecurityCode.For(code);

            var result = securityCode.ToString();

            result.ShouldBe(code);
        }

        [Fact]
        public void ImplicitConversionToStringResultsInCorrectString()
        {
            const string code = "123";

            var securityCode = SecurityCode.For(code);

            string result = securityCode;

            result.ShouldBe(code);
        }

        [Fact]
        public void ExplicitConversionFromStringSetsDomainAndName()
        {
            const string code = "123";

            var securityCode = (SecurityCode)code;

            securityCode.Code.ShouldBe(code);
        }

        [Fact]
        public void ShouldThrowSecurityCodeInvalidExceptionForCodeLessThan3Chars()
        {
            Assert.Throws<SecurityCodeInvalidException>(() => (SecurityCode)"1");
        }

        [Fact]
        public void ShouldThrowSecurityCodeInvalidExceptionForCodeMoreThan3Chars()
        {
            Assert.Throws<SecurityCodeInvalidException>(() => (SecurityCode)"1234");
        }

        [Fact]
        public void ShouldThrowSecurityCodeInvalidExceptionForCodeAlphanumeric()
        {
            Assert.Throws<SecurityCodeInvalidException>(() => (SecurityCode)"a23");
        }
    }
}
