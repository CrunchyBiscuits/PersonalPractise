using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class HardProblems
    {
        // 17.16
        public int Massage(int[] nums)
        {
            if (nums == null || nums.Length < 1)
            {
                return 0;
            }

            int dp0 = 0;
            int dp1 = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int temp0 = Math.Max(dp0, dp1);
                int temp1 = dp0 + nums[i];

                dp0 = temp0;
                dp1 = temp1;
            }

            return Math.Max(dp0, dp1);
        }
    }
}
