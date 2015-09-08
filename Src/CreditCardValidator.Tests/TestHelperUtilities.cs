using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CreditCardValidator;
using Newtonsoft.Json;
using Xunit;

namespace CreditCardUnitTest
{
    public static class TestHelperUtilities
    {
        public static TheoryData<CardIssuer> CardIssuers
        {
            get
            {
                var theoryData = new TheoryData<CardIssuer>();
                //var cardIssuers = (Enum.GetValues(typeof (CardIssuer))
                //    .Cast<CardIssuer>()
                //    .Where(x => x != CardIssuer.Unknown))
                //    .ToArray();

                //theoryData.Add(cardIssuers);

                //return theoryData;
                foreach (var issuer in Enum.GetValues(typeof(CardIssuer))
                    .Cast<CardIssuer>()
                    .Where(issuer => issuer != CardIssuer.Unknown))
                {
                    theoryData.Add(issuer);
                }

                return theoryData;
            }
        }

        public static TheoryData<string> LuhnNumbers
        {
            get
            {
                var json = File.ReadAllText("Data\\LuhnNumbers.json");
                var numbers = JsonConvert.DeserializeObject<List<string>>(json);
                var theoryData = new TheoryData<string>();
                foreach (var number in numbers)
                {
                    theoryData.Add(number);
                }

                return theoryData;
            }
        }

        public static TheoryData<string> LuhnCheckDigits
        {
            get
            {
                var json = File.ReadAllText("Data\\LuhnCheckDigits.json");
                var numbers = JsonConvert.DeserializeObject<List<string>>(json);
                var theoryData = new TheoryData<string>();
                foreach (var number in numbers)
                {
                    theoryData.Add(number);
                }

                return theoryData;
            }
        }

        public static TheoryData<KeyValuePair<string, string[]>> CreditCards()
        {
            var json = File.ReadAllText("Data\\ValidCards.json");
            var creditCards = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

            var data = new TheoryData<KeyValuePair<string, string[]>>();
            foreach (var item in creditCards)
            {
                data.Add(item);
            }

            return data;
        }

        public static TheoryData<KeyValuePair<string, string[]>> CreditCards(CardIssuer cardIssuer)
        {
            var theoryData = new TheoryData<KeyValuePair<string, string[]>>();
            foreach (var creditCard in CreditCards()
                .SelectMany(item => item.Cast<KeyValuePair<string, string[]>>())
                .Where(x => x.Key.Equals(cardIssuer.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                theoryData.Add(creditCard);
            }

            return theoryData;
        }
    }
}