using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public const long BigPrimeNumber = 87178291199;
        public const long ChosenX = 100;

        public long[] Solve(string pattern, string text)
        {
            int P = pattern.Length;
            int textLenght = text.Length;
            long PtHash = PolyHash(pattern, 0, P);

            List<long> occurrences = new List<long>();

            long[] H = PreComputeHashes(text, P, BigPrimeNumber, ChosenX);

            for (int i = 0; i < textLenght - P + 1; i++) if(H[i] == PtHash) occurrences.Add(i);

            return occurrences.ToArray();
        }

        // public static long[] PreComputeHashes(
        //    string T,
        //    int P,
        //    long p,
        //    long x)
        // {

        //     int testStr = T.Length;

        //     long[] result = new long[testStr - P + 1];
            
        //     for (int i = 0; i < testStr - P + 1; i++)
        //     {
        //         result[i]= PolyHash(T, i, P, p, x);
        //     }


        //     return result;

        // }

        public static long[] PreComputeHashes(
           string T,
           int P,
           long p,
           long x)
        {
            int len = T.Length;
            long[] H = new long[len - P + 1];

            H[len - P] = PolyHash(T, len - P, P);

            long y = 1;
            for (int i = 0; i < P; i++) y = (y * x) % p;
                

            for (int i = len - P - 1; i >= 0; i--) H[i] = ((H[i + 1] * x ) + T[i] - (T[i + P] * y ) + p*1000) % p;

            return H;
        }


       

        public static long PolyHash(string str, int start, int count,long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            for (int i = start + count - 1; i >= start; i--) hash = (hash * x + (int)str[i]) % p;
            return hash;
        }

        
    }
}
