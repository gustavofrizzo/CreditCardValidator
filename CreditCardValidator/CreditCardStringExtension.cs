using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{
    public static class CreditCardStringExtension
    {
        public static CardIssuer CreditCardBrand(this String cardNumber)
        {
            return new CreditCardDetector(cardNumber).Brand;
        }

        public static String CreditCardBrandName(this String cardNumber)
        {
            return new CreditCardDetector(cardNumber).BrandName;
        }

        public static bool ValidCreditCardBrand(this String cardNumber, params CardIssuer[] issuers)
        {
            return new CreditCardDetector(cardNumber).IsValid(issuers);
        }
    }
}
