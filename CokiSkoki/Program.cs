using System;
using System.Collections.Generic;
using System.Linq;

namespace CokiSkoki
{
    public static class Startup
    {
        private static void Main()
        {
            Console.ReadLine();
            var buildingsRaw = Console.ReadLine().Split();
            var buildings = new int[buildingsRaw.Length];
            // Cycle it manually to reduce processing time.
            for (int i = 0; i < buildingsRaw.Length; i++)
            {   
                buildings[i] = int.Parse(buildingsRaw[i]);
            }
            var jumpsArray = new int[buildings.Length];

            // Use RAM instead of cycling again thru the array to get the MAX value
            Stack<int> stack = new Stack<int>();

            for (int i = buildings.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && buildings[stack.Peek()] <= buildings[i])
                {
                    int peekIndex = stack.Pop();
                    jumpsArray[peekIndex] = stack.Count;
                }

                stack.Push(i);
            }

            while (stack.Count > 0)
            {
                int peekIndex = stack.Pop();
                jumpsArray[peekIndex] = stack.Count;
            }
            #region Old Solution
            /*int maxHigh = 0;
            for (var i = 0; i < buildings.Length; i++)
            {
                int lastHighestHeight = buildings[i], count = 0;
                for (var j = i + 1; j < buildings.Length; j++)
                    if (lastHighestHeight < buildings[j])
                    {
                        lastHighestHeight = buildings[j];
                        count++;
                    }

                jumpsArray[i] = count;
                if (count > maxHigh)
                    maxHigh = count;
            }*/
            #endregion
            
            Console.WriteLine(jumpsArray.Max() + Environment.NewLine + string.Join(" ", jumpsArray));
        }
    }
}