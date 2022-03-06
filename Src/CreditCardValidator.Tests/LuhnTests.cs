using CreditCardValidator;
using Shouldly;
using Xunit;

namespace CreditCardUnitTest
{
    public class LuhnTests
    {
        public class CheckLuhnTests
        {
            public static TheoryData<string> LuhnNumbers
            {
                get { return TestHelperUtilities.LuhnNumbers; }
            }

            [Theory]
            [MemberData(nameof(LuhnNumbers))]
            public void GivenAValidLuhnNumber_CheckLuhn_ReturnsTrue(string number)
            {
                // Arrange.

                // Act and Assert.
                Luhn.CheckLuhn(number).ShouldBe(true);
            }
        }

        public class CreateCheckDigitTests
        {
            public static TheoryData<string> LuhnCheckDigits
            {
                get { return TestHelperUtilities.LuhnCheckDigits; }
            }

            [Theory]
            [MemberData(nameof(LuhnCheckDigits))]
            public void GivenAValidLuhnNumber_CreateCheckDigit_ReturnsAnEqualNumber(string number)
            {
                // Arrange.
                var numberWithOutDigit = number.Substring(0, number.Length - 1);

                //Act.
                numberWithOutDigit += Luhn.CreateCheckDigit(numberWithOutDigit);

                // Assert.
                numberWithOutDigit.ShouldBe(number);
            }
        }
    }
}