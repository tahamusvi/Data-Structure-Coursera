using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] numbers)
        {

            long Smax = -1;
            long sum = 0;

            for(int i = 0 ; i < n ; i++){
                sum = sum + numbers[i];

                if(sum < 0){
                    sum = 0;
                }
                
                if(Smax < sum){
                    Smax = sum;
                }
            }

            return Smax;



        }
    }
}
