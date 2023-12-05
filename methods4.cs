using System;
using System.Collections.Generic;

namespace ДвухсторонняяОчередь
{
    public class Deque<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int count;

        public void AddFirst(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            count++;
        }

        public void AddLast(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            count++;
        }

        public List<int> Find(T data)
        {
            List<int> positions = new List<int>();
            DoublyNode<T> current = head;
            int position = 0;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    positions.Add(position);
                }
                current = current.Next;
                position++;
            }
            return positions;
        }

        public bool Remove(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current == head && current == tail)
                    {
                        head = null;
                        tail = null;
                    }
                    else if (current == head)
                    {
                        head = current.Next;
                        head.Previous = null;
                    }
                    else if (current == tail)
                    {
                        tail = current.Previous;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                    }
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void RemoveFirst()
        {
            if (count > 0)
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                }
                count--;
            }
        }

        public void RemoveLast()
        {
            if (count > 0)
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail = tail.Previous;
                    tail.Next = null;
                }
                count--;
            }
        }

        public void Print()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                Console.Write(current.Data.ToString() + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();
            deque.AddFirst(1);
            deque.AddLast(2);
            deque.AddFirst(3);
            deque.AddLast(4);

            deque.Print();

            List<int> positions = deque.Find(2);
            foreach (int position in positions)
            {
                Console.WriteLine("2 на позицию " + position);
            }

            deque.Remove(3);
            deque.Print();  

            deque.RemoveFirst();
            deque.Print();

            deque.RemoveLast();
            deque.Print();
        }
    }
}
