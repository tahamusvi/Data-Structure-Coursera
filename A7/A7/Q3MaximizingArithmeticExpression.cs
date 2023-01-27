using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            int numberAmount = (expression.Length / 2) + 1;

            List<long> numbers = new List<long>(numberAmount);
            List<char> op = new List<char>(numberAmount - 1);

            long[,] MaxTable = new long[numberAmount,numberAmount];
            long[,] MinTable = new long[numberAmount,numberAmount];

            for(int i = 0 ; i<expression.Length ; i++)
            {
                if(i % 2 == 0) numbers.Add(int.Parse(expression[i].ToString()));
                else op.Add(expression[i]);
            }

            for(int i = 0 ; i < numbers.Count ;i++)
            {
                MaxTable[i,i] = numbers[i];
                MinTable[i,i] = numbers[i];
            }

            long res = 0;


            for (int d = 1 ; d < numbers.Count ; d++)
            {
                for (int i = 0; i < numbers.Count - d ; i++)
                {
                    int j = d + i;

                    long[] temp = DpS(i,j,op,MaxTable,MinTable);
                    MinTable[i,j] = temp[0];
                    MaxTable[i,j] = temp[1];

                    res = temp[1];
                    

                }
            }



            return res ;
        }


        public static long[] DpS(int i, int j ,List<char> op,long[,] MaxTable,long[,] MinTable)
        {
            long min = long.MaxValue;
            long max = long.MinValue;

            long[] Ans = new long[2]; 
            long[] result = new long[4];

            for(int k = i ; k <= j-1 ;k++)
            {
                result = OpOnNum(op[k],MaxTable,MinTable,i,k,j);
                min = (long)Math.Min(min, Math.Min(result[0], Math.Min(result[1], Math.Min(result[2], result[3]))));
                max = (long)Math.Max(max, Math.Max(result[0], Math.Max(result[1], Math.Max(result[2], result[3]))));
                
                
            }

            Ans[0] = min;
            Ans[1] = max;


            return Ans;
        }



        public static long[] OpOnNum(char ops ,long[,] MaxTable,long[,] MinTable,int i , int t , int j)
        {
            long[] result = new long[4];

            if(ops == '*')
            {
                result[0] = MaxTable[i, t] * MaxTable[t + 1, j];
                result[1] = MaxTable[i, t] * MinTable[t + 1, j];
                result[2] = MinTable[i, t] * MaxTable[t + 1, j];
                result[3] = MinTable[i, t] * MinTable[t + 1, j];
            }
            else if(ops == '+')
            {
                result[0] = MaxTable[i, t] + MaxTable[t + 1, j];
                result[1] = MaxTable[i, t] + MinTable[t + 1, j];
                result[2] = MinTable[i, t] + MaxTable[t + 1, j];
                result[3] = MinTable[i, t] + MinTable[t + 1, j];
            }
            else 
            {
                result[0] = MaxTable[i, t] - MaxTable[t + 1, j];
                result[1] = MaxTable[i, t] - MinTable[t + 1, j];
                result[2] = MinTable[i, t] - MaxTable[t + 1, j];
                result[3] = MinTable[i, t] - MinTable[t + 1, j];
            }

            return result;
        }




    }
}
