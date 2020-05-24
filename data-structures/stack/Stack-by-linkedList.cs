using System;
using System.Collections.Generic;

namespace StackByLinkedList
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

    class Stack<T>
    {
        public Node<T> top;

        public Stack() { }

        public void push(T item)
        {
            Node<T> node = new Node<T>(item, top);
            top = node;
        }

        public T pop()
        {
            if (top is null) throw new Exception();

            T topValue = top.value;
            top = top.next;

            return topValue;
        }

        public T peek()
        {
            if (top is null) throw new Exception();
            return top.value;
        }

        public bool isEmpty()
        {
            return top is null;
        }

        public void print()
        {
            Node<T> tmp = top;
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
            Stack<int> stack = new Stack<int>();

            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.push(4);
            stack.push(5);
            stack.push(6);
            stack.pop();


            Console.WriteLine(stack.peek());
            Console.WriteLine(stack.isEmpty());
            stack.print();
        }
    }
}
