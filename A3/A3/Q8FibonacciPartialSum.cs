using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            long total;
            if(a>b){
                total = b;
                b = a;
                a = total;
            }

            a = a % 60;
            b = b % 60;


            total = fibSum(b) - fibSum(a-1);
            if(total<0){
                total = total + 10;
            }
  
            return total ;
            // throw new NotImplementedException();
        }


        public long fibSum(long n){

            long leftover = n % 60;
            

            long somLeftOver  = fibonacciOnMod(leftover+2,10)-1;

            if(somLeftOver<0){
                somLeftOver = 9;
            }

            return somLeftOver;
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
