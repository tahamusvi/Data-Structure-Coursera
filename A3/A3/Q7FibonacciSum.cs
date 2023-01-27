using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {

        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long a)
        {
            long periodMod = pisanoPeriod(10);


            long leftover = a % periodMod;
            long pr = (a - leftover) / periodMod;
            

            long sumOnePeriod = fibonacciOnMod(periodMod+2,10)-1;
            long somLeftOver  = fibonacciOnMod(leftover+2,10)-1;

            if(somLeftOver<0){
                somLeftOver = 9;
            }

            long total = (pr * sumOnePeriod) % 10 + somLeftOver;


            return total;
            
        }


        public long fibonacciOnMod(long n,long mod)
        {
            var fib_list = new long[n+2];

            fib_list[0] = 0;
            fib_list[1] = 1;

            for(int i = 2; i<=n ;i++){
                fib_list[i] = (fib_list[i-1] + fib_list[i-2]) % mod;
            }

            return fib_list[n];
        }




        public long pisanoPeriod(long mod){
            long pre = 0;
            long curr = 1;
            long pw2_mod = mod * mod ;
            long temp = 0;
            long result = 0; 

            for(int i = 0 ; i < pw2_mod ; i++){
                temp = pre;
                pre = curr;
                curr = (temp + pre) % mod;

                if((pre == 0) && (curr == 1)){
                    result = i+1;
                }
            }

            return result;
        }


    }
}
