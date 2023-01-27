using System.Linq;
using System;
using System.Collections.Generic;

namespace E2
{
    public class E2Processors
    {

        public static string ProcessQ1Tickets(string inStr, Func<long, Tuple<string, string>[], string[]> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            Tuple<string, string>[] arr = new Tuple<string, string>[n];
            for (int i = 1; i <= n; i++){
                string[] line = lines[i].Split("->");
                arr[i - 1] = Tuple.Create(line[0], line[1]);
            }

            string[] result = Solve(n, arr);

            return string.Join('\n', result);
        }

        public static string ProcessQ2Median(string inStr, Func<long, long[],String> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var n = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => int.Parse(d)).ToArray()[0];
            long[] arr = new long[n];
            for(int i=0;i<n;i++)
            {
                arr[i] = long.Parse(lines [i+1]);
            }
            
            return Solve(n,arr);
        }

        public static string ProcessQ3ExtractCode(string inStr, Func<string, string> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string input = lines[0];

            return Solve(input);
        }
    }
}
