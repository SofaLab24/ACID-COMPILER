using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CompilerCS
{
    class Lexer
    {
        private string FileName;
        private List<string> codeLines;
        public List<List<Tuple<int, string>>> Output;
        private TokenEnumerator Tokens;

        public Lexer(string fileName)
        {
            FileName = fileName;
            codeLines = File.ReadAllText(fileName).Split(';', StringSplitOptions.RemoveEmptyEntries).ToList();
            Output = new List<List<Tuple<int, string>>>();
            Tokens = new TokenEnumerator();
            ExecuteTasks();
        }

        private void ExecuteTasks()
        {
            foreach (var line in codeLines)
            {
                List<Tuple<int, string>> lexedLine = new List<Tuple<int, string>>();
                foreach (var token in line.Split(new []{' ', '\n', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Tokens.Contains(token))
                    {
                        lexedLine.Add(new Tuple<int, string>(Tokens.TokenDictionary[token], token));
                    }
                    else
                    {
                        bool isDigit = true;
                        foreach (var charOfToken in token)
                        {
                            if (!Char.IsDigit(charOfToken))
                            {
                                isDigit = false;
                            }
                        }

                        if (isDigit)
                        {
                            lexedLine.Add(new Tuple<int, string>(Tokens.TokenDictionary["integer"], token));
                        }
                        else
                        {
                            lexedLine.Add(new Tuple<int, string>(Tokens.TokenDictionary["variable"], token));
                        }
                    }
                }
                Output.Add(lexedLine);
            }
        }
    }
}
