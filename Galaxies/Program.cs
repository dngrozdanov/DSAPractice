using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxies
{
    static class Program
    {
        static char[,] Matrix;
        static List<int> Galaxies = new List<int>();
        static int BestCounter = 0;

        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int height = input[0];
            int width = input[1];
            Matrix = new char[height, width];

            FillMatrix();

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int y = 0; y < Matrix.GetLength(1); y++)
                {
                    TraverseMatrix(new Vector2(i, y));
                    if (BestCounter != 0)
                    {
                        Galaxies.Add(BestCounter);
                        BestCounter = 0;
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, Galaxies.OrderByDescending(x => x)));
            // DEBUG
            //PrintMatrix();
        }

        static void TraverseMatrix(Vector2 currentPos)
        {
            if (currentPos.X >= Matrix.GetLength(0))
                return;
            if (currentPos.Y >= Matrix.GetLength(1))
                return;
            if (currentPos.X < 0)
                return;
            if (currentPos.Y < 0)
                return;

            if (Matrix[currentPos.X, currentPos.Y] == '2')
                return;

            if (Matrix[currentPos.X, currentPos.Y] == '1')
            {
                BestCounter++;

                Matrix[currentPos.X, currentPos.Y] = '2';

                TraverseMatrix(new Vector2(currentPos.X + 1, currentPos.Y));
                TraverseMatrix(new Vector2(currentPos.X - 1, currentPos.Y));
                TraverseMatrix(new Vector2(currentPos.X, currentPos.Y + 1));
                TraverseMatrix(new Vector2(currentPos.X, currentPos.Y - 1));
            }
        }

        public class Vector2
        {
            public Vector2(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

        public static void FillMatrix()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                var lane = Console.ReadLine();
                for (int y = 0; y < Matrix.GetLength(1); y++)
                {
                    Matrix[i, y] = lane[y];
                }
            }
        }

        public static void PrintMatrix()
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < Matrix.GetLength(1); col++)
                    Console.Write(String.Format("{0} ", Matrix[row, col]));
                Console.WriteLine();
            }
        }
    }
}