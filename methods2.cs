using System;
using System.Collections.Generic;

class Queue
{
    private int[] queue;
    private int count;
    private int head;

    public Queue()
    {
        queue = new int[100];
        head = -1;
        count = 0;
    }

    public string Push(int item)
    {
        if (count == queue.Length)
            throw new InvalidOperationException("Переполнение очереди");
        queue[count++] = item;
        return "ok";
    }

    public int Pop()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Очередь пуста");
        }
        int value = queue[++head];
        count--;
        return value;
    }

    public int Front()
    {
        if (count == 0)
        {
            throw new InvalidOperationException("Очередь пуста");
        }
        return queue[head + 1];
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
        Console.WriteLine("bye");
        Environment.Exit(0);
    }
}

namespace methods1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            while (true)
            {
                Console.WriteLine("Введите команду:");
                string[] input = Console.ReadLine().Split();
                string team = input[0];

                switch (team)
                {
                    case "push":
                        int value = int.Parse(input[1]);
                        Console.WriteLine(q.Push(value));
                        break;
                    case "pop":
                        Console.WriteLine(q.Pop());
                        break;
                    case "front":
                        Console.WriteLine(q.Front());
                        break;
                    case "size":
                        Console.WriteLine(q.Size());
                        break;
                    case "clear":
                        Console.WriteLine(q.Clear());
                        break;
                    case "exit":
                        q.Exit();
                        break;
                }
            }
        }
    }
}