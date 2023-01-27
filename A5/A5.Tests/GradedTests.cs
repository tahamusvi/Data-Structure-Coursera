using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A5.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q1BinarySearch()
        {
            RunTest(new Q1BinarySearch("TD1"));
        }
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q2MajorityElement()
        {
            RunTest(new Q2MajorityElement("TD2"));
        }
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q3ImprovingQuickSort()
        {
            RunTest(new Q3ImprovingQuickSort("TD3"));
        }
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q4NumberOfInversions()
        {
            RunTest(new Q4NumberOfInversions("TD4"));
        }
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q5OrganizingLottery()
        {
            RunTest(new Q5OrganizingLottery("TD5"));
        }
        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q6ClosestPoints()
        {
            RunTest(new Q6ClosestPoints ("TD6"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A5", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}