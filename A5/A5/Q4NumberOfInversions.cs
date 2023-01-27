using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] a)
        {
            return mergeSort(a,n);
        }



        public static long mergeSort(long[] a,long n){
            long total = 0;

            if (n<2) return 0;


            long mid = (int)n / 2;

            long[] left = new long[mid];
            long[] right = new long[n- mid];

            for(int i=0 ; i<mid ; i++){
                left[i] = a[i];
            }

            for(int i=(int)mid ; i<n ; i++){
                right[i - mid] = a[i];
            }

            total += mergeSort(left,mid);
            total += mergeSort(right,n-mid);


            return total + merge(a,left,right,mid,n-mid);

        }

        public static long merge(long[] a ,long[] left,long[] right,long leftN,long rightN){
            int i=0,j=0,k=0;
            long inv = 0;

            while(i < leftN && j < rightN){
                if(left[i] <= right[j]){
                    a[k++] = left[i++];
                }
                else{
                    a[k++] = right[j++];
                    inv += (leftN - i);
                }
            }


            while(i < leftN){
                a[k++] = left[i++];
            }
            while(j < rightN){
                a[k++] = right[j++];
            }



            return inv;


        }

    }
}
