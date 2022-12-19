using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new Reader();

            var results = new List<PasswordPolicyLine>();

            foreach (var line in RawData.Data)
            {
                var policy = reader.ReadLine(line);

                // Part 1
                //if (policy.IsValid())
                //{
                //    results.Add(policy);
                //}

                // Part 2
                if (policy.IsValidPartTwoRules())
                {
                    results.Add(policy);
                }
            }


            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
