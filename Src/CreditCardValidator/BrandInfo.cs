using System.Collections.Generic;

namespace CreditCardValidator
{
    internal class BrandInfo
    {
        public BrandInfo()
        {
            Rules = new List<Rule>();
            BrandName = "Unknown";
            SkipLuhn = false;
        }

        public List<Rule> Rules { get; set; }
        public string BrandName { get; set; }
        public bool SkipLuhn { get; set; }
    }
}