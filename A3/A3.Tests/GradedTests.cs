using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace A3.Tests
{
    [TestClass()]
    public class GradedTests
    {
        [TestMethod(), Timeout(400)]
        public void SolveTest_Q1MergeSort()
        {
            RunTest(new Q1MergeSort("TD1"));
        }

        [TestMethod(), Timeout(100)]
        public void SolveTest_Q2Fibonacci()
        {
            RunTest(new Q2FibonacciFast("TD2"));
        }

        [TestMethod(), Timeout(400)]
        public void SolveTest_Q3FibonacciLastDigit()
        {
            RunTest(new Q3FibonacciLastDigit("TD3"));
        }

        [TestMethod(), Timeout(100)]
        public void SolveTest_Q4GCD()
        {
            RunTest(new Q4GCD("TD4"));
        }

        [TestMethod(), Timeout(100)]
        public void SolveTest_Q5LCM()
        {
            RunTest(new Q5LCM("TD5"));
        }

        [TestMethod(), Timeout(100)]
        public void SolveTest_Q6FibonacciMod()
        {
            RunTest(new Q6FibonacciMod("TD6"));
        }

        [TestMethod(), Timeout(100)]
        public void SolveTest_Q7FibonacciSum()
        {
            RunTest(new Q7FibonacciSum("TD7"));
        }

        [TestMethod(), Timeout(100)]
        public void SolveTest_Q8FibonacciPartialSum()
        {
            RunTest(new Q8FibonacciPartialSum("TD8"));
        }

        [TestMethod(), Timeout(200)]
        public void SolveTest_Q9FibonacciSumSquares()
        {
            RunTest(new Q9FibonacciSumSquares("TD9"));
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A3", p.Process, p.TestDataName, p.Verifier,
                VerifyResultWithoutOrder: p.VerifyResultWithoutOrder,
                excludedTestCases: p.ExcludedTestCases);
        }
    }
}