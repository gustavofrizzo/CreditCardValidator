using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{

    /// <summary>
    /// Issuing institutes accepted.
    /// </summary>
    public enum CardIssuer
    {
        AmericanExpress,
        ChinaUnionPay,
        Dankort,
        DinersClub,
        DinnerClubUS,
        Discover,
        Hipercard,
        JCB,
        Laser,
        Maestro,
        MasterCard,
        Rupay,
        Solo,
        Switch,
        Visa,
        Unknown,
    }

    internal static class CreditCardData
    {
        public static Dictionary<CardIssuer, BrandInfo> BrandsData;

        /// <summary>
        /// A static constructor is used to initialize any static data, or to perform a particular 
        /// action that needs to be performed once only. It is called automatically before the 
        /// first instance is created or any static members are referenced.
        /// </summary>
        static CreditCardData()
        {
            BrandsData = new Dictionary<CardIssuer, BrandInfo>();
            LoadData();
        }

        private static void LoadData()
        {
            #region Populating

            BrandsData.Add(CardIssuer.Visa, new BrandInfo()
            {
                BrandName = "Visa",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 13, 16 }, 
                        Prefixes = new List<string>() { "4" } 
                    }
                }
            });

            BrandsData.Add(CardIssuer.MasterCard, new BrandInfo()
            {
                BrandName = "MasterCard",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16 }, 
                        Prefixes = new List<string>() { "51", "52", "53", "54", "55" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Unknown, new BrandInfo()
            {
                BrandName = "Unknown",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>(), 
                        Prefixes = new List<string>()
                    }
                }
            });


            #endregion
        }


    }
}
