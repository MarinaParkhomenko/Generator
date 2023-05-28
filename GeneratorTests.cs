using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class GeneratorTests
    {
        public GeneratorTests()
        {

        }

        public void FrequencyTest(int[] array, int length)
        {
            double sum = 0;

            for (int i = 0; i < length; i++)
            {
                sum += array[i];
            }

            double result = sum / length;

            Console.WriteLine("Frequency test result is " + result);
        }

        public void DifferentialTest(int[] array, int length)
        {
            double sum = 0;

            for (int i = 0; i < length - 1; i++)
            {
                sum += array[i] ^ array[i + 1];
            }

            double result = sum / (length - 1);

            Console.WriteLine("Differential test result is " + result);
        }

    }
}
