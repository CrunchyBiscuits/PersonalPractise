using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PersonalPractise
{
    class TreeAndGraph
    {
        // 面试金典 4.1 https://leetcode-cn.com/problems/route-between-nodes-lcci/
        public bool FindWhetherExistsPath(int n, int[][] graph, int start, int target)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> frontier = new Queue<int>();
            frontier.Enqueue(start);

            Dictionary<int, HashSet<int>> paths = new Dictionary<int, HashSet<int>>();
            foreach (int[] s in graph)
            {
                if (!paths.ContainsKey(s[0]))
                {
                    paths.Add(s[0], new HashSet<int>());
                }
                paths[s[0]].Add(s[1]);
            }


            bool answer = false;
            while (frontier.Count > 0)
            {
                int s = frontier.Dequeue();
                if (visited.Contains(s))
                {
                    continue;
                }
                if (s == target)
                {
                    answer = true;
                    break;
                }
                else
                {
                    visited.Add(s);
                    if (paths.ContainsKey(s))
                    {
                        foreach (int end in paths[s])
                        {
                            frontier.Enqueue(end);
                        }
                    }
                }

            }

            return answer;
        }

        // 面试金典 4.2 https://leetcode-cn.com/problems/minimum-height-tree-lcci/
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return helper(nums, 0, nums.Length - 1);
        }

        TreeNode helper(int[] nums, int start, int end)
        {
            if (start > end) return null;

            int mid = (end - start) / 2 + start;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = helper(nums, start, mid - 1);
            root.right = helper(nums, mid + 1, end);
            return root;
        }

        // 面试金典 4.3 https://leetcode-cn.com/problems/list-of-depth-lcci/
        //public ListNode[] ListOfDepth(TreeNode tree)
        //{

        //}
    }
}
