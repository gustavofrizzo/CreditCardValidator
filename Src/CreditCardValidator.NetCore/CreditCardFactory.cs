using CreditCardValidator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardValidator
{
    public static class CreditCardFactory
    {
        [ThreadStatic]
        private static readonly Random RandomNumber = new Random();

        public static string RandomCardNumber(CardIssuer brand)
        {
            return RandomCardNumber(brand, 0);
        }

        public static string RandomCardNumber(CardIssuer cardIssuer, int length)
        {
            var rules = ValidationHelper.GetRulesByLength(cardIssuer, length);

            if (length > 0 && rules.Count == 0)
                throw new ArgumentException($"The card number length [{length}] is not valid for the card issuer [{cardIssuer}].");

            string number = "";

            var rule = rules.Count == 0 ? CreditCardData.BrandsData[cardIssuer].Rules.First() : rules.First();

            length = length > 0 ? length : rule.Lengths.First();

            number += rule.Prefixes[RandomNumber.Next(0, rule.Prefixes.Count)];

            var numberLength = number.Length;
            for (int i = 0; i < length - 1 - numberLength; i++)
            {
                number += RandomNumber.Next(0, 10);
            }

            number += Luhn.CreateCheckDigit(number);

            return number;
        }
    }
}
