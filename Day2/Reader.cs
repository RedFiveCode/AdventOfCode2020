using System;
using System.Text.RegularExpressions;

namespace Day2
{
    class Reader
    {
        public PasswordPolicyLine ReadLine(string line)
        {
            var regex = new Regex(@"(\d+)\-(\d+) (.): (.*)");

            var match = regex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            var min = Int32.Parse(match.Groups[1].Value);
            var max = Int32.Parse(match.Groups[2].Value);
            char ch = match.Groups[3].Value[0];
            var text = match.Groups[4].Value;

            return new PasswordPolicyLine(min, max, ch, text);   
        }
    }
}
