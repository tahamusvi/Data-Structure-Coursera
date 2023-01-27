using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            long result = 0;
 
            mergeSort(adRevenue,averageDailyClick.Length);
            mergeSort(averageDailyClick,averageDailyClick.Length);

            long[] AvR = new long[averageDailyClick.Length];

            for (int i = 0; i < averageDailyClick.Length ; i++){
                AvR[i] = adRevenue[i] * averageDailyClick[i];
            }
    
            for(int i = 0;i<slotCount;i++){
                result += AvR[i];
            }

            return result;
            
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
