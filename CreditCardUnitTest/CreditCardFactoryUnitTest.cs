using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator;

namespace CreditCardUnitTest
{
    [TestClass]
    public class CreditCardFactoryUnitTest
    {
        [TestMethod]
        public void Creating_Validating_RandomCardNumbers()
        {
            foreach (var issuer in Enum.GetValues(typeof(CardIssuer)))
            {
                if ((CardIssuer)issuer == CardIssuer.Unknown)
                    continue;

                String number = CreditCardFactory.RandomCardNumber((CardIssuer)issuer);

                CreditCardDetector card = new CreditCardDetector(number);

                Assert.IsTrue(card.Brand == (CardIssuer)issuer,
                    String.Format("card.Brand should be {0}, but is {1}. Number = {2}", issuer, card.Brand, card.CardNumber));

                Assert.IsTrue(card.IsValid((CardIssuer)issuer), 
                    String.Format("should be a valid {0} card. Number = {1}", (CardIssuer)issuer, card.CardNumber));
                
                Assert.IsTrue(card.IsValid(), 
                    String.Format("should be a valid card. Brand = {0}, number = {1}", card.Brand, card.CardNumber));

                if ((CardIssuer)issuer != CardIssuer.Visa)
                    Assert.IsFalse(card.IsValid(CardIssuer.Visa),
                        String.Format("card should not be Visa. Brand = {0}, Number = {1}", card.Brand, card.CardNumber));
            }



            /*String number = CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);

            CreditCardDetector card = new CreditCardDetector(number);

            Assert.IsTrue(card.Brand == CardIssuer.MasterCard);
            Assert.IsTrue(card.IsValid(CardIssuer.MasterCard));
            Assert.IsTrue(card.IsValid());
            Assert.IsFalse(card.IsValid(CardIssuer.Visa));*/
        }
    }
}
