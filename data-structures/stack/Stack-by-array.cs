using System;
using System.Collections.Generic;

namespace StackByArray
{
    class Stack<T>
    {
        public List<T> data;

        public Stack()
        {
            data = new List<T>();
        }

        public void push(T item)
        {
            data.Add(item);
        }

        public T pop()
        {
            if (data.Count == 0) throw new Exception();
            T top = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            return top;
        }

        public T peek()
        {
            return data[data.Count - 1];
        }

        public bool isEmpty()
        {
            return data.Count == 0;
        }

        public void print()
        {
            for (int i = data.Count - 1; i >= 0; i--)
            {
                Console.Write(data[i]);
                if (i != 0) Console.Write(" ");
                else Console.WriteLine();
            }
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
            stack.pop();


            Console.WriteLine(stack.peek());
            Console.WriteLine(stack.isEmpty());
            stack.print();
        }
    }
}
