using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{

    public class ListNode
    {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
 }
    class LinkedListQuestions
    {

        public static void Main(string[] args)
        {
            LinkedListQuestions a = new LinkedListQuestions();
            ListNode b = new ListNode(1);
            b.next = new ListNode(1);
            b.next.next = new ListNode(2);


            Console.WriteLine(a.RemoveDuplicateNodes(b).val);
            Console.WriteLine(a.RemoveDuplicateNodes(b).next.val);
        }

        // 面试金典2.1 https://leetcode-cn.com/problems/remove-duplicate-node-lcci/
        public ListNode RemoveDuplicateNodes(ListNode head)
        {
            HashSet<int> int_set = new HashSet<int>();
            if (head == null || head.next == null) return head;
            ListNode shadowHead = head;
            ListNode shadowFollow = head.next;
            int_set.Add(head.val);
            while (shadowFollow!= null)
            {
                if (!int_set.Add(shadowFollow.val))
                {
                    shadowHead.next = shadowFollow.next;
                    shadowFollow = shadowHead.next;
                    continue;
                }
                shadowHead = shadowFollow;
                shadowFollow = shadowFollow.next;
            }


            return head;
        }

        // 面试金典2.2 https://leetcode-cn.com/problems/kth-node-from-end-of-list-lcci/
        public int KthToLast(ListNode head, int k)
        {
            if (head == null || head.next == null) return head.val;
            int ans = 0;
            ListNode first = head;
            ListNode second = head;
            while (k != 0)
            {
                second = second.next;
                k--;
            }

            while (second != null)
            {
                first = first.next;
                second = second.next;
            }


            ans = first.val;
            return ans;
        }

        // 面试金典2.3 https://leetcode-cn.com/problems/delete-middle-node-lcci/
        public void DeleteNode(ListNode node)
        {
            if (node.next != null)
            {
                node.val = node.next.val;
                node.next = node.next.next;
            }
            else
            {
                node = null;
            }
        }

        // 面试金典2.4 https://leetcode-cn.com/problems/partition-list-lcci/
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null) return null;
            ListNode shadow = head;
            while (shadow.next!= null)
            {
                if (shadow.next.val < x)
                {
                    ListNode temp = shadow.next;
                    shadow.next = temp.next;
                    temp.next = head;
                    head = temp;
                }
                else
                {
                    shadow = shadow.next;
                }
            }

            return head;
        }

        // 面试金典2.5 https://leetcode-cn.com/problems/sum-lists-lcci/
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ans = new ListNode(0);
            ListNode shadow = ans;
            var carry = 0;
            while (l1 != null || l2 != null)
            {
                // 计算两数和进位的和
                var n1 = l1 == null ? 0 : l1.val;
                var n2 = l2 == null ? 0 : l2.val;
                var sum = carry + n1 + n2;
                // 计算进位
                carry = sum / 10;
                // 将余数添加
                shadow.next = new ListNode(sum % 10);
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
                shadow = shadow.next;
            }
            // 如果最后产生进位，需要添加
            if (carry != 0)
            {
                shadow.next = new ListNode(carry);
            }

            return ans.next;
        }

        // 面试金典2.6 https://leetcode-cn.com/problems/palindrome-linked-list-lcci/
        public bool IsPalindrome(ListNode head)
        {
            ListNode reversedListNode = ReversedList(head);
            while(reversedListNode!=null && head != null)
            {
                if (reversedListNode.val != head.val)
                {
                    return false;
                }
                reversedListNode = reversedListNode.next;
                head = head.next;
            }
            return true;
        }

        public ListNode ReversedList(ListNode node)
        {
            ListNode tail = null;
            while (node != null)
            {
                ListNode n = new ListNode(node.val);
                n.next = tail;
                tail = n;
                node = node.next;
            }

            return tail;
        }

        // 面试金典2.7 https://leetcode-cn.com/problems/intersection-of-two-linked-lists-lcci/
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode shadow1 = headA;
            ListNode shadow2 = headB;
            while (shadow1 != shadow2)
            {
                shadow1 = shadow1 != null ? shadow1.next : headB;
                shadow2 = shadow2 != null ? shadow2.next : headA;
            }
            return shadow2;
        }

        // 面试金典2.8 https://leetcode-cn.com/problems/linked-list-cycle-lcci/
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)
                {
                    break;
                }
            }

            if (slow != fast) return null;

            fast = head;

            while (slow != fast)
            {
                fast = fast.next;
                slow = slow.next;
            }

            return slow;
        }
    }
}
