using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANG
{
    [TestFixture]
    public class ContainerWithMostWater
    {
        [Test]
        public void ContainerWithMostWaterTest()
        {
            var res = ContainerWithMostWater1(new int[] { 7, 1, 2, 3, 9 });

            Assert.AreEqual(28, res);

            res = ContainerWithMostWater1(new int[] { });

            Assert.AreEqual(0, res);

            res = ContainerWithMostWater1(new int[] { 7});

            Assert.AreEqual(0, res);

            res = ContainerWithMostWater1(new int[] { 6,9,3,4,5,8});

            Assert.AreEqual(32, res);

            res = ContainerWithMostWater2(new int[] { 7, 1, 2, 3, 9 });

            Assert.AreEqual(28, res);

            res = ContainerWithMostWater2(new int[] { });

            Assert.AreEqual(0, res);

            res = ContainerWithMostWater2(new int[] { 7 });

            Assert.AreEqual(0, res);

            res = ContainerWithMostWater2(new int[] { 6, 9, 3, 4, 5, 8 });

            Assert.AreEqual(32, res);
        }

        /// <summary>
        /// 取得陣列中 2 數值相乘後最大的容器面積
        /// 算式 = 2數最小值 min(a,b) *  2數位置相減的寬 (bi - ai)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        private int ContainerWithMostWater1(int[] heights)
        {
            // 空值或陣列數小於 2 回傳 0
            if (heights == null || heights.Length < 2) return 0;

            int maxArea = 0;
            int height = 0;
            int width = 0;
            for (int i = 0; i < heights.Length; i += 1)
            {
                for(int j = i + 1; j < heights.Length; j += 1)
                {
                    // 取得 2 比較數值較小的
                    height = heights[i];
                    if(height > heights[j])
                    {
                        height = heights[j];
                    }

                    // 判斷最大計算面積
                    // min * (j-i)
                    // 計算結果大於暫存的最大值則替換
                    width = (j - i);
                    if (height * width > maxArea)
                    {
                        maxArea = height * width;
                    }
                }
            }

            return maxArea;
        }

        /// <summary>
        /// 取得陣列中 2 數值相乘後最大的容器面積
        /// 算式 = 2數最小值 min(a,b) *  2數位置相減的寬 (bi - ai)
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        private int ContainerWithMostWater2(int[] heights)
        {
            // 空值或陣列數小於 2 回傳 0
            if (heights == null || heights.Length < 2) return 0;

            // 運用雙指標來減少迴圈
            // 每次移動較小值的指標來做比較(移動較小值，對面積的計算結果影響較大)
            int maxArea = 0;
            int p1 = 0;
            int p2 = heights.Length - 1;
            int height = 0;
            int width = 0;
            while (p1 < p2) 
            {
                // 取得 2 比較數值較小的
                height = heights[p1];
                if (height > heights[p2])
                {
                    height = heights[p2];
                }

                // 判斷最大計算面積
                // min * (p2-p1)
                // 計算結果大於暫存的最大值則替換
                width = (p2 - p1);
                if (height * width > maxArea)
                {
                    maxArea = height * width;
                }

                // 2 數中較小的值移動
                if (heights[p1] > heights[p2])
                {
                    p2 -= 1;
                }
                else
                {
                    p1 += 1;
                }
            }

            return maxArea;
        }
    }
}
