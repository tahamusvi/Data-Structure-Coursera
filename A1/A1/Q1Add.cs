using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A1
{
    public class Q1Add: Processor
    {
        public Q1Add(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>) Solve);


        public long Solve(long a, long b)
        {
            return a + b;
        }
    }
}
