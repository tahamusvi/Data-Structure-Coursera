using System;
using TestCommon;

namespace E1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        
        public override string Process(string inStr) => E1Processors.ProcessQ1(inStr, Solve);

        public long Solve(long n, long[] Tasks)
        {
            long result = 0;
            long time = 0;

            Array.Sort(Tasks);

            foreach (long item in Tasks)
            {
                if(item > time) 
                {
                    result++;
                    time++;
                }
                
            }

            return result;
        }
    }
}
