using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
            long[] index = new long[b.Length];


            for(int i = 0; i < b.Length; i++){
                index[i] = BinarySearch(a,0,a.Length - 1,b[i]);
            }


            return index;
        }


        public static long BinarySearch(long[] n ,long low,long high,long key){
            while(true){
                if(high < low){
                    return -1;
                }
                long mid = low + ((high - low)/2);

                if(key == n[mid]){
                    return mid;
                }

                else if (key < n[mid]){
                    high = mid - 1;
                }
                else{
                    low = mid + 1;
                }

            }
        }




        
    }
}
