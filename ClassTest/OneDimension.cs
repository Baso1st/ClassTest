using System;
using System.IO;
using System.Linq;

namespace ClassTest
{
    class OneDimension
    {
        static int[] possibleValues = new int[] { 0, -1, 1};
        static int matrixSideLength = 5;
        static int[,] theMatrix = new int[matrixSideLength, matrixSideLength];
        static int[] theMatrixAsArray = new int[matrixSideLength * matrixSideLength];
        static int desiredSum = 16;
        static long counter = 0;
        static bool foundSolution = false;
        static int totalSum = 0;
        public static void permutate(int index = 0)
        {
            if (foundSolution || totalSum > desiredSum)
            {
                return;
            }

            if ((theMatrixAsArray.Length - index) < (desiredSum - totalSum))
            {
                return;
            }

            foreach (var value in possibleValues)
            {
                counter++;
                if (counter % 1000000 == 0)
                {
                    var count = (counter / 1000000);
                    //Console.WriteLine(count);
                    File.WriteAllText("TheCounter.txt", $"{count}");
                }

                InsertIntoTheMatrixAndTheArray(index, value);

                if (hasABadNeighbor(index))
                {
                    continue;
                }

                totalSum = Sum();

                if (totalSum == desiredSum)
                {
                    Output();
                    //foundSolution = true;
                    return;
                }
                if ((index + 1) < theMatrixAsArray.Length)
                {
                    permutate(index + 1);
                }
            }
            InsertIntoTheMatrixAndTheArray(index, 0);
        }

        public static int GetThePreviousValue(int value)
        {
            if (value == 1)
            {
                return -1;
            }
            return 0;
        }

        public static void InsertIntoTheMatrixAndTheArray(int index, int value)
        {
            var x = (int)Math.Floor((decimal)(index / matrixSideLength));
            var y = index % matrixSideLength;
            theMatrixAsArray[index] = value;
            theMatrix[x, y] = value;
        }

        public static void Output()
        {
            var solution = "";
            for (int i = 0; i < theMatrixAsArray.Length; i++)
            {
                solution += $"{theMatrixAsArray[i]}, ";
            }
            solution += "\n";
            File.AppendAllText("theFile.txt", solution);
        }

        static bool hasABadNeighbor(int index)
        {
            if (theMatrixAsArray[index] == 0)
            {
                return false;
            }
            var x = (int)Math.Floor((decimal)(index / matrixSideLength));
            var y = index % matrixSideLength;

            return !isLeftGood(x, y) || !isRightGood(x, y) || !isTopGood(x, y)
                || !isBottomGood(x, y) || !isTopLeftGood(x, y) || !isTopRightGood(x, y)
                || !isBottomLeftGood(x, y) || !isBottomRightGood(x, y);

        }

        private static int Sum()
        {
            int totalSum1 = 0;
            int totalSum2 = 0;
            for (int i = 0; (i + 1) < theMatrixAsArray.Length; i += 2)
            {
                totalSum1 += Math.Abs(theMatrixAsArray[i + 0]);
                totalSum2 += Math.Abs(theMatrixAsArray[i + 1]);
            }
            totalSum1 += totalSum2 + Math.Abs(theMatrixAsArray[theMatrixAsArray.Length - 1]);
            return totalSum1;
        }

        private static bool isLeftGood(int x, int y)
        {
            try
            {
                var adjacentIndex = x - 1;
                return theMatrix[adjacentIndex, y] == 0 || theMatrix[adjacentIndex, y] == theMatrix[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isRightGood(int x, int y)
        {
            try 
            {
                var adjacentIndex = x + 1;
                return theMatrix[adjacentIndex, y] == 0 || theMatrix[adjacentIndex, y] == theMatrix[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isTopGood(int x, int y)
        {
            try
            {
                var adjacentIndex = y - 1;
                return theMatrix[x, adjacentIndex] == 0 || theMatrix[x, adjacentIndex] == theMatrix[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }
        private static bool isBottomGood(int x, int y)
        {
            try
            {
                var adjacentIndex = y + 1;
                return theMatrix[x, adjacentIndex] == 0 || theMatrix[x, adjacentIndex] == theMatrix[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isTopLeftGood(int x, int y)
        {
            try
            {
                var adjacentX = x - 1;
                var adjacentY = y + 1;
                return theMatrix[adjacentX, adjacentY] == 0 || theMatrix[x, y] == 1
                    || (theMatrix[x, y] == -1  && theMatrix[adjacentX, adjacentY] == 1);
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isTopRightGood(int x, int y)
        {
            try
            {
                var adjacentX = x + 1;
                var adjacentY = y + 1;
                return theMatrix[adjacentX, adjacentY] == 0 || theMatrix[x, y] == -1
                    || (theMatrix[x, y] == 1 && theMatrix[adjacentX, adjacentY] == -1);
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isBottomLeftGood(int x, int y)
        {
            try
            {
                var adjacentX = x - 1;
                var adjacentY = y - 1;
                return theMatrix[adjacentX, adjacentY] == 0 || theMatrix[x, y] == -1
                    || (theMatrix[x, y] == 1 && theMatrix[adjacentX, adjacentY] == -1);
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isBottomRightGood(int x, int y)
        {
            try
            {
                var adjacentX = x + 1;
                var adjacentY = y - 1;
                return theMatrix[adjacentX, adjacentY] == 0 || theMatrix[x, y] == 1
                    || (theMatrix[x, y] == -1 && theMatrix[adjacentX, adjacentY] == 1);
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }
    }
}
