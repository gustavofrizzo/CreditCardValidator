using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
