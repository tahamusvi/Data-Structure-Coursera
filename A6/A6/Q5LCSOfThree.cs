using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            long l1 = seq1.Length;
            long l2 = seq2.Length;
            long l3 = seq3.Length;
            

            long[,,] matrix = new long[l1+1,l2+1,l3+1];

            

            for(int i = 0 ; i <= l1 ; i++) matrix[i,0,0] = 0;

            for(int j = 0 ; j <= l2 ; j++) matrix[0,j,0] = 0;

            for(int j = 0 ; j <= l3 ; j++) matrix[0,0,j] = 0;


            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    for (int k = 1; k <= l3; k++)
                    {
                        if( seq1[i-1] == seq2[j-1] && seq2[j-1] == seq3[k-1]) matrix[i,j,k] = matrix[i-1,j-1,k-1] + 1 ;
                        else matrix[i,j,k] = Math.Max(Math.Max(matrix[i-1,j,k], matrix[i,j-1,k]), matrix[i,j,k-1]);
                    }
                }
            }



            return matrix[l1,l2,l3];
        }
    }
}

