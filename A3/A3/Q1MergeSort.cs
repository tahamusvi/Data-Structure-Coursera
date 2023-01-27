using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            // throw new NotImplementedException();
            mergeSort(a,n);
            return a;

        }


        public static void mergeSort(long[] a,long n){

            if (n<2) return ;


            long mid = (int)n / 2;

            long[] left = new long[mid];
            long[] right = new long[n- mid];

            for(int i=0 ; i<mid ; i++){
                left[i] = a[i];
            }

            for(int i=(int)mid ; i<n ; i++){
                right[i - mid] = a[i];
            }

            mergeSort(left,mid);
            mergeSort(right,n-mid);

            merge(a,left,right,mid,n-mid);



        }

        public static void merge(long[] a ,long[] left,long[] right,long leftN,long rightN){
            int i=0,j=0,k=0;

            while(i < leftN && j < rightN){
                if(left[i] <= right[j]){
                    a[k++] = left[i++];
                }
                else{
                    a[k++] = right[j++];
                }
            }


            while(i < leftN){
                a[k++] = left[i++];
            }
            while(j < rightN){
                a[k++] = right[j++];
            }


        }

    

    }
}
