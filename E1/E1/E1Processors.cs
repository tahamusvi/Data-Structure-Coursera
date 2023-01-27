using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1
{
    public class E1Processors
    {
        public static string ProcessQ1(string inStr, Func<long, long[], long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var num = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray()[0];
            var arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            
            long result = Solve(num, arr);
            return result.ToString();
        }

        public static string ProcessQ2(string inStr, Func<long, long, long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var firstLine = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            var n = firstLine[0];
            var k = firstLine[1];
            
            long result = Solve(n, k);
            return result.ToString();
        }

        public static string ProcessQ3(string inStr, Func<long, long[], long> Solve)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long [] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, arr).ToString();
        }
    }
}
