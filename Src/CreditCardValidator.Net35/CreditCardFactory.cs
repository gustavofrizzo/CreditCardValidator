using CreditCardValidator.Helpers;
using System;
using System.Linq;

namespace CreditCardValidator
{
    public static class CreditCardFactory
    {
        private static readonly Random RandomNumber = new Random();

        public static string RandomCardNumber(CardIssuer brand, int length = 0)
        {
            if (length > 0 && !ValidationHelper.IsAValidLength(brand, length))
                throw new ArgumentException(String.Format("{0} is not valid length for card issuer {1}", length, brand));

            string number = "";

            var rule = CreditCardData.BrandsData[brand].Rules.First();

            int len = length > 0 ? length : rule.Lengths.First();

            if (brand != CardIssuer.Unknown)
                number += rule.Prefixes[RandomNumber.Next(0, rule.Prefixes.Count)];

            var numberLength = number.Length;
            for (int i = 0; i < len - 1 - numberLength; i++)
            {
                number += RandomNumber.Next(0, 10);
            }

            number += Luhn.CreateCheckDigit(number);

            return number;
        }
    }
}
