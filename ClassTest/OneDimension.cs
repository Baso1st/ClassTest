using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static void permutate(int index = 0)
        {
            if (foundSolution)
            {
                return;
            }
            foreach (var value in possibleValues)
            {
                counter++;
                if(counter % 1000000 == 0)
                {
                    var count = (counter / 1000000);
                    Console.WriteLine(count);
                    File.WriteAllText("TheCounter.txt", $"{count}");
                }

                insertIntoTheMatrixAndTheArray(index, value);
                var totalSum = theMatrixAsArray.Sum(i => Math.Abs(i));

                if (totalSum > desiredSum || hasABadNeighbor(index))
                {
                    insertIntoTheMatrixAndTheArray(index, 0);
                    return;
                }

                if (totalSum == desiredSum)
                {
                    Output();
                    foundSolution = true;
                    return;
                }
                if((index + 1) < theMatrixAsArray.Length)
                {
                    permutate(index + 1);
                }
            }
            insertIntoTheMatrixAndTheArray(index, 0);
        }


        public static void insertIntoTheMatrixAndTheArray(int index, int value)
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
            File.WriteAllText("theFile.txt", solution);
        }

        static bool hasABadNeighbor(int index)
        {
            if (theMatrixAsArray[index] == 0)
            {
                return false;
            }

            //var matrixSideLength = ((int)Math.Sqrt(theMatrixAsArray.Length));

            //var theMatrix = new int[matrixSideLength, matrixSideLength];

            //for (int j = 0; j < theMatrix.GetLength(0); j++)
            //{
            //    for (int k = 0; k < theMatrix.GetLength(1); k++)
            //    {
            //        theMatrix[j, k] = theMatrixAsArray[k + (j * matrixSideLength)];
            //    }
            //}

            var x = (int)Math.Floor((decimal)(index / matrixSideLength));
            var y = index % matrixSideLength;

            return !isLeftGood(x, y) || !isRightGood(x, y) || !isTopGood(x, y)
                || !isBottomGood(x, y) || !isTopLeftGood(x, y) || !isTopRightGood(x, y)
                || !isBottomLeftGood(x, y) || !isBottomRightGood(x, y);

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
