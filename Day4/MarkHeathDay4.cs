
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day4
{
    class MarkHeathDay4
    {
		// from https://github.com/markheath/AdventOfCode2020/blob/master/AdventOfCode2020/Day4.cs
		public (string, string) ExpectedResult => ("204", "179");
		private static readonly string[] expectedFields = "byr;iyr;eyr;hgt;hcl;ecl;pid".Split(';'); // cid not needed

		public IEnumerable<Dictionary<string, string>> ParsePassports(IEnumerable<string> lines)
		{
			return lines.Split("")
				.Select(b => b.SelectMany(line => line.Split(' '))
					.Select(p => p.Split(':'))
					.ToDictionary(p => p[0], p => p[1]));
		}

		public bool IsPassportValid(Dictionary<string, string> passport)
		{
			return expectedFields.All(p => passport.ContainsKey(p));
		}
		public bool IsPassportValid2(Dictionary<string, string> passport)
		{
			var hasAllFields = expectedFields.All(p => passport.ContainsKey(p));
			if (!hasAllFields) return false;
			var birthYear = Int32.Parse(passport["byr"]);
			var issueYear = Int32.Parse(passport["iyr"]);
			var expirationYear = Int32.Parse(passport["eyr"]);
			var height = passport["hgt"];
			var hairColor = passport["hcl"];
			var eyeColor = passport["ecl"];
			var passportId = passport["pid"];

			if (birthYear < 1920 || birthYear > 2002) return false;
			if (issueYear < 2010 || issueYear > 2020) return false;
			if (expirationYear < 2020 || expirationYear > 2030) return false;
			if (!Regex.IsMatch(hairColor, "^#[0-9a-f]{6}$")) return false;
			if (!Regex.IsMatch(eyeColor, "^amb|blu|brn|gry|grn|hzl|oth$")) return false;
			if (!Regex.IsMatch(passportId, "^[0-9]{9}$")) return false;
			if (height.EndsWith("cm"))
			{
				if (int.TryParse(height.Substring(0, height.Length - 2), out var cm))
				{
					if (cm < 150 || cm > 193) return false;
				}
				else
				{
					return false;
				}
			}
			else if (height.EndsWith("in"))
			{
				if (int.TryParse(height.Substring(0, height.Length - 2), out var inches))
				{
					if (inches < 59 || inches > 76) return false;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			return true;

		}

		public (string, string) Solve(IEnumerable<string> input)
		{
			var x = ParsePassports(input);

			var result = x.Where(p => IsPassportValid2(p)).ToList();

			Console.WriteLine($"MH ({result.Count})");
			var builder = new StringBuilder();
			result.ForEach(p => builder.Append(ToString(p)));
			Console.WriteLine(builder);

			var a = ParsePassports(input).Count(IsPassportValid).ToString();
			var b = ParsePassports(input).Count(IsPassportValid2).ToString();
			return (a, b);
		}

		public string ToString(Dictionary<string, string> map)
		{
			var builder = new StringBuilder();
			builder.Append($"BirthYear={GetValue(map, "byr")}, ");
			builder.Append($"IssueYear={GetValue(map, "iyr")}, ");
			builder.Append($"ExpirationYear={GetValue(map, "eyr")}, ");
			builder.Append($"Height={GetValue(map, "hgt")}, ");
			builder.Append($"HairColour={GetValue(map, "hcl")}, ");
			builder.Append($"EyeColour={GetValue(map, "ecl")}, ");
			builder.Append($"PassportId={GetValue(map, "pid")}");
			builder.AppendLine();

			return builder.ToString();
		}

		public string GetValue(Dictionary<string, string> map, string key)
        {
			if (map.ContainsKey(key))
            {
				return map[key];
            }

			return "(none)";
        }
	}
}
