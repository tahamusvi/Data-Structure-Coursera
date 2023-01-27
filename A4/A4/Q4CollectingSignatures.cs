using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            long[] resultPoint = new long[tenantCount];
            var Lines =  createList(startTimes,endTimes);

            
            long point = Lines[0].Item2;
            resultPoint[0] = point;


            int count = 1;
            foreach (var end in Lines){
                if (end.Item1 > point){
                    resultPoint[count] = end.Item2;
                    count++;
                    point = end.Item2;
                }
            }
            return count;
        }

        public static List<Tuple<long,long>> createList(long[] startTimes, long[] endTimes){
            List<Tuple<long,long>> l = new List<Tuple<long,long>>();
            
            for (int i = 0; i < startTimes.Length; i++){
                l.Add(new Tuple<long, long>(startTimes[i],endTimes[i]));
            }

            l = l.OrderBy(x => x.Item2).ToList();

            return l;
        }











    }
}
