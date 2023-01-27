using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] a)
        {
            long result = majority(a,0,n-1);

            if(result != 0){
                result = 1;
            }

            return result;
        }

        public static long majority(long[] n,long left ,long right){
            if((left + 1 == right)||(left + 2 == right)){
                return n[left];
            }

            long mid = (left+right) / 2;

            long majorLeft = majority(n,left,mid);
            long majorRight = majority(n,mid,right);


            long countR = 0;
            long countL = 0;


            for(long k = left;k < right+1 ; k++){
                if(majorLeft == n[k]){
                    countL++;
                }
                if(majorRight == n[k]){
                    countR++;
                }
            }



            double majorNumber = (double)(right +1 - left) / 2;


            if((countL > majorNumber) && majorLeft != 0){
                return majorLeft;
            }
            else if((countR > majorNumber) && majorRight != 0){
                return majorRight;
            }
            else{
                return 0;
            }


        }
    }
}
