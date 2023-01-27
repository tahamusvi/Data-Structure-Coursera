using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            if(money == 0){
                return 0;
            }


           long amountCoin = 0 ;


           for(int i = 10; i > 4 ; i-=5){
                amountCoin += (money - (money % i)) / i;
                money = money % i;
           }

           amountCoin += money;
           
           return amountCoin;

        
        }

    }
}
