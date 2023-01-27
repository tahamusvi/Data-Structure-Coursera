using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    

    public class Node
    {
        public Contact data;
        public Node next;
        public Node prev;

        public Node(Contact person)
        {
            this.data = person;
            this.next = null;
            this.prev = null;
        }
    }


    public class LinkedList
    {
        public Node head;

        public LinkedList()
        {
            head = null;
        }

        public void insert(Contact person)
        {
            Node n = new Node(person);

            if(this.head == null)
            {
                this.head = n;
                return;
            }
            
            Node temp = head;
            while(temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = n;
            n.prev = temp;
        }

        public void delete(long key)
        {
            if(head == null) return;

            Node temp = head;

            if (temp != null && temp.data.Number == key)
            {  
                if(temp.next == null) head = null;
                else
                {
                    head = temp.next;  
                    head.prev = null; 
                }                
                return;  
            }
            while((temp != null) && (temp.data.Number != key)) temp = temp.next;
            
            if(temp == null) return;
            if (temp.next != null) temp.next.prev = temp.prev;          
            if (temp.prev != null) temp.prev.next = temp.next;   
            
        }

        public string find(long key)
        {
            if(head == null) return "not found";

            Node temp = head;

            if(temp.data.Number == key) return temp.data.Name;

            while((temp != null) && (temp.data.Number != key)) temp = temp.next;
            
            if(temp == null) return "not found";
            return temp.data.Name;    
             

        }


    }


    public class Contact
    {
        public string Name;
        public long Number;

        public Contact(string name, long number)
        {
            Name = name;
            Number = number;
        }

        override public String ToString()
        {
            return this.Name;
        }
    }

    public class PhoneBook
    {
        public long number;
        public LinkedList[] row ;
        public PhoneBook(long n)
        {
            this.number = n;
            this.row = new LinkedList[n];
            for (int i = 0; i < n; i++) row[i] = new LinkedList();
        }

        public void Add(long num,string name)
        {
            long row_num = num % this.number;
            Contact person = new Contact(name,num);

            if(this.find(num) == "not found") row[row_num].insert(person);
            else {
                this.del(num);
                row[row_num].insert(person);
            }
            
        }

        public void del(long num)
        {
            long row_num = num % this.number;
            row[row_num].delete(num);
        }

        public string find(long num)
        {
            long row_num = num % this.number;
            return row[row_num].find(num);
        }
    }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        protected List<Contact> PhoneBookList;

        public string[] Solve(string [] commands)
        {
            List<string> result = new List<string>();
            PhoneBook ph = new PhoneBook(750);


            foreach(var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                long number = long.Parse(args[0]);

                switch (cmdType)
                {
                    case "add":
                        ph.Add(number,args[1]);
                        break;


                        
                    case "del":
                        ph.del(number);
                        break;


                    case "find":
                        result.Add(ph.find(number));
                        break;
                }


            }
            return result.ToArray();
        }
    

        
    }
}
