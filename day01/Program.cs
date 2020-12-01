using System;
using System.IO;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new StreamReader(args[0]).ReadToEnd()
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => long.Parse(a))
                .OrderBy(a => a)
                .ToArray();
            // Part 1
            // long result = FindResult(numbers, 2020, 0);
            
            // Part 2
            long temp = 0;
            int i = 0;
            for (; i < numbers.Length - 2; i++)
            {
                temp = FindResult(numbers, 2020 - numbers[i], i + 1);
                if (temp != 0)
                {
                    break;
                }
            }

            Console.WriteLine(numbers[i] * temp);
        }


        private static long FindResult(long[] numbers, long target, int start)
        {
            int i = start;
            int j = numbers.Length - 1;
            while (i < j)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    break;
                }
                else if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            if (i < j)
            {
                return numbers[i] * numbers[j];
            }

            return 0;
        }
    }
}
