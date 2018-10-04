using System;
using System.Collections.Generic;
using System.Linq;

namespace CokiSkoki
{
    public static class Startup
    {
        private static void Main()
        {
            var num = new List<int> { 12, 2, 6, 14, 8, 1, 5, 3, 12, 4, 9, 3, 10 };
            HashSet<int> hashSet = new HashSet<int>();
            var sum = 13;
            for (int i = 0; i < num.Count; i++)
            {
                if (hashSet.Contains(sum - num[i]))
                {
                    Console.WriteLine(sum - num[i] + " " + num[i]);
                }
                else
                {
                    hashSet.Add(num[i]);
                }
            }
        }
    }
}