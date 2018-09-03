using System;
using System.Collections;
using System.Collections.Generic;

namespace HDNLToy
{
    static class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            for (int i = 0; i < num; i++)
            {
                stack.Push(Console.ReadLine());
            }

            foreach (var item in stack)
            {
                var current = int.Parse(item[2].ToString());

                if (current)
                {

                }
            }

        }
    }
}