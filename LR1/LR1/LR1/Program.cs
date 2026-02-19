using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов массива: ");
            int Lenght = Convert.ToInt32(Console.ReadLine());
            int[] Array = new int[Lenght];
            for (int index = 0; index < Lenght; index++)
            {
                Console.Write($"Элемент [{index}]: ");
                Array[index] = Convert.ToInt32(Console.ReadLine());
            }
            int sum = 0;
            double average = 0.0;
            int count = 0;
            foreach (int element in Array)
            {
                sum += element;
            }
            average = sum / Lenght;
            foreach (int element in Array)
            {
                if (element < average)
                {
                    ++count;
                }
            }
            Console.WriteLine($"Среднее значение массива: {average}");
            Console.WriteLine($"Количество элементов, меньших среднего значения: {count} ");
        }
    }
}
