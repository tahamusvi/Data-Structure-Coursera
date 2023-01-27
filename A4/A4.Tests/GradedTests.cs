using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A4.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(200)]
        public void SolveTest_Q1ChangingMoney()
        {
            RunTest(new Q1ChangingMoney("TD1"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q2MaximizingLoot()
        {
            RunTest(new Q2MaximizingLoot("TD2"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q3MaximizingOnlineAdRevenue()
        {
            RunTest(new Q3MaximizingOnlineAdRevenue("TD3"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q4CollectingSignatures()
        {
            RunTest(new Q4CollectingSignatures("TD4"));
        }

        [TestMethod(), Timeout(500)]
        public void SolveTest_Q5MaximizeNumberOfPrizePlaces()
        {
            RunTest(new Q5MaximizeNumberOfPrizePlaces("TD5"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q6MaximizeSalary()
        {
            RunTest(new Q6MaximizeSalary("TD6"));
        }

        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q7MaxSubarraySum()
        {
            RunTest(new Q7MaxSubarraySum("TD7"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A4", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}