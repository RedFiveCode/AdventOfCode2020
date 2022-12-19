using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = @"C:\JM\Stuff\Advent of Code 2020\Day7\TestData.txt";

            var reader = new BagReader();
            //var bagList = reader.ReadBags(testData);
            var bagList = reader.ReadBagColours(testData).ToList();

            //var result = bagList.Where(b => b.ContainsBag("shiny gold")).ToList();
        }
    }
}
