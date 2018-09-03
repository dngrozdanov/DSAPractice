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
                tempDictionary.Add(item, Passengers.AddLast(item));
            }
            for (int i = 0; i < int.Parse(numbers[1]); i++)
            {
                string inputLine = Console.ReadLine();
                var toBeMoved = tempDictionary[inputLine.Substring(0,inputLine.IndexOf(' '))];
                var toBeMovedNextTo = tempDictionary[inputLine.Substring(inputLine.IndexOf(' ') + 1)];
                Passengers.Remove(toBeMoved);
                Passengers.AddBefore(toBeMovedNextTo, toBeMoved);
            }
            Console.WriteLine(string.Join(" ", Passengers));
        }
    }
}