using CreditCardValidator;
using Shouldly;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            [Fact]
            public void TestUnknownCardIssuerGeneration()
            {
                for(int i = 0; i < 10000; i++)
                {
                    var unkCard = CreditCardFactory.RandomCardNumber(CardIssuer.Unknown);

                    CreditCardDetector detector = new CreditCardDetector(unkCard);

                    detector.Brand.ShouldBe<CardIssuer>(CardIssuer.Unknown);
                }
            }

            [Fact]
            public void TestMultiThreadRandomCardNumberGeneration()
            {
                var tasks = new List<Task>();
                var results = new ConcurrentDictionary<string, byte>();

                for (int i = 0; i < 20; i++)
                {
                    var task = new Task(() =>
                    {
                        for (int j = 0; j < 1000; j++)
                        {
                            var cardNumber = CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);

                            Assert.NotNull(cardNumber);
                            Assert.True(results.TryAdd(cardNumber, 0), $"Error: Factory generated a duplicated card number: [{cardNumber}]");
                        }
                    });

                    tasks.Add(task);
                }

                tasks.ForEach(t => t.Start());
                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}