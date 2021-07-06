using System;
using System.Linq;

namespace ClassTest
{
    class Program
    {
        static int[] possibleValues = new int[] { 0, -1, 1 };
        static void Main(string[] args)
        {

            var theMatrix = new int[2];
            //var x = 847288609443;

            //for (long i = 0; i < x; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //for (int index = 0; index < theMatrix.Length; index++)
            //{
            //    permutate(theMatrix, index);
            //}
            permutate(theMatrix);
        }

        static bool permutate(int[] theMatrix, int index = 0)
        {
            if (index >= theMatrix.Length)
            {
                return false;
            }

            foreach (var value in possibleValues)
            {
                theMatrix[index] = value;
                var permutated = permutate(theMatrix, index + 1);
                if (!permutated)
                {
                    Output(theMatrix);
                }
            }
            Console.WriteLine("\n");
            return true;
        }


        public static void Output(int[] theMatrix)
        {
            foreach (var cell in theMatrix)
            {
                Console.Write(cell);
                Console.Write(", ");
            }
            Console.WriteLine("\n");
        }

        //static bool hasABadNeighbor()
        //{
        //    return false;
        //}
    }
}
