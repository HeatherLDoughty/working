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

//You start with a two dimensional grid of cells, where each cell is either alive or dead. 
//In this version of the problem, the grid is finite, and no life can exist off the edges. 

//When calcuating the next generation of the grid, follow these rules:

//   1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
//   2. Any live cell with more than three live neighbours dies, as if by overcrowding.
//   3. Any live cell with two or three live neighbours lives on to the next generation.
//   4. Any dead cell with exactly three live neighbours becomes a live cell.
//You should write a program that can accept an arbitrary grid of cells, 
        ///and will output a similar grid showing the next generation
        ///

    [Test]
        public void Test_GameOfLife()
        {
            bool[] row1 = { false, false, false, false ,false};
            bool[] row2 = { false, true, true, false,false };
            bool[] row3 = { false, true, false, false,false };
            bool[] row4 = { false, true, true,false,false };
            bool[] row5 = { false, false, false, false ,false};
            bool[][] grid = { row1, row2, row3, row4, row5 };

            bool[][] rslt = GameOfLife(grid);

            Assert.AreEqual(4, rslt.Select(x => x.Count(y => y == true)).Sum());
        }


    private bool[][] GameOfLife(bool[][] grid)
    {
        IEnumerable<int> range = Enumerable.Range(0, grid.Count());
        bool[][] rslt = range.Select(x => range.Select(y => false).ToArray()).ToArray();

        
        for (int i = 0; i < grid.Count(); i++)
        {
            bool[] rw = (bool[])grid[i];
            bool[] rwAbove = i - 1 >= 0 ? (bool[]) grid[i-1]: null;
            bool[] rwBelow = i + 1 < grid.Count() ? (bool[])grid[i + 1] : null;
            for (int j = 0; j < rw.Count(); j++){rslt[i][j] = IsAlive(j, rw, rwAbove, rwBelow);}
        }

            return rslt;
    }

    private bool IsAlive(int idx, bool[] rw, bool[] rwAbove, bool[] rwBelow)
    {
        int livingNeighbors = 0;
        bool imAlive = rw[idx];
        
        livingNeighbors += CountRow(rw, idx);
        livingNeighbors += CountRow(rwAbove, idx);
        livingNeighbors += CountRow(rwBelow, idx);

        if (imAlive) livingNeighbors -= 1; //dont count yourself

        if (livingNeighbors == 3) return true;
        if (livingNeighbors < 2 || livingNeighbors > 3) return false;
        return imAlive;
    }


    private int CountRow(bool[] rw, int idx)
    {
        if (rw == null) return 0;

        int? previdx = idx - 1 < 0 ? (int?)null : idx - 1;
        int? nextidx = idx + 1 >= rw.Count() ? (int?)null : idx + 1;
        int livingNeighbors = 0;
        if (rw[idx]) { livingNeighbors += 1; }
        livingNeighbors += CountNeighbor(rw, previdx);
        livingNeighbors += CountNeighbor(rw, nextidx);
        return livingNeighbors;

    }
    private int CountNeighbor(bool[] rw, int? idx)
    {
        if (idx.HasValue && rw[idx.Value]) { return 1; }
        return 0;
    }

    }
}
