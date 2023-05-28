using System;

namespace lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int length = 12000; // об'єм вибірки

            // задаємо початкові значення LFSR
            List<LFSR> LFSRs = new List<LFSR>()
            {
               new LFSR(10, new int[] { 1,0,0,0,0,0,0,1,0,0 }, new int[] { 3 }), // x10+x3+1
               new LFSR(11, new int[] { 1,0,0,0,0,0,0,0,0,1,0 }, new int[] { 2 }), // x11+x2+1
               new LFSR(12, new int[] { 1,0,0,0,0,0,1,0,1,0,0,1 }, new int[] { 6, 4, 1 }), // x12+x6+x4+x+1
               new LFSR(13, new int[] { 1,0,0,0,0,0,0,0,0,1,1,0,1 }, new int[] { 4, 3, 1 }), // x13+x4+x3+x+1
            };

            // створюємо генератор
            Generator g = new Generator(LFSRs, length);
            int[] generator = g.MakeGenerator();
            g.PrintGenerator(generator);
            Console.WriteLine();

            // тести
            GeneratorTests tests = new GeneratorTests();
            tests.FrequencyTest(generator, length);
            tests.DifferentialTest(generator, length);
        }
    }
}