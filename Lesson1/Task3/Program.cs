using System;

namespace Task3
{
    //Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл) вычисления числа Фибоначчи.

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n для вычисления числа Фибоначчи: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Fibonucci() = {Fibonucci(n)}");
            Console.WriteLine($"Fibonucci2() = {Fibonucci2(n).cur}");
            Console.WriteLine($"Fibonucci3() = {Fibonucci3(n)}");

            Console.WriteLine("********* Fibonucci(), Fibonucci2(), Fibonucci3() *************");
            TestCase test1 = new TestCase() {
                n = 0,
                Expected = 0,
                ExpectedException = null
            };
            test1.TestFunction(Fibonucci);
            test1.TestFunction(x => Fibonucci2(x).cur);
            test1.TestFunction(Fibonucci3);

            Console.WriteLine("********* Fibonucci(), Fibonucci2(), Fibonucci3() *************");
            TestCase test2 = new TestCase()
            {
                n = 1,
                Expected = 1,
                ExpectedException = null
            };
            test2.TestFunction(Fibonucci);
            test2.TestFunction(x => Fibonucci2(x).cur);
            test2.TestFunction(Fibonucci3);

            Console.WriteLine("********* Fibonucci(), Fibonucci2(), Fibonucci3() *************");
            TestCase test3 = new TestCase()
            {
                n = 10,
                Expected = 55,
                ExpectedException = null
            };
            test3.TestFunction(Fibonucci);
            test3.TestFunction(x => Fibonucci2(x).cur);
            test3.TestFunction(Fibonucci3);

            Console.ReadKey();
        }

        /// <summary>
        /// Первый вариант рассчета рекурсивной формулы Фибоначчи (влоб) не оптимальный...
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonucci(int n)// O(2^N)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonucci(n - 1) + Fibonucci(n - 2);            
        }

        /// <summary>
        /// Второй вариант рассчета рекурсивной формулы Фибоначчи быстрый. (не делается лишняя работа)
        /// т.к. формула использует предыдущее вычисленное значение числа...
        /// </summary>
        /// <param name="n"></param>
        /// <returns>last - значение Фибоначчи на предыдущей итерации,
        /// cur - значение Фибоначчи на текущей итерации
        /// </returns>
        private static (long last, long cur) Fibonucci2(int n) //O(N)
        {
            long last, cur;
            if (n == 0) return (1, 0);
            (last, cur) = Fibonucci2(n - 1);
            return (cur, last + cur);
        }


        /// <summary>
        /// Расчет Фибоначчи без рекурсии
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long Fibonucci3(int n) {//O(N)
            if (n == 0) return 0;
            long S1 = 0;
            long S2 = 1;
            for (int i= 1; i < n; i++) {
                long S = S1 +S2;
                S1 = S2;
                S2 = S;
            }
            return S2;
        }
    }
}
