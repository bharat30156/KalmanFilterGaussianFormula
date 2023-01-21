using System;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;

namespace GussianFormula
{
    class program
    {
        static void RunNormal(int sampleSizes)
        {
            double[] X = new  double[sampleSizes];
            var norm = new Normal(new Random());
            norm.Samples(X);

            const int numBuckets = 10;
            var histogram = new Histogram(X, numBuckets);
            Console.WriteLine("Sample sizes: {0:NO}", sampleSizes);

            for (int i = 0; i < numBuckets; i++)
            {
                string bar = new string('#', (int)(histogram[i].Count * 360 / sampleSizes));
                Console.WriteLine(" {0:0:00} : {1}", histogram[i].LowerBound, bar);
            }

            var statistics = new DescriptiveStatistics(X);
            Console.WriteLine("  Mean: " + statistics.Mean);
            Console.WriteLine("StdDev: " + statistics.StandardDeviation);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            RunNormal(100);
            RunNormal(1000);
            RunNormal(100000);
        }
    }
}

