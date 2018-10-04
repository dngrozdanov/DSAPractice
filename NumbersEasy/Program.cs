using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace NumbersEasy
{
    static class Program
    {
        static void Main()
        {
            BigInteger? currentNumber = null;
            string input;
            StringBuilder stringBuilder = new StringBuilder();

            while ((input = Console.ReadLine()) != "end")
            {
                // Command Manager
                string[] tempInput = input.Split();
                string command = tempInput[0];
                string args = "";
                if (tempInput.Length > 1)
                    args = tempInput[1];

                switch (command)
                {
                    case "print":
                        {
                            if (currentNumber.ToString().Length > 0)
                                stringBuilder.AppendLine(currentNumber.ToString());
                            else
                                stringBuilder.AppendLine();
                            break;
                        }
                    case "set":
                        currentNumber = BigInteger.Parse(args);
                        break;
                    case "front-add":
                        currentNumber = BigInteger.Parse(args + currentNumber.ToString());
                        break;
                    case "front-remove":
                        {
                            if (currentNumber.ToString().Length > 0)
                                currentNumber = BigInteger.Parse(currentNumber.ToString().Remove(0, 1));
                            break;
                        }
                    case "back-add":
                        currentNumber = BigInteger.Parse(currentNumber.ToString() + args);
                        break;
                    case "back-remove":
                        {
                            if (currentNumber.ToString().Length > 0)
                                currentNumber = BigInteger.Parse(currentNumber.ToString().Remove(currentNumber.ToString().Length - 1));
                            break;
                        }
                    case "reverse":
                        {
                            if (currentNumber.ToString().Length > 0)
                                currentNumber = BigInteger.Parse(currentNumber.ToString().Reverse().Aggregate("", (s, c) => s + c));
                            break;
                        }
                }
            }
            Console.WriteLine(stringBuilder.ToString().TrimEnd());
        }
    }
}