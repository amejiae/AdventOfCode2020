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
            List<PasswordEntry> validPasswords = new List<PasswordEntry>();
            List<PasswordEntry> invalidPasswords = new List<PasswordEntry>();

            foreach (PasswordEntry passwordEntry in input)
            {
                if (IsPasswordValid(passwordEntry))
                {
                    validPasswords.Add(passwordEntry);
                }
                else
                {
                    invalidPasswords.Add(passwordEntry);
                }
            }

            Console.WriteLine(validPasswords);
        }

        private bool IsPasswordValid(PasswordEntry passwordEntry)
        {
            int characterOccurences = passwordEntry.Password.Count(f => f == passwordEntry.Character);
            if (characterOccurences >= passwordEntry.Min && characterOccurences <= passwordEntry.Max)
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
