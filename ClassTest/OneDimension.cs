using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest
{
    class OneDimension
    {
        static int[] possibleValues = new int[] { 0, -1, 1 };
        static int[] theMatrix = new int[9];
        static int desiredSum = 6;
        //static void Main(string[] args)
        //{
        //    permutate();
        //}

        public static void permutate(int index = 0)
        {
            foreach (var value in possibleValues)
            {
                theMatrix[index] = value;
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
                if ((index + 1) < theMatrix.Length)
                {
                    permutate(index + 1);
                }
            }
            theMatrix[index] = 0;
        }


        public static void Output(int[] theMatrix)
        {
            for (int i = 0; i < theMatrix.Length; i++)
            {
                //Console.Write($"{i}: {theMatrix[i]}, ");
                //Console.Write($"{theMatrix[i]}, ");
                System.Diagnostics.Debug.Write($"{theMatrix[i]}, ");
            }
            System.Diagnostics.Debug.WriteLine("\n");
            //Console.WriteLine("\n");
        }

        static bool hasABadNeighbor(int index)
        {
            if (theMatrix[index] == 0)
            {
                return false;
            }

            var matrixSideLength = ((int)Math.Sqrt(theMatrix.Length));

            var theMatrixIn2D = new int[matrixSideLength, matrixSideLength];

            for (int j = 0; j < theMatrixIn2D.GetLength(0); j++)
            {
                for (int k = 0; k < theMatrixIn2D.GetLength(1); k++)
                {
                    theMatrixIn2D[j, k] = theMatrix[k + (j * matrixSideLength)];
                }
            }

            var x = (int)Math.Floor((decimal)(index / matrixSideLength));
            var y = index % matrixSideLength;

            return !isLeftGood(x, y, theMatrixIn2D) || !isRightGood(x, y, theMatrixIn2D) || !isTopGood(x, y, theMatrixIn2D)
                || !isBottomGood(x, y, theMatrixIn2D) || !isTopLeftGood(x, y, theMatrixIn2D) || !isTopRightGood(x, y, theMatrixIn2D)
                || !isBottomLeftGood(x, y, theMatrixIn2D) || !isBottomRightGood(x, y, theMatrixIn2D);

            //var rightIndex = index + 1;
            //var topIndex = index + matrixSideLength;
            //var bottomIndex = index - matrixSideLength;

            //var topLeftIndex = index + matrixSideLength - 1;
            //var topRightIndex = index + matrixSideLength + 1;
            //var bottomLeftIndex = index - (matrixSideLength + 1);
            //var bottomRightIndex = index - (matrixSideLength - 1);

            //if (isAdjacentDifferent(index, leftIndex)
            //    || isAdjacentDifferent(index, rightIndex)
            //    || isAdjacentDifferent(index, topIndex)
            //    || isAdjacentDifferent(index, bottomIndex))
            //{
            //    return true;
            //}

            //if (isItWithinArrayLimitAndNotZero(topLeftIndex) && theMatrix[index] == -1 && theMatrix[topLeftIndex] == -1)
            //{
            //    return true;
            //}

            //if (isItWithinArrayLimitAndNotZero(bottomRightIndex) && theMatrix[index] == -1 && theMatrix[bottomRightIndex] == -1)
            //{
            //    return true;
            //}

            //if (isItWithinArrayLimitAndNotZero(topRightIndex) && theMatrix[index] == 1 && theMatrix[topRightIndex] == 1)
            //{
            //    return true;
            //}

            //if (isItWithinArrayLimitAndNotZero(bottomLeftIndex) && theMatrix[index] == 1 && theMatrix[bottomLeftIndex] == 1)
            //{
            //    return true;
            //}

        }

        private static bool isLeftGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentIndex = x - 1;
                return theMatrixIn2D[adjacentIndex, y] == 0 || theMatrixIn2D[adjacentIndex, y] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isRightGood(int x, int y, int[,] theMatrixIn2D)
        {
            try 
            {
                var adjacentIndex = x + 1;
                return theMatrixIn2D[adjacentIndex, y] == 0 || theMatrixIn2D[adjacentIndex, y] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isTopGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentIndex = y - 1;
                return theMatrixIn2D[x, adjacentIndex] == 0 || theMatrixIn2D[x, adjacentIndex] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }
        private static bool isBottomGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentIndex = y + 1;
                return theMatrixIn2D[x, adjacentIndex] == 0 || theMatrixIn2D[x, adjacentIndex] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isTopLeftGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentX = x - 1;
                var adjacentY = y + 1;
                return theMatrixIn2D[adjacentX, adjacentY] == 0 || theMatrixIn2D[adjacentX, adjacentY] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isTopRightGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentX = x + 1;
                var adjacentY = y + 1;
                return theMatrixIn2D[adjacentX, adjacentY] == 0 || theMatrixIn2D[adjacentX, adjacentY] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isBottomLeftGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentX = x - 1;
                var adjacentY = y - 1;
                return theMatrixIn2D[adjacentX, adjacentY] == 0 || theMatrixIn2D[adjacentX, adjacentY] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private static bool isBottomRightGood(int x, int y, int[,] theMatrixIn2D)
        {
            try
            {
                var adjacentX = x + 1;
                var adjacentY = y - 1;
                return theMatrixIn2D[adjacentX, adjacentY] == 0 || theMatrixIn2D[adjacentX, adjacentY] == theMatrixIn2D[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }


        //public static bool isAdjacentDifferent(int index, int adjacentIndex)
        //{
        //    if (isItWithinArrayLimitAndNotZero(adjacentIndex) && theMatrix[adjacentIndex] != theMatrix[index])
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public static bool isItWithinArrayLimitAndNotZero(int index)
        //{
        //    return index >= 0 && index < theMatrix.Length && theMatrix[index] != 0;
        //}
    }
}
