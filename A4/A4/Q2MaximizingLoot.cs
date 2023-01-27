using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            int indMax = 0;
            long stolen = 0;


            double[] VPW = new double[values.Length];

            for (int i = 0; i < values.Length ; i++){
                VPW[i] = (double)values[i] / (double)weights[i];
            }
            


            while(capacity > 0){
                indMax = findMax(VPW);
                VPW[indMax] = -1;
                
                if(capacity > weights[indMax]){
                    capacity -= weights[indMax];
                    stolen += values[indMax];
                }
                else{
                    stolen += (values[indMax]* capacity )/ weights[indMax];
                    capacity = 0;
                }
            } 

            System.Console.WriteLine(stolen);

            return stolen;



            
        }


        public static int findMax(double[] ar){
            double max = 0;
            int count = 0;
            for (int i = 0; i < ar.Length ; i++){
                if(ar[i]>max){
                    max = ar[i];
                    count = i ;
                }
            }
            return count;
        }

        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
