using System;
using System.Collections.Generic;
using System.Linq;

namespace GreaterMoney
{
    class Program
    {
        static void Main()
        {
            var firstBag = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            var secondBag = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            var resultBag = new List<int>();
            for (int i = 0; i < firstBag.Count; i++)
            {
                for (int y = secondBag.IndexOf(firstBag[i]); y < secondBag.Count; y++)
                {
                    if (firstBag[i] < secondBag[y])
                    {
                        resultBag.Add(secondBag[y]);
                        break;
                    }
                    if (y == secondBag.Count - 1)
                    {
                        resultBag.Add(-1);
                    }
                }
            }
            Console.WriteLine(string.Join(",", resultBag));
        }
    }
}