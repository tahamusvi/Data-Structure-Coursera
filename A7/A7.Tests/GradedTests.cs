using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A7.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {

        [TestMethod(), Timeout(300)]
        public void SolveTest_Q1MaximumGold()
        {
            RunTest(new Q1MaximumGold("TD1"));
        }

        [TestMethod(), Timeout(300)]
        public void SolveTest_Q2PartitioningSouvenirs()
        {
            RunTest(new Q2PartitioningSouvenirs("TD2"));
        }


        [TestMethod(), Timeout(300)]
        public void SolveTest_Q3MaximizingArithmeticExpression()
        {
            RunTest(new Q3MaximizingArithmeticExpression("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A7", p.Process, p.TestDataName, p.Verifier);
        }               
    }
}
