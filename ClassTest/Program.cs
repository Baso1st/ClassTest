using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassTest
{
    class SalesLine
    {
        public int ID { get; set; }
        public int PieceCount { get; set; }
        public List<Bundle> bundles { get; set; }
    }

    class Bundle
    {
        public int ID { get; set; }
        public int PieceCount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var salesLines = new List<SalesLine>();
            var bundles = new List<Bundle>();

            foreach (var line in salesLines)
            {
                var linesPossibleBundleCombination = PermutationAlgorithm(bundles, line);
                linesPossibleBundleCombination.OrderBy(p => p.Count());
                line.bundles = linesPossibleBundleCombination[0];
                var lineBundlesIds = line.bundles.Select(b2 => b2.ID).ToList();
                bundles = bundles.Where(b => !lineBundlesIds.Contains(b.ID)).ToList();
            }
        }


        public static List<List<Bundle>> PermutationAlgorithm(List<Bundle> bundles, SalesLine line)
        {
            double count = Math.Pow(2, bundles.Count);
            var probabilities = new List<List<Bundle>>();
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2);
                var probability = new List<Bundle>();
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        if(probability.Sum(p => p.PieceCount) + bundles[j].PieceCount <= line.PieceCount)
                        {
                            probability.Add(bundles[j]);
                        }
                    }
                }

                if (probability.Count() > 0 && probability.Sum(p => p.PieceCount) == line.PieceCount)
                {
                    probabilities.Add(probability);
                }
            }
            return probabilities;
        }
    }
}
