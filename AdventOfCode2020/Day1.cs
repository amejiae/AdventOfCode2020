using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day1 : ProgramBase
    {
        private readonly List<int> _input1;
        private readonly List<int> _input2;
        private readonly List<int> _input3;

        public Day1()
        {
            _input1 = GetInputAsList();
            _input2 = GetInputAsList();
            _input3 = GetInputAsList();
        }

        public override void Solve()
        {
            Console.WriteLine(SolvePart1());
            Console.WriteLine(SolvePart2());
        }

        public string SolvePart1()
        {
            foreach (int expense in _input1)
            {
                foreach (var expense2 in _input2)
                {
                    if (expense + expense2 == 2020)
                    {
                        return (expense * expense2).ToString();
                    }
                }
            }

            return string.Empty;
        }

        public string SolvePart2()
        {
            foreach (int expense in _input1)
            {
                foreach (var expense2 in _input2)
                {
                    foreach (int expense3 in _input3)
                    {
                        if (expense + expense2 + expense3 == 2020)
                        {
                            return (expense * expense2 * expense3).ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }

        private List<int> GetInputAsList()
        {
            var inputFile = File.ReadLines(".\\Inputs\\Day1.txt");
            return inputFile.Select(inputLine => Convert.ToInt32(inputLine)).ToList();
        }
    }
}
