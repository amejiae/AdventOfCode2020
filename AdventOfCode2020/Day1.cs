using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day1 : ProgramBase
    {
        public override void Solve()
        {
            List<int> input1 = GetInputAsList();
            List<int> input2 = GetInputAsList();
            List<int> input3 = GetInputAsList();

            foreach (int expense in input1)
            {
                foreach (var expense2 in input2)
                {
                    foreach (int expense3 in input3)
                    {
                        if (expense + expense2 + expense3 == 2020)
                        {
                            Console.WriteLine(expense * expense2 * expense3);
                        }
                    }
                }
            }
        }

        private List<int> GetInputAsList()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day1.txt");
            return inputFile.Select(inputLine => Convert.ToInt32(inputLine)).ToList();
        }
    }
}
