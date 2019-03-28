using CreditCardValidator;
using Shouldly;
using System;
using System.Linq;
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

			[Theory]
			[MemberData("CardIssuers")]
			public void GivenACardIssuer_RandomCardNumber_ReturnsAValidCard_Length_MaxLength(CardIssuer cardIssuer)
			{
				// Arrange.
				var maxLength = TestHelperUtilities.Lengths(cardIssuer).Last();

				// Act.
				var number = CreditCardFactory.RandomCardNumber(cardIssuer, maxLength);

				// Assert.
				var detector = new CreditCardDetector(number);
				number.Length.ShouldBe(maxLength);
				detector.Brand.ShouldBe(cardIssuer);
				detector.IsValid(cardIssuer).ShouldBe(true);
				detector.IsValid().ShouldBe(true);
			}

			[Theory]
			[MemberData("CardIssuers")]
			public void GivenACardIssuer_RandomCardNumber_ReturnsAValidCard_Length_MinLength(CardIssuer cardIssuer)
			{
				// Arrange.
				var minLength = TestHelperUtilities.Lengths(cardIssuer).FirstOrDefault();

				// Act.
				var number = CreditCardFactory.RandomCardNumber(cardIssuer, minLength);

				// Assert.
				var detector = new CreditCardDetector(number);
				number.Length.ShouldBe(minLength);
				detector.Brand.ShouldBe(cardIssuer);
				detector.IsValid(cardIssuer).ShouldBe(true);
				detector.IsValid().ShouldBe(true);
			}

			[Theory]
			[MemberData("CardIssuers")]
			public void GivenACardIssuer_RandomCardNumber_ReturnsAValidCard_Length_Invalid(CardIssuer cardIssuer)
			{
				// Arrange.
				string number = "";
				Exception e = new Exception();

				// Act.
				try {
					number = CreditCardFactory.RandomCardNumber(cardIssuer, 99);
				}
				catch (Exception ex)
				{
					e = ex;					
				}

				// Assert
				e.ShouldBeOfType<ArgumentException>();
				e.Message.ShouldBe("99 is not valid length for card issuer " + cardIssuer.ToString());
				number.Length.ShouldBe(0);
			}
		}
    }
}