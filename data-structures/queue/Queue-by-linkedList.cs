using System;
using System.Collections.Generic;

namespace QueueByLinkedList
{
    class Node<T>
    {
        public T value;
        public Node<T> next;

        public Node(T _value, Node<T> _next)
        {
            value = _value;
            next = _next;
        }
    }

    class Queue<T>
    {
        public Node<T> first;
        public Node<T> last;

        public Queue() { }

        public void enqueue(T item)
        {
            Node<T> node = new Node<T>(item, null);

            if (first is null) first = node;
            if (last != null) last.next = node;
            last = node;
        }

        public T dequeue()
        {
            if (first is null) throw new Exception();
            T firstValue = first.value;

            first = first.next;
            if (first is null) last = null;

            return firstValue;
        }

        public T peek()
        {
            if (first is null) throw new Exception();
            return first.value;
        }

        public bool isEmpty()
        {
            return first is null;
        }

        public void print()
        {
            Node<T> tmp = first;
            while (tmp != null)
            {
                Console.Write(tmp.value + " ");
                tmp = tmp.next;
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
