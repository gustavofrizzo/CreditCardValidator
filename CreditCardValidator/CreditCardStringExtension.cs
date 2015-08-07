namespace CreditCardValidator
{
    public static class CreditCardStringExtension
    {
        public static CardIssuer CreditCardBrand(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).Brand;
        }

        public static string CreditCardBrandName(this string cardNumber)
        {
            return new CreditCardDetector(cardNumber).BrandName;
        }

        public static bool ValidCreditCardBrand(this string cardNumber, params CardIssuer[] issuers)
        {
            return new CreditCardDetector(cardNumber).IsValid(issuers);
        }
    }
}
