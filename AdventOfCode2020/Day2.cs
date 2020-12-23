using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class Day2 : ProgramBase
    {
        public override void Solve()
        {
            var input = GetInputAsList();
            int validPasswords = 0;

            foreach (PasswordEntry passwordEntry in input)
            {
                if (IsPasswordValid(passwordEntry))
                {
                    validPasswords ++;
                }
            }

            Console.WriteLine(validPasswords);
        }

        private bool IsPasswordValid(PasswordEntry passwordEntry)
        {
            int characterOccurences = passwordEntry.Password.Split(passwordEntry.Character).Length - 1;
            if (Enumerable.Range(passwordEntry.Min, passwordEntry.Max).Contains(characterOccurences))
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
            entry.Character = line.Substring(line.IndexOf(':') - 1, 1);
            entry.Password = line.Substring(line.IndexOf(':') + 1).Trim();

            return entry;
        }
    }

    internal class PasswordEntry
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string Character { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Min}-{Max} {Character}:{Password}";
        }
    }
}
