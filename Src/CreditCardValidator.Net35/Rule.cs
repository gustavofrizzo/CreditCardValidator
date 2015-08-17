using System.Collections.Generic;

namespace CreditCardValidator
{
    internal class Rule
    {
        public Rule()
        {
            Lengths = new List<int>();
            Prefixes = new List<string>();
        }

        public List<int> Lengths { get; set; }
        public List<string> Prefixes { get; set; }
    }
}