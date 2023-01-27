//using Microsoft.SolverFoundation.Solvers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;

namespace TestCommon
{
    public static class TestTools
    {
        public static readonly char[] IgnoreChars = new char[] { '\n', '\r', ' ' };

        public static readonly char[] NewLineChars = new char[] { '\n', '\r' };


        public static string Process(string inStr, Func<string[], string> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            return solve(lines);
        }

        public static string Process(string inStr, Func<int, int?[,], string> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            int dim = int.Parse(lines[0].Trim());
            var table = lines.Skip(1).Select(l =>
                l.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                 .Select(e => (e == ".") ?
                    null :
                    new int?(int.Parse(e))).ToArray()).ToArray();

            int?[,] table2d = new int?[dim, dim];
            for (int i = 0; i < dim; i++)
                for (int j = 0; j < dim; j++)
                    table2d[i, j] = table[i][j];

            return solve(dim, table2d);
        }
        public static string ProcessQ(string inStr, Func<BigInteger, BigInteger, BigInteger[], string> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var n = BigInteger.Parse(lines[0]);
            var e = BigInteger.Parse(lines[1]);

            /*String[] input = lines[2].Split(',');
            BigInteger[] cipher = new BigInteger[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                cipher[i] = BigInteger.Parse(input[i]);
            }
            return solve(n, e, cipher);*/



            var cipher = lines[2].Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(x => BigInteger.Parse(x)).ToArray();
            return solve(n, e, cipher);

        }

        public static string ProcessQ(string inStr, Func<BigInteger, BigInteger[]> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var n = BigInteger.Parse(lines[0]);
            var result = solve(n);
            //return string.Join(" ", result);
            return string.Join("\n", result);
        }


        public static string ProcessQ(string inStr, Func<BigInteger, BigInteger, BigInteger> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var n = BigInteger.Parse(lines[0]);
            var e = BigInteger.Parse(lines[1]);
            var result = solve(n, e);
            return result.ToString();
        }

        public static string ProcessQ(string inStr, Func<BigInteger, BigInteger, string, BigInteger[]> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var n = BigInteger.Parse(lines[0]);
            var e = BigInteger.Parse(lines[1]);
            var plain = lines[2];
            var result = solve(n, e, plain);
            return string.Join(",", result);
        }

        public static string ProcessQ(string inStr, Func<BigInteger, BigInteger, BigInteger, BigInteger> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var p = BigInteger.Parse(lines[0]);
            var q = BigInteger.Parse(lines[1]);
            var e = BigInteger.Parse(lines[2]);
            var result = solve(p, q, e);
            return result.ToString();
        }

        public static string Process(string inStr, Func<long, char[], long[][], char[]> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long nodeCount, edgeCount;
            ParseTwoNumbers(lines[0], out nodeCount, out edgeCount);
            var colors = lines[1].ToCharArray();
            var graph = ReadTree(lines.Skip(2));
            var result = solve(nodeCount, colors, graph);
            return new string(result);
        }


        public static string Process(string inStr, Func<long, long[][], Tuple<long, long[]>> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long nodeCount, edgeCount;
            ParseTwoNumbers(lines[0], out nodeCount, out edgeCount);
            var graph = ReadTree(lines.Skip(1));
            var result = solve(nodeCount, graph);

            if (result.Item1 == -1)
                return result.Item1.ToString();

            return $"{result.Item1}\n{string.Join(" ", result.Item2)}";
        }

        public static string Process(string inStr, Func<long, long[], long[][], long> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long n = long.Parse(lines[0]);
            var funFactors = lines[1].Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x)).ToArray();
            var hierarchy = ReadTree(lines.Skip(2));
            return solve(n, funFactors, hierarchy).ToString();
        }

        public static string Process(
            string inStr, Func<long, long, long[][],
            Tuple<bool, long[]>> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long c, v;
            ParseTwoNumbers(lines[0], out v, out c);
            var cnf = ReadTree(lines.Skip(1));

            var result = solve(v, c, cnf);

            string output = result.Item1 ?
                $"SATISFIABLE\n{string.Join(" ", result.Item2)}"
                : "UNSATISFIABLE";

            return output;
        }

        public static string Process(string inStr, Func<long, long, long[][], long[], string[]> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long eqCount, varCount;
            ParseTwoNumbers(lines[0], out eqCount, out varCount);
            var A = ReadTree(lines.Skip(1).Take((int)eqCount));
            var b = lines.Last().Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(v => long.Parse(v)).ToArray();

            return string.Join("\n", solve(eqCount, varCount, A, b));
        }

        public static string Process(string inStr, Func<long, double[,], double[]> processor)
        {
            long count;
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(lines.First());
            double[,] data = new double[count, count + 1];
            for (int i = 0; i < count; i++)
            {
                String[] line = lines[i + 1].Split(' ');
                for (int j = 0; j < count + 1; j++)
                {

                    double.TryParse(line[j], out data[i, j]);

                }

            }
            return string.Join(" ", processor(count, data));
        }

        public static string Process(string inStr, Func<int, int, long[,], string[]> processor)
        {
            int N, M;
            var lines = inStr.Split('\n');
            int.TryParse(lines.First().Split(' ')[0], out M);
            int.TryParse(lines.First().Split(' ')[1], out N);
            long[,] data = new long[N, 2];
            for (int i = 0; i < N; i++)
            {

                String[] line = lines[i + 1].Split(' ');
                long.TryParse(line[0], out data[i, 0]);
                long.TryParse(line[1], out data[i, 1]);

            }
            return string.Join("\n", processor(M, N, data));
        }


        public static string Process(string inStr, Func<int, int, double[,], String> processor)
        {
            int N, M;
            var lines = inStr.Split('\n');
            int.TryParse(lines.First().Split(' ')[0], out M);
            int.TryParse(lines.First().Split(' ')[1], out N);
            //Console.WriteLine(M + "-" + N);M=c,N=node
            double[,] data = new double[M + 1, N + 1];
            //Console.WriteLine(lines.Length);
            for (int i = 0; i < M; i++)
            {

                //Console.WriteLine(lines[i + 1]);
                String[] line = lines[i + 1].Split(' ');
                for (int j = 0; j < N; j++)
                {

                    double.TryParse(line[j], out data[i, j]);

                }

            }
            for (int i = 0; i < M; i++)
                double.TryParse(lines[M + 1].Split(' ')[i], out data[i, N]);

            for (int j = 0; j < N; j++)
                double.TryParse(lines[M + 2].Split(' ')[j], out data[M, j]);
            data[M, N] = 0;
            return processor(M, N, data);
        }

        public static string Process(string inStr, Func<long, long, long[][], long[]> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long rowCount, colCount;
            ParseTwoNumbers(lines[0], out rowCount, out colCount);
            long[][] matrix = ReadTree(lines.Skip(1));

            return string.Join(" ", solve(rowCount, colCount, matrix));
        }

        public static string Process(string inStr, Func<long, long, long[][], long> solve)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long nodeCount, edgeCount;
            ParseTwoNumbers(lines[0], out nodeCount, out edgeCount);
            long[][] edges = ReadTree(lines.Skip(1));

            return solve(nodeCount, edgeCount, edges).ToString();
        }

        private const string Space = " ";

        public static string Process(string inStr, Func<string, long[], long[], string[]> solve, string outDelim = Space)
        {
            var toks = inStr.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            var text = toks[0];
            long[] sa = new long[text.Length];
            for (int i = 1; i <= text.Length; i++)
            {
                sa[i - 1] = long.Parse(toks[i]);
            }
            long[] lcp = new long[text.Length - 1];
            for (int i = text.Length + 1; i < toks.Length; i++)
            {
                lcp[i - 1 - text.Length] = long.Parse(toks[i]);
            }
            return string.Join(outDelim, solve(text, sa, lcp));
        }

        public static string Process(string inStr, Func<string, long[]> solve)
        {
            var str = inStr.Trim(IgnoreChars);
            return string.Join(" ", solve(str));
        }

        public static string Process(string inStr, Func<string, string> solve)
        {
            return solve(inStr.Trim(IgnoreChars));
        }

        public static string Process(string inStr, Func<string, string, string> solve)
        {
            var tokens = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var str1 = tokens[0];
            var str2 = tokens[1];
            return solve(str1, str2);
        }

        public static string Process(string inStr, Func<string, string[]> solve)
        {
            return string.Join("\n", solve(inStr.Trim(IgnoreChars)));
        }

        public static string Process(string inStr,
            Func<string, long, string[], long[]> solve,
            string outDelim = Space)
        {
            var toks = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            var str1 = toks[0];
            long cnt = long.Parse(toks[1]);
            var strList = toks.Skip(2).ToArray();

            return string.Join(outDelim, solve(str1, cnt, strList));
        }

        public static void RunLocalTest(
            string AssignmentName,
            Func<string, string> Processor,
            string TestDataName,
            Action<string, string> Verifier,
            bool VerifyResultWithoutOrder = false,
            HashSet<int> excludedTestCases = null) =>
                            RunLocalTest(
                                    AssignmentName,
                                    Processor,
                                    TestDataName,
                                    false,
                                    null,
                                    int.MaxValue,
                                    Verifier ?? (VerifyResultWithoutOrder ?
                                        (Action<string, string>)FileVerifierIgnoreOrder :
                                        (Action<string, string>)FileVerifier),
                                    excludedTestCases);

        public static void RunLocalTest(
            string AssignmentName,
            Func<string, string> Processor,
            string TestDataName = null,
            bool saveMode = false,
            string testDataPathOverride = null,
            int maxTestCases = int.MaxValue,
            Action<string, string> Verifier = null,
            HashSet<int> excludedTestCases = null)
        {
            Verifier = Verifier ?? FileVerifier;
            string testDataPath = $"TestData";
            if (!string.IsNullOrEmpty(TestDataName))
                testDataPath = Path.Combine(testDataPath, $"{AssignmentName}.{TestDataName}");

            if (!string.IsNullOrEmpty(testDataPathOverride))
                testDataPath = testDataPathOverride;

            Assert.IsTrue(Directory.Exists(testDataPath));
            string[] inFiles = Directory.GetFiles(testDataPath, "*In_*.txt");

            Assert.IsTrue(inFiles.Length > 0);

            int testCaseNumber = 0;
            List<string> failedTests = new List<string>();
            TimeSpan totalTime = new TimeSpan(0);
            foreach (var inFile in inFiles.OrderBy(x => FileNumber(x)))
            {
                if (excludedTestCases != null &&
                    excludedTestCases.Contains(FileNumber(inFile)))
                {
                    Console.WriteLine($"Excluding test case: {Path.GetFileName(inFile)}");
                    continue;
                }

                if (++testCaseNumber > maxTestCases)
                    break;

                Stopwatch sw;
                string outFile;
                try
                {
                    var lines = File.ReadAllText(inFile);

                    sw = Stopwatch.StartNew();
                    string result = Processor(lines);
                    sw.Stop();
                    totalTime += sw.Elapsed;

                    result = result.Trim(IgnoreChars);
                    if (saveMode)
                    {
                        outFile = inFile.Replace("In_", "Out_");
                        File.WriteAllText(outFile, result);
                        Console.WriteLine($"{Path.GetFileName(Path.GetDirectoryName(inFile))}: {Path.GetFileName(inFile)}=>{Path.GetFileName(outFile)}");
                        continue;
                    }

                    Verifier(inFile, result);

                    Console.WriteLine($"Test Passed ({sw.Elapsed.ToString()}): {inFile}");
                }
                catch (Exception e)
                {
                    failedTests.Add($"Test failed for input {inFile}: {e.Message}");
                    Console.WriteLine($"Test Failed: {inFile}");
                }
            }

            Assert.IsTrue(failedTests.Count == 0,
                $"{failedTests.Count} out of {inFiles.Length} tests failed: " +
                $"{new string(string.Join("\n", failedTests).Take(1000).ToArray())}");

            Console.WriteLine($"All {inFiles.Length} tests passed: {totalTime.ToString()}.");
        }

        private static void FileVerifier(string inputFileName, string testResult) =>
            FileVerifierSpecifyOrder(inputFileName, testResult, false);

        private static void FileVerifierIgnoreOrder(string inputFileName, string testResult) =>
            FileVerifierSpecifyOrder(inputFileName, testResult, true);

        private static void FileVerifierSpecifyOrder(string inputFileName, string testResult, bool ignoreOrder)
        {
            string outFile = inputFileName.Replace("In_", "Out_");
            Assert.IsTrue(File.Exists(outFile));

            var expectedLines = File.ReadAllLines(outFile)
                .Select(line => line.Trim(IgnoreChars)) // Ignore white spaces 
                .Where(line => !string.IsNullOrWhiteSpace(line)); // Ignore empty lines

            testResult = testResult.Replace("\r\n", "\n");

            if (ignoreOrder)
            {
                expectedLines = expectedLines.OrderBy(x => x);
                testResult = string.Join("\n",
                    testResult.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries)
                              .OrderBy(x => x));
            }
            string expectedResult = string.Join("\n", expectedLines);

            Assert.AreEqual(expectedResult, testResult, $"TestCase:{Path.GetFileName(inputFileName)}");
        }

        public static int FileNumber(string fileName)
        {
            int start = fileName.LastIndexOf('_');
            int end = fileName.LastIndexOf('.');
            string fileNumber = fileName.Substring(start + 1, end - start - 1);
            return int.Parse(fileNumber);
        }

        public static string Process(string inStr, Func<long, long[][], long, long, long> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long count = int.Parse(lines.First());
            long[][] data = ReadTree(lines.Skip(1).Take(lines.Length - 2));
            long[] last = lines.Last().Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(n => long.Parse(n))
                                  .ToArray();

            return string.Join("\n", processor(count, data, last[0], last[1]).ToString());
        }

        public static string Process(string inStr, Func<long, long, long[][], long[][], long, long[][], long[]> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long[] count = lines.First().Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(n => long.Parse(n))
                                        .ToArray();
            long[][] points = ReadTree(lines.Skip(1).Take((int)count[0]));
            long[][] edges = ReadTree(lines.Skip(1 + (int)count[0]).Take((int)count[1]));
            long queryCount = long.Parse(lines.Skip(1 + (int)count[0] + (int)count[1]).Take(1).FirstOrDefault());
            long[][] queries = ReadTree(lines.Skip(2 + (int)count[0] + (int)count[1]));

            return string.Join("\n", processor(count[0], count[1], points, edges, queryCount, queries));
        }

        public static string Process(string inStr, Func<long, long[][], long, double> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long count = int.Parse(lines.First());
            long[][] data = ReadTree(lines.Skip(1).Take(lines.Length - 2));
            long last = int.Parse(lines.Last());

            return string.Join("\n", processor(count, data, last).ToString());
        }

        public static string Process(string inStr, Func<long, long[][], double> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long count = int.Parse(lines.First());
            long[][] data = ReadTree(lines.Skip(1).Take(lines.Length - 1));

            return string.Join("\n", processor(count, data).ToString());
        }

        public static string Process(string inStr, Func<long, long, long[][], long, long[][], long[]> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long[] count = lines.First().Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(n => long.Parse(n))
                                        .ToArray();
            long[][] data = ReadTree(lines.Skip(1).Take((int)count[1]));

            long queryCount = long.Parse(lines.Skip(1 + (int)count[1]).Take(1).FirstOrDefault());
            long[][] queries = ReadTree(lines.Skip(2 + (int)count[1]));

            return string.Join("\n", processor(count[0], count[1], data, queryCount, queries));
        }

        public static string Process(string inStr, Func<long, long[][], long, string[]> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long count = int.Parse(lines.First());
            long[][] data = ReadTree(lines.Skip(1).Take(lines.Length - 2));
            long[] last = lines.Last().Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(n => long.Parse(n))
                                  .ToArray();

            return string.Join("\n", processor(count, data, last[0]));
        }

        public static string Process(string inStr, Func<long, long[][], long> processor)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            long count = int.Parse(lines.First());
            long[][] data = ReadTree(lines.Skip(1));

            return string.Join("\n", processor(count, data).ToString());
        }

        public static string Process(string inStr, Func<long, long[][], long[]> processor)
        {
            long count;
            long[][] data;
            ParseGraph(inStr, out count, out data);

            return string.Join(" ", processor(count, data));
        }

        public static void ParseGraph(string inStr, out long count, out long[][] data)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            count = int.Parse(lines.First());
            data = ReadTree(lines.Skip(1));
        }

        public static string Process(string inStr, Func<long[][], long[][]> processor)
        {
            long[][] data = ReadTree(inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries));

            return string.Join("\n", processor(data)
                .Select(a => string.Join(" ", a)));
        }

        public static string Process(string inStr, Func<string, long[][], string> processor)
        {
            var lines = inStr.Split(NewLineChars,
                StringSplitOptions.RemoveEmptyEntries);
            string text = lines.First();
            long[][] data = ReadTree(lines.Skip(1));

            return processor(text, data);
        }

        public static string Process(string inStr, Func<long[][], bool> processor)
        {
            long[][] data = ReadTree(inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries));

            return processor(data).ToString();
        }

        private static long[][] ReadTree(IEnumerable<string> lines)
        {
            return lines.Select(line => line.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(n => long.Parse(n))
                                     .ToArray()
                 ).ToArray();
        }


        public static string Process(
            string inStr,
            Func<string, string, long[]> processor,
            string outDelim = Space)
        {
            var toks = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(outDelim, processor(toks[0], toks[1]));
        }

        public static string Process(string inStr, Func<long, string[], string[]> processor)
        {
            var toks = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries)
                 .Where(l => !string.IsNullOrWhiteSpace(l));

            long count = long.Parse(toks.First());
            var remainingLines = toks.Skip(1).ToArray();
            return
                string.Join("\n", processor(count, remainingLines));
        }

        public static string Process(string inStr, Func<string[], string[]> processor)
        {
            return
                string.Join("\n",
                processor(inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries)
                 .Where(l => !string.IsNullOrWhiteSpace(l))
                 .ToArray()));
        }

        public static string Process(string inStr, Func<string, string, long> longProcessor)
        {
            var toks = inStr.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            return longProcessor(toks[0], toks[1]).ToString();
        }

        public static string Process(string inStr, Func<string, long> longProcessor)
        {
            return longProcessor(inStr.Trim(IgnoreChars)).ToString();
        }

        public static string Process(string inStr, Func<long[], Tuple<long, long>[]> longProcessor)
        {
            long[] inArray = inStr
                .Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s))
                .ToArray();

            return string.Join("\n", longProcessor(inArray).Select(t => $"{t.Item1} {t.Item2}"));
        }

        public static string Process(string inStr, Func<long, long[], Tuple<long, long>[]> longProcessor)
        {
            var allNumbers = inStr
                .Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => long.Parse(s));

            long firstNumber = allNumbers.First();
            long[] remainingNumbers = allNumbers.Skip(1).ToArray();

            return string.Join("\n", longProcessor(firstNumber, remainingNumbers).Select(t => $"{t.Item1} {t.Item2}"));
        }

        public static string Process(string inStr,
            Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }

        public static string Process(string inStr,
            Func<long, long[]> longProcessor)
        {
            long n = long.Parse(inStr);
            return string.Join("\n", longProcessor(n));
        }

        public static string Process(string inStr,
            Func<long, long[], string> longProcessor)
        {

            var lines = inStr.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            long count = long.Parse(lines.Take(1).First());
            var numbers = lines.Skip(1)
                .Select(n => long.Parse(n))
                .ToArray();

            Assert.AreEqual(count, numbers.Length);

            string result = longProcessor(numbers.Length, numbers);
            Assert.IsTrue(result.All(c => char.IsDigit(c)));
            return result;
        }

        public static string Process(string inStr,
            Func<long, long, long> longProcessor)
        {
            long a, b;
            ParseTwoNumbers(inStr, out a, out b);
            return longProcessor(a, b).ToString();
        }

        public static string Process<_RetType>(
            string inStr,
            Func<long, long[], long[], _RetType> longProcessor)
        {
            List<long> list1 = new List<long>(),
                       list2 = new List<long>();

            long firstLine;

            firstLine = ReadParallelArray(inStr, list1, list2);

            return longProcessor(firstLine,
                list1.ToArray(),
                list2.ToArray()).ToString();
        }

        public static string Process(
            string inStr,
            Func<long, long[], long[], long[]> longProcessor)
        {
            List<long> list1 = new List<long>(),
                       list2 = new List<long>();

            long firstLine;

            firstLine = ReadParallelArray(inStr, list1, list2);

            return string.Join("\n",
                longProcessor(firstLine, list1.ToArray(), list2.ToArray()));
        }

        public static string Process(
            string inStr,
            Func<long[], long[], long[]> longProcessor)
        {
            using (StringReader reader = new StringReader(inStr))
            {
                string[] line = reader.ReadLine().Split(IgnoreChars,
                StringSplitOptions.RemoveEmptyEntries);

                long[] firstLine = new long[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    firstLine[i] = long.Parse(line[i]);
                }

                line = reader.ReadLine().Split(IgnoreChars,
                 StringSplitOptions.RemoveEmptyEntries);

                long[] secondLine = new long[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    secondLine[i] = long.Parse(line[i]);
                }

                return string.Join("\n", longProcessor(firstLine, secondLine));
            }
        }

        public static string Process(
            string inStr,
            Func<long, long[], long> longProcessor)
        {
            var lines = inStr.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            long count = long.Parse(lines.First());
            var numbers = lines.Skip(1)
                .Select(n => long.Parse(n))
                .ToArray();

            string result = longProcessor(count, numbers).ToString();
            Assert.IsTrue(result.All(c => char.IsDigit(c)));
            return result;
        }

        private static IEnumerable<long[]> ParseInputArrays(string inStr)
        {
            var lines = inStr.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
                yield return
                    line.Split().Select(n => long.Parse(n)).ToArray();
        }

        public static string Process(
            string inStr,
            Func<long[], long[], long[], long> longProcessor
            )
        {
            var lists = ParseInputArrays(inStr).ToArray();
            return longProcessor(lists[0], lists[1], lists[2]).ToString();
        }

        public static string Process(
            string inStr,
            Func<long[], long[], long> longProcessor
            )
        {
            var lists = ParseInputArrays(inStr).ToArray();
            return longProcessor(lists[0], lists[1]).ToString();
        }

        public static string Process(
            string inStr,
            Func<long, long[], long[]> longProcessor)
        {
            var lines = inStr.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            long count = long.Parse(lines.Take(1).First());
            var numbers = lines.Skip(1)
                .Select(n => long.Parse(n))
                .ToArray();

            Assert.AreEqual(count, numbers.Length);

            return string.Join("\n",
                longProcessor(numbers.Length, numbers.ToArray()));
        }

        public static string Process(
            string inStr,
            Func<long[], long[], long[], long[]> longProcessor)
        {
            long[] list1;
            List<long> list2 = new List<long>();
            List<long> list3 = new List<long>();
            string firstLine;

            using (StringReader reader = new StringReader(inStr))
            {
                firstLine = reader.ReadLine();
                string[] toks = firstLine.Split(IgnoreChars,
                    StringSplitOptions.RemoveEmptyEntries);

                list1 = toks.Select(long.Parse).ToArray();

                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                    long a, b;
                    ParseTwoNumbers(line, out a, out b);
                    list2.Add(a);
                    list3.Add(b);
                }

            }

            return string.Join("\n",
                longProcessor(list1, list2.ToArray(), list3.ToArray()));
        }

        public static string Process(string inStr, Func<long, long, long[], long[], long> longProcessor)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            ParseTwoNumbers(lines[0], out long d, out long e);
            var list1 = new List<long>();
            var list2 = new List<long>();
            using (StringReader reader = new StringReader(inStr))
            {
                string line = null;
                string firstLine = reader.ReadLine();
                while (null != (line = reader.ReadLine()))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    long a, b;
                    ParseTwoNumbers(line, out a, out b);
                    list1.Add(a);
                    list2.Add(b);
                }

            }

            return longProcessor(d, e, list1.ToArray(), list2.ToArray()).ToString(); ;
        }


        private static long ReadParallelArray(string inStr,
            List<long> list1, List<long> list2)
        {
            long firstLine;
            using (StringReader reader = new StringReader(inStr))
            {
                firstLine = long.Parse(reader.ReadLine());

                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    long a, b;
                    ParseTwoNumbers(line, out a, out b);
                    list1.Add(a);
                    list2.Add(b);
                }

            }

            return firstLine;
        }

        public static void ParseTwoNumbers(string inStr,
            out long a, out long b)
        {
            var toks = inStr.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries);
            a = long.Parse(toks[0]);
            b = long.Parse(toks[1]);
        }
        /* Only used in SatSolver for Algorithm Class
                public static void SatVerifier(
                    string inFileName,
                    string strResult)
                {
                    string outFile = inFileName.Replace("In", "Out");
                    string expected = File.ReadAllText(outFile);

                    Debug.WriteLine($"Solving {Path.GetFileName(outFile)}");

                    var lines = strResult.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);

                    long expCount, varCount;
                    TestTools.ParseTwoNumbers(lines[0], out expCount, out varCount);
                    //Abort after 500ms
                    AbortPolicy abortPolicy = new AbortPolicy(5000);
                    var sat = new SatSolverParams(abortPolicy.TimeOver);
                    List<Literal[]> cnf = lines
                             .Skip(1)
                             .Select(e => e.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => int.Parse(s))
                                           .Where(v => v != 0)
                                           .Select(v => new Literal(Math.Abs(v), v > 0))
                                           .ToArray())
                             .ToList();
                    var result = SatSolver.Solve(sat, (int)varCount + 1, cnf);
                    bool bSat = result.Any();
                    Debug.WriteLine($"Solution found: {bSat}");
                    var bExpectedSat =
                        expected.Trim(TestTools.IgnoreChars) == "SATISFIABLE";

                    Assert.AreEqual(bExpectedSat, bSat);
                }


                public static void SatAssignmentVerifier(
                    string inFileName,
                    string strResult)
                {
                    string outFile = inFileName.Replace("In", "Out");
                    var expectedLines = File.ReadAllLines(outFile);
                    var inCNFLines = File.ReadAllLines(inFileName);
                    var actualLines = strResult.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);

                    Debug.WriteLine($"Solving {Path.GetFileName(outFile)}");

                    bool expectedSat = expectedLines.First().Trim() == "SATISFIABLE";
                    bool actualSat = actualLines.First().Trim() == "SATISFIABLE";

                    Assert.AreEqual(expectedSat, actualSat);

                    // If the asnwer is UNSAT no further checking
                    if (!expectedSat)
                        return;

                    // Parse the provided assignment
                    var assignment = actualLines.Last()
                        .Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                        .Select(l => long.Parse(l))
                        .ToArray();

                    // Map the assignemnt to a 0/1 array 
                    long[] assignmentMap = new long[assignment.Length + 1];
                    foreach (var l in assignment)
                        assignmentMap[Math.Abs(l)] = l < 0 ? 0 : 1;

                    // Parse input to ensure provided assignment satisfies all clauses.
                    bool assignmentSat = inCNFLines.Skip(1)
                        .Select(l => l.Split(IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(t => long.Parse(t)).ToArray())
                        .All(clause => {
                            return clause.Sum(l => 
                            l > 0 ?
                                assignmentMap[Math.Abs(l)]:
                                assignmentMap[Math.Abs(l)] ^ 1
                                ) > 0;
                        });

                    Assert.IsTrue(assignmentSat, $"SAT Claim but UNSAT Assignment.");
                }


                public static void TSPVerifier(string inFileName, string strResult)
                {
                    string outFile = inFileName.Replace("In", "Out");
                    long expectedLength = long.Parse(
                        File.ReadAllLines(outFile).First().Trim(IgnoreChars));

                    var lines = strResult.Split(NewLineChars, StringSplitOptions.RemoveEmptyEntries);
                    long actualLength = long.Parse(lines[0]);

                    Assert.AreEqual(expectedLength, actualLength);

                    if (expectedLength == -1)
                        return; // No need for futher verification

                    long[] actualPath = lines[1].Split(IgnoreChars)
                        .Select(t => long.Parse(t)-1).ToArray();

                    TSPPathVerifier verifier = new TSPPathVerifier(actualPath, actualLength);

                    Process(File.ReadAllText(inFileName),
                        (Func<long, long[][], Tuple<long, long[]>>)verifier.ValidTSPPath);
                }


                public static void GraphColorVerifier(string inFileName, string strResult)
                {
                    string outFile = inFileName.Replace("In", "Out");
                    bool isPossibleExpected = File.ReadAllText(outFile)
                        .Trim(IgnoreChars).ToLower() != "impossible";

                    bool isPossibleActual = strResult.Trim(IgnoreChars).ToLower() != "impossible";

                    if (!isPossibleExpected)
                        Assert.IsFalse(isPossibleActual, "Solution provided but none possible.");
                    else
                    {
                        var colorAssignment = strResult.ToCharArray();
                        ColorAssignmentVerifier verifier = new ColorAssignmentVerifier(colorAssignment);
                        Process(File.ReadAllText(inFileName), verifier.ValidateColorAssignment);
                    }
                }
                */
        public static void ApproximateLongVerifier(string inFileName, string strResult)
        {
            string outFile = inFileName.Replace("In_", "Out_");
            Assert.IsTrue(File.Exists(outFile));

            var expectedLines = File.ReadAllLines(outFile)
                .Select(line => line.Trim(IgnoreChars)) // Ignore white spaces 
                .Where(line => !string.IsNullOrWhiteSpace(line)); // Ignore empty lines

            strResult = strResult.Replace("\r\n", "\n");

            var res = long.Parse(strResult);
            var exp = long.Parse(expectedLines.First());

            Assert.IsTrue(Math.Abs(res - exp) <= 1, $"TestCase:{Path.GetFileName(inFileName)}");
        }
    }

    class TSPPathVerifier
    {
        public TSPPathVerifier(long[] actualPath, long actualPathLength)
        {
            this.ActualPath = actualPath;
            this.ActualPathLength = actualPathLength;
        }

        private long[] ActualPath;
        private long ActualPathLength;

        public Tuple<long, long[]> ValidTSPPath(
            long nodeCount, long[][] edges)
        {
            long sum = 0;
            long?[,] matrix = new long?[nodeCount, nodeCount];

            edges.ToList().ForEach(e =>
            {
                matrix[e[0] - 1, e[1] - 1] = e[2];
                matrix[e[1] - 1, e[0] - 1] = e[2];
            });


            for (int i = 0; i < ActualPath.Length - 1; i++)
            {
                Assert.IsNotNull(matrix[ActualPath[i], ActualPath[i + 1]]);
                sum += matrix[ActualPath[i], ActualPath[i + 1]].Value;
            }
            Assert.IsNotNull(
                matrix[ActualPath[ActualPath.Length - 1],
                        ActualPath[0]]);

            sum += matrix[ActualPath[ActualPath.Length - 1],
                          ActualPath[0]].Value;

            Assert.AreEqual(ActualPathLength, sum);

            return Tuple.Create(0L, new long[] { 0 });
        }
    }

    class ColorAssignmentVerifier
    {
        public readonly char[] Assignment;
        public ColorAssignmentVerifier(char[] assignment)
        {
            this.Assignment = assignment;
        }

        public char[] ValidateColorAssignment(long nodeCount, char[] colors, long[][] edges)
        {
            // First make sure the assignment has only RGB colors.
            Assert.IsTrue(Assignment.Distinct().Count() <= 3);

            // Now make sure for every edge has different colors on each end

            foreach (var e in edges)
                Assert.AreNotEqual(
                    this.Assignment[e[0] - 1],
                    this.Assignment[e[1] - 1]
                    );

            return null;
        }
    }



    class AbortPolicy
    {
        private int msTimeout;
        private Stopwatch sw;
        public AbortPolicy(int msTimeout)
        {
            this.msTimeout = msTimeout;
            sw = Stopwatch.StartNew();
        }

        public bool TimeOver() =>
            sw.ElapsedMilliseconds > msTimeout;
    }


}
