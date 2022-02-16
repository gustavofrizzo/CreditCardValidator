using CreditCardValidator.Helpers;
using System;
using System.Linq;

namespace CreditCardValidator
{
    public static class Luhn
    {
        // Convert to int.
        private static readonly Func<char, int> CharToInt = c => c - '0';

        private static readonly Func<int, bool> IsEven = i => i % 2 == 0;

        // New Double Concept => 7 * 2 = 14 => 1 + 4 = 5.
        private static readonly Func<int, int> DoubleDigit = i => (i * 2).ToString().ToCharArray().Select(CharToInt).Sum();

        /// <summary>
        /// Verify if the card number is valid.
        /// </summary>
        /// <param name="creditCardNumber"></param>
        /// <returns></returns>
        public static bool CheckLuhn(string creditCardNumber)
        {
            if (!ValidationHelper.IsAValidNumber(creditCardNumber))
                throw new ArgumentException("Invalid number. Just numbers and white spaces are accepted in the string.");

            var checkSum = creditCardNumber
                .RemoveWhiteSpace()
                .ToCharArray()
                .Select(CharToInt)
                .Reverse()
                .Select((digit, index) => IsEven(index + 1) ? DoubleDigit(digit) : digit)
                .Sum();

            return checkSum % 10 == 0;
        }

        public static string CreateCheckDigit(string number)
        {
            if (!ValidationHelper.IsAValidNumber(number))
                throw new ArgumentException("Invalid number. Just numbers and white spaces are accepted in the string.");

            var digitsSum = number
                .RemoveWhiteSpace()
                .ToCharArray()
                .Reverse()
                .Select(CharToInt)
                .Select((digit, index) => IsEven(index) ? DoubleDigit(digit) : digit)
                .Sum();

            digitsSum = digitsSum * 9;

            return digitsSum
                .ToString()
                .ToCharArray()
                .Last()
                .ToString();
        }
    }
}
