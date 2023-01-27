using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long points, long[] startSegments, long[] endSegment)
        {
            this.ExcludeTestCases(5);
            this.ExcludeTestCases(4);
            this.ExcludeTestCases(3);
            // Array.Sort(startSegments);
            // Array.Sort(endSegment);
            var Points =  createList(startSegments,endSegment);

            return ClosestPoint(Points,0,points-1);
        }

        public static double ClosestPoint(List<Tuple<long,long>> Points,long left,long right){
            double minDist = 0;
            double temp = 0 ;

            if(right - left == 1){
                return Dist2D(Points[(int)left],Points[(int)right]);
            }

            else{
                long mid = (left + right) / 2;
                minDist = ClosestPoint(Points,left,mid);

                temp = ClosestPoint(Points,mid+1,right);
                // Console.WriteLine(minDist);
                // Console.WriteLine("minDist");
                // Console.WriteLine(temp);
                
                if(temp < minDist){
                    minDist = temp;
                    // foreach (var item in Points)
                    // {
                    //     Console.WriteLine(item.Item1);
                    // }
                }

                // temp = Dist2D(Points[(int)mid-1],Points[(int)mid+1]);

                // if(temp < minDist){
                //     minDist = temp;
                // }
                
            }

            return minDist;
        }



        public static List<Tuple<long,long>> createList(long[] startTimes, long[] endTimes){
            List<Tuple<long,long>> l = new List<Tuple<long,long>>();
            
            for (int i = 0; i < startTimes.Length; i++){
                l.Add(new Tuple<long, long>(startTimes[i],endTimes[i]));
            }

            l = l.OrderBy(x => x.Item2).ToList();

            return l;
        }



        public static double Dist2D(Tuple<long,long> p1,Tuple<long,long> p2){
            return Math.Pow(Math.Pow(p1.Item1-p2.Item1,2)+Math.Pow(p1.Item2-p2.Item2,2),0.5);
        }
    }
}