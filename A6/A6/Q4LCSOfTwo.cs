using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long l1 = seq1.Length;
            long l2 = seq2.Length;
            

            long[,] matrix = new long[l1+1,l2+1];

            

            for(int i = 0 ; i <= l1 ; i++) matrix[i,0] = 0;

            for(int j = 0 ; j <= l2 ; j++) matrix[0,j] = 0;


            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    if( seq1[i-1] == seq2[j-1]){
                        matrix[i,j] = matrix[i-1,j-1] + 1 ;
                    }
                    else{
                        matrix[i,j] = Math.Max(matrix[i-1,j], matrix[i,j-1]);
                    }
                }
            }



            return matrix[l1,l2];
        }
    }
}
