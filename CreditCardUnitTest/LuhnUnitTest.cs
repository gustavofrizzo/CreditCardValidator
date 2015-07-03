using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditCardValidator;
using System.Collections.Generic;

namespace CreditCardUnitTest
{
    [TestClass]
    public class LuhnUnitTest
    {
        [TestMethod]
        public void Validating_CheckLuhn()
        {
            List<String> numbers = new List<string>() { "5328017940476466", "4929174520522064", "6011939908785655", 
                                                        "349514561709734", "3088689936484764", "5340328330477582", 
                                                        "4916303389920714", "370040022538449" };

            foreach (String number in numbers)
            {
                Assert.IsTrue(Luhn.CheckLuhn(number), String.Format("number {0} should be valid.", number));
            }
        }
        
        [TestMethod]
        public void Validating_CreateCheckDigit()
        {
            List<String> validNumbers = new List<string>() { "4539877049525937", "6331101999990016", "6011860911436872", 
                                                             "349514561709734", "3088689936484764", "5340328330477582", 
                                                             "4916303389920714", "370040022538449" };

            foreach (String number in validNumbers)
            {
                String numberWithOutDigit = number.Substring(0, number.Length - 1);

                numberWithOutDigit += Luhn.CreateCheckDigit(numberWithOutDigit);

                Assert.AreEqual(number, numberWithOutDigit, 
                    String.Format("Original = {0}, Created = {1}", number, numberWithOutDigit));
            }
        }
    }
}
