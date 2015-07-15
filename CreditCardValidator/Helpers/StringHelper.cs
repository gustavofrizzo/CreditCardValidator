using System;
using System.Linq;

namespace CreditCardValidator.Helpers
{
    internal static class StringHelper
    {
        public static string RemoveWhiteSpace(this String input)
        {
            return new String(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
