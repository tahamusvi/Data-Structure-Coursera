using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A12
{
    public class Q2AddExitToMaze : Processor
    {
        public Q2AddExitToMaze(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            Disjoint dis = new Disjoint(nodeCount);
            
            for (int i = 0; i < edges.Length; i++) dis.union(edges[i][1] - 1,edges[i][0] - 1);


            long result = 0;
            List<long> ind = new List<long>();

            for (int i = 0; i < dis.parent.Length; i++) ind.Add(dis.find(i));


            ind.Sort();

            long temp = -1;

            foreach (var item in ind)
            {
                if(temp != item)
                {
                    temp = item;
                    result++;
                }
                else continue;
            }


            return result;
        }
    }
}
