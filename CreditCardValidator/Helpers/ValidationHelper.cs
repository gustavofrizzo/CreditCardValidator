using System;
using System.Linq;

namespace CreditCardValidator.Helpers
{
    internal static class ValidationHelper
    {
        public static bool IsAValidNumber(String number)
        {
            number = number.RemoveWhiteSpace();

            return (number.ToCharArray().All(Char.IsNumber) && !String.IsNullOrEmpty(number));
        }
    }
}
