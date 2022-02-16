using System.Collections.Generic;
using System.Linq;
using CreditCardValidator;
using Shouldly;
using Xunit;

namespace CreditCardUnitTest
{
    public class CreditCardStringExtensionTests
    {
        public class CreditCardBrandTests
        {
            public static TheoryData<string> MasterCardNumbers
            {
                get
                {
                    var masterCard = TestHelperUtilities.CreditCards(CardIssuer.MasterCard);
                    var numbers = masterCard
                        .SelectMany(x => x.Cast<KeyValuePair<string, string[]>>())
                        .SelectMany(x => x.Value)
                        .ToList();
                    var theoryData = new TheoryData<string>();
                    foreach (var number in numbers)
                    {
                        theoryData.Add(number);
                    }

                    return theoryData;
                }
            }

            [Theory]
            [MemberData(nameof(MasterCardNumbers))]
            public void Validating_CreditCardBrand(string number)
            {
                number.CreditCardBrand().ShouldBe(CardIssuer.MasterCard);
            }

            [Theory]
            [MemberData(nameof(MasterCardNumbers))]
            public void Validating_CreditCardBrandIgnoreLength(string number)
            {
                number.CreditCardBrandIgnoreLength().ShouldBe(CardIssuer.MasterCard);
            }
        }
    }
}