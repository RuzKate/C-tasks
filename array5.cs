using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        int index = 0;

        int[] matrix1 = new int[1000 * 1000];
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 1000; j++)
            {
                matrix1[index] = random.Next(10);
                Console.Write($"{matrix1[index]}\t");
                index++;
            }
        }
        index = 0;

        Console.WriteLine('\n');
        int[] matrix2 = new int[1000 * 1000];
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 1000; j++)
            {
                matrix2[index] = random.Next(10);
                Console.Write($"{matrix2[index]}\t");
                index++;
            }
        }
        index = 0;

        int[] res = new int[1000 * 1000];
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                for (int k = 0; k < 1000; k++)
                {
                    res[i * 1000 + j] += matrix1[i * 1000 + k] * matrix2[k * 1000 + j];

                }
            }
        }


        Console.WriteLine();

        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine();
            for (int j = 0; j < 1000; j++)
            {
                Console.Write($"{res[index]}\t");
                index++;
            }
        }
    }
}

