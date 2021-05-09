using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompilerCS
{
    class CppCompiler
    {
        private List<string> InputLines;
        public List<string> OutputLines;

        public CppCompiler(List<String> input)
        {
            InputLines = input;
            OutputLines = new List<string>();
            ExecuteTask();
        }

        private void ExecuteTask()
        {
            OutputLines.Add("#include<iostream>");
            OutputLines.Add("using namespace std;");
            OutputLines.Add("int main(){");
            OutputLines.AddRange(InputLines);
            OutputLines.Add("return 0;}");

            //TEST
            foreach (var line in OutputLines)
            {
                Console.WriteLine(line);   
            }

            File.WriteAllLines("program.cpp", OutputLines);
            System.Diagnostics.Process.Start("g++", "-Wall -Wextra -Werror -g program.cpp -o program.exe");
        }
    }
}
