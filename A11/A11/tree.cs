using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    
    class tree
    {
        public node root;
        public long amount;
        public List<long> Inorder = new List<long>();
        public List<long> InorderId = new List<long>();
        public List<long> Postorder = new List<long>();
        public List<long> Preorder = new List<long>();

        public tree(long n)
        {
            node rt = new node(n);
            root = rt;
            amount = 1;
        }

        public static node Search(ref node root, long key)
        {
            node Node = root;
            node last = root;
            node next = null;

            while (Node != null)
            {
                if (Node.key >= key  && (next == null || Node.key < next.key)) next = Node;
                
                last = Node;

                if (Node.key == key) break;
                
                else if (Node.key < key) Node = Node.right;
                
                else Node = Node.left;                
            }

            return next;
        }

        public void createTree(long[][] nodes,node temp,long i )
        {
            long left = nodes[i][1];
            long right = nodes[i][2];

            if(left == -1 && right == -1) return;

            if(left != -1) 
            {
                temp.addLeft(nodes[left][0]);
                this.createTree(nodes,temp.left,left);
            }
            if(right != -1) 
            {
                temp.addRight(nodes[right][0]);
                this.createTree(nodes,temp.right,right);
            }

        }

        public static long updateAmount(node n)
        {
            if(n == null) return 0;
            long rChild = 0 , lChild = 0;

            if(n.right != null)  rChild = updateAmount(n.right);
            if(n.left != null)  lChild = updateAmount(n.left);


            return  rChild + lChild;
        }

        public void PreOrderfunc(node nr)
        {
            Stack<node> s = new Stack<node>();
            node curr = root;
            s.Push(curr);
            while(s.Count > 0)
            {
                curr = s.Pop();
                Preorder.Add(curr.key);
                if(curr.right != null) s.Push(curr.right);
                if(curr.left != null) s.Push(curr.left);
            }
        }

        public void PostOrderfunc(node nr)
        {
            Stack<node> s = new Stack<node>();
            node curr = root;
            s.Push(nr);

            while (s.Count > 0)
            {
                node temp = s.Pop();
                Postorder.Add(temp.key);              
                if(temp.left != null) s.Push(temp.left);
                if(temp.right != null) s.Push(temp.right);             
            }
            Postorder.Reverse();
        }
        
        public void InOrderfunc(node nr)
        {
            Stack<node> s = new Stack<node>();
            node curr = root;
            long count = 0;

            while (curr != null || s.Count > 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.left;
                }
                curr = s.Pop();
                Inorder.Add(curr.key);
                InorderId.Add(++count);
                curr = curr.right;
            }
        }

        public void InOrderRec(node nr)
        {
            if(nr == null) return;

            if(nr.left != null ) InOrderRec(nr.left);
            // Console.WriteLine(nr.key);
            Inorder.Add(nr.key);
            if(nr.right != null ) InOrderRec(nr.right);

        }

        public static bool TestBST(node root, long Min, long Max)
        {
            if (root.key < Min || root.key >= Max) return false;

            if (root.left == null && root.right == null) return true;

            else if (root.left == null) return TestBST(root.right, root.key, Max);
            else if (root.right == null) return TestBST(root.left, Min, root.key);

            else return ((TestBST(root.right, root.key, Max))) && (TestBST(root.left, Min, root.key));

        }
    }
}
