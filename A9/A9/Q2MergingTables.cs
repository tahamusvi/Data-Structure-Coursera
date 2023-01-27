using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            throw new NotImplementedException();
        }

    }
}
