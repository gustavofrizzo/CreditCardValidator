using CreditCardValidator.Helpers;
using System;
using System.Linq;

namespace CreditCardValidator
{
    public static class Luhn
    {
        //Convert to int
        private static Func<char, int> charToInt = c => c - '0';

        private static Func<int, bool> isEven = i => i % 2 == 0;

        //New Double Concept => 7 * 2 = 14 => 1 + 4 = 5
        private static Func<int, int> doubleDigit = i => (i * 2).ToString().ToCharArray().Select(charToInt).Sum();

        /// <summary>
        /// Verify if the card number is valid.
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns></returns>
        public static bool CheckLuhn(String creditCardNumber)
        {
            if (!ValidationHelper.IsAValidNumber(creditCardNumber))
                throw new ArgumentException("Invalid number. Just numbers and white spaces are accepted on the string.");

            var checkSum = creditCardNumber
                .RemoveWhiteSpace()
                .ToCharArray()
                .Select(charToInt)
                .Reverse()
                .Select((digit, index) => isEven(index + 1) ? doubleDigit(digit) : digit)
                .Sum();

            return checkSum % 10 == 0;
        }

        public static String CreateCheckDigit(String number)
        {
            if (!ValidationHelper.IsAValidNumber(number))
                throw new ArgumentException("Invalid number. Just numbers and white spaces are accepted on the string.");

            var digitsSum = number
                .RemoveWhiteSpace()
                .ToCharArray()
                .Reverse()
                .Select(charToInt)
                .Select((digit, index) => isEven(index) ? doubleDigit(digit) : digit)
                .Sum();

            digitsSum = digitsSum * 9;

            return digitsSum.ToString().ToCharArray().Last().ToString();
        }
    }
}
