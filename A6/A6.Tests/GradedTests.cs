using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(200)]
        public void SolveTest_Q1MoneyChange()
        {
            RunTest(new Q1MoneyChange("TD1"));
        }

        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q2PrimitiveCalculator()
        {
            RunTest(new Q2PrimitiveCalculator("TD2"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q3EditDistance()
        {
            RunTest(new Q3EditDistance("TD3"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q4LCSOfTwo()
        {
            RunTest(new Q4LCSOfTwo("TD4"));
        }

        [TestMethod(), Timeout(600)]
        public void SolveTest_Q5LCSOfThree()
        {
            RunTest(new Q5LCSOfThree("TD5"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A6", p.Process, p.TestDataName, p.Verifier);
        }

    }
}