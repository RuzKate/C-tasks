using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] answer = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            answer[i] = Math.Abs(nums.Take(i).Sum() - nums.Skip(i + 1).Sum());
        }
        Console.WriteLine(string.Join(" ", answer));
    }
}
