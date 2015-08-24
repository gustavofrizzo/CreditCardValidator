using CreditCardValidator;
using Shouldly;
using Xunit;

namespace CreditCardUnitTest
{
    public class CreditCardFactoryTests
    {
        public class RandomCardNumberTests
        {
            public static TheoryData<CardIssuer> CardIssuers
            {
                get { return TestHelperUtilities.CardIssuers; }
            }

            [Theory]
            [MemberData("CardIssuers")]
            public void GivenACardIssuer_RandomCardNumber_ReturnsAValidCard(CardIssuer cardIssuer)
            {
                // Arrange.

                // Act.
                var number = CreditCardFactory.RandomCardNumber(cardIssuer);

                // Assert.
                var detector = new CreditCardDetector(number);
                detector.Brand.ShouldBe(cardIssuer);
                detector.IsValid(cardIssuer).ShouldBe(true);
                detector.IsValid().ShouldBe(true);
            }
        }
    }
}