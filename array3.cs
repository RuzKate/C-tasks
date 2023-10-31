using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static int[] NewArray()
    {
        Console.WriteLine("Введите количество элементов в массиве:");
        int num = Convert.ToInt32(Console.ReadLine());

        Random random = new Random();
        int[] array = new int[num];

        for (int i = 0; i < num; i++)
        {
            array[i] = random.Next(100);
        }
        
        Console.WriteLine(string.Join(", ", array));
        return array;
    }

    public static void Addition()
    {
        int[] array1 = NewArray();
        int[] array2 = NewArray();
        bool flag = true;
        while (flag)
        {
            if (array1.Length == array2.Length)
            {
                flag = false;
            }
            else
            {
                Console.WriteLine("Длина массивов разная, попробуйте еще раз!");
                array1 = NewArray();
                array2 = NewArray();
            }
        }
        int[] result = Enumerable.Zip(array1, array2, (x, y) => x + y).ToArray();
        Console.WriteLine(string.Join(", ", result));
    }

    public static void Multiplication()
    {
        int[] array = NewArray();
        Console.WriteLine("Введите число, на которое нужно умножить массив:");
        int num = Convert.ToInt32(Console.ReadLine());

        int[] result = array.Select(x => x * num).ToArray();
        Console.WriteLine(string.Join(", ", result));
    }

    public static void CommonValues()
    {
        int[] array1 = NewArray();
        int[] array2 = NewArray();

        int[] result = array1.Where(x => array2.Contains(x)).ToArray(); 
        Console.WriteLine(string.Join(", ", result));
    }

    public static void PrintValue()
    {
        int[] array = NewArray();
    }

    public static void Sorting()
    {
        int[] array = NewArray();
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] < array[j])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
        Console.WriteLine($"Отсортированный массив по убыванию: {string.Join(", ", array)}");
    }

    public static void FindingValue()
    {
        int[] array = NewArray();
        int minn = 1000;
        int maxx = 0;
        int average_value = 0;
        int summa = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (minn > array[i])
            {
                minn = array[i];
            }
            if (maxx < array[i])
            {
                maxx = array[i];
            }
            summa += array[i];
        }
        average_value = summa / array.Length;
        Console.WriteLine($"Минимальное значение: {minn}");
        Console.WriteLine($"Максимальное значение: {maxx}");
        Console.WriteLine($"Среднее значение: {average_value}");
    }

    public static void Main()
    {
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Возможные операции над массивами:");
            Console.WriteLine("1.Сложение массивов поэлементно в случае равенства длины массивов");
            Console.WriteLine("2.Умножение массива на число осуществляется поэлементно");
            Console.WriteLine("3.Поиск общих значений двух массивов(длины массивов могут быть разные)");
            Console.WriteLine("4.Печать значений массива");
            Console.WriteLine("5.Упорядочивание значений массива по убыванию");
            Console.WriteLine("6.Поиск min, max значение в массиве, среднего значения всех значений массива");
            Console.WriteLine("0.Выход\n");

            string n = Console.ReadLine();
            if (n == "0")
            {
                break;
            }
            Dictionary<string, Action> operations = new Dictionary<string, Action>
            {
                { "1", Addition},
                { "2", Multiplication},
                { "3", CommonValues},
                { "4", PrintValue},
                { "5", Sorting},
                { "6", FindingValue}
            };
            operations[n]();
        }
    }
}