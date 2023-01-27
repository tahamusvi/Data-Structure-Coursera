using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {

            List<Tuple<long, long>> result = new List<Tuple<long, long>>();

            for (long i = (array.Length/2)-1; i >= 0; i--) Sift(array, array.Length, i,result);

            return result.ToArray();

        }



        public static void Sift(long[] Heap, long size, long i,List<Tuple<long, long>> result)
        {
            long check = i;

            if ((2 * i + 1) < size && Heap[(2 * i + 1)] < Heap[check]) check = (2 * i + 1);
            if ((2 * i + 2) < size && Heap[(2 * i + 2)] < Heap[check]) check = (2 * i + 2);

            if (check != i)
            {
                result.Add(new Tuple<long, long>(i,check));
                swap(Heap,i,check);
                Sift(Heap, size, check,result);
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
