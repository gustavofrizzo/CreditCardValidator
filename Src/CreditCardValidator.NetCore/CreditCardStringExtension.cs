namespace CreditCardValidator
{
    public static class CreditCardStringExtension
    {
        public static CardIssuer CreditCardBrand(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).Brand;
        }

        public static CardIssuer CreditCardBrandIgnoreLength(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber, true).Brand;
        }

        public static string CreditCardBrandName(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).BrandName;
        }

        public static string CreditCardBrandNameIgnoreLength(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber, true).BrandName;
        }

        public static bool ValidCreditCardBrand(this string cardNumber, params CardIssuer[] issuers)
        {
            return new CreditCardDetector(cardNumber).IsValid(issuers);
        }
    }
}
