using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q5Rope : Processor
    {
        public Q5Rope(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long[][], string>)Solve);

        public string Solve(string text, long[][] queries)
        {
            // foreach(var q in queries)
            // {
            //     int i = (int)q[0],
            //         j = (int)q[1],
            //         k = (int)q[2];

            //     int cutLen = j - i + 1;
            //     string cut = text.Substring(i, cutLen);
            //     text = text.Remove(i, cutLen);
            //     text = text.Insert(k, cut);
            // }
            // return text;

            return "";
        }
    }
}

 