using System;
using System.Collections.Generic;
using System.Linq;
using PaymentProvider.Domain.Common;
using PaymentProvider.Domain.Exceptions;
using PaymentProvider.Domain.Exceptions.InvalidExceptions;

namespace PaymentProvider.Domain.ValueObjects
{
    public class CreditCardNumber : ValueObject
    {
        static Func<char, int> charToInt = c => c - '0';

        static Func<int, int> doubleDigit = n => (n * 2).ToString().Select(charToInt).Sum();

        static Func<int, bool> isOddIndex = index => index % 2 == 0;

        public static bool LuhnCheck(string creditCardNumber)
        {
            var checkSum = creditCardNumber
                .Select(charToInt)
                .Reverse()
                .Select((digit, index) => isOddIndex(index) ? digit : doubleDigit(digit))
                .Sum();

            return checkSum % 10 == 0;
        }

        private CreditCardNumber()
        {

        }

        public static CreditCardNumber For(string cardNumber)
        {
            var creditCardNumber = new CreditCardNumber();

            bool isValid;
            try
            {
                isValid = LuhnCheck(cardNumber);
                creditCardNumber.Number = cardNumber;
            }
            catch (Exception ex)
            {
                throw new CreditCardNumberInvalidException(cardNumber, ex);
            }

            return isValid ? creditCardNumber : throw new CreditCardNumberInvalidException(cardNumber, null);
        }

        public string Number { get; private set; }

        public static implicit operator string(CreditCardNumber cardNumber)
        {
            return cardNumber.ToString();
        }

        public static explicit operator CreditCardNumber(string cardNumber)
        {
            return For(cardNumber);
        }
        public override string ToString()
        {
            return $"{Number}";
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
        }
    }
}
