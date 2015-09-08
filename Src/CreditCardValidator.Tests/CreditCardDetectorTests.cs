using System;
using System.Collections.Generic;
using CreditCardValidator;
using Shouldly;
using Xunit;

namespace CreditCardUnitTest
{
    public class CreditCardDetectorTests
    {
        public class ConstructorTests
        {
            public static TheoryData<KeyValuePair<string, string[]>> CreditCards
            {
                get { return TestHelperUtilities.CreditCards(); }
            }

            [Theory]
            [MemberData("CreditCards")]
            public void GivenANumber_Constructor_CreatesANewInstance(KeyValuePair<string, string[]> data)
            {
                // Arrange.
                foreach (var number in data.Value)
                {
                    // Act.
                    var detector = new CreditCardDetector(number);

                    // Assert.
                    detector.IsValid().ShouldBe(true);
                    detector.Brand.ToString().ShouldBe(data.Key);
                }
            }

            [Fact]
            public void InvalidNumbers_CreditCardDetector()
            {
                // Arrange.
                const string invalidNumber = "411111-11h1111";

                // Act.
                var exception = Should.Throw<Exception>(() => new CreditCardDetector(invalidNumber));

                // Assert.
                exception.Message.ShouldBe("Invalid number. Just numbers and white spaces are accepted on the string.");
            }
        }
    }
}