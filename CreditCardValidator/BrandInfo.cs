using System;
using System.Collections.Generic;

namespace CreditCardValidator
{
    internal class BrandInfo
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
}
