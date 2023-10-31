using System;

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

        Console.WriteLine("Введите количество элементов в новом массиве:");
        number = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите позицию, с которой необходимо вставить новый массив:");
        int position = int.Parse(Console.ReadLine());

        int[] new_array = new int[array.Length + number];
        Array.Copy(array, 0, new_array, 0, position);
        for (int i = 0; i < number; i++)
        {
            new_array[position + i] = i;
        }
        Array.Copy(array, position, new_array, position + number, array.Length - position);

        Console.WriteLine(string.Join(", ", new_array));
    }
}