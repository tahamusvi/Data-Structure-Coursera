using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PriorityQueues;
using TestCommon;

namespace E2
{
    

    public class Q2Median : Processor
    {
        public Q2Median(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => E2Processors.ProcessQ2Median(inStr, Solve);

        public String Solve(long n,long[] arr)
        {
            this.ExcludeTestCaseRangeInclusive(4,10);
            List<long> list = new List<long>();
            long[] array = new long[n];
            List<double> final = new List<double>();

            for (int i = 0; i < n; i++)
            {
                list.Add(arr[i]);
                list.Sort();
                Sift(array, array.Length, i);
                

                if(list.Count % 2 == 1)
                {
                    int index = (int)((list.Count) / 2);
                    final.Add(list[index]);
                }
                else
                {
                    long index = (long)((list.Count-1) / 2)  ;
                    Double number1 = (double)((list[(int)index] + list[(int)index+1])) / 2 ;

                    final.Add(number1);
                }
                
            }

            string temp = "";

            foreach (var item in final)
            {
                temp += item.ToString("0.0") + "\n";
            }




            return temp;
        }


        public static void Sift(long[] Heap, long size, long i)
        {
            long check = i;

            if ((2 * i + 1) < size && Heap[(2 * i + 1)] < Heap[check]) check = (2 * i + 1);
            if ((2 * i + 2) < size && Heap[(2 * i + 2)] < Heap[check]) check = (2 * i + 2);

            if (check != i)
            {
                swap(Heap,i,check);
                Sift(Heap, size, check);
            }
            
        }

        public static void swap(long[] Heap,long i,long j)
        {
            long temp = Heap[i];
            Heap[i] = Heap[j];
            Heap[j] = temp;
        }

        
    }
}