using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator;

namespace CreditCardUnitTest
{
    [TestClass]
    public class CreditCardFactoryUnitTest
    {
        [TestMethod]
        public void CreatingRandomCardNumber()
        {
            String number = CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);

            CreditCardDetector card = new CreditCardDetector(number);

            Assert.IsTrue(card.Brand == CardIssuer.MasterCard);
            Assert.IsTrue(card.IsValid(CardIssuer.MasterCard));
        }
    }
}
