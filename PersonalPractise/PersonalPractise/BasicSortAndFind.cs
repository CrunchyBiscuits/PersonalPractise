using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace PersonalPractise
{
    class BasicSortAndFind
    {
        public static void Main()
        {
            int[] array = { 49, 38, 65, 97, 76, 13, 27 };
            BasicSortAndFind bsaf = new BasicSortAndFind();
            bsaf.QuickSort(array, 0, array.Length - 1);
            foreach (int item in array)
            {
                Console.Write("{0}\t", item);
            }
            Console.WriteLine();
            ;
        }

        // 二分查找
        public int binarySearch(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            int low = 0;
            int high = arr.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (arr[mid] < target)
                {
                    low = mid + 1;
                }
                else if (arr[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            // return low;
            return -1;
        }

        public int binarySearchRecursive(int[] arr, int target, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            int mid = (low + high) / 2;
            if (arr[mid] < target)
            {
                return binarySearchRecursive(arr, target, mid + 1, high);
            }
            else if (arr[mid] > target)
            {
                return binarySearchRecursive(arr, target, low, mid - 1);
            }
            else
            {
                return mid;
            }
        }

        // 快速排序
        private void QuickSort(int[] arr, int begin, int end)
        {
            if (begin >= end) return;   //两个指针重合就返回，结束调用
            int pivotIndex = QuickSort_Once(arr, begin, end);  //会得到一个基准值下标

            QuickSort(arr, begin, pivotIndex - 1);  //对基准的左端进行排序  递归
            QuickSort(arr, pivotIndex + 1, end);   //对基准的右端进行排序  递归
        }

        private int QuickSort_Once(int[] arr, int begin, int end)
        {
            int pivot = arr[end];   //将首元素作为基准
            int i = begin;
            int j = end;
            while (i < j)
            {
                while (arr[i] <= pivot && i < j) //从左到右，寻找首个大于基准pivot的元素
                {
                    i++; //指针向后移
                }
                arr[j] = arr[i];  //执行到此,i已指向从左端起首个大于基准pivot的元素，执行替换

                while (arr[j] >= pivot && i < j)  //从右到左，寻找第一个小于基准pivot的元素
                {
                    j--; //指针向前移
                }
                arr[i] = arr[j];  //执行到此，j已指向从右端起第一个小于基准pivot的元素，执行替换

            }

            //退出while循环,执行至此，必定是 i= j的情况（最后两个指针会碰头）
            //i(或j)所指向的既是基准位置，定位该趟的基准并将该基准位置返回
            arr[i] = pivot;
            return i;
        }

        // 插入排序
        // 选择排序
        // 归并排序
        // 递归排序



        // 280 摆动排序 两两交换
        public void WiggleSort(int[] nums)
        {
            if (nums == null || nums.Length < 2)
            {
                return;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if ((i % 2 == 0 && nums[i] > nums[i - 1]) ||
                    (i % 2 != 0 && nums[i] < nums[i - 1]))
                {
                    nums[i - 1] = nums[i - 1] + nums[i];
                    nums[i] = nums[i - 1] - nums[i];
                    nums[i - 1] = nums[i - 1] - nums[i];
                }
            }
        }

        // 324 摆动排序2 因为没有等于，多以碰到连续相等数据，没法像280里的思路进行交换

        // 973 最接近原点的k个点 利用快速排序进行查找

        // 853 车队
        public int CarFleet(int target, int[] position, int[] speed)
        {
            int N = position.Length;
            if (N == 0)
            {
                return 0;
            }
            // 创建车的数据结构，记录每辆车的到达时间和位置
            Car[] cars = new Car[N];
            for (int i = 0; i < N; i++)
            {
                cars[i] = new Car(position[i], (double)(target - position[i]) / speed[i]);
            }

            Array.Sort(cars, (a, b) =>
            {
                return a.position - b.position;
            });

            int ans = 0, t = N;
            // 如果到达时间比前面的车时间长，那么追不上前面的车，就没法组成车队，那么车队++
            while (--t > 0)
            {
                if (cars[t].time < cars[t - 1].time)
                {
                    ans++;
                }
                else
                {
                    cars[t - 1] = cars[t];
                }
            }

            return ans + (t == 0 ? 1 : 0);
        }
        public class Car
        {
            public int position;
            public double time;
            public Car(int p, double t)
            {
                this.position = p;
                this.time = t;
            }
        }

        // 922 按奇偶排序数组2
        public int[] SortArrayByParityII(int[] A)
        {
            int even = 1;
            for (int i = 0; i < A.Length; i+=2)
            {
                if (A[i]%2==1)
                {
                    while (A[even]%2==1)
                    {
                        even += 2;
                    }

                    int temp = A[i];
                    A[i] = A[even];
                    A[even] = temp;
                }
            }

            return A;
        }

        // 1451 重新排列句子中的单词
        public string ArrangeWords(string text)
        {
            string[] words = text.Split(" ");
            Dictionary<int, List<string>> wordsByLen = new Dictionary<int, List<string>>();
            foreach (string word in words)
            {
                int key = word.Length;
                if (wordsByLen.ContainsKey(key))
                {
                    wordsByLen[key].Add(word);
                }
                else
                {
                    List<string> temp = new List<string>();
                    temp.Add(word);
                    wordsByLen.Add(key, temp);
                }
            }

            StringBuilder sb = new StringBuilder();
            int index = 1;
            while (wordsByLen.Count!=0)
            {
                if (wordsByLen.ContainsKey(index))
                {
                    foreach (string item in wordsByLen[index])
                    {
                        sb.Append(item + " ");
                    }
                    wordsByLen.Remove(index);
                }

                index++;
            }

            string ans = sb.ToString().Trim().ToLower();

            return ans.Substring(0, 1).ToUpper() + ans.Substring(1);
        }
    }
}
