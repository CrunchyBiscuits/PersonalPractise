using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PersonalPractise
{
    class SortAndFind
    {
        // 面试金典 10.01
        public void Merge(int[] A, int m, int[] B, int n)
        {
            int indexA = m - 1;
            int indexB = n - 1;
            int allIndex = m + n - 1;

            while (indexB >= 0 && indexA >= 0)
            {
                if (A[indexA] > B[indexB])
                {
                    A[allIndex] = A[indexA];
                    indexA--;
                }
                else
                {
                    A[allIndex] = B[indexB];
                    indexB--;
                }
                allIndex--;
            }
            while (indexB >= 0)
            {
                A[allIndex] = B[indexB];
                indexB--;
                allIndex--;
            }
        }

        // 面试金典 10.02
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> Dic = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string str = strs[i];
                char[] vals = str.ToCharArray();
                Array.Sort(vals);
                string key = new string(vals);
                if (Dic.ContainsKey(key))
                {
                    Dic[key].Add(str);
                }
                else
                {
                    Dic.Add(key, new List<string>() { str });
                }
            }
            return Dic.Values.ToArray();
        }

        // 面试金典 10.03
        public int Search(int[] arr, int target)
        {
            //int low = 0;
            //int high = arr.Length - 1;
            //int mid;
            //while (low <= high)
            //{
            //    mid = (low + high) / 2;
            //    if (arr[mid] < target)
            //    {
            //        low = mid + 1;
            //    }
            //    else if (arr[mid] > target)
            //    {
            //        high = mid - 1;
            //    }
            //    else
            //    {
            //        return mid;
            //    }
            //}
            //return -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        // 面试金典 10.09
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int row = 0;
            int col = matrix[0].Length - 1;
            while (row < matrix.Length && col>=0)
            {
                if (matrix[row][col] == target)
                {
                    return true;
                }
                else if (matrix[row][col] > target)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }

        // 面试金典 10.10
        public class StreamRank
        {
            private IList<int> store;
            private Dictionary<int, int> rank;
            public StreamRank()
            {
                store = new List<int>();
                rank = new Dictionary<int, int>();
            }

            public void Track(int x)
            {
                store.Add(x);
                if (!rank.ContainsKey(x))
                {
                    rank.Add(x, 1);
                }
                rank[x] = GetRankOfNumber(x);
            }

            public int GetRankOfNumber(int x)
            {
                int ans = 0;
                for (int i = 0; i < store.Count; i++)
                {
                    if (store[i] <= x)
                    {
                        ans++;
                    }
                }
                return ans;
            }
        }

        // 面试金典 10.11
        public void WiggleSort(int[] nums)
        {
            if (nums.Length<=1)
            {
                return;
            }
            for (int i = 1; i < nums.Length; i++)
            {
                if (i%2==0 && nums[i]<nums[i-1])
                {
                    int temp = nums[i];
                    nums[i] = nums[i - 1];
                    nums[i - 1] = temp;
                }
                else if (i%2!=0 && nums[i]>nums[i-1])
                {
                    int temp = nums[i];
                    nums[i] = nums[i - 1];
                    nums[i - 1] = temp;
                }
            }
        }
    }

}
