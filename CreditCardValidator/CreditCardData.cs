using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{
    public enum IssuingInstitutes
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
        NobodyKnows,
    }

    public static class CreditCardData
    {
        public static Dictionary<IssuingInstitutes, BrandInfo> BrandsRules = new Dictionary<IssuingInstitutes, BrandInfo>();

        /// <summary>
        /// A static constructor is used to initialize any static data, or to perform a particular 
        /// action that needs to be performed once only. It is called automatically before the 
        /// first instance is created or any static members are referenced.
        /// </summary>
        static CreditCardData()
        {
            LoadData();
        }

        private static void LoadData()
        {
            #region Populating

            BrandsRules.Add(IssuingInstitutes.Visa, new BrandInfo()
            {
                BrandName = "Visa",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        lengths = new List<int>() { 13, 16 }, 
                        prefixes = new List<string>() { "4" } 
                    }
                }
            });

            BrandsRules.Add(IssuingInstitutes.MasterCard, new BrandInfo()
            {
                BrandName = "MasterCard",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        lengths = new List<int>() { 16 }, 
                        prefixes = new List<string>() { "51", "52", "53", "54", "55" }
                    }
                }
            });


            #endregion
        }


    }
}
