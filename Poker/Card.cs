using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Card
    {
        public int Number { get; set; }
        public string Pattern { get; set; }

        public Card(int number, string pattern)
        {
            Number = number;
            Pattern = pattern;
        }
    }
}