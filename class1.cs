using System;
using System.Collections.Generic;

class Program
{
    static void SearchMinimum(int[][] array, out int min)
    {
        min = int.MaxValue;
        foreach (var row in array)
        {
            foreach (var num in row)
            {
                if (num < min)
                {
                    min = num;
                }
            }
        }
    }

    static void SearchMaximum(int[][] array, out int max)
    {
        max = int.MinValue;
        foreach (var row in array)
        {
            foreach (var num in row)
            {
                if (num > max)
                {
                    max = num;
                }
            }
        }
    }

    static void SumLines(int[][] array, out int[] sums)
    {
        sums = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            int sum = 0;
            foreach (var num in array[i])
            {
                sum += num;
            }
            sums[i] = sum;
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Сколько значений в массиве?");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите массив:");
        int[][] array = new int[n][];
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            int[] row = new int[input.Length];
            for (int j = 0; j < input.Length; j++)
            {
                if (int.TryParse(input[j], out int parsedNum))
                {
                    row[j] = parsedNum;
                }
                else
                {
                    row[j] = 0;
                }
            }
            array[i] = row;
        }

        SearchMinimum(array, out int res_min);
        SearchMaximum(array, out int res_max);
        SumLines(array, out int[] res_sum);

        Console.WriteLine($"Min: {res_min}, Max: {res_max}, sum: {string.Join(" ", res_sum)}");
    }
}