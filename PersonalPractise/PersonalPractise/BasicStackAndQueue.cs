using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using Microsoft.VisualBasic.CompilerServices;

namespace PersonalPractise
{
    // 基础栈
    class BasicStack
    {
        public class StackNode<T>
        {
            public T data;
            public StackNode<T> next;

            public StackNode(T data)
            {
                this.data = data;
            }
        }

        private StackNode<int> top;

        public int pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            int val = top.data;
            top = top.next;
            return val;
        }

        public void push(int val)
        {
            StackNode<int> node = new StackNode<int>(val);
            node.next = top;
            top = node;
        }

        public int peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException();
            }
            return top.data;
        }

        public bool isEmpty()
        {
            return top == null;
        }
    }

    // 基础队列
    class BasicQueue
    {
        public class QueueNode<T>
        {
            public T data;
            public QueueNode<T> next;

            public QueueNode(T data)
            {
                this.data = data;
            }
        }

        QueueNode<int> front, rear;

        public int remove()
        {
            if (front == null)
            {
                throw new InvalidOperationException();
            }
            int val = front.data;
            front = front.next;
            if (front == null)
            {
                rear = null;
            }
            return val;
        }

        public void add(int val)
        {
            QueueNode<int> node = new QueueNode<int>(val);
            if (rear != null)
            {
                rear.next = node;
            }
            rear = node;
            if (front == null)
            {
                front = rear;
            }
        }

        public int peek()
        {
            if (front == null)
            {
                throw new InvalidOperationException();
            }
            return front.data;
        }

        public bool isEmpty()
        {
            return front == null;
        }
    }

    // 优先队列/堆实现，插入复杂度logN

    // 双端队列
    class BasicStackAndQueue
    {
        // leetcode 84 -- 单调栈 + 哨兵技巧
        public int LargestRectangleArea(int[] heights)
        {
            // 暴力法
            //int ans = 0;
            //if (heights == null || heights.Length == 0) 
            //{
            //    return 0;
            //}

            //for (int mid = 0; mid < heights.Length; mid++)
            //{
            //    int height = heights[mid];
            //    int left = mid;
            //    int right = mid;
            //    while (left - 1 >= 0 && heights[left - 1] >= height)
            //    {
            //        left--;
            //    }
            //    while (right + 1 < heights.Length && heights[right + 1] >= height)
            //    {
            //        right++;
            //    }

            //    ans = Math.Max(ans,(right - left + 1) * height);
            //}
            //return ans;


            //if (heights == null || heights.Length == 0)
            //{
            //    return 0;
            //}

            //int l = heights.Length;
            //Stack<int> stack = new Stack<int>();
            //int result = 0;
            //for (int i = 0; i <= l; i++)
            //{
            //    int cur = i == l ? -1 : heights[i];
            //    while (stack.Count != 0 && cur <= heights[stack.Peek()])
            //    {
            //        int height = heights[stack.Pop()];
            //        int left = stack.Count == 0 ? 0 : (stack.Peek() + 1);
            //        int right = i - 1;
            //        int area = height * (right - left + 1);
            //        result = Math.Max(result, area);
            //    }
            //    stack.Push(i);
            //}


            //return result;

            // 这里为了代码简便，在柱体数组的头和尾加了两个高度为 0 的柱体。
            int[] tmp = new int[heights.Length + 2];

            Array.Copy(heights, 0, tmp, 1, heights.Length);

            Stack<int> stack = new Stack<int>();
            int area = 0;
            for (int i = 0; i < tmp.Length; i++)
            {
                // 对栈中柱体来说，栈中的下一个柱体就是其「左边第一个小于自身的柱体」；
                // 若当前柱体 i 的高度小于栈顶柱体的高度，说明 i 是栈顶柱体的「右边第一个小于栈顶柱体的柱体」。
                // 因此以栈顶柱体为高的矩形的左右宽度边界就确定了，可以计算面积 ～
                while (stack.Count != 0 && tmp[i] < tmp[stack.Peek()])
                {
                    int h = tmp[stack.Pop()];
                    area = Math.Max(area, (i - stack.Peek() - 1) * h);
                }
                stack.Push(i);
            }

            return area;
        }

        // leetcode 295 -- 中位数， 优先队列/堆的使用
        // 优先队列的使用，详情见java题解
        // 题目描述 https://leetcode-cn.com/problems/find-median-from-data-stream/
        public class MedianFinder
        {
            /** initialize your data structure here. */

            Heap maxHeap = new Heap(10000, true);
            Heap minHeap = new Heap(10000, false);

            public MedianFinder()
            {

            }

            public void AddNum(int num)
            {
                if (maxHeap.heapSize == 0)
                {
                    maxHeap.Push(num);
                    return;
                }

                if (num <= maxHeap.topNum)
                    maxHeap.Push(num);
                else
                    minHeap.Push(num);
                if (maxHeap.heapSize - minHeap.heapSize > 1)
                {
                    int maxTop = maxHeap.Pop();
                    minHeap.Push(maxTop);
                }
                else if (minHeap.heapSize - maxHeap.heapSize > 0)
                {
                    int minTop = minHeap.Pop();
                    maxHeap.Push(minTop);
                }

            }

            public double FindMedian()
            {
                int count = maxHeap.heapSize + minHeap.heapSize;
                if ((count & 1) == 1)//奇数
                    return maxHeap.topNum;
                else
                    return (minHeap.topNum + maxHeap.topNum) / 2.0f;
            }

            class Heap
            {
                int[] nums;
                public int heapSize { get; private set; }
                public int capacity { get; private set; }
                public int topNum => nums[1];
                bool max;

                public Heap(int capacity, bool max)
                {
                    this.capacity = capacity;
                    nums = new int[capacity];
                    this.max = max;
                }

                public int Pop()
                {
                    if (heapSize <= 0)
                        throw new System.Exception("堆为空！");

                    int res = nums[1];
                    int curNum = nums[heapSize--];
                    nums[1] = curNum;
                    int parent = 1, childL = parent * 2, childR;
                    while (childL <= heapSize)
                    {

                        childR = childL + 1;
                        if (max)
                        {
                            int maxChild;
                            if (childR <= heapSize)
                                maxChild = nums[childL] >= nums[childR] ? childL : childR;
                            else
                                maxChild = childL;
                            if (nums[parent] >= nums[maxChild])
                                break;
                            int temp = nums[parent];
                            nums[parent] = nums[maxChild];
                            nums[maxChild] = temp;
                            parent = maxChild;
                        }
                        else
                        {
                            int minChild;
                            if (childR <= heapSize)
                                minChild = nums[childL] <= nums[childR] ? childL : childR;
                            else
                                minChild = childL;
                            if (nums[parent] <= nums[minChild])
                                break;
                            int temp = nums[parent];
                            nums[parent] = nums[minChild];
                            nums[minChild] = temp;
                            parent = minChild;
                        }

                        childL = parent * 2;
                    }
                    return res;
                }

                public void Push(int num)
                {
                    nums[++heapSize] = num;
                    int curChild = heapSize, parent = curChild / 2;
                    while (parent > 0)
                    {
                        if (max)
                        {
                            if (nums[parent] >= nums[curChild])
                                break;
                        }
                        else
                        {
                            if (nums[parent] <= nums[curChild])
                                break;
                        }
                        int temp = nums[parent];
                        nums[parent] = nums[curChild];
                        nums[curChild] = temp;
                        curChild = parent;
                        parent = curChild / 2;
                    }
                }
            }
        }

        // leetcode 1249 删除无效括号 栈的应用
        public string MinRemoveToMakeValid(string s)
        {
            if (s == null || s.Length <= 0)
            {
                return s;
            }

            // check用于标识是否要在答案中删除，true表示要删除
            bool[] check = new bool[s.Length];
            // 栈结构用于括号的匹配，只有匹配到左括号才入栈，匹配到右括号出栈
            Stack<int> index = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                // 如果是左括号入栈，此时先标识要删除，因为可能有“))((”这样的情况
                if (s[i] == '(')
                {
                    index.Push(i);
                    check[i] = true;
                }
                // 右括号，如果栈为0 那么删除，不是就出栈
                if (s[i] == ')' && index.Count != 0)
                {
                    int temp = index.Pop();
                    check[temp] = false;
                }
                else if (s[i] == ')' && index.Count == 0)
                {
                    check[i] = true;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (!check[i])
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }

        // leetcode 42 -- 接雨水
        public int Trap(int[] height)
        {
            if (height == null)
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();
            int answer = 0;
            int index = 0;
            while (index < height.Length)
            {
                // 如果当前的高度比栈顶的元素高，说明可能有积水
                while (stack.Count != 0 && height[index] > height[stack.Peek()])
                {
                    int top = stack.Pop();
                    if (stack.Count == 0)
                    {
                        break;
                    }

                    // 计算宽度，当前的柱子下标减去栈顶的，此时还需要多减1，因为当前柱子自己的高度不算
                    int distance = index - stack.Peek() - 1;

                    // 计算高度，需要找到当前高度和栈顶元素高度中较矮的那个，然后减去之前出栈元素的高度，意思就是抛开之前出栈元素那一层
                    int squareHeight = Math.Min(height[index], height[stack.Peek()]) - height[top];

                    answer += distance * squareHeight;
                }
                stack.Push(index);
                index++;
            }

            return answer;
        }

        // leetcode 85 -- 最大矩形
        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }
            int[] height = new int[matrix[0].Length];//动态规划，确定每一个点的高，然后 逐层实现  柱状图中最大的矩形
            int max = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    height[j] = matrix[i][j] == '1' ? (height[j] + 1) : 0;
                }
                int tempmax = LargestRectangleArea85(height);//构造  柱状图中最大的矩形，逐层实现
                max = Math.Max(max, tempmax);
            }
            return max;
        }

        public int LargestRectangleArea85(int[] heights)
        {
            int[] ta = new int[heights.Length];
            int[] leftbound = new int[heights.Length];
            int[] rightbound = new int[heights.Length];
            int top = -1;
            //单调栈--左
            for (int i = 0; i < heights.Length; i++)
            {
                while (top >= 0 && heights[i] <= heights[ta[top]])
                {
                    ta[top] = 0;
                    top--;
                }
                if (top == -1)
                {
                    leftbound[i] = -1;
                }
                else
                {
                    leftbound[i] = ta[top];
                }
                ta[++top] = i;
            }
            //单调栈--右
            top = -1;
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                while (top >= 0 && heights[i] <= heights[ta[top]])
                {
                    ta[top] = 0;
                    top--;
                }
                if (top == -1)
                {
                    rightbound[i] = heights.Length;
                }
                else
                {
                    rightbound[i] = ta[top];
                }
                ta[++top] = i;
            }
            int max = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                max = Math.Max(max, heights[i] * (rightbound[i] - leftbound[i] - 1));
            }
            return max;
        }

        // leetcode 239 -- 滑动窗口最大值, 双端队列
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return new int[0];
            }

            int[] result = new int[nums.Length - k + 1];
            LinkedList<int> deque = new LinkedList<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // 如果队列不为空，且队列长度已经和k一样了，那么从前端出队。
                if (deque.Count != 0 && deque.First.Value == i - k)
                {
                    deque.RemoveFirst();
                }

                // 如果新入栈元素大于队尾元素，将队尾元素移除，用于保证队首元素始终为滑动窗口最大值
                while (deque.Count != 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                // 在初始情况没达到滑动窗口的值的时候不应该存答案
                if (i + 1 >= k)
                {
                    result[i + 1 - k] = nums[deque.First.Value];
                }
            }


            return result;
        }

        // leetcode 23 -- 合并k个排序链表
        public class ListNodeIndex
        {
            public ListNode Node { get; set; }
            public int Index { get; set; }
            public ListNodeIndex(ListNode node, int index) { Node = node; Index = index; }
        }
        public ListNode MergeKLists(ListNode[] lists)
        {
            // 使用sortedset代替优先队列
            // 如果两个node的值相等，返回index较小的那个
            SortedSet<ListNodeIndex> ss = new SortedSet<ListNodeIndex>(Comparer<ListNodeIndex>.Create((a, b) => a.Node.val == b.Node.val ? a.Index - b.Index : a.Node.val - b.Node.val));
            ListNode head = new ListNode(0), p = head;

            // 首节点入队列
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null) ss.Add(new ListNodeIndex(lists[i], i));
            }


            while (ss.Count != 0)
            {
                // Remove root and add to result set
                ListNodeIndex min = ss.Min;
                ss.Remove(min);
                p.next = min.Node;
                p = p.next;

                // Get a node from 0~k linkedList, add to priority queue. 
                min.Node = min.Node.next;
                if (min.Node != null) ss.Add(min);
            }

            return head.next;
        }

        // leetcode 895 -- 最大频率栈

        public class FreqStack
        {
            // 数对应出现的频率
            Dictionary<int, int> freq;
            // 频率对应一组数
            Dictionary<int, Stack<int>> group;
            // 记录最大频率
            int maxFreq;

            public FreqStack()
            {
                freq = new Dictionary<int, int>();
                group = new Dictionary<int, Stack<int>>();
                maxFreq = 0;
            }

            public void Push(int x)
            {
                if (freq.ContainsKey(x))
                {
                    freq[x] += 1;
                }
                else
                {
                    freq.Add(x, 1);
                }

                int f = freq[x];
                maxFreq = Math.Max(maxFreq, f);

                if (group.ContainsKey(f))
                {
                    group[f].Push(x);
                }
                else
                {
                    Stack<int> stack = new Stack<int>();
                    stack.Push(x);
                    group.Add(f, stack);
                }
            }

            public int Pop()
            {
                int x = group[maxFreq].Pop();
                freq[x] -= 1;
                if (group[maxFreq].Count == 0)
                {
                    maxFreq--;
                }
                return x;
            }
        }

        // leetcode 621 -- 任务调度器
        public int LeastInterval(char[] tasks, int n)
        {
            // 第一步 统计每种任务的数量
            int[] types = new int[26];
            foreach (char item in tasks)
            {
                types[item - 'A'] = types[item - 'A'] + 1;
            }

            // 第二步 对任务数量进行排序
            Array.Sort(types);

            //第三步 根据任务量最多（如A任务）的任务计算时间
            int max = types[25];
            int time = (max - 1) * (n + 1) + 1;  // 最多任务为max，那么间隔有max-1个，间隔时间加上本身任务的运行时间
            int i = 24;

            //第四步 检查是否还有和任务最多数量一样多的任务，统计最后一个A运行完之后是否还有任务，这取决于和A数量一样多的任务
            while (i >= 0 && types[i] == max)
            {
                time++;
                i--;
            }

            return Math.Max(time, tasks.Length);
        }

        // leetcode 622 -- 循环队列
        public class MyCircularQueue
        {
            int queueLength;
            LinkedList<int> queue;
            /** Initialize your data structure here. Set the size of the queue to be k. */
            public MyCircularQueue(int k)
            {
                queueLength = k;
                queue = new LinkedList<int>();
            }

            /** Insert an element into the circular queue. Return true if the operation is successful. */
            public bool EnQueue(int value)
            {
                if (!IsFull())
                {
                    queue.AddLast(value);
                    return true;
                }
                return false;
            }

            /** Delete an element from the circular queue. Return true if the operation is successful. */
            public bool DeQueue()
            {
                if (!IsEmpty())
                {
                    queue.RemoveFirst();
                    return true;
                }
                return false;
            }

            /** Get the front item from the queue. */
            public int Front()
            {
                if (queue.Count==0||queue.First==null)
                {
                    return -1;
                }
                return queue.First.Value;
            }

            /** Get the last item from the queue. */
            public int Rear()
            {
                if (queue.Count == 0 || queue.First == null)
                {
                    return -1;
                }
                return queue.Last.Value;
            }

            /** Checks whether the circular queue is empty or not. */
            public bool IsEmpty()
            {
                return queue.Count == 0;
            }

            /** Checks whether the circular queue is full or not. */
            public bool IsFull()
            {
                return queue.Count == queueLength;
            }
        }
    }
}
