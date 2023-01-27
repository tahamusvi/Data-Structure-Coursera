using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            tree tr = new tree(nodes[0][0]);

            node temp = tr.root;
            tr.createTree(nodes,temp,0);
            
            // tr.amount = nodes.Length;     
            
            tr.PreOrderfunc(tr.root);
            tr.PostOrderfunc(tr.root);
            tr.InOrderfunc(tr.root);

   
            long [][] result = new long[3][];

            result[0] = tr.Inorder.ToArray();
            result[1] = tr.Preorder.ToArray();
            result[2] = tr.Postorder.ToArray();


            return result;
        }
    }
}














