using System;
using System.Linq;
using CreditCardValidator.Helpers;

namespace CreditCardValidator
{
    public class CreditCardDetector
    {
        public string CardNumber { get; private set; }
        public CardIssuer Brand { get; private set; }
        public string BrandName { get; private set; }
        internal bool IgnoreLengthCheck { get; private set; }

        public CreditCardDetector(string cardNumber)
        {
            if (!ValidationHelper.IsAValidNumber(cardNumber))
                throw new ArgumentException("Invalid number. Just numbers and white spaces are accepted on the string.");

            CardNumber = cardNumber.RemoveWhiteSpace();
            IgnoreLengthCheck = false;
            LoadCard();
        }

        internal CreditCardDetector(string cardNumber, bool ignoreLengthCheck)
        {
            if (!ValidationHelper.IsAValidNumber(cardNumber))
                throw new ArgumentException("Invalid number. Just numbers and white spaces are accepted on the string.");

            CardNumber = cardNumber.RemoveWhiteSpace();
            IgnoreLengthCheck = ignoreLengthCheck;

            if (ignoreLengthCheck)
                LoadCardIgnoreCardLength();
            else
                LoadCard();
        }

        public string IssuerCategory
        {
            get { return MajorIndustryIdentifier.Categories[Convert.ToInt32(CardNumber[0].ToString())]; }
        }

        private void LoadCard()
        {
            foreach (var brandData in CreditCardData.BrandsData)
            {
                // CardInfo from one brand.
                var cardInfo = brandData.Value;

                foreach (var rule in cardInfo.Rules)
                {
                    if (rule.Lengths.Any(c => c == CardNumber.Length) &&
                        rule.Prefixes.Any(c => CardNumber.StartsWith(c)))
                    {
                        Brand = brandData.Key;
                        BrandName = cardInfo.BrandName;
                        return;
                    }
                }
            }

            Brand = CardIssuer.Unknown;
            BrandName = CardIssuer.Unknown.ToString();
        }

        private void LoadCardIgnoreCardLength()
        {
            foreach (var brandData in CreditCardData.BrandsData)
            {
                // CardInfo from one brand.
                var cardInfo = brandData.Value;

                foreach (var rule in cardInfo.Rules)
                {
                    if (rule.Prefixes.Any(c => CardNumber.StartsWith(c)))
                    {
                        Brand = brandData.Key;
                        BrandName = cardInfo.BrandName;
                        return;
                    }
                }
            }

            Brand = CardIssuer.Unknown;
            BrandName = CardIssuer.Unknown.ToString();
        }

        public bool IsValid()
        {
            // The Brand rules were already checked by LoadCard(). So, if a card has a brand, means
            // that the number meets at least one of the rule requirements.
            return CreditCardData.BrandsData[Brand].SkipLuhn || Luhn.CheckLuhn(CardNumber);
        }

        public bool IsValid(params CardIssuer[] issuers)
        {
            return issuers.Any(issuer => issuer == Brand && IsValid());
        }
    }
}