using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator.Helpers
{
    internal static class ValidationHelper
    {
        public static bool IsAValidNumber(String number)
        {
            number = number.RemoveWhiteSpace();

            return (number.All(Char.IsNumber) && !String.IsNullOrEmpty(number));
        }
    }
}
