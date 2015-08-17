using System;
using System.Linq;

namespace CreditCardValidator
{
    public static class CreditCardFactory
    {
        private static readonly Random RandomNumber = new Random();

        public static string RandomCardNumber(CardIssuer brand)
        {
            string number = "";
            var rule = CreditCardData.BrandsData[brand].Rules.First();

            if (brand != CardIssuer.Unknown)
                number += rule.Prefixes[RandomNumber.Next(0, rule.Prefixes.Count)];

            var numberLength = number.Length;
            for (int i = 0; i < rule.Lengths.First() - 1 - numberLength; i++)
            {
                number += RandomNumber.Next(0, 10);
            }

            number += Luhn.CreateCheckDigit(number);
            
            return number;
        }
    }
}
