using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PersonalPractise
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Daily
    {
        //public static void Main(string[] args)
        //{

        //}

        //NUM392 https://leetcode-cn.com/problems/is-subsequence/
        public bool IsSubsequence(string s, string t)
        {
            var sLength = s.Length;
            if (sLength < 1)
                return true;
            var count = 0;
            char[] sC = s.ToCharArray();
            foreach (char tC in t.ToCharArray())
            {
                if (count == sLength)
                    return true;
                if (tC == sC[count])
                {
                    count++;
                }
            }


            return count == sLength;
        }

        //NUM104 https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            var leftVal = 1 + MaxDepth(root.left);
            var rigthVal = 1 + MaxDepth(root.right);
            return leftVal > rigthVal ? leftVal : rigthVal;
        }

        //NUM343 https://leetcode-cn.com/problems/integer-break/
        public int IntegerBreak(int n)
        {
            int[] allN = new int[n + 1];
            allN[0] = allN[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    allN[i] = Math.Max(allN[i], Math.Max(j * (i - j), j * allN[i - j]));
                }

            }

            return allN[n];
        }

        //NUM557 https://leetcode-cn.com/problems/reverse-words-in-a-string-iii/
        public string ReverseWords(string s)
        {
            string[] strs = s.Split(" ");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] temp = strs[i].ToCharArray();
                Array.Reverse(temp);
                if (i == strs.Length - 1)
                {
                    sb.Append(new string(temp));
                }
                else
                {
                    sb.Append(new string(temp) + " ");
                }
            }
            return sb.ToString();
        }

        //LCP 07
        public int count;
        public int NumWays(int n, int[][] relation, int k)
        {
            Dictionary<int, List<int>> trans = new Dictionary<int, List<int>>();
            for (int i = 0; i < relation.Length; i++)
            {
                int key = relation[i][0];
                int val = relation[i][1];
                if (trans.ContainsKey(key))
                {
                    trans[key].Add(val);
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(val);
                    trans.Add(key, temp);
                }
            }
            count = 0;
            searchWays(n, k, trans, 0, 0);
            return count;

        }

        public void searchWays(int n, int k, Dictionary<int, List<int>> trans, int key, int depth)
        {
            if (depth == k)
            {
                if (key == n - 1)
                {
                    count++;
                }
                return;
            }
            if (!trans.ContainsKey(key))
            {
                return;
            }
            else
            {
                foreach (int item in trans[key])
                {
                    searchWays(n, k, trans, item, depth + 1);
                }
            }
        }

        // 53 最大连续子区间和
        public int MaxSubArray(int[] nums)
        {
            int pre = 0;
            int sum = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                pre = Math.Max(nums[i], pre + nums[i]);
                sum = Math.Max(sum, pre);
            }

            return sum;
        }

        // 70 爬楼梯 + 滚动数组
        public int ClimbStairs(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        // 680 验证回文字符串 2 + 双指针
        public bool ValidPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else
                {
                    bool flagL = true, flagR = true;
                    for (int i = left, j = right - 1; i < j; i++, j--)
                    {
                        if (s[i] != s[j])
                        {
                            flagL = false;
                            break;
                        }
                    }

                    for (int i = left + 1, j = right; i < j; i++, j--)
                    {
                        if (s[i] != s[j])
                        {
                            flagR = false;
                            break;
                        }
                    }

                    return flagL || flagR;
                }
            }
            return true;
        }

        // 605 种花问题 遇到边界值判断可以在两边添加哨兵
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {

            if (flowerbed.Length < 1 || flowerbed == null)
            {
                return false;
            }

            int count = 0;

            int[] newFlowerbed = new int[flowerbed.Length + 2];
            for (int i = 1; i < newFlowerbed.Length - 1; i++)
            {
                newFlowerbed[i] = flowerbed[i - 1];
            }


            for (int i = 1; i < newFlowerbed.Length - 1; i++)
            {
                if (newFlowerbed[i] == 0 && newFlowerbed[i - 1] == 0 && newFlowerbed[i + 1] == 0)
                {
                    newFlowerbed[i] = 1;
                    count++;
                }
            }

            return count >= n;
        }

        // 758 字符串中加粗单词
        public string BoldWords(string[] words, string S)
        {
            bool[] isBold = new bool[S.Length];
            // 设置所有需要加粗的字段
            foreach (string word in words)
            {
                int index = S.IndexOf(word, 0);
                while (index != -1)
                {
                    for (int i = index; i < index + word.Length; i++) // 这里index+word.Length
                    {
                        isBold[i] = true;
                    }
                    index = S.IndexOf(word, index + 1);
                }
            }

            // 根据bold的判断，添加字符串
            // 需要注意边界值的判断
            StringBuilder builder = new StringBuilder();
            if (isBold[0])
            {
                builder.Append("<b>");
            }
            for (int i = 0; i < S.Length; i++)
            {
                builder.Append(S[i]);
                if (i == S.Length - 1)
                {
                    if (isBold[i])
                    {
                        builder.Append("</b>");
                    }
                    break;
                }
                if (!isBold[i] && isBold[i + 1])
                {
                    builder.Append("<b>");
                }
                else if (isBold[i] && !isBold[i + 1])
                {
                    builder.Append("</b>");
                }
            }


            return builder.ToString();
        }


        // 找所有子串
        // S.indexOf的用法


        // 1010 总持续时间可被60整除的歌曲 取模优化方法 一对对数的时候使用
        public int NumPairsDivisibleBy60(int[] time)
        {
            if (time == null || time.Length < 2)
            {
                return 0;
            }

            int res = 0;
            int[] counts = new int[60];
            for (int i = 0; i < time.Length; i++)
            {
                time[i] %= 60;
                if (time[i] != 0)
                {
                    res += counts[60 - time[i]];
                }
                else
                {
                    res += counts[time[i]];
                }
                counts[time[i]]++;
            }
            return res;
        }

        // 1002 查找常用字符
        public IList<string> CommonChars(string[] A)
        {
            if (A == null || A.Length < 1)
            {
                return null;
            }
            int n = A.Length;
            int[] minFrequence = new int[26];
            // 每个位置更新最大值
            for (int i = 0; i < minFrequence.Length; i++)
            {
                minFrequence[i] = int.MaxValue;
            }

            foreach (string word in A)
            {
                int[] freq = new int[26];
                foreach (char ch in word)
                {
                    freq[ch - 'a']++;
                }

                // 这个循环特别重要，因为单单通过字符出现的数量与数组长度比较，会出现一个字符串出现很多同一个字符，而另一个没有的情况
                for (int i = 0; i < 26; i++) 
                {
                    minFrequence[i] = Math.Min(minFrequence[i], freq[i]);
                }
            }

            IList<string> ans = new List<string>();
            for (int i = 0; i < minFrequence.Length; i++)
            {
                int count = minFrequence[i];
                char chr = (char)('a' + i);
                while (count > 0)
                {
                    ans.Add(chr + "");
                    count--;
                }
            }

            return ans;
        }

        // 463 岛屿的周长
        public int IslandPerimeter(int[][] grid)
        {
            int islandsCount = 0;
            int interfaceCount = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        islandsCount++;
                        interfaceCount += CheckHelper(grid, i - 1, j);
                        interfaceCount += CheckHelper(grid, i + 1, j);
                        interfaceCount += CheckHelper(grid, i, j - 1);
                        interfaceCount += CheckHelper(grid, i, j + 1);
                    }
                }
            }

            return islandsCount * 4 - interfaceCount;
        }
        public int CheckHelper(int[][] grid, int i, int j)
        {
            if (i >= 0 && i < grid.Length && j >= 0 && j < grid[0].Length)
            {
                if (grid[i][j] == 1)
                {
                    return 1;
                }
            }
            return 0;
        }

        // 122 买卖股票的最佳时机
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int dp0 = 0, dp1 = -prices[0];
            for (int i = 1; i < n; i++)
            {
                int newDp0 = Math.Max(dp0,dp1 + prices[i]);
                int newDp1 = Math.Max(dp1, dp0 - prices[i]);
                dp0 = newDp0;
                dp1 = newDp1;
            }
            return dp0;
        }
    }
}
