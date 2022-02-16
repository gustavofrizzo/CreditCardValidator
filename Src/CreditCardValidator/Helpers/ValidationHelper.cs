using System.Collections.Generic;
using System.Linq;

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

        internal static List<Rule> GetRulesByLength(CardIssuer cardIssuer, int length)
        {
            var rules = CreditCardData.BrandsData[cardIssuer].Rules;

            var result = new List<Rule>();

            foreach (var rule in rules)
            {
                if (rule.Lengths.Contains(length))
                    result.Add(rule);
            }

            return result;
        }
    }
}