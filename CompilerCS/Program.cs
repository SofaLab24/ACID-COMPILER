using System;

namespace CompilerCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer test = new Lexer(@"testProgram.acid");
            Parser parser = new Parser(test.Output);
            CppCompiler cppCompiler = new CppCompiler(parser.OutputLines);
        }
    }
}
