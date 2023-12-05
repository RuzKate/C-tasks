using System;
using System.Collections.Generic;

class Stack
{
    private int[] stack;
    private int count;

    public Stack()
    {
        stack = new int[100];
    }

    public string Push(int item)
    {
        if (count == stack.Length)
            throw new InvalidOperationException("Переполнение стека");
        stack[count++] = item;
        return "ok";
    }

    public int Pop()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Стек пуст");
        }
        int value = stack[--count];
        stack[count] = default(int);
        return value;
    }

    public int Back()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Стек пуст");
        }
        return stack[count - 1];
    }

    public int Size()
    {
        return count;
    }

    public string Clear()
    {
        count = 0;
        return "ok";
    }

    public void Exit()
    {
        Environment.Exit(0);
    }
}

namespace methods1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            while (true)
            {
                Console.WriteLine("Введите команду:");
                string[] input = Console.ReadLine().Split();
                string team = input[0];

                switch (team)
                {
                    case "push":
                        int value = int.Parse(input[1]);
                        Console.WriteLine(s.Push(value));
                        break;
                    case "pop":
                        Console.WriteLine(s.Pop());
                        break;
                    case "back":
                        Console.WriteLine(s.Back());
                        break;
                    case "size":
                        Console.WriteLine(s.Size());
                        break;
                    case "clear":
                        Console.WriteLine(s.Clear());
                        break;
                    case "exit":
                        s.Exit();
                        break;
                }
            }
        }
    }
}
