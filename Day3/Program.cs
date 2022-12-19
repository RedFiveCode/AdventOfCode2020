using System;
using System.Collections.Generic;
using System.Drawing;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {

            var reader = new MapReader();

            //var dataFile = @"C:\JM\Stuff\Advent of Code 2020\Day3\Day3Test.txt";
            var dataFile = @"C:\JM\Stuff\Advent of Code 2020\Day3\Day3.txt";

            var map = reader.ReadMap(dataFile);

            var navigator = new MapNavigator(map);


            // Part One
            var count = navigator.Navigate(3, 1);

            Console.WriteLine($"Tree count {count}");

            // Part Two
            var slopes = new List<Point>() {    new Point(1,1),
                                                new Point(3,1),
                                                new Point(5,1),
                                                new Point(7,1),
                                                new Point(1,2)};

            int product = 1;
            foreach (var p in slopes)
            {
                var treeCount = navigator.Navigate(p.X, p.Y);

                product *= treeCount;
            }

            Console.WriteLine($"Tree product count {product}");

        }
    }
}
