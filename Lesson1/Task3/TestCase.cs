using System;

namespace Task3
{
    public class TestCase
    {
        public delegate long FuncDelegate(int n);
        /// <summary>
        /// счетчик тестов
        /// </summary>
        public static int testCount = 0;
        /// <summary>
        /// аргумент на который тестируем функцию
        /// </summary>
        public int n { get; set; }
        /// <summary>
        /// Ожидаемый результат функции
        /// </summary>
        public long Expected { get; set; }
        /// <summary>
        /// ожидаемое исключение
        /// </summary>
        public Exception ExpectedException { get; set; }
        public TestCase()
        {
            testCount++;
        }

        public void TestFunction(FuncDelegate func)
        {
            string resultStr = $"Test №{testCount}: аргумент = {n} результат = ";
            try
            {
                long funcResult = func(n);

                if (funcResult == Expected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(resultStr + funcResult + " VALID TEST");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultStr + funcResult + " INVALID TEST");
                }
            }
            catch (Exception)
            {
                if (ExpectedException != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(resultStr + "Exception" + " VALID TEST");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultStr + "Exception" + " INVALID TEST");
                }
            }
            Console.ResetColor();
        }
    }

}
