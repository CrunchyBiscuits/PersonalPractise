using System;
using System.Collections.Generic;
using System.Text;

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
                while (curr!=null)
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

        // leetcode 25 -- k个一组反转，带队人，头插法
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
                    if (cache.Count>=capacity)
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

                if (head!=null)
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

        // leetcode 
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode first = head;
            ListNode second = head;
            while (n!=0)
            {
                second = second.next;
                n--;
            }

            while (second.next!=null)
            {
                first = first.next;
                second = second.next;
            }
            first.next = first.next.next;

            return head;
        }
    }
}
