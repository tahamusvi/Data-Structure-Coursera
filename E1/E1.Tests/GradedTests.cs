using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1;
using TestCommon;

namespace E1.Tests
{
    [DeploymentItem("TestData", "E1_TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void Q1Test()
        {
            RunTest(new Q1("TD1"));
        }

        [TestMethod(), Timeout(1000)]
        public void Q2Test()
        {
            RunTest(new Q2("TD2"));
        }

        [TestMethod(), Timeout(1000)]
        public void Q3Test()
        {
            RunTest(new Q3("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E1", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
