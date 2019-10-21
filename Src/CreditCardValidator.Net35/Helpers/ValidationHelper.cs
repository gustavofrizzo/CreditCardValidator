using System.Linq;
using System.Text.RegularExpressions;

namespace CreditCardValidator.Helpers
{
    internal static class ValidationHelper
    {
        public static bool IsAValidNumber(string number)
        {
            number = number.RemoveWhiteSpace();

            return (number
                .ToCharArray()
                .All(char.IsNumber) &&
                    !string.IsNullOrEmpty(number));
        }

        public static bool IsAMaskedNumber(string number)
        {
            number = number.RemoveWhiteSpace();
            return Regex.IsMatch(number, @"^\d{6}\*+\d{4}$");
        }
    }
}