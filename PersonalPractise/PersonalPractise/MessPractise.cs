using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalPractise
{
    class MessPractise
    {
        // 1512 https://leetcode-cn.com/problems/number-of-good-pairs/
        public int NumIdenticalPairs(int[] nums)
        {
            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        ans++;
                    }
                }
            }

            return ans;
        }

        // 1431 https://leetcode-cn.com/problems/kids-with-the-greatest-number-of-candies/
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            int large = candies.Max();

            IList<bool> ans = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i]+extraCandies>=large)
                {
                    ans.Add(true);
                }
                else
                {
                    ans.Add(false);
                }
            }

            return ans;
        }

        // 1470 https://leetcode-cn.com/problems/shuffle-the-array/
        public int[] Shuffle(int[] nums, int n)
        {
            int[] ans = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                ans[i * 2] = nums[i];
                ans[i * 2 + 1] = nums[n+i];
            }

            return ans;
        }

        // 1486 https://leetcode-cn.com/problems/xor-operation-in-an-array/
        public int XorOperation(int n, int start)
        {
            int ans = start;
            for (int i = 1; i < n; i++)
            {
                ans ^= (start + 2 * i);
            }

            return ans;
        }

        // LCP06 https://leetcode-cn.com/problems/na-ying-bi/
        public int MinCount(int[] coins)
        {
            int ans = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                int coinNum = coins[i];
                if (coinNum < 3)
                {
                    ans++;
                }
                else
                {
                    int left = coinNum % 2;
                    ans += coinNum / 2 + left;
                }
            }

            return ans;
        }

        // 1389 https://leetcode-cn.com/problems/create-target-array-in-the-given-order/
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] target = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = nums.Length-1; j > index[i]; j--)
                {
                    target[j] = target[j - 1];
                }
                target[index[i]] = nums[i];
            }
            return target;
        }

        // 1365 https://leetcode-cn.com/problems/how-many-numbers-are-smaller-than-the-current-number/
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int[] help = new int[nums.Length];
            Array.Copy(nums, help,nums.Length);
            Array.Sort(help);
            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = Array.IndexOf(help, nums[i]);
            }


            return ans;
        }

    }
}
