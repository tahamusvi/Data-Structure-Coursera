using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            long l1 = str1.Length;
            long l2 = str2.Length;

            // for (int i = 0; i < l1; i++) Console.WriteLine(str1[i]);
            

            long[,] matrix = new long[l1+1,l2+1];

            

            for(int i = 0 ; i <= l1 ; i++) matrix[i,0] = i;

            for(int j = 0 ; j <= l2 ; j++) matrix[0,j] = j;


            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    long plus = 1;
                    if( str1[i-1] == str2[j-1]){
                        plus = 0;
                    }
                    matrix[i,j] = Math.Min(Math.Min(matrix[i-1,j] + 1 , matrix[i,j-1] + 1),matrix[i-1,j-1] + plus);
                }
            }



            return matrix[l1,l2];

        }
    
    }
}







