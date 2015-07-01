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
        //private IssuingInstitutes brand;
        private String brandName;
        private String cardNumber;

        public CreditCardDetector(String number)
        {
            cardNumber = number;
        }

        public String CardNumber
        {
            get
            {
                return cardNumber;
            }
            private set { }
        }

        public IssuingInstitutes Brand
        {
            get
            {
                var rules = CreditCardData.BrandsRules;

                foreach (var rule in rules)
                {
                    var r = rule.Value.Rules;

                    foreach (var r2 in r)
                    {
                        if (r2.lengths.Any(c => c == cardNumber.Length) && r2.prefixes.Any(c => cardNumber.StartsWith(c)))
                        {
                            return rule.Key;
                        }
                    }
                }

                return IssuingInstitutes.NobodyKnows;
            }
            private set { }
        }

        public String BrandName
        {
            get
            {
                var rules = CreditCardData.BrandsRules;

                foreach (var rule in rules)
                {
                    var r = rule.Value.Rules;

                    foreach (var r2 in r)
                    {
                        if (r2.lengths.Any(c => c == cardNumber.Length) && r2.prefixes.Any(c => cardNumber.StartsWith(c)))
                        {
                            return rule.Value.BrandName;
                        }
                    }
                }

                return "NobodyKnows";
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
