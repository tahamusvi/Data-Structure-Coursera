using System;
using System.Collections.Generic;
using TestCommon;

namespace A12
{

    public class Q1MazeExit : Processor
    {
        public Q1MazeExit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);

        public long Solve(long nodeCount, long[][] edges, long StartNode, long EndNode)
        {
            Disjoint dis = new Disjoint(nodeCount);
            
            for (int i = 0; i < edges.Length; i++) dis.union(edges[i][1] - 1,edges[i][0] - 1);


            if (dis.find(StartNode - 1) == dis.find(EndNode - 1))
                return 1;
            return 0;
        }

     }
}
