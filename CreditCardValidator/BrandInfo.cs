using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
