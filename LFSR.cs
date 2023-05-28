using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class LFSR
    {
        public int Depth
        { get; set; }

        public int[] Value
        { get; set; }

        public int[] Coeffs
        { get; set; }

        public LFSR(int depth, int[] value, int[] coeffs)
        {
            Depth = depth;
            Value = value;
            Coeffs = coeffs;
        }

        //   виконується одна ітерація роботи LFSR
        public void LFSRGenerator()
        {
            int xorValue = Value[0];

            int[] temp = new int[Depth];

            int d = 1; // на яку кількість позицій здвигаємо 
            int k = 0;
            // починається здвиг на одиницю
            for (int i = d; i < Depth; i++)
            {
                temp[k] = Value[i];
                k++;
            }

            for (int i = 0; i < d; i++)
            {
                temp[k] = Value[i];
                k++;
            }

            for (int i = 0; i < Depth; i++)
            {
                Value[i] = temp[i];
            } // закінчується здвиг на одиницю

            Value[Depth - 1] = xorValue;

            // виконується операція xor
            foreach (int coeff in Coeffs)
            {
                xorValue ^= Value[Depth - coeff];
            }

            Value[Depth - 1] = xorValue;
        }

        
        public int GetLast()
        {
            int lastValue = Value[Depth - 1];
            LFSRGenerator();
            return lastValue;
        }
    }
}
