using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            var numbers = new List<long>();

            for(int i = 1; i<=n ; i++){
                numbers.Add(i);
                n -= i;
            }

            int c = numbers.Count();
            numbers[c-1] += n;

            return numbers.ToArray();
        }


    }
}

