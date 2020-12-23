using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day2 : ProgramBase
    {
        private readonly IEnumerable<PasswordEntry> _input;

        public Day2()
        {
            _input = GetInputAsList();
        }
        public override void Solve()
        {
            SolvePart1();
            SolvePart2();
        }

        private void SolvePart1()
        {
            var input = GetInputAsList();
            int validPasswords = 0;
            foreach (PasswordEntry passwordEntry in input)
            {
                if (IsPasswordValidPart1(passwordEntry))
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
        }

        private void SolvePart2()
        {
            int validPasswords = 0;
            foreach (PasswordEntry passwordEntry in _input)
            {
                if (IsPasswordValidPart2(passwordEntry))
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
        }

        private static bool IsPasswordValidPart1(PasswordEntry passwordEntry)
        {
            int characterOccurrences = passwordEntry.Password.Count(f => f == passwordEntry.Character);

            if (characterOccurrences >= passwordEntry.Min && characterOccurrences <= passwordEntry.Max)
            {
                return true;
            }

            return false;
        }

        private static bool IsPasswordValidPart2(PasswordEntry passwordEntry)
        {
            var positionOneValue = passwordEntry.Password.Substring(passwordEntry.Min - 1, 1);
            var positionTwoValue = passwordEntry.Password.Substring(passwordEntry.Max - 1, 1);

            if (positionOneValue == passwordEntry.Character.ToString() && positionTwoValue == passwordEntry.Character.ToString())
            {
                return false;
            }

            if (positionOneValue == passwordEntry.Character.ToString() || positionTwoValue == passwordEntry.Character.ToString())
            {
                return true;
            }

            return false;
        }

        private IEnumerable<PasswordEntry> GetInputAsList()
        {
            var passwordEntries = new List<PasswordEntry>();
            var lines = File.ReadLines(".\\Inputs\\Day2.txt").ToList();

            foreach (string line in lines)
            {
                var passwordEntry = GetPassWordEntryFromInput(line);
                
                passwordEntries.Add(passwordEntry);
            }

            return passwordEntries;
        }

        private static PasswordEntry GetPassWordEntryFromInput(string line)
        {
            var entry = new PasswordEntry();
            entry.Min = int.Parse(line.Substring(0, line.IndexOf('-')));
            entry.Max = int.Parse(line.Substring(line.IndexOf('-') + 1, 2));
            entry.Character = line.Substring(line.IndexOf(':') - 1, 1).ToCharArray().First();
            entry.Password = line.Substring(line.IndexOf(':') + 1).Trim();

            return entry;
        }
    }

    internal class PasswordEntry
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char Character { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Min}-{Max} {Character}:{Password}";
        }
    }
}
