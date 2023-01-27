using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A10.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(2000)]
        public void SolveTest_Q1PhoneBook()
        {
            RunTest(new Q1PhoneBook("TD1"));
        }

        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q2HashingWithChain()
        {
            RunTest(new Q2HashingWithChain("TD2"));
        }


        [TestMethod(), Timeout(1000)]
        public void SolveTest_Q3RabinKarp()
        {
            RunTest(new Q3RabinKarp("TD3"));
        }


        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A10", p.Process, p.TestDataName, p.Verifier, VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }


        /// <summary>
        /// This test is just to help you test your
        /// PreComputeHashes function. It is not graded
        /// </summary>
        [TestMethod()]
        public void PreComputeHashesTest()
        {
            // Uncomment the following line if you want to have it run
            Assert.Inconclusive();
            string testStr = "aaaa";
            int patternLen = 2;
            long[] H = Q3RabinKarp.PreComputeHashes(
                testStr, patternLen, 101, 3);

            for (int i = 0; i < testStr.Length - patternLen + 1; i++)
            {
                long expectedHash =
                    Q2HashingWithChain.PolyHash(testStr, i, patternLen, 101, 3);
                Assert.AreEqual(expectedHash, H[i]);
            }
        }
    }
}