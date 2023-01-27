using TestCommon;
using System;
using System.Collections.Generic;

namespace E2
{
    public class Node2
    {
        public string city1;
        public string city2;

        public Node2(string c1,string c2)
        {
            this.city1 = c1;
            this.city2 = c2;
        }
    }

    public class list
    {
        public long n;
        public List<Node2> l ;
        public long cap = 0;
        public list()
        {
            l = new List<Node2>();
        }

        public string find(string key)
        {
            for (int i = 0; i < cap; i++)
            {
                if(l[i].city1 == key) return "yes";
            }
            return "no";   
        }

        public string find(string key,int n)
        {
            for (int i = 0; i < cap; i++)
            {
                if(l[i].city1 == key) return l[i].city2;
            }
            return null;   
        }
        public void insert(string c1,string c2)
        {
            l.Add(new Node2(c1,c2));
            cap++;
        }

    }


    
        public class table
    {
        public long number;
        public list[] row ;
        public table(long n)
        {
            this.number = n;
            this.row = new list[n];
            for (int i = 0; i < n; i++) row[i] = new list();
        }

        public void Add(string text,string city)
        {
            long row_num = Q1Tickets.PolyHash(text,0,text.Length) % this.number;
            
            if(this.find(text,city) != "yes"){
                row[row_num].insert(text,city);
            }
        }

        public string find(string text,string city)
        {
            long row_num = Q1Tickets.PolyHash(text,0,text.Length) % this.number;
            
            return row[row_num].find(text);
        }
       

        public string[] arrayFind(string text,string city,long number)
        {
            long row_num = Q1Tickets.PolyHash(text,0,text.Length) % this.number;
            List<string> final = new List<string>();
            final.Add(text);
            final.Add(city);

            long n = number;
            string next = city;

            while(n > 1)
            {
                row_num = Q1Tickets.PolyHash(next,0,next.Length) % this.number;
                next = row[row_num].find(next,0);
                final.Add(next);
                n--;
            }
            
            return final.ToArray();
        }

  
    }


    public class Q1Tickets : Processor
    {
        public Q1Tickets(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ1Tickets(inStr, Solve);

        public string[] Solve(long n, Tuple<string, string>[] tickets)
        {
            table tb = new table(n);


            // find des and mabda
            List<string> citys1 = new List<string>();
            List<string> imp = new List<string>();

            for (int i = 0; i < n; i++)
            {
                citys1.Add(tickets[i].Item1);
                citys1.Add(tickets[i].Item2);
            }

            citys1.Sort();

            for (int i = 0; i < (2*n)-1; i++)
            {
                if((citys1[i] != citys1[i+1]) && (citys1[i] != citys1[i-1])) imp.Add(citys1[i]);
            }

            if((citys1[(int)(2*n-1)] != citys1[(int)(2*n - 2)])) imp.Add(citys1[(int)(2*n - 1)]);
            if((citys1[0] != citys1[1])) imp.Add(citys1[0]);



            for (int i = 0; i < n; i++) tb.Add(tickets[i].Item1,tickets[i].Item2);

            long flag = 0;
            string city2 = "";
            for (int i = 0; i < n; i++)
            {
                if(imp[0] == tickets[i].Item1) 
                {
                    flag = 0;
                    city2 = tickets[i].Item2;
                }
                if(imp[1] == tickets[i].Item1) 
                {
                    flag = 1;
                    city2 = tickets[i].Item2;
                }
            }
            
            string city1 = imp[(int)flag];
            

            
            string[] final = tb.arrayFind(city1,city2,n);

            // foreach (var item in final)
            // {
            //     Console.WriteLine(item);
                
            // }
            



            return final;
        }



        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 26543;

        public static long PolyHash(string str, int start, int count,long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = start + count - 1; i >= 0; i--) hash = (hash * x + (int)str[i]) % p;
            return hash;
        }

        
    }
}
