using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator;

namespace CreditCardUnitTest
{
    [TestClass]
    public class CreditCardStringExtensionUnitTest
    {
        [TestMethod]
        public void Validating_CreditCardBrand()
        {
            Assert.AreEqual(CardIssuer.MasterCard, "5239088204232455".CreditCardBrand());
        }

        [TestMethod]
        public void Validating_CreditCardBrandName()
        {
            Assert.AreEqual(CardIssuer.MasterCard.ToString(), "5239088204232455".CreditCardBrandName());
        }

        [TestMethod]
        public void Validating_ValidCreditCardBrand()
        {
            Assert.IsTrue("5239088204232455".ValidCreditCardBrand(CardIssuer.MasterCard));
        }
    }
}
