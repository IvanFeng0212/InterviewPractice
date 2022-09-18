using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    [TestFixture]
    public class StringQuestions
    {
        #region FizzBuzz

        [TestCase("Fizz",3)]
        [TestCase("Buzz", 5)]
        [TestCase("FizzBuzz", 15)]
        [TestCase("", 26)]
        public void FizzBuzz(string expectVal,int testVal) 
        {
            Assert.AreEqual(expectVal, RunFizzBuzz(testVal));
        }

        private string RunFizzBuzz(int testVal)
        {
            if (testVal % 3 == 0 && testVal % 5 == 0) return "FizzBuzz";

            if (testVal % 3 == 0) return "Fizz";

            if (testVal % 5 == 0) return "Buzz";

            return string.Empty;
        }

        #endregion

        #region RomanNumbers

        /// <summary>
        /// Ⅰ（1）、Ⅴ（5）、Ⅹ（10）、Ⅼ（50）、Ⅽ（100）、Ⅾ（500）和 Ⅿ（1000）
        /// 右加左減
        /// 在較大的羅馬數字的右邊記上較小的羅馬數字，表示大數字加小數字
        /// 在較大的羅馬數字的左邊記上較小的羅馬數字，表示大數字減小數字
        /// </summary>
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(45, "XLV")]
        [TestCase(99, "XCIX")]
        [TestCase(8, "VIII")]
        public void RomanNumbers(int expectVal, string romanNum) 
        {
            Assert.AreEqual(expectVal, Roman.Parse(romanNum));
        }

        private class Roman
        {
            private static Dictionary<char, int> RomanNumberDic = new Dictionary<char, int>() 
            {
                { 'I',1},
                { 'V',5},
                { 'X',10},
                { 'L',50},
                { 'C',100},
                { 'D',500},
                { 'M',1000}
            };

            public static int Parse(string romanNumbers) 
            {
                var res = 0;

                for(int i = 0;i < romanNumbers.Length; i += 1)
                {
                    // 在較大的羅馬數字的左邊記上較小的羅馬數字，表示大數字減小數字
                    if (i + 1 < romanNumbers.Length && CheckRoman(romanNumbers[i], romanNumbers[i + 1]))
                    {
                        res -= RomanNumberDic[romanNumbers[i]];
                    }
                    else
                    {
                        res += RomanNumberDic[romanNumbers[i]];
                    }
                }

                return res;
            }

            /// <summary>
            /// 判斷當前羅馬數字值是否小於下一位數
            /// </summary>
            private static bool CheckRoman(char current,char next)
            {
                return RomanNumberDic[current] < RomanNumberDic[next];
            }
        }

        #endregion

        #region NonRepeatingCharacter

        /// <summary>
        /// 取得非重複字元 O(n)
        /// </summary>
        [TestCase("a", "abbccddee")]
        [TestCase("", "aabbccddee")]
        public void NonRepeatingCharacter(string expectVal, string testVal)
        {
            Assert.AreEqual(expectVal, GetNonRepeatingCharacter(testVal));
        }

        /// <summary>
        /// 取得非重複字元 O(n)
        /// </summary>
        private string GetNonRepeatingCharacter(string testVal)
        {
            Dictionary<char,int> tempDic = new Dictionary<char, int>();

            for(int i = 0; i < testVal.Length; i += 1)
            {
                if (tempDic.ContainsKey(testVal[i]))
                {
                    tempDic[testVal[i]] += 1;
                }
                else
                {
                    tempDic.Add(testVal[i], 1);
                }
            }

            for (int i = 0; i < testVal.Length; i += 1)
            {
                if (tempDic[testVal[i]] == 1) return testVal[i].ToString();
            }

            return string.Empty;
        }

        #endregion

        #region OneAwayStrings

        /// <summary>
        /// 檢查 2 字串是否差異 1 個字 O(n)
        /// s1 = abcde  = true
        /// s2 = abde = true
        /// 
        /// s1 = a = true
        /// s2 = a = true
        /// 
        /// s1 = abc = false
        /// s2 = cca = false
        /// </summary>
        [TestCase(true, "abcde", "abde")]
        [TestCase(true, "a", "a")]
        [TestCase(false, "abc", "cca")]
        public void OneAwayStrings(bool expectVal, string strA,string strB)
        {
            Assert.AreEqual(expectVal, CheckOneAwayStrings(strA, strB));
        }

        private bool CheckOneAwayStrings(string strA,string strB)
        {
            // 長度差異超過 1 個字
            if (strA.Length - strB.Length > 1 || strB.Length - strA.Length > 1) 
                return false;

            // 字串長度相同
            if(strA.Length == strB.Length)
            {
                return IsOneAwayStringsSameLength(strA, strB);
            }

            // 字串長度不相同
            if (strA.Length > strB.Length)
            {
                return IsOneAwayStringsDiffLength(strA, strB);
            }

            if (strB.Length > strA.Length)
            {
                return IsOneAwayStringsDiffLength(strB, strA);
            }

            return false;
        }

        /// <summary>
        /// 不相同長度處理方法 A > B
        /// </summary>
        private bool IsOneAwayStringsDiffLength(string strA, string strB)
        {
            int indexB = 0;
            int diffCount = 0;

            while(indexB < strB.Length)
            {
                if(strB[indexB] == strA[indexB + diffCount])
                {
                    indexB += 1;
                    continue;
                }

                if (strB[indexB] != strA[indexB + diffCount])
                {
                    diffCount += 1;
                }

                if (diffCount > 1) return false;
            }

            return true;
        }

        /// <summary>
        /// 相同長度處理方法
        /// </summary>
        /// <returns></returns>
        private bool IsOneAwayStringsSameLength(string strA, string strB)
        {
            int diffCount = 0;

            for(int i = 0; i < strA.Length; i += 1)
            {
                if(strA[i] != strB[i])
                {
                    diffCount += 1;
                }

                if (diffCount > 1) return false;
            }

            return true;
        }

        #endregion
    }
}
