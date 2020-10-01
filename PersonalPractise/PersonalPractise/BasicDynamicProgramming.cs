using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PersonalPractise
{
    class BasicDynamicProgramming
    {
        // 状态变量
        // 递推方程
        // 初始条件

        /*
         序列型
         划分型
         博弈题目
         背包问题
         */

        // 198 打家劫舍 普通序列型
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length < 1)
            {
                return 0;
            }

            int N = nums.Length;

            int[] dp = new int[N + 1];
            dp[0] = 0;
            dp[1] = nums[0];

            for (int i = 2; i <= N; i++)
            {
                dp[i] = Math.Max(dp[i - 2] + nums[i - 1], dp[i - 1]);
            }

            return dp[N];
        }

        // 265 粉刷房子2 序列型 + 二维数组
        public int MinCostII(int[][] costs)
        {
            if (costs == null || costs.Length == 0)
            {
                return 0;
            }

            int n = costs.Length;
            int k = costs[0].Length;
            int ans = int.MaxValue;

            int[,] dp = new int[n + 1, k];

            for (int i = 0; i < k; i++)
            {
                dp[0, i] = 0;
                dp[1, i] = costs[0][i];
            }

            for (int i = 2; i < n + 1; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    int minVal = int.MaxValue;
                    for (int x = 0; x < k; x++)
                    {
                        if (j != x)
                        {
                            minVal = Math.Min(minVal, costs[i - 1][j] + dp[i - 1, x]);
                        }
                    }
                    dp[i, j] = minVal;
                }
            }

            for (int i = 0; i < k; i++)
            {
                ans = Math.Min(dp[n, i], ans);
            }

            return ans;
        }

        // 132 分割回文串2 划分型

        // 486 预测赢家 博弈型/区间型

        // 416 分割等和子集 背包问题
        public bool CanPartition(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return false;
            }

            int sum = nums.Sum() % 2 != 0 ? -1 : nums.Sum() / 2;
            if (sum == -1)
            {
                return false;
            }

            bool[] dp = new bool[sum + 1];

            dp[0] = true;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = sum; j >= nums[i]; j--)
                {
                    if (dp[j-nums[i]])
                    {
                        dp[j] = true;
                    }
                }
            }

            return dp[sum];
        }
    }
}
