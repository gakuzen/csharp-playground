using System;
using System.Collections.Generic;

namespace QueueByArray
{
    class Queue<T>
    {
        public List<T> data;

        public Queue()
        {
            data = new List<T>();
        }

        public void enqueue(T item)
        {
            data.Add(item);
        }

        public T dequeue()
        {
            T first = data[0];
            data.RemoveAt(0);
            return first;
        }

        public T peek()
        {
            return data[0];
        }

        public bool isEmpty()
        {
            return data.Count == 0;
        }

        public void print()
        {
            foreach (T item in data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    static class Test
    {
        static public void test()
        {
            Queue<int> queue = new Queue<int>();
            queue.enqueue(1);
            queue.enqueue(2);
            queue.enqueue(3);
            queue.enqueue(4);
            queue.enqueue(5);

            Console.WriteLine(queue.dequeue());
            Console.WriteLine(queue.peek());
            queue.print();
        }
    }
}
