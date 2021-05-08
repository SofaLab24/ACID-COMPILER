using System;
using System.Collections.Generic;
using System.Text;

namespace CompilerCS
{
    class TokenEnumerator
    {
        public Dictionary<string, int> TokenDictionary;

        public TokenEnumerator()
        {
            TokenDictionary = new Dictionary<string, int>()
            {
                {"EOF", 0},
                {"(", 1},
                {")", 2},
                {"int", 3},
                {"string", 4},
                {"integer", 5},
                {"variable", 6},
                {"=", 7},
                {"*", 8},
                {"/", 9},
                {"+", 10},
                {"-", 11},
                {"print", 12},
                {"error", 99}
            };
        }

        public bool Contains(string value)
        {
            foreach (var token in TokenDictionary)
            {
                if (token.Key == value) return true;
            }

            return false;
        }
    }
}
