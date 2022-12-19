using System;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();

            var testData = @"C:\JM\Stuff\Advent of Code 2020\Day6\TestData.txt";
            var data = @"C:\JM\Stuff\Advent of Code 2020\Day6\Data.txt";

            // Part One
            var groups = reader.Read(data);

            var plane = new Plane();
            plane.AddGroups(groups);

            Console.WriteLine($"Count {plane.Sum}"); // 6911

            // Part Two

            var groupOfPeople = reader.ReadGroups(data);

            //groupOfPeople.ForEach(g => g.GetQuestions());
            var sum = groupOfPeople.Sum(g => g.CountQuestionsWhereEveryoneAnsweredYes());

            Console.WriteLine($"Sum {sum}"); // 3473
        }
    }
}
