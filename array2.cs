using System;
using System.Linq;

namespace array2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов в массиве:");
            int number = int.Parse(Console.ReadLine());
            int[] array = new int[number];

            for (int i = 0; i < number; i++)
            {
                array[i] = i;
            }

            array = array.Skip(array.Length / 2).Concat(array.Take(array.Length / 2)).ToArray(); // пропускает первую половину + извлекает первую половину
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
