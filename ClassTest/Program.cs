using System;
using System.Linq;

namespace ClassTest
{
    class Program
    {
        static int[] possibleValues = new int[] { 0, -1, 1 };
        static int[] theMatrix = new int[4];
        static int desiredSum = 3;
        static void Main(string[] args)
        {
            permutate();
        }

        static void permutate(int index = 0)
        {
            if (index < theMatrix.Length)
            {
                foreach (var value in possibleValues)
                {
                    var totalSum = theMatrix.Sum(i => Math.Abs(i));

                    if (totalSum > desiredSum || hasABadNeighbor(index))
                    {
                        theMatrix[index] = 0;
                        return;
                    }

                    if (totalSum == desiredSum)
                    {
                        Output(theMatrix);
                        return;
                    }

                    theMatrix[index] = value;
                    permutate(index + 1);

                }
            }
        }


        public static void Output(int[] theMatrix)
        {
            for (int i = 0; i < theMatrix.Length; i++)
            {
                //Console.Write($"{i}: {theMatrix[i]}, ");
                Console.Write($"{theMatrix[i]}, ");
            }
            Console.WriteLine("\n");
        }

        static bool hasABadNeighbor(int index)
        {
            if (theMatrix[index] == 0)
            {
                return false;
            }

            var matrixSideLength = ((int)Math.Sqrt(theMatrix.Length));

            var leftIndex = index - 1;
            var rightIndex = index + 1;
            var topIndex = index + matrixSideLength;
            var bottomIndex = index - matrixSideLength;

            var topLeftIndex = index + matrixSideLength - 1;
            var topRightIndex = index + matrixSideLength + 1;
            var bottomLeftIndex = index - (matrixSideLength + 1);
            var bottomRightIndex = index - (matrixSideLength - 1);

            if (isAdjacentDifferent(index, leftIndex)
                || isAdjacentDifferent(index, rightIndex)
                || isAdjacentDifferent(index, topIndex)
                || isAdjacentDifferent(index, bottomIndex))
            {
                return true;
            }

            if(isItWithinArrayLimitAndNotZero(topLeftIndex) && theMatrix[index] == -1 && theMatrix[topLeftIndex] == -1)
            {
                return true;
            }

            if (isItWithinArrayLimitAndNotZero(bottomRightIndex) && theMatrix[index] == -1 && theMatrix[bottomRightIndex] == -1)
            {
                return true;
            }

            if (isItWithinArrayLimitAndNotZero(topRightIndex) && theMatrix[index] == 1 && theMatrix[topRightIndex] == 1)
            {
                return true;
            }

            if (isItWithinArrayLimitAndNotZero(bottomLeftIndex) && theMatrix[index] == 1 && theMatrix[bottomLeftIndex] == 1)
            {
                return true;
            }


            return false;
        }

        public static bool isAdjacentDifferent(int index, int adjacentIndex)
        {
            if (isItWithinArrayLimitAndNotZero(adjacentIndex) && theMatrix[adjacentIndex] != theMatrix[index])
            {
                return true;
            }
            return false;
        }

        public static bool isItWithinArrayLimitAndNotZero(int index)
        {
            return index > 0 && index < theMatrix.Length && theMatrix[index] != 0;
        }

        static bool tempCondition()
        {
            return theMatrix[8] == -1
                && theMatrix[7] == -1
                && theMatrix[6] == 1;
        }
    }
}
