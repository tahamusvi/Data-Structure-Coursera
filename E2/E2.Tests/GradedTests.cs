using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;
using System;
using System.Collections.Generic;

namespace E2.Tests
{
    [DeploymentItem("TestData", "E2_TestData")]
    [TestClass()]
    public class GradedTests
    {
        // Time azafe shode ast.
        [TestMethod(), Timeout(3000)]
        public void Q1TicketsTest()
        {
            RunTest(new Q1Tickets("TD1"));
        }

        [TestMethod(), Timeout(1000)]
        public void Q2Median()
        {
            RunTest(new Q2Median("TD2"));
        }

        [TestMethod(), Timeout(1000)]
        public void Q3ExtractCode()
        {
            RunTest(new Q3ExtractCode("TD3"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("E2", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}
