using System;
using System.Collections.Generic;

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
