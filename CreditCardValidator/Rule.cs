using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidator
{
    internal class Rule
    {
        public List<int> Lengths;
        public List<String> Prefixes;

        public Rule()
        {
            Lengths = new List<int>();
            Prefixes = new List<String>();
        }
    }
}
