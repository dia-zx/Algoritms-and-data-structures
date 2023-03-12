using System;

namespace Task1
{
    //    Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм
    //проверки, простое число или нет.
    //1. Написать консольное приложение.
    //2. Алгоритм реализовать отдельно в функции согласно блок-схеме.
    //3. Написать проверочный код в main функции .
    class Program
    {
        /// <summary>
        /// Функция, востановленная из блоксхемы.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Function(int n)
        {
            int d = 0;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0) d++;
            }
            if (d == 0) return "Простое";
            return "Не простое";
        }

        

        public class TestCase
        {
            public delegate string FuncDelegate(int n);
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
            public string Expected { get; set; }
            /// <summary>
            /// ожидаемое исключение
            /// </summary>
            public Exception ExpectedException { get; set; }

            public void TestFunction(FuncDelegate func)
            {
                testCount++;
                string resultStr = $"Test №{testCount}: аргумент = {n} результат = ";
                try
                {
                    string funcResult = func(n);

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


        static void Main(string[] args)
        {
            new TestCase()
            {
                n = 10,
                Expected = "Не простое",
                ExpectedException = null
            }.TestFunction(Function);

            new TestCase()
            {
                n = 37,
                Expected = "Простое",
                ExpectedException = null
            }.TestFunction(Function);

            new TestCase()
            {
                n = 556,
                Expected = "Не простое",
                ExpectedException = null
            }.TestFunction(Function);

            new TestCase()
            {
                n = 15592,
                Expected = "Не простое",
                ExpectedException = null
            }.TestFunction(Function);

            Console.ReadKey();
        }
    }
}
