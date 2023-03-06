namespace Task2
{//Вычислить асимптотическую сложность функции StrangeSum

    class Program
    {

        public static int StrangeSum(int[] inputArray) //  O(1) + O(N) * O(N) * O(N) * O(8) + O(1)  => O(N^3) 
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++)// O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++)// O(N)
                    {
                        int y = 0; //O(1)
                        if (j != 0) //O(1)
                        {
                            y = k / j; //O(1)
                        }
                        sum += inputArray[i] + i + k + j + y;//O(5)
                    }
                }
            }
            return sum; //O(1)
        }


        static void Main(string[] args)
        {
        }
    }
}
