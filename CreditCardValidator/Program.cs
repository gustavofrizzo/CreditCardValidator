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
            BrandName = "unkdown";
            SkipLuhn = false;
        }

    }

    public class Rule
    {
        public List<int> lengths;
        public List<String> prefixes;

        public Rule()
        {
            lengths = new List<int>();
            prefixes = new List<string>();
        }
    }

    public class CreditCardDetector
    {
        //private CardIssuer brand;
        private String _brandName;
        private String _cardNumber;
        private CardIssuer _cardIssuer;

        public CreditCardDetector(String cardNumber)
        {
            _cardNumber = cardNumber;
            LoadCard();
        }

        public String CardNumber
        {
            get
            {
                return _cardNumber;
            }
            private set { }
        }

        private void LoadCard()
        {
            foreach (var brandRules in CreditCardData.BrandsRules)
            {
                //All cardInfo from one brand.
                var cardInfo = brandRules.Value;

                foreach (var rule in cardInfo.Rules)
                {
                    if (rule.lengths.Any(c => c == _cardNumber.Length) && rule.prefixes.Any(c => _cardNumber.StartsWith(c)))
                    {
                        _cardIssuer = brandRules.Key;
                        _brandName = cardInfo.BrandName;
                        return;
                    }
                }
            }

            _cardIssuer = CardIssuer.Unknown;
            _brandName = CardIssuer.Unknown.ToString();

        }

        public CardIssuer Brand
        {
            get
            {
                return _cardIssuer;
            }
            private set { }
        }

        public String BrandName
        {
            get
            {
                return _brandName;
            }
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
            CreditCardDetector my2 = new CreditCardDetector("4992734871632");

            Console.WriteLine(my.CardNumber + " - " + my.BrandName);
            Console.WriteLine(my2.CardNumber + " - " + my2.BrandName);

            Console.ReadKey();
        }
    }
}
