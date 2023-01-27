using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10.Tests
{
    [TestClass()]
    public class BloomFilterTests
    {
        [TestMethod()]
        public void BloomFilterTest()
        {
            Assert.Inconclusive();
            //Assert.Inconclusive("Not Implemented");
            // تعداد پسوردها - ثابت. عوض نکنید.
            int pwdCount = 1_000_000;

            // اندازه مناسب را خودتون انتخاب کنید
            int filterSize =(int)(5.6 * pwdCount);

            // تعداد توابع را هم خودتان تنظیم کنید
            int hashFnCount = 4;

            Q4BloomFilter filter = new Q4BloomFilter(filterSize, hashFnCount);
            HashSet<string> passwords = new HashSet<string>();

            foreach(string pwd in RandomStringGenerator(pwdCount, 0))
            {
                // پسورد را به فیلتر اضافه کن
                filter.Add(pwd);

                // پسوردها را در یک دیکشنری هم ذخیره کن که بتوانیم
                // false positive rate
                // را حساب کنیم
                passwords.Add(pwd);
            }

            // تمام پسوردهای اضافه شده باید حتما جواب مثبت بدهند
            foreach (string pwd in passwords)
            {
                Assert.IsTrue(filter.Test(pwd));
            }

            double falsePositive = 0;
            foreach (string pwd in RandomStringGenerator(pwdCount, 1))
            {
                bool filterAnswer = filter.Test(pwd);
                bool trueAnswer = passwords.Contains(pwd);

                // اگر فیلتر بگه توی لیست نیست، ولی واقعا باشه که کلا اشتباه شده
                Assert.IsFalse(!filterAnswer && trueAnswer);

                // اگر فیلتر بگه توی لیست هست ولی واقعا نباشه میشه falsePositive
                if (!trueAnswer && filterAnswer)
                    falsePositive++;
            }

            double falsePositiveRatio = falsePositive / pwdCount;
            double storageRatio = ((double)filterSize) / (passwords.Sum(x => x.Length * 8));
            Console.WriteLine($"False Positive Ratio: {falsePositiveRatio}");
            Console.WriteLine($"Bloom Filter Size =  {filterSize / 8 / 1024}K");
            Console.WriteLine($"Password File Size =  {passwords.Sum(x => x.Length) / 1024}K");
            Console.WriteLine($"Storage Ratio =  {storageRatio}");

            Assert.IsTrue(falsePositiveRatio < 0.1);
            Assert.IsTrue(storageRatio < 0.05);
        }

        protected static readonly char[] Chars = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();

        private IEnumerable<string> RandomStringGenerator(int count=int.MaxValue, int rndSeed = 0)
        {
            Random rnd = new Random(rndSeed);

            for (int i = 0; i < count; i++)
            {
                string pwd = new string(
                    Enumerable.Range(1, rnd.Next(5, 25))
                        .Select(r => Chars[rnd.Next(0, Chars.Length)]).ToArray());

                yield return pwd;
            }
        }
    }
}