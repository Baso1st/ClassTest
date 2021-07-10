using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sw = Stopwatch.StartNew();
                OneDimension.permutate();
                sw.Stop();
                File.WriteAllText("theEnd.txt", sw.Elapsed.ToString());
            }
            catch (Exception e)
            {
                File.WriteAllText("errorLog.txt", e.Message);
                throw;
            }
        }
    }
}
