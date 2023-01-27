using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q4SetWithRangeSums : Processor
    {
        public Q4SetWithRangeSums(string testDataName) : base(testDataName){}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);


        public static long M = 1000000001;

        public static long X = 0;       

        public string[] Solve(string[] lines)
        {
            X = 0;
            splayTree tr = new splayTree();
            List<string> result = new List<string>();

            foreach (var line in lines)
            {
                char cmd = line[0];
                string args = line.Substring(1).Trim();
                long number = 0;
                
                if(cmd != 's') number = Convert(long.Parse(args));
                
                switch (cmd)
                {
                    case '+':
                        tr.Add(number);
                        break;


                        
                    case '?':
                        string temp = tr.find(number);
                        result.Add(temp);
                        break;


                    case '-':
                        tr.delete(number);
                        break;


                    case 's':
                        string[] arg2 = args.Split();
                        long l = Convert(long.Parse(arg2[0]));
                        long r = Convert(long.Parse(arg2[1]));

                        long final = tr.sum(l , r);
                        
                        X = final % M ;
                        result.Add(final.ToString());

                        break;
                }
                
                
            }

            return result.ToArray();
        }


        private long Convert(long i)
            => i = (i + X) % M;


    }
}