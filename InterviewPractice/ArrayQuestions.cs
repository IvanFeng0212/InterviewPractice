using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{

    [TestFixture]
    public class ArrayQuestions
    {
        #region CommonElementsInTwoSortedArrays

        /// <summary>
        /// 取得 2 已排序陣列內共同項目
        /// </summary>
        [Test]
        public void CommonElementsInTwoSortedArrays()
        {
            var array1 = new int[] { 1, 3, 4, 5, 7, 8, 9 };
            var array2 = new int[] { 2, 4, 6, 8, 10 };

            var res = GetCommon(array1,array2);

            Assert.AreEqual(2, res.Count);
        }

        /// <summary>
        /// 取得 2 已排序陣列內共同項目
        /// </summary>
        private List<int> GetCommon(int[] arrayA,int[] arrayB)
        {
            int indexA = 0;
            int indexB = 0;

            var res = new List<int>();
            while (indexA < arrayA.Length && indexB < arrayB.Length)
            {
                if(arrayA[indexA] == arrayB[indexB])
                {
                    res.Add(indexA);

                    indexA += 1;
                    indexB += 1;
                }

                if(arrayA[indexA] > arrayB[indexB])
                {
                    indexB += 1;
                }

                if(arrayA[indexA] < arrayB[indexB])
                {
                    indexA += 1;
                }
            }

            return res;
        }

        #endregion

        #region IsOneArrayARotationOfAnother

        /// <summary>
        /// 一個陣列是另一個陣列的旋轉嗎 O(n)
        /// </summary>
        [Test]
        public void IsOneArrayARotationOfAnother()
        {
            var arrayA = new int[] { 1, 2, 3, 4, 5 };
            var arrayB = new int[] { 4, 5, 1, 2, 3 };

            var res = CheckIsRotation(arrayA, arrayB);

            Assert.IsTrue(res);
        }

        /// <summary>
        /// 一個陣列是另一個陣列的旋轉嗎 O(n)
        /// </summary>
        private bool CheckIsRotation(int[] arrayA,int[] arrayB)
        {
            // 2 陣列不同長不為旋轉陣列
            if (arrayA.Length != arrayB.Length) return false;

            // 預設陣列 B 的初始 index = -1，取得陣列 A 第一個值與陣列 B 相同值的位置，若無表示不為旋轉陣列
            int indexB = -1;
            for(int i = 0; i < arrayB.Length; i += 1)
            {
                if(arrayA[0] == arrayB[i])
                {
                    indexB = i;
                }
            }

            if(indexB == -1) return false;

            int j;
            for(int i = 0; i < arrayA.Length; i += 1)
            {
                // 取得陣列 B 對應陣列 A 的 Index 位置
                // A[0] = 1
                // B[4] = 1
                // j = (4 + 0) % 7 = 4
                j = (indexB + i) % arrayA.Length;

                // 若對應值不符表示不為旋轉陣列
                if (arrayA[i] != arrayB[j]) return false;
            }

            return true;
        }

        #endregion

        #region MostFrequentlyOccurringItem

        /// <summary>
        /// 取得 Array 中最常出現項目 O(n)
        /// </summary>
        [Test]
        public void MostFrequentlyOccurringItem()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 2,1,1 };

            var res = GetFrequentlyItem(array);

            Assert.AreEqual(1, res);
        }

        /// <summary>
        /// 取得 Array 中最常出現項目 O(n)
        /// </summary>
        private int GetFrequentlyItem(int[] array)
        {
            // 出現最多次的數字次數
            int maxCount = 0;

            // 當前出現最多次的數字
            int res = -1;

            // 暫存字典存放對應數字(Key)與次數
            Dictionary<int, int> tempDic = new Dictionary<int, int>();

            foreach (int item in array)
            {
                if (!tempDic.ContainsKey(item))
                {
                    tempDic.Add(item, 1);

                    continue;
                }

                tempDic[item] += 1;

                // 若 key 存在次數 +1，並判斷次數是法大於暫存的最大次數，若大於就更新
                if (tempDic[item] > maxCount)
                {
                    maxCount = tempDic[item];
                    res = item;
                }
            }

            return res;
        }

        #endregion
    }
}
