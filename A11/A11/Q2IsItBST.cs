using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            tree tr = new tree(nodes[0][0]);

            node temp = tr.root;
            tr.createTree(nodes,temp,0);    
            tr.InOrderfunc(tr.root);

            bool isBST = true;
            long[] iOL = tr.Inorder.ToArray(); //inOrderList

            for (int i = 0; i < nodes.Length-1; i++)
            {
                if(iOL[i] > iOL[i+1])
                {
                    isBST = false;
                    break;
                } 
                
            }



            return isBST;
        }
    }
}
