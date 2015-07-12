using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MVCStudy_Tests
{
    [TestFixture]
  public  class Tests_noodle
    {

        [Test]
        public void FizzBuzz()
        {
            Enumerable.Range(1, 99).ToList().ForEach(x =>
            {
                if (x % 15 == 0)
                { Console.WriteLine("FizzBuzz"); }
                else if (x % 3 == 0)
                { Console.WriteLine("Fizz"); }
                else if (x % 5 == 0)
                { Console.WriteLine("Buzz"); }
                else { Console.WriteLine(x); }
            });
        }

        [Test]
        public void FizzBuzz2()
        {
            Enumerable.Range(1, 99).Select(x =>
                (x % 15 == 0) ? "FizzBuzz" :
                (x % 3 == 0) ? "Fizz" :
                (x % 5 == 0) ? "Buzz" :
                x.ToString()).ToList().ForEach(s => Console.WriteLine(s));
        }


        [Test]
        public void TeaParty()
        {
            Assert.AreEqual("Mr. x", Greeting(true, false, "x"));
            Assert.AreEqual("Sir x", Greeting(true, true, "x"));
            Assert.AreEqual("Ms. x", Greeting(false, true, "x"));
        }


        public string Greeting(bool pIsMale, bool pIsKnight, string pName)
        {
            return (pIsMale ? pIsKnight ? "Sir" : "Mr." : "Ms.") + " " + pName;
        }

        [Test]
        public void CountDown()
        {
            Assert.AreEqual("10 9 8 7 6 5 4 3 2 1 0", DoCountDown(10));
        }

        public string DoCountDown(int pStart)
        {
            List<int> nums = new List<int>();
            for (int i = pStart; i >= 0; i--)
            {
                nums.Add(i);
            }

            return string.Join(" ", nums);
        }

        [Test]
        public void CsharpLoops()
        {

            List<int> nums = new List<int>();
            for (int i = 10; i >= 0; i--)
            {
                nums.Add(i);
            }

            nums.ForEach(x => Console.Write(x));

            Console.WriteLine();

            nums.Clear();
            for (int i = 0; i < 10; i++)
            {
                nums.Add(i);
            }

            nums.ForEach(x => Console.Write(x));

            Console.WriteLine();

            nums.Clear();
            int y = 0;
            while (y < 10)
            {
                nums.Add(y);
                y++;
            }

            nums.ForEach(x => Console.Write(x));
            Console.WriteLine();

            nums.Clear();
            do
            {
                y--;
                nums.Add(y);
            } while (y > 0);
            nums.ForEach(x => Console.Write(x));
        }

        [Test]
        public void SingleLineFib()
        {
            //From the internet because Idont like my fib solution ...dont understand Aggregate method...
            //this method incorrectly gives 1 for idx 0

            int n = 0;
            int fib = Enumerable.Range(1, n).Skip(2).Aggregate(new KeyValuePair<int, int>(1, 1), 
                                                        (seq, index) => new KeyValuePair<int, int>(seq.Value, seq.Key + seq.Value)).Value;
            Console.WriteLine(fib);
        }

        [Test]
        public void FibKiller()
        {
            //0 1 1 2 3 5 8 13 21
            int startNum = 0;
            int count = 50;
            Enumerable.Range(startNum, count).ToList().ForEach(x => Console.WriteLine(CalculateFib(x)));
        }

        public Int64 CalculateFib(int pIdx)
        {
            /*F 0 = 0
              F 1 = 1
              F n = F n-1 + F n-2 (if n>1)*/
            List<Int64> nums = new List<Int64>();
            for (int i = 0; i <= pIdx; i++)
            {
                if (i == 0 || i == 1) { nums.Add(i); } else { nums.Add(nums[i - 1] + nums[i - 2]); }
            }
            return nums[nums.Count() - 1];
        }
    }
}
