using System;
using System.Collections.Generic;
using System.Text;

namespace CompilerCS
{
    class Parser
    {
        private List<List<Tuple<int, string>>> Input;
        public List<string> OutputLines;
        public Parser(List<List<Tuple<int, string>>> output)
        {
            Input = output;
            OutputLines = new List<string>();
            ExecuteTask();
        }

        private void ExecuteTask()
        {
            foreach (var line in Input)
            {
                string outLine = "";
                bool printStart = false;
                bool printEnd = false;
                foreach (var element in line)
                {
                    if (element.Item2.Equals("print"))
                    {
                        outLine += "cout << ";
                        printStart = printEnd = true;
                    }
                    else if (element.Item2.Equals("int"))
                    {
                        outLine += "int ";
                    }
                    else if (element.Item2.Equals("(") && printStart)
                    {
                        printStart = false;
                    }
                    else if (element.Item2.Equals(")") && printEnd)
                    {
                        printEnd = false;
                        outLine += "<<endl;";
                    }
                    else
                    {
                        outLine += element.Item2;
                    }
                }

                outLine += ";";
                OutputLines.Add(outLine);
            }
        }
    }
}
