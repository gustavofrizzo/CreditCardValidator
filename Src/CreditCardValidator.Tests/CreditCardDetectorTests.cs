using System;
using System.Collections.Generic;
using System.IO;
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
            [MemberData(nameof(CreditCards))]
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

        public List<RangeHelper> Ranges { get; }

        public CreditCardDetectorTests()
        {
            Ranges = LoadRanges();
        }
        
        private List<RangeHelper> LoadRanges()
        {
            var csv = File.ReadAllLines(Path.Combine("Data", "ranges.csv"));

            List<RangeHelper> ranges = new List<RangeHelper>();

            foreach(string line in csv)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("iin_start"))
                    continue;

                var columns = line.Split(',');

                if (string.IsNullOrWhiteSpace(columns[0]) || string.IsNullOrWhiteSpace(columns[4]))
                    continue;

                ranges.Add(new RangeHelper(columns[0], columns[4]));
            }

            return ranges;
        }

        [Fact]
        public void CheckRanges()
        {
            foreach(var range in this.Ranges)
            {
                CardIssuer ci = range.Range.CreditCardBrandIgnoreLength();

                (ci.ToString().ToLower() == range.CardIssuer.ToLower()).ShouldBe(true);
            }
        }
    }

    public class RangeHelper
    {
        public string Range { get; set; }
        public string CardIssuer { get; set; }

        public RangeHelper(string range, string issuer)
        {
            Range = range;
            CardIssuer = issuer;
        }

        public override string ToString()
        {
            return $"{Range} - {CardIssuer}";
        }
    }
}