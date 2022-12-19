using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    class Reader
    {
        public List<PassportRecord> ReadRecords(string data)
        {
            var passportList = new List<PassportRecord>();

            using (var reader = new StringReader(data))
            {
                var currentLine = reader.ReadLine();
                var currentChunk = new StringBuilder();

                while (currentLine != null)
                {
                    // assemble current line into chunks
                    if (currentLine.Length != 0)
                    {
                        currentChunk.AppendLine(currentLine);
                    }
                    else
                    {
                        var passport = ParseChunk(currentChunk.ToString());

                        passportList.Add(passport);

                        currentChunk.Clear();
                    }

                    currentLine = reader.ReadLine(); // next line
                }
                // read last chunk
                if (currentChunk.Length > 0)
                {
                    var passport = ParseChunk2(currentChunk.ToString());
                    passportList.Add(passport);
                }
            }


            return passportList;
        }

        public List<TypedPassportRecord> ReadTypedRecords(string data)
        {
            var passportList = new List<TypedPassportRecord>();

            using (var reader = new StringReader(data))
            {
                var currentLine = reader.ReadLine();
                var currentChunk = new StringBuilder();

                while (currentLine != null)
                {
                    // assemble current line into chunks
                    if (currentLine.Length != 0)
                    {
                        currentChunk.AppendLine(currentLine);
                    }
                    else
                    {
                        var passport = ParseTypedChunk(currentChunk.ToString());

                        passportList.Add(passport);

                        currentChunk.Clear();
                    }

                    currentLine = reader.ReadLine(); // next line
                }
                // read last chunk
                if (currentChunk.Length > 0)
                {
                    var passport = ParseTypedChunk(currentChunk.ToString());
                    passportList.Add(passport);
                }
            }


            return passportList;
        }

        private PassportRecord ParseChunk(string chunk)
        {
            var passport = new PassportRecord();

            // "iyr:2010 ecl:gry hgt:181cm pid: 591597745\r\nbyr:1920 hcl:#6b5442 eyr:2029 cid:123"
            var line = chunk.Replace(Environment.NewLine, " ");

            // "iyr:2010 ecl:gry hgt:181cm pid: 591597745 byr:1920 hcl:#6b5442 eyr:2029 cid:123"
            var fields = line.Split(' ');

            foreach (var field in fields)
            {
                var keyValue = field.Split(':');

                if (keyValue.Length >= 2)
                {
                    var key = keyValue[0];
                    var value = keyValue[1];

                    switch (key)
                    {
                        case "byr": passport.BirthYear = value; break;
                        case "iyr": passport.IssueYear = value; break;
                        case "eyr": passport.ExpirationYear = value; break;
                        case "hgt": passport.Height = value; break;
                        case "hcl": passport.HairColour = value; break;
                        case "ecl": passport.EyeColour = value; break;
                        case "pid": passport.PassportId = value; break;
                        case "cid": passport.CountryId = value; break;

                        default: throw new ArgumentOutOfRangeException();
                    }
                }
            }

            return passport;
        }

        private PassportRecord ParseChunk2(string chunk)
        {
            var passport = new PassportRecord();

            // "iyr:2010 ecl:gry hgt:181cm pid: 591597745\r\nbyr:1920 hcl:#6b5442 eyr:2029 cid:123"
            var line = chunk.Replace(Environment.NewLine, " ");


            // "iyr:2010 ecl:gry hgt:181cm pid: 591597745 byr:1920 hcl:#6b5442 eyr:2029 cid:123"
            passport.BirthYear = GetMatchingText(line, "byr");
            passport.IssueYear = GetMatchingText(line, "iyr");
            passport.ExpirationYear = GetMatchingText(line, "eyr");

            passport.Height = GetMatchingText(line, "hgt");

            passport.HairColour = GetMatchingText(line, "hcl");
            passport.EyeColour = GetMatchingText(line, "ecl");

            passport.PassportId = GetMatchingText(line, "pid");
            passport.CountryId = GetMatchingText(line, "cid");

            return passport;
        }

        private TypedPassportRecord ParseTypedChunk(string chunk)
        {
            var passport = new TypedPassportRecord();

            // "iyr:2010 ecl:gry hgt:181cm pid: 591597745\r\nbyr:1920 hcl:#6b5442 eyr:2029 cid:123"
            var line = chunk.Replace(Environment.NewLine, " ");


            // "iyr:2010 ecl:gry hgt:181cm pid: 591597745 byr:1920 hcl:#6b5442 eyr:2029 cid:123"

            if (ContainsMatchingKey(line, "byr"))
            {
                passport.BirthYear = GetMatchingNumber(line, "byr");
            }

            if (ContainsMatchingKey(line, "iyr"))
            {
                passport.IssueYear = GetMatchingNumber(line, "iyr");
            }

            if (ContainsMatchingKey(line, "eyr"))
            {
                passport.ExpirationYear = GetMatchingNumber(line, "eyr");
            }

            if (ContainsMatchingKey(line, "hgt"))
            {
                var height = GetMatchingText(line, "hgt");

                if (height.EndsWith("cm"))
                {
                    var digits = height.Replace("cm", "");
                    passport.Height = Int32.Parse(digits);
                    passport.HeightUnits = HeightUnits.Centimetres;
                }
                else if (height.EndsWith("in"))
                {
                    var digits = height.Replace("in", "");
                    passport.Height = Int32.Parse(digits);
                    passport.HeightUnits = HeightUnits.Inches;
                }
            }

            if (ContainsMatchingKey(line, "hcl"))
            {
                passport.HairColour = GetMatchingText(line, "hcl");
            }

            if (ContainsMatchingKey(line, "ecl"))
            {
                var eyeColour = GetMatchingText(line, "ecl");

                passport.EyeColour = GetEyeColour(eyeColour);
            }

            if (ContainsMatchingKey(line, "pid"))
            {
                passport.PassportId = GetMatchingText(line, "pid");
            }

            if (ContainsMatchingKey(line, "cid"))
            {
                passport.CountryId = GetMatchingText(line, "cid");
            }

            return passport;
        }

        private bool ContainsMatchingKey(string line, string key)
        {
            var regex = new Regex($@"{key}:(.+) ");

            var match = regex.Match(line);

            return match.Success;
        }

        private int GetMatchingNumber(string line, string key)
        {
            var regex = new Regex($@"{key}:(\d+) ");

            var match = regex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            return Int32.Parse(match.Groups[1].Value);
        }

        private string GetMatchingText(string line, string key)
        {
            var regex = new Regex($@"{key}:(.+?) ");

            var match = regex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            return match.Groups[1].Value;
        }

        private EyeColour GetEyeColour(string text)
        {
            switch (text)
            {
                // amb blu brn gry grn hzl oth
                case "amb": return EyeColour.Amber; 
                case "blu": return EyeColour.Blue;
                case "brn": return EyeColour.Brown;
                case "gry": return EyeColour.Grey;
                case "grn": return EyeColour.Green;
                case "hzl": return EyeColour.Hazel;
                case "oth": return EyeColour.Other;
                default: return EyeColour.Unknown;
            }
        }
    }
}
