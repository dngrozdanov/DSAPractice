using System;
using System.Text;
using System.Collections.Generic;

namespace Expressions
{
    class Solution
    {
        public static List<String> answer;

        public static String digits;

        public static long target;

        static void Main()
        {
            AddOperators(Console.ReadLine(), int.Parse(Console.ReadLine()));
            Console.WriteLine(answer.Count);
        }

        public static void Recurse(int index, long value, StringBuilder ops, long previousValue)
        {
            String nums = digits;

            if ((index == nums.Length))
            {
                if ((value == target))
                {
                    answer.Add(ops.ToString());
                }

                return;
            }

            long current_val = 0;
            String current_val_rep = null;
            int length = nums.Length;

            for (int i = index; (i < length); i++)
            {

                current_val = (long)((current_val * 10)
                               + Char.GetNumericValue(nums[i]));
                current_val_rep = current_val.ToString();

                if ((index == 0))
                {
                    Recurse((i + 1), current_val, new StringBuilder(ops.ToString() + (current_val_rep)), current_val);
                }
                else
                {
                    long v = (value - previousValue);

                    Recurse((i + 1), (v
                                    + (previousValue * current_val)), new StringBuilder(ops.ToString() + '*' + (current_val_rep)), (previousValue * current_val));

                    Recurse((i + 1), (value + current_val), new StringBuilder(ops.ToString() + '+' + current_val_rep), current_val);

                    Recurse((i + 1), (value - current_val), new StringBuilder(ops.ToString() + '-' + current_val_rep), (current_val * -1));
                }

                if ((nums[index] == '0'))
                {
                    break;
                }
            }
        }

        public static List<String> AddOperators(String num, int tempTarget)
        {
            if ((num.Length == 0))
            {
                return new List<String>();
            }

            target = tempTarget;
            digits = num;
            answer = new List<String>();
            Recurse(0, 0, new StringBuilder(), 0);
            return answer;
        }
    }
}