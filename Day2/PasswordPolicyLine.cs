using System;
using System.Linq;

namespace Day2
{
    class PasswordPolicyLine
    {
        public PasswordPolicyLine(int min, int max, char ch, string text)
        {
            Min = min;
            Max = max;
            Character = ch;
            Text = text;
        }

        public int Min { get; private set; }
        public int Max { get; private set; }

        public char Character { get; private set; }

        public string Text { get; private set; }

        public bool IsValid()
        {
            var count = Text.ToCharArray().Count(ch => ch == Character);

            return count >= Min && count <= Max;
        }

        public bool IsValidPartTwoRules()
        {
            var chars = Text.ToCharArray();

            int firstIndex = Min - 1;
            int secondIndex = Max - 1;

            return (chars[firstIndex] == Character ^ chars[secondIndex] == Character);
            //return (chars[firstIndex] == Character && chars[secondIndex] != Character) ||
            //       (chars[firstIndex] != Character && chars[secondIndex] == Character);
        }

        public override string ToString()
        {
            return $"{Min}-{Max} '{Character}' '{Text}'";
        }
    }
}
