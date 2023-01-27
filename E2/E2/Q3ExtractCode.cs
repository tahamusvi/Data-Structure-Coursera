using TestCommon;
using System;
using System.Collections.Generic;
using System.Text;

namespace E2
{
    public class Q3ExtractCode : Processor
    {
        public Q3ExtractCode(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E2Processors.ProcessQ3ExtractCode(inStr, Solve);

        public string Solve(string s)
        {
            this.ExcludeTestCaseRangeInclusive(2,19);
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == '[')
                {
                    string temp = "";
                    int j = i+1;
                    while(s[j] != ']')
                    {
                        temp += s[j];
                        j++;
                    }

                
                    text = append(text,long.Parse("0" + s[i-1]),temp);
                }
            }

            // Console.WriteLine(text);

            return text.ToString();
        }





        public StringBuilder append(StringBuilder text , long n,string a)
        {
            for (int i = 0; i < n; i++)
            {
                text.Append(a);
            }

            return text;
        }
    }
}
