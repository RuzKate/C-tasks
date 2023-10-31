using System;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        Console.WriteLine("Введите информацию о проданных билетах:");
        string[][] matrix = new string[n][];
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            matrix[i] = row;
        }
        int k = int.Parse(Console.ReadLine());
        int res = -1;

        foreach (string[] row in matrix)
        {
            if (string.Join("", row).Contains(new string('0', k)))
            {
                res = Array.IndexOf(matrix, row);
                Console.WriteLine($"Номер ряда: {res + 1}");
                break;
            }
        }
        if (res == -1)
        {
            Console.WriteLine(0);
        }

        
    }
}