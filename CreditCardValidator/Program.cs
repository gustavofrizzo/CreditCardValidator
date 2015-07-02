using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{
    class Program
    {

        static void Main(String[] args)
        {
            Console.WriteLine("Hi");

            /*Console.WriteLine(Luhn.CheckLuhn("79927398713")); //true
            Console.WriteLine(Luhn.CheckLuhn("378282246310005")); //true
            Console.WriteLine(Luhn.CheckLuhn("601111511111111437")); //false
            Console.WriteLine(Luhn.CheckLuhn("49927398716")); //true
            */
            /*using (StreamReader r = new StreamReader("Brands.json"))
            {
                string json = r.ReadToEnd();
                dynamic aa = JsonConvert.DeserializeObject(json);

                Console.WriteLine(aa.mastercard);
            }*/

            CreditCardDetector my = new CreditCardDetector("5239088204232455");
            CreditCardDetector my2 = new CreditCardDetector("4111111111111111");

            Console.WriteLine(my.CardNumber + " - " + my.BrandName + " - " + my.IsValid(CardIssuer.Visa, CardIssuer.MasterCard) + " - " + my.IssuerCategory);
            Console.WriteLine(my2.CardNumber + " - " + my2.BrandName + " - " + my2.IsValid() + " - " + my2.IssuerCategory);
            
            Console.WriteLine();

            
            /*Console.WriteLine(Luhn.CheckLuhn("5543548990584147"));
            Console.WriteLine(Luhn.CheckLuhn("6011860911436872"));
            Console.WriteLine(Luhn.CheckLuhn("6331101999990016"));
            Console.WriteLine(Luhn.CheckLuhn("4222222222222"));*/


            /*Console.WriteLine("4539877049525937" + " " + Luhn.CreateCheckDigit("453987704952593"));
            Console.WriteLine("6331101999990016" + " " + Luhn.CreateCheckDigit("633110199999001"));
            Console.WriteLine("6011860911436872" + " " + Luhn.CreateCheckDigit("601186091143687"));*/

            Console.WriteLine("5239088204232455".CreditCardBrand());
            Console.WriteLine("5239088204232455".CreditCardBrandName());
            Console.WriteLine("5239088204232455".ValidCreditCardBrand(CardIssuer.MasterCard));

            for (int i = 0; i < 2; i++)
            {
                var a = CreditCardFactory.RandomCardNumber(CardIssuer.MasterCard);
                Console.WriteLine(a + " " + Luhn.CheckLuhn(a));
            }

                Console.ReadKey();
        }
    }
}
