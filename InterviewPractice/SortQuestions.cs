using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    [TestFixture]
    public class SortQuestions
    {
        #region QuickSort

        [Test]
        public void QuickSort() 
        {
            var array = new int[] { 2, 3, 5, 1, 2, 6, 7, 9, 10, 2, 1 };

            var res = QuickSort(array);

            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(10, res[res.Length -1]);
        }

        private int[] QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);

            return array;
        }

        private void QuickSort(int[] array, int left, int right)
        {
            // 1. 如果左邊 index >= 右邊就結束
            if (left >= right) return;

            // 2. 取得中位數值 pivot
            int pivot = array[(left + right) / 2];

            // 3. 進行排序，並取得最終 left index 位置
            var partition = this.Partition(array, left, right, pivot);

            // 4. 分割陣列重複執行排序法
            QuickSort(array, left, partition - 1);
            QuickSort(array, partition, right);
        }

        private int Partition(int[] array, int left, int right, int pivot)
        {
            int temp;
            // 當左邊位置小於等於右邊位置持續執行
            while (left <= right) 
            {
                // 持續移動左邊位置，直到找到 大於 pivot 的位置
                while (array[left] < pivot)
                {
                    left += 1;
                }

                // 持續移動右邊位置，直到找到 小於 pivot 的位置
                while (array[right] > pivot)
                {
                    right -= 1;
                }

                // 找到對應值且位置尚未交叉，交換數值
                if (left <= right)
                {
                    temp = array[right];
                    array[right] = array[left];
                    array[left] = temp;

                    left += 1;
                    right -= 1;
                }
            }

            return left;
        }

        #endregion

        #region MergeSort

        [Test]
        public void MergeSort()
        {
            var array = new int[] { 2, 3, 5, 1, 2, 6, 7, 9, 10, 2, 1 };

            var res = MergeSort(array);

            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(10, res[res.Length - 1]);
        }

        private int[] MergeSort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);

            return array;
        }

        private void MergeSort(int[] array, int left, int right)
        {
            // 指標左大於右時停止分割
            if (left >= right) return;

            // 取得中間 Index
            int m = (left + right) / 2;

            // 持續分割左邊陣列
            MergeSort(array, left, m);

            // 持續分割右邊陣列
            MergeSort(array, m + 1, right);

            MergeSort(array, left, m, right);
        }

        private void MergeSort(int[] array, int left, int m, int right)
        {
            // 0 0 1
            // 取得合併排序用存陣列大小(左跟右)

            // 0-0+1
            int lLength = (m - left) + 1;

            // 1 - 0
            int rLength = right - m;

            // 建立暫存資料陣列
            int[] leftArray = new int[lLength];
            int[] rightArray = new int[rLength];

            // 給暫存陣列設值
            for (int i = 0; i < lLength; i+=1) 
            {
                leftArray[i] = array[left + i];
            }

            for (int i = 0; i < rLength; i+=1)
            {
                rightArray[i] = array[m + 1 + i];
            }

            // 初始化左右暫存陣列起始位置
            int leftIndex = 0;
            int rightIndex = 0;

            // 初始化排序陣列位置為左
            int originIndex = left;
            while (leftIndex < lLength && rightIndex < rLength)
            {
                // 左大於右
                if (leftArray[leftIndex] >= rightArray[rightIndex])
                {
                    array[originIndex] = rightArray[rightIndex];

                    rightIndex += 1;
                }
                else // 左小於右 
                {
                    array[originIndex] = leftArray[leftIndex];

                    leftIndex += 1;
                }

                originIndex += 1;
            }

            // 將未排序值依序補上
            while (leftIndex < lLength)
            {
                array[originIndex] = leftArray[leftIndex];

                leftIndex += 1;
                originIndex += 1;
            }

            while (rightIndex < rLength)
            {
                array[originIndex] = rightArray[rightIndex];

                rightIndex += 1;
                originIndex += 1;
            }
        }

        #endregion

        #region SelectSort

        [Test]
        public void SelectSort()
        {
            var array = new int[] { 2, 3, 5, 1, 2, 6, 7, 9, 10, 2, 1 };

            var res = SelectSort(array);

            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(10, res[res.Length - 1]);
        }

        private int[] SelectSort(int[] array)
        {
            int minIndex;
            int temp;

            for(int i = 0; i < array.Length; i += 1)
            {
                minIndex = i;

                // 不斷更新最小值位置
                for (int j = i + 1; j < array.Length; j += 1)
                {
                    if(array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }

                // 將最小值放置當前次數的最前端
                temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }

            return array;
        }

        #endregion

        #region InsertSort

        [Test]
        public void InsertSort()
        {
            var array = new int[] { 2, 3, 5, 1, 2, 6, 7, 9, 10, 2, 1 };

            var res = InsertSort(array);

            Assert.AreEqual(1, res[0]);
            Assert.AreEqual(10, res[res.Length - 1]);
        }

        private int[] InsertSort(int[] array)
        {
            int temp;
            int currentIndex;
            for(int i = 1; i < array.Length; i += 1)
            {
                // 設定比對範圍
                currentIndex = i;

                // 暫存當前值
                temp = array[i];

                while (currentIndex > 0 && array[currentIndex - 1] > temp) 
                {
                    array[currentIndex] = array[currentIndex - 1];

                    currentIndex -= 1;
                }

                // 比對數值，大的往後放，並找到適當位置放入(比前面大，比後面小)
                array[currentIndex] = temp;
            }

            return array;
        }

        #endregion
    }
}
