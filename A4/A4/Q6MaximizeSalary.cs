using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


         public virtual string Solve(long n, long[] numbers)
        {
            var nums = numbers.ToList();
            string result = "";
            
            for(int i = 0 ; i < n ; i++)
            {
                long max = 0;
                foreach (var x in nums)
                {
                    max = Compare(x,max);
                }

                result += max.ToString();
                nums.Remove(max);
            }


            return result;
        }

        public static long Compare(long n,long m){

            string s1 = n.ToString() + m.ToString();
            string s2 = m.ToString() + n.ToString();

            if(int.Parse(s1)>int.Parse(s2)){
                return n;
            }
            return m;
        }

    }
}

