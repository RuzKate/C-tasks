using System;
using System.Collections.Generic;

class Stack
{
    private string[] stack;
    private int count;

    public Stack()
    {
        stack = new string[100];
    }

    public string Push(string item)
    {
        if (count == stack.Length)
            throw new InvalidOperationException("Переполнение стека");
        stack[count++] = item;
        return "ok";
    }

    public string Pop()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Стек пуст");
        }
        string value = stack[--count];
        stack[count] = default(string);
        return value;
    }

    public string Back()
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

            Console.WriteLine("Введите выражение:");
            string team = Console.ReadLine();

            for (int i = 0; i < team.Length; i++)
            {
                if (team[i] == '(')
                {
                    s.Push("(");
                }
                else if (team[i] == ')')
                {
                    if (s.Size() == 0)
                    {
                        Console.WriteLine($") на позиции {i}");
                        Console.WriteLine("Выражение не корректно");
                        s.Exit();
                    }
                    s.Pop();
                }
            }
            if (s.Size() == 0)
            {
                Console.WriteLine("Выражение корректно");
            }
            else
            {
                Console.WriteLine("Выражение не корректно");
                Console.WriteLine($"( в количестве - {s.Size()}");
            }
        }
    }
}
