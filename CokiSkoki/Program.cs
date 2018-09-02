using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CokiSkoki
{
    public static class Startup
    {
        private static void Main()
        {
            //Console.ReadLine();
            int[] buildings = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] jumpsArray = new int[buildings.Length];

            for (int i = 0; i < buildings.Length; i++)
            {
                for (int j = i + 1; j < buildings.Length; j++)
                {
                    if (buildings[i] < buildings[j])
                        jumpsArray[i]++;
                }
            }

            Console.WriteLine(string.Join(" ", jumpsArray));
        }
    }
}