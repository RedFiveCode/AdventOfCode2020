using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();

            var results = reader.ReadPairData();

            foreach(var result in results)
            {
                Console.WriteLine($"{result} => {result.Product()}");
            }

            var tripleResults = reader.ReadTripleData();

            foreach (var result in tripleResults)
            {
                Console.WriteLine($"{result} => {result.Product()}");
            }
        }
    }
}
