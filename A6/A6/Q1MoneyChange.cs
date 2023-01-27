using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] coins = new long[]{1,3,4};
            long[] states = new long[n+1];

            for (int i = 0; i < n+1; i++)
            {
                states[i] = long.MaxValue;
            }

            states[0] = 0;

            ChangeMoney(n,states,coins);

            return states[n];
        }


        public static long ChangeMoney(long n,long[] states,long[] coins)
        {

            for (int i = 0; i < n+1; i++)
            {
                foreach (var coin in coins)
                {
                    if(i - coin >= 0)
                    {
                        if(states[i] > states[i-coin] + 1) states[i] = states[i-coin] + 1;
                    }
                }
                
            }


            return states[n];
        }


    }
}
