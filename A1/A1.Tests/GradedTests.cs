using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A1.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1Add()
        {
            RunTest(new Q1Add("TD1"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A1", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }

    }
}