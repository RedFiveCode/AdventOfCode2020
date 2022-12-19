using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Day7
{
    class BagReader
    {
        public List<Bag> ReadBags(string filename)
        {
            var bagList = new List<Bag>();

            var lines = File.ReadAllLines(filename);

            foreach(var line in lines)
            {
                var bag = ReadLine(line);
                bagList.Add(bag);
            }

            return bagList;
        }

        public Bag ReadLine(string line)
        {
            // light red bags contain 1 bright white bag, 2 muted yellow bags.
            // dark orange bags contain 3 bright white bags, 4 muted yellow bags.
            // bright white bags contain 1 shiny gold bag.
            // dotted black bags contain no other bags.

            var regex = new Regex(@"(.+ .+) bags contain (.*)");


            var match = regex.Match(line);

            if (!match.Success)
            {
                throw new ArgumentOutOfRangeException();
            }

            var bag = new Bag(match.Groups[1].Value);

            // parse second part - no contained bags
            regex = new Regex(@"no other bags\.");

            if (regex.IsMatch(line))
            {
                return bag;
            }

            var secondPart = match.Groups[2].Value;

            // parse second part - only one contained bag
            regex = new Regex(@"(\d) (.+ .+) bag\.");

            match = regex.Match(secondPart);

            if (match.Success)
            {
                var count = Int32.Parse(match.Groups[1].Value);
                var name = match.Groups[2].Value;

                bag.AddContainedBag(name, count);

                return bag;
            }

            // parse second part - only two contained bags
            regex = new Regex(@"(\d) (.+ .+) bags?, (\d) (.+ .+) bags?\.");

            match = regex.Match(secondPart);

            if (match.Success)
            {
                // only two contained bag colours

                int index = 1;
                while (index < match.Groups.Count)
                {
                    var count = Int32.Parse(match.Groups[index].Value);
                    var name = match.Groups[index + 1].Value;
                    bag.AddContainedBag(name, count);

                    index += 2;
                }

                return bag;
            }

            throw new ArgumentOutOfRangeException();
        }

        public List<string> ReadBagColours(string filename)
        {
            var results = new List<string>();

            var lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                var colours = ReadBagColoursFromLine(line);
                results.AddRange(colours);
            }

            return results;
        }

        private List<string> ReadBagColoursFromLine(string line)
        {
            var results = new List<string>();

            // "light red bags contain..."

            var regex = new Regex(@"(.+ .+) bags contain");

            var match = regex.Match(line);

            if (match.Success)
            {
                results.Add(match.Groups[1].Value);
            }

            // "...1 shiny gold bag."
            regex = new Regex(@"(\d+ (.+ .+) bag\.)");

            match = regex.Match(line);

            if (match.Success)
            {
                results.Add(match.Groups[2].Value);
            }

            // "...1 dark olive bag, 2 vibrant plum bags."
            regex = new Regex(@"(\d+ (.+ .+) bag,)");

            match = regex.Match(line);

            if (match.Success)
            {
                results.Add(match.Groups[2].Value);
            }


            return results;
        }
    }
}
