using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDimension.permutate();
            File.WriteAllText("theEnd.txt", "WTF");
        }
    }
}
