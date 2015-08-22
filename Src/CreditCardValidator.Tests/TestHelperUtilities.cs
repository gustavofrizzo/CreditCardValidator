using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Xunit;

namespace CreditCardUnitTest
{
    public static class TestHelperUtilities
    {
        public static TheoryData<KeyValuePair<string, string[]>> ValidCardData
        {
            get
            {
                var json = File.ReadAllText("Data\\ValidCards.json");
                var cards = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(json);

                var data = new TheoryData<KeyValuePair<string, string[]>>();
                foreach (var item in cards)
                {
                    data.Add(item);
                }

                return data;
            }
        }
    }
}