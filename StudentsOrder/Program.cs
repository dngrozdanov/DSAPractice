using System;
using System.Collections.Generic;

namespace StudentsOrder
{
    static class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split();
            var input = Console.ReadLine().Split();
            var Passengers =
                new LinkedList<string>();
            var tempDictionary = new Dictionary<string, LinkedListNode<string>>();
            foreach (var item in input)
            {
                var node = Passengers.AddLast(item);
                tempDictionary.Add(item, node);
            }
            for (int i = 0; i < int.Parse(numbers[1]); i++)
            {
                var temp = Console.ReadLine().Split();
                Passengers.Remove(temp[0]);
                Passengers.AddBefore(tempDictionary[temp[1]], temp[0]);
                tempDictionary[temp[0]] = Passengers.AddBefore(tempDictionary[temp[1]], temp[0]);
            }
            foreach (var item in Passengers)
            {
                Console.Write(item + " ");
            }
        }
    }
}