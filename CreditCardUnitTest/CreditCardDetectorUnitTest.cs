using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using CreditCardValidator;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CreditCardUnitTest
{
    [TestClass]
    public class CreditCardDetectorUnitTest
    {
        [TestMethod]
        public void Validating_CreditCardDetector()
        {
            using (StreamReader r = new StreamReader(@"Data\ValidCards.json"))
            {
                string json = r.ReadToEnd();
                var allCardNumbers = JsonConvert.DeserializeObject<Dictionary<String, String[]>>(json);

                foreach (var cardsBrand in allCardNumbers)
                {
                    foreach (var number in cardsBrand.Value)
                    {
                        CreditCardDetector detector = new CreditCardDetector(number);

                        Assert.IsTrue(detector.IsValid());
                        Assert.AreEqual(cardsBrand.Key, detector.Brand.ToString());
                    }
                }

            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidNumbers_CreditCardDetector()
        {
            String invalidNumber = "411111-11h1111";

            CreditCardDetector detc = new CreditCardDetector(invalidNumber);
        }

    }
}
