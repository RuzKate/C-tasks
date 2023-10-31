using System;
using System.Collections.Generic;
using System.Linq;

public class Array
{
    private int size;
    public int[] array;

    public Array(int size)
    {
        this.size = size;
        this.array = new int[size];
    }

    public void InputData()
    {
        while (true)
        {
            Console.WriteLine("Введите данные массива:");
            try
            {
                for (int i = 0; i < size; i++)
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Введенные данные не являются целыми числами!");
            }
            catch
            {
                Console.WriteLine("Выход за пределы массива!");
            }
        }
    }

    public void InputDataRandom()
    {
        var random = new Random();
        array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(1, 11);
        }
    }

    public void Print()
    {
        while (true)
        {
            Console.WriteLine("Введите диапазон индексов:");
            try
            {
                var x = int.Parse(Console.ReadLine());
                var y = int.Parse(Console.ReadLine());
                Console.WriteLine(string.Join(" ", array[x..(y + 1)]));
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Введите целые числа!");
            }
            catch
            {
                Console.WriteLine($"В массиве {size} значений, введите индексы из этого диапазона!");
            }
        }
    }

    public void FindValue()
    {
        while (true)
        {
            Console.WriteLine("Введите элемент, индекс которого хотели бы узнать:");
            int value = Convert.ToInt32(Console.ReadLine());

            if (array.Contains(value))
            {
                for (int i = 0; i < size; i++)
                {
                    if (array[i] == value)
                    {
                        Console.WriteLine($"Index: {i}");
                    }
                }
                break;
            }
            else
            {
                Console.WriteLine("Этого элемента нет в массиве!");
            }
        }
    }

    public void DelValue()
    {
        while (true)
        {
            Console.WriteLine("Введите элемент, который хотите удалить:");
            int value = Convert.ToInt32(Console.ReadLine());

            if (array.Contains(value))
            {
                array = array.Where(val => val != value).ToArray();
                size = array.Length;
                break;
            }
            else
            {
                Console.WriteLine("Этого элемента нет в массиве!");
            }
        }     
    }

    public void FindMax(out int max)
    {
        max = array[0];
        for (int i = 1; i < size; i++)
            if (array[i] > max)
            {
                max = array[i];
            }
    }

    public void Add()
    {
        Array arr2 = new Array(size);
        arr2.InputDataRandom();
        int[] result = new int[size];
        for (int i = 0; i < size; i++)
        {
            result[i] = array[i] + arr2.array[i];
        }
        Console.WriteLine($"{string.Join(' ', array)} + {string.Join(' ', arr2.array)} = {string.Join(' ', result)}");
    }

    public void Sort()
    {
        int temp;
        for (int i = 0; i < size; i++)
        {
            for (int j = size - 1; j > i; j--)
            {
                if (array[j - 1] > array[j])
                {
                    temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }          
        }
    }
            
}

class Program
{
    static void Main(string[] args)
    {
        Array arr = new Array(5);
        arr.InputData();
        Console.WriteLine(string.Join(" ", arr.array));

        arr.InputDataRandom();      
        Console.WriteLine($"Random: {string.Join(' ', arr.array)}");

        arr.Print();

        arr.FindValue();

        arr.DelValue();
        Console.WriteLine(string.Join(", ", arr.array));

        arr.FindMax(out int max);
        Console.WriteLine($"Max: {max}");

        arr.Add();

        arr.Sort();
        Console.WriteLine($"Sort: {string.Join(", ", arr.array)}");
    }
}