using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long sum = 0;

            foreach (long item in souvenirs)
            {
                sum += item;
            }


            if((sum % 3 != 0) || (sum == 0)) return 0;

            long W = sum / 3;


            long[,] matrix = new long[souvenirs.Length+1,W+1];

            long max = long.MinValue;

            for (int i = 0; i <= souvenirs.Length; i++) matrix[i,0] = 0;

            for (int i = 0; i <= W; i++) matrix[0,i] = 0;



            for(int i = 1; i <= souvenirs.Length ;i++)
            {
                for(int j = 1; j <= W ; j++){
                    if(souvenirs[i-1] <= j) max = Math.Max(souvenirs[i-1] + matrix[i-1,j-souvenirs[i-1]],matrix[i-1,j]) ;
                    else max = matrix[i-1,j];

                    matrix[i,j] = max;
                }
            }


            if(matrix[souvenirs.Length,W] == W) return 1 ;
            return 0;
        }
    }
}
