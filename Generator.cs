using lab1;

namespace lab1
{
    public  class Generator
    {
        public List<LFSR> LSFRs
        { get; set; }

        public int Length
        { get; set; }

        public Generator(List<LFSR> lfsrs, int length)
        {
            LSFRs = lfsrs;
            Length = length;
        }

        public int[] MakeGenerator()
        {
            int[] result = new int[Length];
            int[] arr_address = new int[LSFRs.Count];
            
            int[] table = MakeTable();

            for (int i = 0; i < Length; i++)
            {
                int address = 0;
                int j = 0;
                foreach(LFSR lsfr in LSFRs)
                {
                    arr_address[j] = lsfr.GetLast();
                    j++;
                }

                address = ConvertTo10(arr_address);
                result[i] = table[address];
            }

            return result;   
        }

        // функція для переведення масиву з двійковими цифрами у десяткове число
        public int ConvertTo10(int[] input)
        {
            Array.Reverse(input);
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == 1)
                {
                    sum += (int)Math.Pow(2, i);
                }
            }
            return sum;
        }

        // генеруємо таблицю розмірністю 2^4 за варіантом
        public int[] MakeTable()
        {
            int n = LSFRs.Count;     //  рахуємо кількість LSFR в генераторі
            double pow = Math.Pow(2, n);
            int[] table = new int[(int)pow];
            int[] temp = new int[(int)pow];
            Random r = new Random();
            
            //   генеруємо таблицю із рівною кількістю 1 і 0
            for (int i = 0; i < pow - 1; i+=2)
            {
                temp[i] = 0;
                temp[i+1] = 1;
            }

            //  рандомно розкидуємо 1 і 0 по масиву 
            temp = temp.OrderBy(x => r.Next()).ToArray();

            for (int i = 0; i < pow; i++)
            {
                table[i] = temp[i];
            }

            return table;
        }

        public void PrintGenerator(int[] result)
        {
            Console.WriteLine("First 50 generated values: ");
            for (int i = 0; i < 50; i++)
            {
                Console.Write(result[i]);
            }
        }
    }
}
