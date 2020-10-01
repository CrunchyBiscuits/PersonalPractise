using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class BasicDoublePointerAndSlideWindow
    {
        // 1004 最大连续1的个数 滑动窗口
        public int LongestOnes(int[] A, int K)
        {
            int ans = 0;

            int start = 0, end;

            for ( end = 0; end < A.Length; end++)
            {
                if (A[end]==0)
                {
                    K--;
                }
                if (K<0)
                {
                    if (A[start]==0)
                    {
                        K++;
                    }
                    start++;
                }
                ans = Math.Max(ans, end - start + 1);
            }

            return ans;
        }

        // 930 和相同的二元子数组
        public int NumSubarraysWithSum(int[] A, int S)
        {
            int preSum = 0;
            int N = A.Length;
            int ans = 0;
            Dictionary<int, int> preSumTable = new Dictionary<int, int>();
            preSumTable.Add(0, 1);
            for (int i = 0; i < N; i++)
            {
                preSum += A[i];
                if (preSumTable.ContainsKey(preSum-S))
                {
                    ans += preSumTable[preSum - S];
                }
                if (preSumTable.ContainsKey(preSum))
                {
                    preSumTable[preSum]++;
                }
                else
                {
                    preSumTable.Add(preSum, 1);
                }
            }

            return ans;
        }

        // 142 环形链表
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            bool hasCycle = false;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (hasCycle)
            {
                slow = head;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
                return fast;
            }
            else
            {
                return null;
            }
        }
    }
}
