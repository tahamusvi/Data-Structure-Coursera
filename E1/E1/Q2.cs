using System;
using TestCommon;

namespace E1
{
    public class Q2 : Processor
    {
        public Q2(string testDataName) : base(testDataName)
        {
        }

        
        public override string Process(string inStr) => E1Processors.ProcessQ2(inStr, Solve);

        public long Solve(long n, long k)
        {
            return SearchSeq(k,n);

        }


        public static long SizeSeq(long n){
            long size = 1;
            while(n>1){
                size *= 2;
                size++;
                n--;
            }

            return size;
        }

        public static long SearchSeq(long k , long n){
            long size = SizeSeq(n);
            long half = (size-1)/2 ;
            half++;

            if(k == half){
                return n; 
            }

            if(k < half)
            {
                return SearchSeq(k,n-1);

            }
            else
            {
                return SearchSeq(k-half,n-1);
            }

        }
    }
}
