using System;
using System.Linq;

namespace CreditCardValidator
{
    public class CreditCardDetector
    {
        private String _brandName;
        private String _cardNumber;
        private CardIssuer _cardIssuer;

        public CreditCardDetector(String cardNumber)
        {
            _cardNumber = cardNumber;
            LoadCard();
        }

        private void LoadCard()
        {
            foreach (var brandData in CreditCardData.BrandsData)
            {
                //cardInfo from one brand.
                var cardInfo = brandData.Value;

                foreach (var rule in cardInfo.Rules)
                {
                    if (rule.Lengths.Any(c => c == _cardNumber.Length) && rule.Prefixes.Any(c => _cardNumber.StartsWith(c)))
                    {
                        _cardIssuer = brandData.Key;
                        _brandName = cardInfo.BrandName;
                        return;
                    }
                }
            }

            _cardIssuer = CardIssuer.Unknown;
            _brandName = CardIssuer.Unknown.ToString();
        }

        public String CardNumber
        {
            get { return _cardNumber; }
            private set { }
        }

        public bool IsValid()
        {
            return CreditCardData.BrandsData[_cardIssuer].SkipLuhn ? true : Luhn.CheckLuhn(_cardNumber);
        }


        public bool IsValid(params CardIssuer[] issuers)
        {
            foreach (var issuer in issuers)
            {
                if (issuer == _cardIssuer && this.IsValid())
                    return true;
            }
            return false;
        }


        public CardIssuer Brand
        {
            get { return _cardIssuer; }
            private set { }
        }

        public String BrandName
        {
            get { return _brandName; }
            private set { }
        }

        public String IssuerCategory
        {
            get
            {
                return MajorIndustryIdentifier.Categories[Convert.ToInt32(_cardNumber.First().ToString())];
            }
            private set { }
        }

    }
}
