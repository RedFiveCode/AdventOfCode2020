using MoreLinq;
using System;
using System.Linq;
using System.Text;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();

            // part 1
            var passportRecords = reader.ReadRecords(RawData.Data);
            var validCount = passportRecords.Count(p => p.IsValid());

            // part 2
            var passportRecords2 = reader.ReadTypedRecords(RawData.Data); // "ecl:#e45ee0 pid:151cm cid:127 iyr:2014 byr:2022 hcl:973bc1 eyr:2033 hgt:181in");
            var validCount2 = passportRecords2.Count(p => p.IsValid() && p.AreFieldsPresent());

            var builder = new StringBuilder();
            var results = passportRecords2.Where(p => p.IsValid() && p.AreFieldsPresent()).ToList();
            Console.WriteLine($"JM ({results.Count})");
            results.ForEach(p => builder.Append(p.ToString()));
            Console.WriteLine(builder);

            var mh = new MarkHeathDay4();

            //var lines = RawData.Data.Replace("\r\n", "\n").Split('\n');

//            var lines = @"cid:177
//iyr:2013 byr:1926 hcl:#efcc98
//pid:298693475 hgt:181cm eyr:2023 ecl:dne".Replace("\r\n", "\n").Split('\n');

            var lines = @"pid:088166852 hgt:155cm cid:307 byr:1940
hcl:#7d3b0c
ecl:#af542f eyr:2023 iyr:2014".Replace("\r\n", "\n").Split('\n');

            mh.Solve(lines);
        }
    }
}
