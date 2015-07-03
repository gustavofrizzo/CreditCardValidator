using System;
using System.Collections.Generic;

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
            #region Populating BrandsData

            BrandsData.Add(CardIssuer.Visa, new BrandInfo()
            {
                BrandName = "Visa",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 13, 16 }, 
                        Prefixes = new List<String>() { "4" } 
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
                        Prefixes = new List<String>() { "51", "52", "53", "54", "55" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.AmericanExpress, new BrandInfo()
            {
                BrandName = "American Express",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 15 }, 
                        Prefixes = new List<String>() { "34", "37" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.DinersClub, new BrandInfo()
            {
                BrandName = "Diners Club",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 14 }, 
                        Prefixes = new List<String>() { "300", "301", "302", "303", "304", "305", "36", "38" }
                    }
                }
            });

            /*BrandsData.Add(CardIssuer.DinersClubUS, new BrandInfo()
            {
                BrandName = "Diners Club US",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16 }, 
                        Prefixes = new List<String>() { "54", "55" }
                    }
                }
            });*/

            BrandsData.Add(CardIssuer.Discover, new BrandInfo()
            {
                BrandName = "Discover",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16 }, 
                        Prefixes = new List<String>() { "6011", "644", "645", "646", "647", "648", "649", "65" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.JCB, new BrandInfo()
            {
                BrandName = "JCB",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 15, 16 }, 
                        Prefixes = new List<String>() { "3528", "3529", "353", "354", "355", "356", "357", "358" }
                    },
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 15 }, 
                        Prefixes = new List<String>() { "1800", "2131" }
                    },
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 19 }, 
                        Prefixes = new List<String>() { "357266" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Laser, new BrandInfo()
            {
                BrandName = "Laser",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16, 17, 18, 19 }, 
                        Prefixes = new List<String>() { "6304", "6706", "6771" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Solo, new BrandInfo()
            {
                BrandName = "Solo",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16, 18, 19 }, 
                        Prefixes = new List<String>() { "6334", "6767" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Switch, new BrandInfo()
            {
                BrandName = "Switch",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16, 18, 19 }, 
                        Prefixes = new List<String>() { "633110", "633312", "633304", "633303", "633301", "633300" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Maestro, new BrandInfo()
            {
                BrandName = "Maestro",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 12, 13, 14, 15, 16, 17, 18, 19 }, 
                        Prefixes = new List<String>() { "500","5010","5011","5012","5013","5014","5015","5016",
                                                        "5017","5018","502","503","504","505","506","507","508",
                                                        "509","56","57","58","59","6010","6012","6013","6014",
                                                        "6015","6016","6017","6018","6019","602","603","604","605",
                                                        "6060","621","627","629","670","671","672","673","674",
                                                        "675","677","6760","6761","6762","6763","6764","6765",
                                                        "6766","6768","6769","679" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.ChinaUnionPay, new BrandInfo()
            {
                BrandName = "China UnionPay",
                SkipLuhn = true,
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16, 17, 18, 19 }, 
                        Prefixes = new List<String>() { "622", "624","625","626","628" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Dankort, new BrandInfo()
            {
                BrandName = "Dankort",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16 }, 
                        Prefixes = new List<String>() { "5019" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Rupay, new BrandInfo()
            {
                BrandName = "Rupay",
                SkipLuhn = true,
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 16 }, 
                        Prefixes = new List<String>() { "6061","6062","6063","6064","6065","6066",
                                                        "6067","6068","6069","607","608" }
                    }
                }
            });

            BrandsData.Add(CardIssuer.Hipercard, new BrandInfo()
            {
                BrandName = "19",
                Rules = new List<Rule>() 
                { 
                    new Rule() 
                    { 
                        Lengths = new List<int>() { 19 }, 
                        Prefixes = new List<String>() { "384" }
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
                        Lengths = new List<int>() { 15 }, 
                        Prefixes = new List<String>()
                    }
                }
            });


            #endregion
        }

    }
}
