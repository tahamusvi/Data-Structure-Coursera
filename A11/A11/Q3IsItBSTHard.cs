using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);


        public bool Solve(long[][] nodes)
        {
            tree tr = new tree(nodes[0][0]);

            node temp = tr.root;
            tr.createTree(nodes,temp,0);

            return tree.TestBST(temp,long.MinValue ,long.MaxValue);    
        }


        
    }
}
