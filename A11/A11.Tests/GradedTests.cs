using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A11.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q1BinaryTreeTraversals()
        {
            RunTest(new Q1BinaryTreeTraversals("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2IsItBST()
        {
            RunTest(new Q2IsItBST("TD2"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q3IsItBSTHard()
        {
            RunTest(new Q3IsItBSTHard("TD3"));
        }

        [TestMethod(), Timeout(6000)] // change the timeout to 6000 if you could solve it
        public void SolveTest_Q4SetWithRangeSums()
        {
            RunTest(new Q4SetWithRangeSums("TD4"));
        }

        // [TestMethod(), Timeout(6000)]
        // public void SolveTest_Q5Rope()
        // {
        //     RunTest(new Q5Rope("TD5"));
        // }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A11", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }

    }
}