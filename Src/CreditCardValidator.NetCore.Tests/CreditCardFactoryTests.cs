﻿using CreditCardValidator;
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
            [MemberData(nameof(CardIssuers))]
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
            [MemberData(nameof(CardIssuers))]
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
            [MemberData(nameof(CardIssuers))]
            public void GivenACardIssuer_RandomCardNumber_ReturnsAValidCard_Length_MinLength(CardIssuer cardIssuer)
            {
                // Arrange.
                var lengths = TestHelperUtilities.Lengths(cardIssuer);

                foreach(var len in lengths)
                {
                    // Act.
                    var number = CreditCardFactory.RandomCardNumber(cardIssuer, len);

                    // Assert.
                    var detector = new CreditCardDetector(number);
                    number.Length.ShouldBe(len);
                    detector.Brand.ShouldBe(cardIssuer);
                    detector.IsValid(cardIssuer).ShouldBe(true);
                    detector.IsValid().ShouldBe(true);
                }
            }

            [Theory]
            [MemberData(nameof(CardIssuers))]
            public void GivenACardIssuer_RandomCardNumber_ReturnsAValidCard_Length_Invalid(CardIssuer cardIssuer)
            {
                // Arrange.
                string number = "";
                Exception e = new Exception();
                int length = 99;

                // Act.
                try
                {
                    number = CreditCardFactory.RandomCardNumber(cardIssuer, length);
                }
                catch (Exception ex)
                {
                    e = ex;
                }

                // Assert
                e.ShouldBeOfType<ArgumentException>();
                e.Message.ShouldBe($"The card number length [{length}] is not valid for the card issuer [{cardIssuer}].");
                number.Length.ShouldBe(0);
            }
        }
    }
}