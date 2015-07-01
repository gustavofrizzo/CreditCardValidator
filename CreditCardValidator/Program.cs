using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{

    public class BrandInfo
    {
        public List<Rule> Rules;
        public String BrandName;
        public bool SkipLuhn;

        public BrandInfo()
        {
            Rules = new List<Rule>();
            BrandName = "Unknown";
            SkipLuhn = false;
        }

    }

    public class Rule
    {
        public List<int> Lengths;
        public List<String> Prefixes;

        public Rule()
        {
            Lengths = new List<int>();
            Prefixes = new List<string>();
        }
    }

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
                //All cardInfo from one brand.
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

        public bool IsValid
        {
            get
            {
                return CreditCardData.BrandsData[_cardIssuer].SkipLuhn ? true : Luhn.CheckLuhn(_cardNumber);
            }
            private set { }
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

    }


    class Program
    {

        static void Main(String[] args)
        {
            Console.WriteLine("Hi");

            Console.WriteLine(Luhn.CheckLuhn("79927398713")); //true
            Console.WriteLine(Luhn.CheckLuhn("378282246310005")); //true
            Console.WriteLine(Luhn.CheckLuhn("601111511111111437")); //false
            Console.WriteLine(Luhn.CheckLuhn("49927398716")); //true

            /*using (StreamReader r = new StreamReader("Brands.json"))
            {
                string json = r.ReadToEnd();
                dynamic aa = JsonConvert.DeserializeObject(json);

                Console.WriteLine(aa.mastercard);
            }*/

            CreditCardDetector my = new CreditCardDetector("5499273565871632");
            CreditCardDetector my2 = new CreditCardDetector("49927398716");

            Console.WriteLine(my.CardNumber + " - " + my.BrandName + " - " + my.IsValid);
            Console.WriteLine(my2.CardNumber + " - " + my2.BrandName + " - " + my2.IsValid);

            Console.ReadKey();
        }
    }
}
