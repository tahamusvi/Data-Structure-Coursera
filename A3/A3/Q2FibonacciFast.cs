using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            var fib_list = new long[n+2];

            fib_list[0] = 0;
            fib_list[1] = 1;

            for(int i = 2; i<=n ;i++){
                fib_list[i] = fib_list[i-1] + fib_list[i-2];
            }

            return fib_list[n];
        }

        
    }
}
