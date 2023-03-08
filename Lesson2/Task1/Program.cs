using System;
using System.Collections.Generic;

namespace Task1
{
    //Задание 3. Необходимо реализовать метод разворота связного списка (двухсвязного или односвязного на выбор).
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(10);
            list.AddLast(20);

            Console.WriteLine("Исходный список:");
            PrintList(list);

            RotateList(list);
            Console.WriteLine("Cписок после разворота (вариант 1):");
            PrintList(list);

            RotateList2(list);
            Console.WriteLine("Cписок после разворота (вариант 2):");
            PrintList(list);
        }

        /// <summary>
        /// метод разворота двухсвязного списка
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        static void RotateList<T>(LinkedList<T> list)
        {
            LinkedListNode<T> left = list.First;
            LinkedListNode<T> right = list.Last;
            T temp;
            while (left != right)
            {
                #region меняем left.Value <-> right.Value
                temp = left.Value;
                left.Value = right.Value;
                right.Value = temp;
                #endregion

                left = left.Next;
                if (left == right) break;
                right = right.Previous;
            }

        }

        /// <summary>
        /// Метод разворота двухсвязного списка вариант 2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        static void RotateList2<T>(LinkedList<T> list)
        {
            LinkedListNode<T> first = list.Last;
            while (first != list.First)
            {
                list.AddLast(first.Previous.Value);
                list.Remove(first.Previous.Value);
            }
        }

        /// <summary>
        /// Вывод списка на консоль
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        static void PrintList<T>(LinkedList<T> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}
