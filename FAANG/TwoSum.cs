using NUnit.Framework;
using System.Collections.Generic;

namespace FAANG
{
    [TestFixture]
    public class TwoSum
    {
        [Test]
        public void Test1()
        {
            var nums = new[] { 1, 3, 7, 9, 2 };

            var res = Solution(nums, 11);

            Assert.AreEqual(new[] {3,4}, res);

            res = Solution(nums, 25);

            Assert.AreEqual(null, res);

            res = Solution(new int[] { }, 1);

            Assert.AreEqual(null, res);

            res = Solution(new int[] { 5 }, 5);

            Assert.AreEqual(null, res);

            res = Solution(new int[] { 1,6 }, 7);

            Assert.AreEqual(new[] { 0, 1 }, res);

            res = Solution2(nums, 11);

            Assert.AreEqual(new[] { 3, 4 }, res);

            res = Solution2(nums, 25);

            Assert.AreEqual(null, res);

            res = Solution2(new int[] { }, 1);

            Assert.AreEqual(null, res);

            res = Solution2(new int[] { 5 }, 5);

            Assert.AreEqual(null, res);

            res = Solution2(new int[] { 1, 6 }, 7);

            Assert.AreEqual(new[] { 0, 1 }, res);
        }

        /// <summary>
        /// 解法 1 ，時間複雜度 = O(n次方)，空間複雜度 = O(1)
        /// </summary>
        private int[]? Solution(int[] nums,int target) 
        {
            if(nums == null || nums.Length < 2) return null;

            int searchVal;
            for(int i = 0; i < nums.Length -1; i += 1) 
            {
                // 尋找值 = 目標值 - 當前值
                searchVal = target - nums[i];

                for(int j = i + 1; j < nums.Length; j += 1)
                {
                    if (searchVal == nums[j])
                        return new int[] { i, j };
                }
            }

            return null;
        }

        /// <summary>
        /// 解法 2 ，時間複雜度 = O(n)，空間複雜度 = O(n)
        /// </summary>
        private int[]? Solution2(int[] nums, int target)
        {
            // var nums = new[] { 1, 3, 7, 9, 2 };
            // target = 11

            if (nums == null || nums.Length < 2) return null;

            // 紀錄需要搜尋的值
            Dictionary<int,int> searchDic = new Dictionary<int,int>();

            for (int i = 0; i < nums.Length; i += 1)
            {
                // 若字典包含需要搜尋的值
                if (searchDic.ContainsKey(nums[i]))
                {
                    return new int[] { searchDic[nums[i]], i };
                }
                else
                {
                    // Dic 存存要搜尋的值
                    // 11 - 1 = 10,0
                    // 11 - 3 = 8,1
                    // 11 - 7 = 4,2
                    // 11 - 9 = 2,3
                    // 11 - 2 = 9,4 -- 不會執行
                    searchDic.Add(target - nums[i], i);
                }
            }

            return null;
        }
    }
}