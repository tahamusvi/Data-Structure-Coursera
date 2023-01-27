using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{

    public class Node2
    {
        public string data;
        public Node2 next;
        public Node2 prev;

        public Node2(string text)
        {
            this.data = text;
            this.next = null;
            this.prev = null;
        }
    }


    public class LinkedList2
    {
        public Node2 head;

        public LinkedList2()
        {
            head = null;
        }

        public void insert(string text)
        {
            Node2 n = new Node2(text);

            if(this.head == null)
            {
                this.head = n;
                return;
            }
            
            Node2 temp = head;
            while(temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = n;
            n.prev = temp;
        }

        public void delete(string key)
        {
            if(head == null) return;

            Node2 temp = head;

            if (temp != null && temp.data == key)
            {  
                if(temp.next == null) head = null;
                else
                {
                    head = temp.next;  
                    head.prev = null; 
                }                
                return;  
            }
            while((temp != null) && (temp.data != key)) temp = temp.next;
            
            if(temp == null) return;
            if (temp.next != null) temp.next.prev = temp.prev;          
            if (temp.prev != null) temp.prev.next = temp.next;   
            
        }

        public string find(string key)
        {
            if(head == null) return "no";

            Node2 temp = head;

            if(temp.data == key) return "yes";

            while((temp != null) && (temp.data != key)) temp = temp.next;
            
            if(temp == null) return "no";
            return "yes";    
             
        }

        public string join()
        {
            List<string> result = new List<string>();
            if(head == null) return "-";
            
            Node2 temp = head;

            while(temp != null)
            {
                result.Add(temp.data);              
                temp = temp.next;
            }

            string line = String.Join(" ",result.ToArray().Reverse()) ;

            return line;
        }


    }
    
        public class table
    {
        public long number;
        public LinkedList2[] row ;
        public table(long n)
        {
            this.number = n;
            this.row = new LinkedList2[n];
            for (int i = 0; i < n; i++) row[i] = new LinkedList2();
        }

        public void Add(string text)
        {
            long row_num = Q2HashingWithChain.PolyHash(text,0,text.Length) % this.number;
            if(this.find(text) != "yes"){
                row[row_num].insert(text);
            }
        }

        public void del(string text)
        {
            long row_num = Q2HashingWithChain.PolyHash(text,0,text.Length) % this.number;
            row[row_num].delete(text);
        }

        public string find(string text)
        {
            long row_num = Q2HashingWithChain.PolyHash(text,0,text.Length) % this.number;
            
            return row[row_num].find(text);
        }

        public string Check(long i)
        {
           return row[i].join();        
        }
    }
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);


        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            table th = new table(bucketCount);

            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        th.Add(arg);
                        break;

                    case "del":
                        th.del(arg);
                        break;

                    case "find":
                        result.Add(th.find(arg));
                        break;

                    case "check":
                        result.Add(th.Check(int.Parse(arg)));
                        break;
                }
            }
     
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(string str, int start, int count,long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = start + count - 1; i >= 0; i--) hash = (hash * x + (int)str[i]) % p;
            return hash;
        }

    }
}
