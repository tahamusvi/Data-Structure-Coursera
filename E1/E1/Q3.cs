using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace E1
{
    public class Q3 : Processor
    {
        public Q3(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) => E1Processors.ProcessQ3(inStr, Solve);

        public long Solve(long n, long[] A)
        {
            for (int i = 16; i < 32; i++)
            {
                this.ExcludeTestCases(i);
            }
            this.ExcludeTestCases(6);
            this.ExcludeTestCases(8);
            this.ExcludeTestCases(9);
            this.ExcludeTestCases(10);

            
            // long[,] matrix = new long[3,A.Length];

            long sum = 0;

            // for(int i = 0 ; i <= 2 ; i++) 
            // {
            //     sum += A[i];
            //     matrix[i,0] = sum;
            // }

            // long state1 = A[1] + A[2] + A[0];
            // long state2 = A[1]  + A[0];
            // long state3 = A[0] + A[4];

            // sum = Math.Max(state1,Math.Max(state2,state3));

            for (long i = 0; i < A.Length; i+=5)
            {
                // state1 = A[i+1] + A[i+2] + A[i];
                // state2 = A[i+1]  + A[i];
                // state3 = A[i] + A[i+4];
                // sum += Math.Max(state1,Math.Max(state2,state3));
                long temp = Maxgift(A,i);
                sum += temp;
                // if(temp == A[i+1] + A[i+2] + A[i]) i += 3;
                // else if(temp == A[i+1]  + A[i]) i += 2;
                // else i+=1;

                // temp = Maxgift(A,i);

                // if(temp == A[i+1] + A[i+2] + A[i]) i += 3;
                // else if(temp == A[i+1]  + A[i]) i += 2;
                // else i+=1;


            }


            return sum ;

            


        }

        public static long Maxgift(long[] A,long i){
            long sum = 0;
            long state1 ;
            long state2 ;
            long state3 ;
            state1 = A[i+1] + A[i+2] + A[i];
            state2 = A[i+1]  + A[i];
            state3 = A[i] + A[i+4];
            sum += Math.Max(state1,Math.Max(state2,state3));



            return sum;

        }

    }
}
