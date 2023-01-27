using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            this.ExcludeTestCases(5);
            
            QuickSort(startSegments,0,startSegments.Length-1);

            QuickSort(endSegment,0,endSegment.Length-1);

            return lottery(startSegments,endSegment,points);
        }


        public static long[] lottery(long[] s,long[] e, long[] point){

            long amount = point.Length;

            long[] final = new long[amount];

            for (int i = 0; i < amount; i++){
                final[i] = BinarySearch(s, 0, s.Length-1, point[i]) - BinarySearch(e, 0, e.Length-1, point[i]);
            }
            return final;
        }


        public static long BinarySearch(long[] n ,long low,long high,long key){
            while(true){
                if(high < low){
                    return high;
                }
                long mid = (int)low + ((high - low)/2);

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
