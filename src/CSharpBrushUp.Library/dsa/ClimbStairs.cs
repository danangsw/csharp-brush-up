using System;

namespace CSharpBrushUp.Library.DSA
{
    public class ClimbStairs
    {
        public int Solution1(int n)
        {
            if (n <= 2) return n;
            var fs = new int[n + 1];
            fs[1] = 1;
            fs[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                fs[i] = fs[i - 1] + fs[i - 2];
            }
            return fs[n];
        }
    }
}