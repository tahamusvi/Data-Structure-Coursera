using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
            QuickSort(a,0,n-1);

            return a;
            
        }

        private static void swap(long[] n, long i, long j)
        {
            long temp = n[i];
            n[i] = n[j];
            n[j] = temp;
        }


        public static void QuickSort(long[] n,long left,long right){
            if(left>=right){
                return ;
            }
            
            long[] mids = prQuickSort(n,left,right);

            QuickSort(n,left,mids[0]-1);
            QuickSort(n,mids[1]+1,right);

        }


        public static long[] prQuickSort(long[] a,long left,long right){

            long check = a[left];

            long j = left;
            long k = left;

            for (long i = left + 1; i <= right; i++){
                if (a[i] < check){
                    k++;
                    swap(a, i, k);
                    j++;
                    swap(a, k, j);
                }
                else if (a[i] == check){
                    k++;
                    swap(a, i, k);
                }
            }


            swap(a, left, j);


            return new long[]{ j + 1, k };

        }

        


    }
}
