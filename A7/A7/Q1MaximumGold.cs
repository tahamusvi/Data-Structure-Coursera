using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            Array.Sort(goldBars);

            long[,] matrix = new long[goldBars.Length+1,W+1];

            long max = long.MinValue;

            for (int i = 0; i <= goldBars.Length; i++) matrix[i,0] = 0;

            for (int i = 0; i <= W; i++) matrix[0,i] = 0;

            for(int i = 1; i <= goldBars.Length ;i++)
            {
                for(int j = 1; j <= W ; j++){
                    if(goldBars[i-1] <= j) max = Math.Max(goldBars[i-1] + matrix[i-1,j-goldBars[i-1]],matrix[i-1,j]) ;
                    else max = matrix[i-1,j];

                    matrix[i,j] = max;
                }
            }
            
            return matrix[goldBars.Length,W];
        }
    }
}
