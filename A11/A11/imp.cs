using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class node
    {
        public long key , sum ;

        public node parent, left, right;
        public node(long n)
        {
            key = n;
            left = null;
            right = null;
            parent = null;
        }

        public node(long key, long sum, node left= null, node right=null, node parent=null)
        {
            this.key = key;
            this.sum = sum;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }
        public void addRight(long n)
        {
            node temp = new node(n);
            right = temp;
        }
        public void addLeft(long n)
        {
            node temp = new node(n);
            left = temp;
        }
        public void addFather(node n)
        {
            parent = n;
        }
    }
}