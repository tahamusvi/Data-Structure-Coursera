using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class splayTree
    {

        public node root ;


        public splayTree() 
        {
            root = null;
        }


        public void Add(long x)
        {
            node left = null, right = null;

            split(root, x, ref left, ref right);

            node temp = ((right == null || right.key != x) ? new node(x, x) : null);
            
            this.root = mergeRight(mergeLeft(left, temp), right);
        }

        public node mergeLeft(node left,node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            node max_left = left;
            while (max_left.right != null) max_left = max_left.right;
            
            splay(ref left, max_left);

            left.right = right;
            Adoption(left);
            return left;
        }

        public void split(node root, long key, ref node left, ref node right)
        {
            // ------------------------
            right = tree.Search(ref root, key);

            splay(ref root, right);

            if (right == null)
            {
                left = root;
                return;
            }

            left = right.left;
            right.left = null;

            if (left != null) left.parent = null;
            
            Adoption(left);
            Adoption(right);
        }


        public void Adoption(node Node)
        {
            if (Node == null) return;
            Node.sum = Node.key;

            if (Node.left != null)
            {
                Node.left.parent = Node;
                Node.sum += Node.left.sum;
            }

            if (Node.right != null) 
            {
                Node.right.parent = Node;
                Node.sum += Node.right.sum;
            }     
            
        }

        public void delete(long x)
        {
            if (find(x) == "Not found") return;

            long Key = root.key;
            if (root.left == null)
            {
                // left null
                root = root.right;
                if (root != null) root.parent = null;
            }
            else if (root.right == null)
            {
                // right null
                root = root.left;
                if (root != null) root.parent = null;
            }
            else
            {
                // both not null or null
                node lt = root.left;
                lt.parent = null;

                root.left = null;
                root = root.right;
                root.parent = null;

                find(Key);

                root.left = lt;
                lt.parent = root;
            }
 
            if (root != null) Adoption(root);
        }

        public void rotateChose(node Node)
        {
            node parent = Node.parent;

            if (parent.left == Node) rotateLeft(Node);  
            else rotateRight(Node); 
            
        }

        public void rotateLeft(node Node)
        {
            node parent = Node.parent;

            if (parent == null) return;

            node grandparent = Node.parent.parent;

            node temp = Node.right;
            Node.right = parent;
            parent.left = temp;
            

            Adoption(parent);
            Node.parent = grandparent;
            Adoption(Node);

            if (grandparent == null) return;
            
            if (grandparent.left == parent) grandparent.left = Node;
            else grandparent.right = Node;

            Adoption(grandparent);
        }

        public void rotateRight(node Node)
        {
            node parent = Node.parent;

            if (parent == null) return;

            node grandparent = Node.parent.parent;

            node temp = Node.left;;
            Node.left = parent;
            parent.right = temp;
            

            Adoption(parent);
            Node.parent = grandparent;
            Adoption(Node);

            if (grandparent == null) return;
            
            if (grandparent.left == parent) grandparent.left = Node;
            else grandparent.right = Node;

            Adoption(grandparent);

        }

        public void AdvanceRotate(node Node)
        {
            if ((Node.parent.left == Node && Node.parent.parent.left == Node.parent)||(Node.parent.right == Node && Node.parent.parent.right == Node.parent))
            {
                rotateChose(Node.parent);
            }
            else rotateChose(Node);
            
            rotateChose(Node);
            
        }
        public void splay(ref node root, node Node)
        {
            if (Node == null) return;
            

            //loop convert Node to root
            while (Node.parent != null)
            {
                if (Node.parent.parent == null){rotateChose(Node); break;}
                AdvanceRotate(Node);
            }

            root = Node;
        }

        public string find(long x)
        {
            node temp = tree.Search(ref root, x);
            splay(ref root, temp);
            if (temp != null && temp.key == x) return "Found";
            return "Not found";
        } 

        public node mergeRight(node left, node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            node min_right = right;
            while (min_right.left != null) min_right = min_right.left;
            
            splay(ref right, min_right);

            right.left = left;
            Adoption(right);
            return right;
        }
        public long sum(long l , long r)
        {
            r++;
            node left = null,right = null,middle = null;

            split(root, r , ref middle, ref right);
            split(middle, l , ref left, ref middle);

            long result = (middle != null ? middle.sum: 0);
            root = mergeLeft(mergeLeft(left, null), mergeLeft(middle, right));
            
            return result;
        }
        
    }
}

 