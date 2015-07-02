using System;
using System.Linq;

namespace CreditCardValidator
{
    public static class CreditCardFactory
    {
        private static Random rnd = new Random();

        public static String RandomCardNumber(CardIssuer brand)
        {
            String number = "";
            var rule = CreditCardData.BrandsData[brand].Rules.First();

            if (brand != CardIssuer.Unknown)
                number += rule.Prefixes[rnd.Next(0, rule.Prefixes.Count)];

            var numberLength = number.Length;
            for (int i = 0; i < rule.Lengths.First() - 1 - numberLength; i++)
            {
                number += rnd.Next(0, 10);
            }

            number += Luhn.CreateCheckDigit(number);
            
            return number;
        }
    }
}
