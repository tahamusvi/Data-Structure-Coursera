using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public long[] Solve(long n)
        {
            long[] ops = new long[n+1];
            long option_count = 3;
            // temporary array
            long[] options = new long[option_count];


            //Create states for DP
            long Minop = MinOp(ops,options);


            long[] numbers = new long[Minop + 1];
            numbers[0] = n;

            //Create Numbers
            for (int i = 1; i <= Minop; i++)
            {
                if (n % 3 == 0 && (ops[n / 3] + 1 == ops[n])) n /= 3;
                else if ((ops[n / 2] + 1 == ops[n]) && n % 2 == 0) n /= 2;
                else n -= 1;

                numbers[i] = n;
            }

            // Reverse
            long[] result = new long[Minop + 1];
            result[Minop] = n;
            result[0] = 1;

            for(int i = 1; i <= Minop; i++) result[i] = numbers[Minop - i];


            return result;
        }


        public static long MinOp(long[] ops,long[] options){
            ops[0] = 0;
            ops[1] = 0;

            for (int i = 2; i < ops.Length; i++)
            {
                for(int j = 0; j < 3 ;j++) options[j] = long.MaxValue;
                

                if (i % 3 == 0) options[0] = ops[i / 3] + 1;
                if (i % 2 == 0) options[1] = ops[i / 2] + 1;
                options[2] = ops[i - 1] + 1;

                ops[i] = Math.Min(Math.Min(options[1], options[0]),options[2]);
            }

            return ops[ops.Length-1];
        }
    }
}
