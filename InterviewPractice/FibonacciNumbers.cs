using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    /// <summary>
    /// Fibonacci Numbers 0 1 1 2 3 5 8 13 ...
    /// </summary>
    [TestFixture]
    public class FibonacciNumbers
    {
        private int[] tempData = new int[100];

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(13, 7)]
        public void Fibonacci(int expectVal, int index)
        {
            Assert.AreEqual(expectVal, GetFibonacci(index));
        }

        private int GetFibonacci(int index)
        {
            if(index == 0) return 0;

            if(index == 1) return 1;

            if(tempData[index] == 0)
            {
                tempData[index] = GetFibonacci(index - 1) + GetFibonacci(index - 2);
            }

            return tempData[index];
        }
    }
}
