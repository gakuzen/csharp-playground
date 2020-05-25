using System;

namespace Comparator
{
    public abstract class Comparator<T>
    {
        public abstract bool equal(T a, T b);
        public abstract bool lessThan(T a, T b);
        public abstract bool lessThanOrEqual(T a, T b);
        public abstract bool greaterThan(T a, T b);
        public abstract bool greaterThanOrEqual(T a, T b);
    }

    public class Int32Comparator : Comparator<int>
    {
        public override bool equal(int a, int b)
        {
            return a == b;
        }
        public override bool lessThan(int a, int b)
        {
            return a < b;
        }
        public override bool lessThanOrEqual(int a, int b)
        {
            return a <= b;
        }
        public override bool greaterThan(int a, int b)
        {
            return a > b;
        }
        public override bool greaterThanOrEqual(int a, int b)
        {
            return a >= b;
        }
    }
}