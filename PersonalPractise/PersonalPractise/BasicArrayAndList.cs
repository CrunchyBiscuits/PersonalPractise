using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PersonalPractise
{
    class BasicArrayAndList
    {
        // 哈希表
        // 单链表
        class SimpleNode
        {
            SimpleNode next;
            int data;

            SimpleNode(int d)
            {
                this.data = d;
            }

            public void addToTail(int d)
            {
                SimpleNode n = new SimpleNode(d);
                SimpleNode shadowHead = this;
                while (shadowHead.next != null)
                {
                    shadowHead = shadowHead.next;
                }
                shadowHead.next = n;
            }

            public SimpleNode delete(SimpleNode head, int d)
            {
                SimpleNode h = head;

                if (h.data == d)
                {
                    return head.next;
                }

                while (h.next != null)
                {
                    if (h.next.data == d)
                    {
                        h.next = h.next.next;
                        return head;
                    }
                    h = h.next;
                }
                return head;
            }

            public SimpleNode reverseLinkedList(SimpleNode head)
            {
                SimpleNode prev = null;
                SimpleNode curr = head;
                while (curr != null)
                {
                    SimpleNode nextTemp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = nextTemp;
                }
                return prev;
            }
        }

        // 双链表
        class DoubleNode
        {
            DoubleNode pre, next;
            int val;

            DoubleNode()
            {

            }
        }

        // leetcode 209 -- 双指针， 滑动窗口
        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums == null || nums.Length < 1) return 0;

            int start = 0, end = 0;
            int sum = 0;
            int minLen = int.MaxValue;
            while (end < nums.Length)
            {
                sum += nums[end];
                while (sum >= s)
                {
                    minLen = Math.Min(minLen, end - start + 1);
                    sum -= nums[start];
                    start++;
                }
                end++;
            }
            return minLen == int.MaxValue ? 0 : minLen;
        }

        // leetcode 26 -- 双指针, 原地修改，删除重复项
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;
            int j = 0;
            int i = 1;
            while (i < nums.Length)
            {
                if (nums[j] != nums[i])
                {
                    j++;
                    nums[j] = nums[i];
                }
                i++;
            }

            return j + 1;
        }

        // leetcode 560 -- 前缀和求连续区间和
        public int SubarraySum(int[] nums, int k)
        {
            // o(n2)
            //int n = nums.Length;
            //int[] presum = new int[n + 1];
            //presum[0] = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    presum[i + 1] = presum[i] + nums[i];
            //}
            //int ans = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i; j < n; j++)
            //    {
            //        if (presum[j + 1] - presum[i] == k)
            //        {
            //            ans++;
            //        }
            //    }
            //}

            //return ans;

            // O(n)
            int N = nums.Length;
            int presum = 0;
            int ans = 0;
            Dictionary<int, int> presumsTable = new Dictionary<int, int>();
            presumsTable.Add(0, 1);
            for (int i = 0; i < N; i++)
            {
                presum += nums[i];
                if (presumsTable.ContainsKey(presum - k))
                {
                    ans += presumsTable[presum - k];
                }
                if (presumsTable.ContainsKey(presum))
                {
                    presumsTable[presum]++;
                }
                else
                {
                    presumsTable.Add(presum, 1);
                }
            }
            return ans;
        }

        // leetcode 25 -- k个一组反转，带队人
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 1)
            {
                return head;
            }

            ListNode fakeHead = new ListNode(0);
            fakeHead.next = head;
            ListNode prev = fakeHead;

            int count = 0;
            ListNode end = head;
            while (end != null)
            {
                count++;
                if (count % k != 0)
                {
                    end = end.next;
                    continue;
                }
                prev = reverseLinkedList(prev, end.next);
                end = prev.next;
            }


            return fakeHead.next;
        }

        public ListNode reverseLinkedList(ListNode prev, ListNode next)
        {
            ListNode last = prev.next;
            ListNode cur = last.next;

            while (cur != next)
            {
                ListNode temp = cur.next;
                cur.next = prev.next;
                prev.next = cur;
                last.next = temp;
                cur = temp;
            }

            return last;
        }

        // leetcode 328 -- 奇偶链表
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode odd = head;
            ListNode even = head.next;
            ListNode evenHead = even;
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }

        // leetcode 146 -- LRU

        public class LRUCache
        {
            public class Node
            {
                public Node pre;
                public Node next;
                public int val;
                public int key;

                public Node(int key, int d)
                {
                    this.key = key;
                    this.val = d;
                }
            }

            Dictionary<int, Node> cache = new Dictionary<int, Node>();
            int capacity;
            Node head = null;
            Node end = null;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
            }

            public int Get(int key)
            {
                if (cache.ContainsKey(key))
                {
                    Node N = cache[key];
                    remove(N);
                    setHead(N);
                    return N.val;
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (cache.ContainsKey(key))
                {
                    Node N = cache[key];
                    remove(N);
                    setHead(N);
                    N.val = value;
                }
                else
                {
                    Node newNode = new Node(key, value);
                    if (cache.Count >= capacity)
                    {
                        cache.Remove(end.key);
                        remove(end);
                    }
                    setHead(newNode);
                    cache.Add(key, newNode);
                }
            }

            public void remove(Node n)
            {
                if (n.pre == null)
                {
                    head = n.next;
                }
                else
                {
                    n.pre.next = n.next;
                }

                if (n.next == null)
                {
                    end = n.pre;
                }
                else
                {
                    n.next.pre = n.pre;
                }
            }

            public void setHead(Node n)
            {
                n.pre = null;
                n.next = head;

                if (head != null)
                {
                    head.pre = n;
                }

                head = n;

                if (end == null)
                {
                    end = head;
                }
            }
        }

        // leetcode 19 --- 删除倒数第N个节点
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode pre = new ListNode(0);
            pre.next = head;
            ListNode first = pre;
            ListNode second = pre;
            while (n != 0)
            {
                second = second.next;
                n--;
            }

            while (second.next != null)
            {
                first = first.next;
                second = second.next;
            }
            first.next = first.next.next;

            return pre.next;
        }

        // leetcode 80 --- 删除多余重复项2
        public int RemoveDuplicates2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int i = 1;
            int count = 1;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] == nums[j - 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count <= 2)
                {
                    nums[i++] = nums[j];
                }
            }
            return i;
        }

        // leetcode 82 删除链表的重复元素
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode pre = new ListNode(0);
            pre.next = head;
            ListNode help = pre;
            while (help.next != null && help.next.next != null)
            {
                if (help.next.val == help.next.next.val)
                {
                    ListNode temp = help.next;
                    while (temp != null && temp.next != null && temp.val == temp.next.val)
                    {
                        temp = temp.next;
                    }
                    help.next = temp.next;
                }
                else
                {
                    help = help.next;
                }
            }

            return pre.next;
        }

        // leetcode 1171

        // 数组遍历-------------------------------------------------------------------
        // 485 最大连续1的个数
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            // 判断边界情况
            if (nums == null || nums.Length < 1)
            {
                return 0;
            }

            int left = 0;
            int right = 0;
            int ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    right++;
                }
                else
                {
                    ans = Math.Max(ans, right - left); //每次刷新双指针的时候进行比较大小
                    left = right;
                }
            }


            return Math.Max(ans, right - left);
        }

        // 495 提莫攻击
        public int FindPoisonedDuration(int[] timeSeries, int duration)
        {
            if (timeSeries == null || timeSeries.Length < 1 || duration == 0)
            {
                return 0;
            }

            if (timeSeries.Length == 1)
            {
                return duration;
            }

            int ans = 0;
            int pointer = timeSeries[0] + duration;

            for (int i = 1; i < timeSeries.Length; i++)
            {
                if (timeSeries[i] < pointer)
                {
                    int temp = timeSeries[i] - timeSeries[i - 1];
                    ans += temp;
                }
                else
                {
                    ans += duration;
                }
                pointer = timeSeries[i] + duration;

            }

            ans += duration;

            return ans;

        }

        // 414 第三大的数
        public int ThirdMax(int[] nums)
        {

            HashSet<int> temp = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                temp.Add(nums[i]);
            }

            if (temp.Count < 3)
            {
                return nums.Max();
            }

            int max1 = nums.Min();
            int max2 = max1;
            int max3 = max1;

            foreach (int item in temp)
            {
                if (item > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = item;
                }
                else if (item > max2)
                {
                    max3 = max2;
                    max2 = item;
                }
                else if (item > max3)
                {
                    max3 = item;
                }
            }

            return max3;
        }

        // 628 三个数的最大积
        public int MaximumProduct(int[] nums)
        {
            Array.Sort(nums);

            // 没有负数直接最大三个值
            // 有一个负数肯定不考虑，有负数的时候，最小和次小值乘最大值和正常最大值比较
            // 全是负数或者只有一个正数包含在以上两个值的比较之中因此可以不用单独列出来
            return Math.Max(nums[0] * nums[1] * nums[nums.Length - 1], nums[nums.Length - 1] * nums[nums.Length - 2] * nums[nums.Length - 3]);
        }

        // 统计数组中的元素-------------------------------------------------------------
        // 645 错误的集合
        public int[] FindErrorNums(int[] nums)
        {
            int[] ans = new int[nums.Length + 1];
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                ans[nums[i]]++;
            }

            for (int i = 1; i < ans.Length; i++)
            {
                if (ans[i] == 2)
                {
                    res[0] = i;
                }
                else if (ans[i] == 0)
                {
                    res[1] = i;
                }
            }

            return res;
        }

        // 697 数组的度
        public int FindShortestSubArray(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> helper = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                if (helper.ContainsKey(nums[i]))
                {
                    helper[nums[i]]++;
                }
                else
                {
                    helper[nums[i]] = 1;
                }
            }

            int degree = helper.Values.Max();

            List<int> ansCanditate = new List<int>();
            foreach (int key in helper.Keys)
            {
                if (helper[key] == degree)
                {
                    ansCanditate.Add(key);
                }
            }

            int ans = int.MaxValue;

            foreach (int item in ansCanditate)
            {
                ans = Math.Min(ans, FindArray(nums, item));
            }

            return ans;
        }

        public int FindArray(int[] nums, int num)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                while (nums[left] != num)
                {
                    left++;
                }
                while (nums[right] != num)
                {
                    right--;
                }
                break;
            }

            return right - left + 1;
        }

        // 448 找到所有数组中消失的数字 符号标记原地修改
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            // 使用额外空间
            //IList<int> ans = new List<int>();
            //int[] helper = new int[nums.Length+1];

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    helper[nums[i]]++;
            //}

            //for (int i = 1; i < helper.Length; i++)
            //{
            //    if (helper[i]==0)
            //    {
            //        ans.Add(i);
            //    }
            //}

            //return ans;

            // 不适用额外空间 原地修改， 通过符号标记

            IList<int> ans = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int newIndex = Math.Abs(nums[i]) - 1;

                if (nums[newIndex] > 0)
                {
                    nums[newIndex] *= -1;
                }
            }


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    ans.Add(i + 1);
                }
            }

            return ans;
        }

        // 442 数组中重复数据 和448相同，变种
        public IList<int> FindDuplicates(int[] nums)
        {
            IList<int> ans = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int newIndex = Math.Abs(nums[i]) - 1; // 一定要加绝对值

                if (nums[newIndex] < 0)
                {
                    ans.Add(newIndex + 1);
                }
                else
                {
                    nums[newIndex] *= -1;
                }
            }

            return ans;
        }

        // 41 缺失的第一个正数
        public int FirstMissingPositive(int[] nums)
        {
            Array.Sort(nums);

            int ans = 1;
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[i] > 0 && !visited.Contains(nums[i]))
                {
                    if (nums[i] != ans)
                    {
                        return ans;
                    }
                    else
                    {

                        ans++;
                    }
                }
                visited.Add(nums[i]);
            }

            return ans;
        }

        // 274 H指数
        public int HIndex(int[] citations)
        {
            int ans = 0;
            Array.Sort(citations);
            for (int i = 0; i < citations.Length; i++)
            {
                if (citations[i] >= citations.Length - i)
                {
                    return citations.Length - i;
                }
            }

            return ans;
        }

        // 数组的改变、移动--------------------------------------------------------------
        // 453 最小移动次数使数组元素相等
        public int MinMoves(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return 0;
            }
            int minNum = nums.Min();

            long ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ans += nums[i] - minNum;
            }

            return (int)ans;
        }

        // 665 非递减数列 边界值的判断 有的时候其实很憨憨的列出所有判定条件反而很聪明
        public bool CheckPossibility(int[] nums)
        {
            if (nums == null || nums.Length < 1)
            {
                return false;
            }
            int count = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    count++;
                }
                // 注意这里的跨过一个值比较，因为可能存在[3,4,2,3]这样的情况，此时就算更换中间的数也无法成功
                if (i != 0 && i != nums.Length - 2 && nums[i - 1] > nums[i + 1] && nums[i] > nums[i + 2])
                    return false;
            }

            return count <= 1;
        }

        // 283 移动零
        public void MoveZeroes(int[] nums)
        {
            int left = 0;
            int right = 0;

            while (left < nums.Length && right < nums.Length)
            {
                while (left < nums.Length && nums[left] != 0)
                {
                    left++;
                }

                // 一定要注意这里的边界情况有一个right<=left的处理
                while (right < nums.Length && nums[right] == 0 || right <= left)
                {
                    right++;
                }
                if (left < nums.Length && right < nums.Length && nums[left] == 0 && nums[right] != 0)
                {
                    nums[left] = nums[right];
                    nums[right] = 0;
                }
            }
        }


        // 二维数组及滚动数组--------------------------------------------------------
        // 118，119 杨辉三角  动态规划
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            // 特殊情况0
            if (numRows == 0)
            {
                return ans;
            }
            // 第一行始终为1
            ans.Add(new List<int>());
            ans[0].Add(1);

            for (int i = 1; i < numRows; i++)
            {
                // 通过index获取上一行
                IList<int> temp = new List<int>();
                IList<int> prev = ans[i - 1];

                // 第一个始终为1
                temp.Add(1);

                // 从第二个数开始计算新的一行
                for (int j = 1; j < i; j++)
                {
                    temp.Add(prev[j - 1] + prev[j]);
                }

                // 最后一个数也为1
                temp.Add(1);

                ans.Add(temp);
            }

            return ans;
        }


        // 598 范围求和2 脑筋急转弯
        public int MaxCount(int m, int n, int[][] ops)
        {
            foreach (int[] item in ops)
            {
                m = Math.Min(m, item[0]);
                n = Math.Min(n, item[1]);
            }

            return m * n;
        }

        // 419 甲板上的战舰

        // 数组的旋转---------------------------------------------------------------
        // 189 旋转数组 额外数组或多次反转
        public void Rotate(int[] nums, int k)
        {
            // 解法1 额外数组
            int[] a = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                // 用除余会好很多
                a[(i + k) % nums.Length] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = a[i];
            }

            // 解法2 多次反转
            k %= nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }

        public void reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        // 396 旋转函数 旋转权重
        public int MaxRotateFunction(int[] A)
        {
            // 通过对权重的循环改变数组
            int n = A.Length;
            int max = int.MinValue;
            if (n == 0)
            {
                return 0;
            }
            for (int i = 0; i < n; i++)
            {
                int num = i;
                int sum = 0;
                foreach (int item in A)
                {
                    if (num == A.Length)
                    {
                        num = 0;
                    }
                    sum += num * item;
                    num++;
                }
                max = Math.Max(max, sum);
            }

            return max;

        }

        // 特定顺序遍历二维数组
        // 54 螺旋矩阵 边界值的设定
        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length < 1)
            {
                return new List<int>();
            }
            int top = 0, bottom = matrix.Length - 1, left = 0, right = matrix[0].Length - 1;
            IList<int> ans = new List<int>();
            while (true)
            {
                for (int i = left; i <= right; i++)
                {
                    ans.Add(matrix[top][i]);
                }
                if (++top > bottom)
                {
                    break;
                }
                for (int i = top; i <= bottom; i++)
                {
                    ans.Add(matrix[i][right]);
                }
                if (--right < left)
                {
                    break;
                }
                for (int i = right; i >= left; i--)
                {
                    ans.Add(matrix[bottom][i]);
                }
                if (--bottom < top)
                {
                    break;
                }
                for (int i = bottom; i >= top; i--)
                {
                    ans.Add(matrix[i][left]);
                }
                if (++left > right)
                {
                    break;
                }
            }

            return ans;
        }

        // 59 螺旋矩阵2 生成螺旋矩阵
        public int[][] GenerateMatrix(int n)
        {
            int[][] ans = new int[n][];
            for (int i = 0; i < n; i++)
            {
                ans[i] = new int[n];
            }
            int top = 0, bottom = n - 1, left = 0, right = n - 1;
            int num = 1;
            while (true)
            {
                for (int i = left; i <= right; i++)
                {
                    ans[top][i] = num++;
                }
                if (++top > bottom)
                {
                    break;
                }
                for (int i = top; i <= bottom; i++)
                {
                    ans[i][right] = num++;
                }
                if (--right < left)
                {
                    break;
                }
                for (int i = right; i >= left; i--)
                {
                    ans[bottom][i] = num++;
                }
                if (--bottom < top)
                {
                    break;
                }
                for (int i = bottom; i >= top; i--)
                {
                    ans[i][left] = num++;
                }
                if (++left > right)
                {
                    break;
                }
            }

            return ans;
        }

        // 498 对角线遍历
        public int[] FindDiagonalOrder(int[][] matrix)
        {
            // 检查空
            if (matrix == null || matrix.Length == 0)
            {
                return new int[0];
            }


            int N = matrix.Length;
            int M = matrix[0].Length;

            // 创建存储答案的数组，以及每次循环暂存数据的List
            int[] result = new int[N * M];
            int k = 0;
            List<int> intermediate = new List<int>();


            // 从左上角开始，先向右，再向下，碰到偶数位置就取反
            for (int d = 0; d < N + M - 1; d++)
            {
                // 每次开始清空数据结构
                intermediate.Clear();

                // 如果到了右边界限，开始向下
                int r = d < M ? 0 : d - M + 1;
                int c = d < M ? d : M - 1;

                // 通过循环取出对角线数据
                while (r < N && c > -1)
                {
                    intermediate.Add(matrix[r][c]);
                    ++r;
                    --c;
                }

                // 偶数位置取反
                if (d % 2 == 0)
                {
                    intermediate.Reverse();
                }

                for (int i = 0; i < intermediate.Count; i++)
                {
                    result[k++] = intermediate[i];
                }
            }
            return result;
        }


        // 二维数组的变换
        // 566
        // 48
        // 73
        // 289

        // 前缀和数组
        // 303
        // 304
        // 238
    }
}
