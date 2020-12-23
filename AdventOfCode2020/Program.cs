using System;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Day1();
            Console.WriteLine($"Part1: {problem.SolvePart1()}");
            Console.WriteLine($"Part2: {problem.SolvePart2()}");

            Console.ReadLine();
        }
    }
}
